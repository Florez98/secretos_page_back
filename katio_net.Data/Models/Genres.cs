using katio_net.Data.Models;

namespace katio.Data.Models;

public class Genres : BaseEntity<int> 
{
    public string name {get; set;}= "";
}