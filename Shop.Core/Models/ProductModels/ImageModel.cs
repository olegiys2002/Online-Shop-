﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Models.ProductModels
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Path { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }



    }
}
