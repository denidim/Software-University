using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopDemo.Core.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Product Identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Product Price
        /// </summary>
        [Required]
        [Range(typeof(decimal), "0.1", "1000", ConvertValueInInvariantCulture = true )]
        public decimal Price { get; set; }


        /// <summary>
        /// Quantity in stock
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
