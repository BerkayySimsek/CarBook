using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FooterAdressById(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Başarıyla Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Alt Adres Başarıyla Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Alt Adres Başarıyla Güncellendi.");
        }
    }
}
