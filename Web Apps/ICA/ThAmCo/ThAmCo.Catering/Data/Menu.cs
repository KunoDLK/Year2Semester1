using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
      public class Menu
      {
            public Menu() { }

            [Key]
            public int MenuId { get; set; }

            [Required, MaxLength(50)]
            public string MenuName { get; set; }
      }
}
