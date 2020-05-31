using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iTrasitionApp.Models
{
    public class Company : DbContext
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Goal { get; set; }
        [Required]
        public int Сurrent { get; set; }
        [Required]
        public int Patrons { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        //[NotMapped]
        public List<Comment> Comments { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
