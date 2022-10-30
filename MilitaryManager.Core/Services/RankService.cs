using AutoMapper;
using MilitaryManager.Core.DTO.Ranks;
using MilitaryManager.Core.Entities.RankEntity;
using MilitaryManager.Core.Interfaces.Repositories;
using MilitaryManager.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryManager.Core.Services
{
    public class RankService : IRankService
    {
        protected readonly IRepository<Rank, int> _rankRepository;
        protected readonly IMapper _mapper;

        public RankService(IRepository<Rank, int> rankRepository, IMapper mapper)
        {
            _rankRepository = rankRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RankDTO>> GetAllRanksAsync()
        {
            var ranks = await _rankRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<RankDTO>>(ranks);
        }
    }
}
