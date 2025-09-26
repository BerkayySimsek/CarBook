using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarId);
            value.Model = command.Model;
            value.Seat = command.Seat;
            value.Fuel = command.Fuel;
            value.Km = command.Km;
            value.Luggage = command.Luggage;
            value.Transmission = command.Transmission;
            value.CoverImageUrl = command.CoverImageUrl;
            value.BigImageUrl = command.BigImageUrl;
            value.BrandId = command.BrandId;
            await _repository.UpdateAsync(value);
        }
    }
}
