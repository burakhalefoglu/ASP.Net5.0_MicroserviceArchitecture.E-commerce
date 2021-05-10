using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.services.Models.DTOs
{
    public class UpdateProductDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryId { get; set; }

        public FeatureDto Feature { get; set; }

        public CategoryDto Category { get; set; }

    }
}
