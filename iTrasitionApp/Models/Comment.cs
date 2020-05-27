using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTrasitionApp.Models
{
    public class Comment
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [Required]
        public string body { get; set; }

        [Required]
        public DateTime date { get; set; }
    }
}
