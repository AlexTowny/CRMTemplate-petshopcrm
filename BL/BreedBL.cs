using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Breed = Entities.Breed;

namespace BL
{
	public class BreedBL
	{
		public async Task<int> AddOrUpdateAsync(Breed entity)
		{
			entity.Id = await new BreedDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BreedDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BreedSearchParams searchParams)
		{
			return new BreedDal().ExistsAsync(searchParams);
		}

		public Task<Breed> GetAsync(int id)
		{
			return new BreedDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BreedDal().DeleteAsync(id);
		}

		public Task<SearchResult<Breed>> GetAsync(BreedSearchParams searchParams)
		{
			return new BreedDal().GetAsync(searchParams);
		}
	}
}

