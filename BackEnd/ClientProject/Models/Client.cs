using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientProject.Models
{
    public class Client
    {
        [Key]
        public int clientId { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string DOB { get; set; }

        public ICollection<ClientDetails> clientDetails { get; set; }
    }
}