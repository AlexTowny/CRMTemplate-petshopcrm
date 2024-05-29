using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BreedModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		public static BreedModel FromEntity(Breed obj)
		{
			return obj == null ? null : new BreedModel
			{
				Id = obj.Id,
				Name = obj.Name,
			};
		}

		public static Breed ToEntity(BreedModel obj)
		{
			return obj == null ? null : new Breed(obj.Id, obj.Name);
		}

		public static List<BreedModel> FromEntitiesList(IEnumerable<Breed> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Breed> ToEntitiesList(IEnumerable<BreedModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
