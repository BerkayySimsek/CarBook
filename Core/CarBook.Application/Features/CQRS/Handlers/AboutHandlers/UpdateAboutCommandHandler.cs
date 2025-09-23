using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _aboutRepository;
        public UpdateAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var value = await _aboutRepository.GetByIdAsync(command.AboutId);
            value.Title = command.Title;
            value.Description = command.Description;
            value.ImageUrl = command.ImageUrl;
            await _aboutRepository.UpdateAsync(value);
        }
    }
}
