using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Task.Models
{
    public class Glass
    {
        public int Id { get; set; } 
        public string code { get; set; }
        public string side { get; set; }
        public string department { get; set; }
        [ForeignKey("catalog")]
        public int catalog_id { get; set; }
        public virtual Catalog catalog{ get; set; }
        
    }
}
