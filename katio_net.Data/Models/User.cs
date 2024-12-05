using System.ComponentModel.DataAnnotations.Schema;
using katio_net.Data.Models;

namespace katio.Data.Models;

public class User : BaseEntity<int> 
{
    public string Name {get; set;}="";
    public string Lastname {get; set;}="";
    public string Email {get; set;}="";
    public string Phone {get; set;}="";
    public string Identification {get; set;}="";
    public string Passhash {get; set;}="";// Password. PassHash

    [ForeignKey("Role")]
    public int RoleId {get; set;}
    public virtual Role? role{get;set;}
    
}