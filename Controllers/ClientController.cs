using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rtt_api.Data;
using rtt_api.Dto.Client;
using rtt_api.Mappers;
using rtt_api.Models;

namespace rtt_api.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDBContext _dBContext;
        public ClientController(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult getAllClients() {

            var clients = _dBContext.Client.ToList().Select(c => c.ToClientDto());
 
            return Ok(clients);
        }


        [HttpGet("export")]
        public IActionResult getAllClientsForExport() {

            var clients = _dBContext.Client.ToList().Select(c => c.ToClientExportDto());

            var csvContent = string.Join(Environment.NewLine, clients.Select(c => 
                $"{c.Id},{c.Name},{c.Surname},{string.Join(" | ", c.Addresses.Select(a => $"{a.Type}:{a.Street} {a.Suburb}, {a.City}, {a.Province}, {a.PostalCode}, {a.Country}"))}"
            ));

            var bytes = System.Text.Encoding.UTF8.GetBytes(csvContent);

            var dateString = DateTime.Now.ToString("yyyyMMdd"); 
            var fileName = $"rtt_client_export_{dateString}.txt";

            var result = new FileContentResult(bytes, "text/plain")
            {
                FileDownloadName = fileName
            };

            return result;
        }

        [HttpGet("/export/{id}")]
        public IActionResult getClientByIdForExport([FromRoute] int id) {

            var client = _dBContext.Client.Find(id);

            if(client == null) {
                return NotFound();
            }else
            {
                return Ok(client.ToClientExportDto());
            }
        }

        [HttpGet("{id}")]
        public IActionResult getClientById([FromRoute] int id) {

            var client = _dBContext.Client.Find(id);

            if(client == null) {
                return NotFound();
            }else
            {
                return Ok(client);
            }
        }

        [HttpPost]
        public IActionResult createClients([FromBody] List<CreateClientRequestDto> clientRequests)
        {
            foreach (var clientRequest in clientRequests)
            {
                var clientModel = clientRequest.ToClientFromCreateDTO();
                _dBContext.Client.Add(clientModel);
            }

            _dBContext.SaveChanges();  

            var createdClients = clientRequests.Select(clientRequest => clientRequest.ToClientFromCreateDTO().ToClientDto()).ToList();
            return Created("getClients", createdClients);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult updateClient([FromRoute] int id, [FromBody] UpdateClientRequestDto updateClient )
        {
            var clientModel = _dBContext.Client.FirstOrDefault(x => x.Id == id);

            if(clientModel == null) {
                return NotFound();
            }else
            {
                clientModel.Cell = updateClient.Cell;

                _dBContext.SaveChanges();
                return Ok(clientModel.ToClientDto());
            }
        }
    }
}