using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rtt_api.Enums;
using rtt_api.Models;

namespace rtt_api.Dto.Address
{
    public class AddressRequestDto
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