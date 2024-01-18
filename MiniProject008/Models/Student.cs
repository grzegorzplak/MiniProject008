
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProject008.Models
{
    [Table("MiniProject008_Students")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        [DisplayName("Language level")]
        public int LanguageLevelId { get; set; }
        public virtual LanguageLevel? LanguageLevel { get; set; }
    }
}
