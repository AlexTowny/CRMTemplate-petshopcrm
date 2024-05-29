using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class BreedDal : BaseDal<DefaultDbContext, Breed, Entities.Breed, int, BreedSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BreedDal()
		{
		}

		protected internal BreedDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Breed entity, Breed dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Breed>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Breed> dbObjects, BreedSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Breed>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Breed> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Breed, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Breed, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Breed ConvertDbObjectToEntity(Breed dbObject)
		{
			return dbObject == null ? null : new Entities.Breed(dbObject.Id, dbObject.Name);
		}
	}
}
