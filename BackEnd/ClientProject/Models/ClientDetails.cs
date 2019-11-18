using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClientProject.Models
{
    public class ClientDetails
    {
        [Key]
        public int id { get; set; }
        
        public int clientId { get; set; }

        public string clientAddress { get; set; }

        public Client client { get; set; }
    }
}