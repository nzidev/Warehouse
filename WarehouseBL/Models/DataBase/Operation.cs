using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WarehouseBL.Models.DataBase
{
    /// <summary>
    /// Операции с товаром
    /// </summary>
    public class Operation
    {
        public int OperationId { get; set; }
        
        public int StaffId { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }

        
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public string ProductName { get; set; }
        /// <summary>
        /// Дата операции
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Прежний статус
        /// </summary>
        public Product.ProductStatus OldStatus { get; set; }
        /// <summary>
        /// Новый статус
        /// </summary>
        public Product.ProductStatus NewStatus { get; set; }
    }
}
