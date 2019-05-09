using CaseTracker.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CaseTracker.Models
{
    public class Message
    {
        public Message()
        {
            db = new ApplicationDbContext();
        }

        public ApplicationDbContext db;

        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Display(Name = "Message")]
        public string MessageBody { get; set; }
    }
}