using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public  DateTime? DeletedDate { get; set; }  
        public string Filepath { get; set; }

        public virtual List<Glass>? Glass { get; set; }
    }
}
