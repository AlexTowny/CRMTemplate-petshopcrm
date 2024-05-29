using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Animal
	{
		public int Id { get; set; }
		public string Nickname { get; set; }
		public int BreedId { get; set; }
		public int TypeId { get; set; }

		public Animal(int id, string nickname, int breedId, int typeId)
		{
			Id = id;
			Nickname = nickname;
			BreedId = breedId;
			TypeId = typeId;
		}
	}
}
