using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAngular2.Model
{
  public class TestModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public TestModel(int id, string name)
    {
      Id = id;
      Name = name;
    }

  }
}
