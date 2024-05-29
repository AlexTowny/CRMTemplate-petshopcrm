using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Breed
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Breed(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
