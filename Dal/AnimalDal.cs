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
	public class AnimalDal : BaseDal<DefaultDbContext, Animal, Entities.Animal, int, AnimalSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public AnimalDal()
		{
		}

		protected internal AnimalDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Animal entity, Animal dbObject, bool exists)
		{
			dbObject.Nickname = entity.Nickname;
			dbObject.BreedId = entity.BreedId;
			dbObject.TypeId = entity.TypeId;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Animal>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Animal> dbObjects, AnimalSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Animal>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Animal> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Animal, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Animal, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Animal ConvertDbObjectToEntity(Animal dbObject)
		{
			return dbObject == null ? null : new Entities.Animal(dbObject.Id, dbObject.Nickname, dbObject.BreedId,
				dbObject.TypeId);
		}
	}
}
