using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rtt_api.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Cell { get; set; } = string.Empty;

        public List<Address> Addresses { get; set; } = []; 

        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}