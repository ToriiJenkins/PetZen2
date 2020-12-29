using PetZen.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetZen.Models
{
    public class PetListItem
    {
        [Key]
        public int PetId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Birthday")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public int MealsPerDay { get; set; }
    }
}
