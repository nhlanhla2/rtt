using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rtt_api.Enums;

namespace rtt_api.Dto.Client
{
    public class AddressDto
    {
        public AddressType Type { get; set; }
        public string Street { get; set; } = string.Empty;
        public string Suburb { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int? ClientId { get; set; } 
    
    }
}