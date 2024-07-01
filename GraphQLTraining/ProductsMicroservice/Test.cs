using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductsMicroservice;

[PrimaryKey(nameof(Id))]
[Table("test", Schema = "public")]
public class Test
{
    public int Id { get; set; }
    public Data Data { get; set; }
}

public class Data
{
    public Foo Foo { get; set; } 
    public string Name { get; set; }
}

public class Foo
{
    public string Name { get; set; }
    public List<FooItem> Items { get; set; }
    
}

public class FooItem
{
   // public string Id { get; set; }
    public string Name { get; set; }
 //   public List<Bar> Bars { get; set; }
}

public class Bar
{
    public string Name { get; set; }
}
