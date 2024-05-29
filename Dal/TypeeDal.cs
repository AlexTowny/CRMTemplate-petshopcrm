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
	public class TypeeDal : BaseDal<DefaultDbContext, Typee, Entities.Typee, int, TypeeSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public TypeeDal()
		{
		}

		protected internal TypeeDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Typee entity, Typee dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Typee>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Typee> dbObjects, TypeeSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Typee>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Typee> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Typee, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Typee, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Typee ConvertDbObjectToEntity(Typee dbObject)
		{
			return dbObject == null ? null : new Entities.Typee(dbObject.Id, dbObject.Name);
		}
	}
}
