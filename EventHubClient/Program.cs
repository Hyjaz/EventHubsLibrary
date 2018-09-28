using System;
using System.Collections.Generic;
using System.IO;
using Autofac;
using Autofac.Core;
using EventHubsTest;
using EventHubsTest.Configuration;
using EventHubsTest.Messages;
using EventHubsTest.Serializer;
using EventHubsTest.Wrappers;
using Newtonsoft.Json;

namespace EventHubClient
{
    class Program
    {
        private static ConfigurationModel s_configurationModel;
        private static IEventHubsParameters s_eventHubsParameters;
        static void Main(string[] args)
        {
            s_configurationModel =
                JsonConvert.DeserializeObject<ConfigurationModel>(File.ReadAllText(@".\\appsettings.json"));
            s_eventHubsParameters = new EventHubsParameters(s_configurationModel.ConnectionString, s_configurationModel.EntityPath);

            var container = RegisterDependencies(new ContainerBuilder());
            using (var scope = container.BeginLifetimeScope())
            {
                var cloudEventHubClient = scope.Resolve<ICloudEventHubClient>();
                cloudEventHubClient.SendMessage(GenerateMessageList()).ConfigureAwait(false).GetAwaiter().GetResult();
            }
        }

        public static IContainer RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterInstance(s_eventHubsParameters);

            builder.RegisterType<PayloadSerializer>().As<IPayloadSerializer>();
            builder.RegisterType<CloudEventHubClient>().As<ICloudEventHubClient>();
            return builder.Build();
        }
        private static IList<IMessage> GenerateMessageList()
        {
            var message = new Message()
            {
                Body = "body",
                FirstName = "firstName",
                LastName = "lastName"
            };
            return new List<IMessage>()
            {
                message,
                message,
                message
            };

        }
    }
}
