using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rtt_api.Dto.Address;
using rtt_api.Dto.Client;
using rtt_api.Models;

namespace rtt_api.Mappers
{
    public static class ClientMappers
    {
        public static ClientDto ToClientDto(this Client clientModel) {

            return new ClientDto {

                Id = clientModel.Id,
                Name = clientModel.Name,
                Surname = clientModel.Surname,
                Cell = clientModel.Cell,
                createdOn = clientModel.createdOn,

                Addresses = clientModel.Addresses.Select(a => new AddressRequestDto
                {
                    Type = a.Type,    
                    Street = a.Street,  
                    City = a.City,
                    Suburb = a.Suburb,
                    Province = a.Province,
                    PostalCode = a.PostalCode,
                    Country = a.Country,
                    ClientId = a.ClientId
                }).ToList()
            };
        }

        public static ClientExportDto ToClientExportDto(this Client clientModel) {

            return new ClientExportDto {
                Id = clientModel.Id,
                Name = clientModel.Name,
                Surname = clientModel.Surname,
                createdOn = clientModel.createdOn,
                Addresses = clientModel.Addresses.Select(a => new AddressDto
                {
                    Type = a.Type,
                    Street = a.Street,  
                    City = a.City,
                    Suburb = a.Suburb,
                    Province = a.Province,
                    PostalCode = a.PostalCode,
                    Country = a.Country,
                    ClientId = a.ClientId
                }).ToList()
            };
        }

        public static Client ToClientFromCreateDTO(this CreateClientRequestDto clientDto) {

            return new Client{
                Name = clientDto.Name,
                Surname = clientDto.Surname,
                Cell = clientDto.Cell,
                createdOn = clientDto.createdOn,
                Addresses = clientDto.Addresses?.Select(a => new Address
                {
                    Type = a.Type,
                    Street = a.Street,
                    City = a.City,
                    Suburb = a.Suburb,
                    Province = a.Province,
                    PostalCode = a.PostalCode,
                    Country = a.Country
                }).ToList() ?? new List<Address>()

            };
        }
    }
}