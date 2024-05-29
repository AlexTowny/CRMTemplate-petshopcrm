using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Breed
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Animal> AnimalBreeds { get; set; } = new List<Animal>();

    public virtual ICollection<Animal> AnimalTypes { get; set; } = new List<Animal>();
}
