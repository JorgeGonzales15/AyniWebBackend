using System.Text.Json.Serialization;

namespace AyniWebBackend.Ayni.Domain.Models;

public class User
{
    public int Id {get; set;}
    public string Name {get; set;}
    
    public string Email { get; set; } //AGREGAR CAMPO
    
    public string Password { get; set; } //AGREGAR CAMPO
    
    //[JsonIgnore]
    //public IList<Crop> Crops { get; set; } = new List<Crop>();
    //public IList<Cost> Costs { get; set; } = new List<Cost>();
    
    //public IList<Profit> Profits { get; set; } = new List<Profit>();
    
    //public IList<Order> Orders { get; set; } = new List<Order>();
}