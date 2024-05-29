using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Typee = Entities.Typee;

namespace BL
{
	public class TypeeBL
	{
		public async Task<int> AddOrUpdateAsync(Typee entity)
		{
			entity.Id = await new TypeeDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new TypeeDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(TypeeSearchParams searchParams)
		{
			return new TypeeDal().ExistsAsync(searchParams);
		}

		public Task<Typee> GetAsync(int id)
		{
			return new TypeeDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new TypeeDal().DeleteAsync(id);
		}

		public Task<SearchResult<Typee>> GetAsync(TypeeSearchParams searchParams)
		{
			return new TypeeDal().GetAsync(searchParams);
		}
	}
}

