
using Microservices.Domain.Models.Ticket;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Microservices.Data.Context
{
    public class ProducerContext : IProducerContext
    {
        private readonly string ticketCollection = "Tickets";
        public ProducerContext(IConfiguration config)
        {
            try
            {
                var client = new MongoClient(config.GetConnectionString("ProducerContext"));
                Db = client.GetDatabase(client.Settings.Credential.Source);
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possivel se conectar ao MongoDB", ex);
            }
        }
        public IMongoDatabase Db { get; private set; }

        public IMongoCollection<TicketModel> Tickets => Db.GetCollection<TicketModel>(ticketCollection);

        public string GetClientString() => Db.Client.ToString();
    }
}
