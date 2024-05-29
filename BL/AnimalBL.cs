using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Animal = Entities.Animal;

namespace BL
{
	public class AnimalBL
	{
		public async Task<int> AddOrUpdateAsync(Animal entity)
		{
			entity.Id = await new AnimalDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new AnimalDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(AnimalSearchParams searchParams)
		{
			return new AnimalDal().ExistsAsync(searchParams);
		}

		public Task<Animal> GetAsync(int id)
		{
			return new AnimalDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new AnimalDal().DeleteAsync(id);
		}

		public Task<SearchResult<Animal>> GetAsync(AnimalSearchParams searchParams)
		{
			return new AnimalDal().GetAsync(searchParams);
		}
	}
}

