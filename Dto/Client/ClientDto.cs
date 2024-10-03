using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rtt_api.Dto.Address;

namespace rtt_api.Dto.Client
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Cell { get; set; } = string.Empty;
        public List<AddressRequestDto> Addresses { get; set; } = new List<AddressRequestDto>(); 
        public DateTime createdOn { get; set; } = DateTime.Now;
    }
}