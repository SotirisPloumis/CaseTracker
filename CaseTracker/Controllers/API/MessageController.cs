using CaseTracker.Models;
using CaseTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;




namespace CaseTracker.Controllers.API
{
    public class MessageController : ApiController
    {
        //private ApplicationDbContext db;
        MessageRepository MessageRepository;

        public MessageController()
        {
            MessageRepository = new MessageRepository();
           // db.Configuration.ProxyCreationEnabled = false;
        }

        public ICollection<Message> messages = new List<Message>();
        public class SmallMessage
        {
            public string body { get; set; }
        }

        // GET: api/Message
        public List<SmallMessage> Get()
        {
            messages = MessageRepository.MessageList();
            List<SmallMessage> toSend = new List<SmallMessage>();
            foreach(var m in messages)
            {
                toSend.Add(new SmallMessage { body = m.MessageBody });
            }
            return toSend;
        }

        // GET: api/Message/5
        public IQueryable<Message> Get(int id)
        {
            return MessageRepository.getMessage(id);
        }

        // POST: api/Message
        public IHttpActionResult Post([FromBody]Message m)
        {
            m.UserId = "260d8616-e3ff-4dfc-89cd-06e3c5a56bbc";

            int id = MessageRepository.AddMessage(m);

            return Ok(id);
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}
