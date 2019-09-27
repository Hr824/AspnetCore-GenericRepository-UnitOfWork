using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCoreApp.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Code")]
        [Required(ErrorMessage = "Code is required")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Column("Title")]
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }


        public List<Person> Persons { get; set; } //1-n
    }
}