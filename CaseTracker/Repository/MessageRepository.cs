using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseTracker.Models;
using Newtonsoft.Json;


namespace CaseTracker.Repository
{
    public class MessageRepository
    {
        ApplicationDbContext db;

        public MessageRepository()
        {
            db = new ApplicationDbContext();
        }

        public int AddMessage(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();

            return message.Id;
        }

        public int AddMessage(string userID, string Message)
        {
            Message message = new Message()
            {
                UserId = userID,
                MessageBody = Message
            };

            db.Messages.Add(message);
            db.SaveChanges();

            return message.Id;
        }

        public ICollection<Message> MessageList()
        {
            var MessageL = db.Messages.ToList();
            return MessageL;
        }

        public IQueryable<Message> getMessage(int id)
        {
            var Message = db.Messages.Where(a => a.Id == id);
            return Message;
        }

    }
}