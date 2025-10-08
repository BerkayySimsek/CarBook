using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaByIdQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaByIdQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var socialMedias = await _repository.GetAllAsync();
            return socialMedias.Select(x => new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = x.SocialMediaId,
                Name = x.Name,
                Url = x.Url,
                Icon = x.Icon,
            }).ToList();
        }
    }
}
