using System.ComponentModel.DataAnnotations.Schema;
using katio_net.Data.Models;

namespace katio.Data.Models;

public class AudioBooks : BaseEntity<int> 
{
    public string Name {get; set;}= "";
    public string ISBN10 {get; set;} = "";
    public string ISBN13 {get; set;}= "";
    public DateTime Published;
    public bool Abridged{get; set;} // resumido o no.
    public int LengthInSeconds {get; set;} // Duracion en segundos
    public string Path {get; set;}= ""; // Donde esta ese libro en el disco.    
    public string Edition {get; set;}= "";

    public string Genre {get; set;}= "";

    [ForeignKey("Narrator")]
    public int NarratorId {get; set;}

    public virtual Narrator? Narrator{get;set;}

}