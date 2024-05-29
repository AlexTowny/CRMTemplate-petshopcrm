using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class TypeeModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Name")]
		public string Name { get; set; }

		public static TypeeModel FromEntity(Typee obj)
		{
			return obj == null ? null : new TypeeModel
			{
				Id = obj.Id,
				Name = obj.Name,
			};
		}

		public static Typee ToEntity(TypeeModel obj)
		{
			return obj == null ? null : new Typee(obj.Id, obj.Name);
		}

		public static List<TypeeModel> FromEntitiesList(IEnumerable<Typee> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Typee> ToEntitiesList(IEnumerable<TypeeModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
