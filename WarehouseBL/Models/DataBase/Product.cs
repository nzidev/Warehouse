using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WarehouseBL.Models.DataBase
{
    /// <summary>
    /// Таблица товара
    /// </summary>
    public class Product
    {
        [Key]
        public int ProdictId { get; set; }
        /// <summary>
        /// название товара
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Варианты статусов 
        /// </summary>
        public enum ProductStatus { 
            All,
            Accept, 
            Warehouse, 
            Sold}
        /// <summary>
        /// Статус товара - Accept, Warehouse, Sold
        /// </summary>
        public ProductStatus Status { get; set; }
        /// <summary>
        /// Цена товара
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Дополнительное описание
        /// </summary>
        public string Description { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }

    }
}
