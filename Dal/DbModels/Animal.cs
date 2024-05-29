using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Animal
{
    public int Id { get; set; }

    public string Nickname { get; set; }

    public int BreedId { get; set; }

    public int TypeId { get; set; }

    public virtual Breed Breed { get; set; }

    public virtual Breed Type { get; set; }
}
