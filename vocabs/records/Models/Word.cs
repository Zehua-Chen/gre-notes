using System.ComponentModel.DataAnnotations;

namespace Records.Models
{
    public class Word
    {
        public int WordId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Misses { get; set; }
    }
}
