using AutoMapper;
using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class EmailService : IEmailService
    {
        IEmailRepository _repo { get; }
        IMapper _mapper { get; }

        public EmailService(IEmailRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(EmailCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.EmailAddress.ToLower() == dto.EmailAddress.ToLower()))
                throw new AlreadyExistException<Email>();
            await _repo.CreateAsync(_mapper.Map<Email>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<EmailListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<EmailListItemDTO>>(data);

        }
    }
}
