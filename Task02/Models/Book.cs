﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        [MaxLength(20)]
        [Required]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }

        //public virtual Authors Authorss { get; set; }

        //public Authors Authors { get; set; }
    }
}
