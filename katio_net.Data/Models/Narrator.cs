using System.ComponentModel.DataAnnotations.Schema;
using katio_net.Data.Models;

namespace katio.Data.Models;

public class Narrator : BaseEntity<int>
{
    public string Name{get; set;} = "";
    public string LastName {get; set;} ="";

    public string Genre {get; set;} ="";
   
    

}