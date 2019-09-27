using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreApp.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Lastname")]
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Column("Firstname")]
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First name")]
        public string Firstname { get; set; }


        public Guid JobId { get; set; } //1-n foreign key
        public Job Job { get; set; }

        public List<PersonActivity> PersonActivities { get; set; } //n-n
    }
}