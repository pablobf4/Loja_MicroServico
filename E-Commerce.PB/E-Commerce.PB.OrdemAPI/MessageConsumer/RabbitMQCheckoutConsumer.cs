
using E_Commerce.PB.OrdemAPI.Messages;
using E_Commerce.PB.OrdemAPI.Model;
using E_Commerce.PB.OrdemAPI.Modell;
using E_Commerce.PB.OrdemAPI.RabbitMQSender;
using E_Commerce.PB.OrdemAPI.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;


namespace E_Commerce.PB.OrdemAPI.MessageConsumer
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly OrdemRepository _repository;
        private IConnection _connection;
        private IModel _channel;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public RabbitMQCheckoutConsumer(OrdemRepository repository,
            IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _repository = repository;
            _rabbitMQMessageSender = rabbitMQMessageSender;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);  
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                CheckoutHeaderVO vo = JsonSerializer.Deserialize<CheckoutHeaderVO>(content);
                ProcessOrder(vo).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessOrder(CheckoutHeaderVO vo)
        {
            OrdemCabecalho order = new()
            {
                UserId = vo.UserId,
                PrimeiroNome = vo.PrimeiroNome,
                Sobrenome = vo.Sobrenome,
                DetalhesPedido = new List<OrdemDetalhe>(),
                NumeroCartao = vo.NumeroCarrinho,
                CupomCodigo = vo.CuponCode,
                CVV = vo.CVV,
                ValorDesconto = vo.ValorDesconto,
                Email = vo.Email,
                MesAnoExpiracao = vo.ExpiracaoMesAno,
                HoraPedido = DateTime.Now,
                ValorCompra = vo.ValorCompra,
                StatusPagamento = false,
                Telefone = vo.Telefone,
                //DateTime = vo.DateTime
            };

            foreach (var details in vo.CarrinhoDetalhe)
            {
                OrdemDetalhe detail = new()
                {
                    IdProduto = details.Produto.Id,
                    NomeProduto = details.Produto.Nome,
                    Preco = details.Produto.Preco
                };
                order.TotalItensCarrinho += details.Contar;
                order.DetalhesPedido.Add(detail);
            }

            await _repository.AddOrder(order);

            PagamentoVO payment = new()
            {
                Name = order.PrimeiroNome + " " + order.Sobrenome,
                CardNumber = order.NumeroCartao,
                CVV = order.CVV,
                ExpiryMonthYear = order.MesAnoExpiracao,
                OrderId = order.Id,
                PurchaseAmount = order.ValorCompra,
                Email = order.Email
            };
            try
            {
                _rabbitMQMessageSender.SendMessage(payment, "orderpaymentprocessqueue");
            }
            catch (Exception)
            {
                //Log
                throw;
            }
        }
    }
}
