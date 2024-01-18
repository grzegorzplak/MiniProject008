using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject008.Models
{
    [Table("MiniProject008_LanguageLevels")]
    public class LanguageLevel
    {
        public int Id { get; set; }
        public string Level { get; set; } = "";
        public ICollection<Student>? Students { get; set; }
    }
}
