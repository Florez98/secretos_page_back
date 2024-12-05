using System.ComponentModel.DataAnnotations.Schema;
using katio_net.Data.Models;

namespace katio.Data.Models;
public class Author : BaseEntity<int>
{
    public string Name {get; set;} ="";
    public string LastName {get; set;} ="";
    public string Country {get; set;} = "";

    public DateOnly BirthDate {get; set;}




}