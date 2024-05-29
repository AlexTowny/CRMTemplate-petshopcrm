using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class AnimalModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Nickname")]
		public string Nickname { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "BreedId")]
		public int BreedId { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "TypeId")]
		public int TypeId { get; set; }

		public static AnimalModel FromEntity(Animal obj)
		{
			return obj == null ? null : new AnimalModel
			{
				Id = obj.Id,
				Nickname = obj.Nickname,
				BreedId = obj.BreedId,
				TypeId = obj.TypeId,
			};
		}

		public static Animal ToEntity(AnimalModel obj)
		{
			return obj == null ? null : new Animal(obj.Id, obj.Nickname, obj.BreedId, obj.TypeId);
		}

		public static List<AnimalModel> FromEntitiesList(IEnumerable<Animal> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Animal> ToEntitiesList(IEnumerable<AnimalModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
