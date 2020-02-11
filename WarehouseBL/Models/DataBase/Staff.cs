using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseBL.Models.DataBase
{
    /// <summary>
    /// Таблица сотрудников
    /// </summary>
    public class Staff
    {
        public int StaffId { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Должность сотрудника
        /// </summary>
        public string Title { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
