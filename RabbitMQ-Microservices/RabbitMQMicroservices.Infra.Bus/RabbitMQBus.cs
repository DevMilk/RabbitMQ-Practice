using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQMicroservices.Domain.Core.Bus;
using RabbitMQMicroservices.Domain.Core.Commands;
using RabbitMQMicroservices.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        private readonly IMediator _mediator;
        //stores (eventName) and list of (Event) types
        private readonly Dictionary<string,List<Type>> _handlers;
        //stores list of all (EventHandler) types
        private readonly List<Type> _eventTypes;

        public RabbitMQBus(IMediator mediator)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
        }
        

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
        public void Publish<T>(T @event) where T : Event
        {
            var eventName = @event.GetType().Name;

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(eventName, false, false, false, null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event));

            channel.BasicPublish("", eventName, null, body);

        }
        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventName = typeof(T).Name;
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<Type>());
            }

            if(_handlers[eventName].Any(s => s.GetType() == handlerType))
            {
                throw new ArgumentException($@"Handler Type {handlerType.Name} already is registered for '{eventName}'"
                    , nameof(handlerType));
            }

            _handlers[eventName].Add(handlerType);

            StartBasicConsume<T>();
        }


        private void StartBasicConsume<T>() where T : Event
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };
            var eventName = typeof(T).Name;

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);

            //When consumer receives message, ConsumerReceived Function will invoke
            consumer.Received += ConsumerReceived;

            channel.BasicConsume(eventName, true, consumer);

        }
        private async Task ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            } 
            catch (Exception ex)
            {

            }
        }
        private async Task ProcessEvent(string eventName, string message)
        {
            //Get EventHandler types by eventName
            if (_handlers.TryGetValue(eventName,out var subscriptions))
            {
                foreach(var subscription in subscriptions)
                {
                    //create instance with type of event handler type (a.k.a subscription)
                    var handler = Activator.CreateInstance(subscription);
                    if (handler == null) continue;

                    //get parameters for handler
                    var eventType = _eventTypes.SingleOrDefault(t => t.Name.Equals(eventName));
                    var @event = JsonConvert.DeserializeObject(message, eventType);

                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                    //invoke Handle function of concreteType with @event parameters
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                }
            }
        }
    }
}
