using katio_net.Data.Models;

namespace katio.Data.Models;

public class Role : BaseEntity<int> 
{
    public String roleName {get; set;}="";
}