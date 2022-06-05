using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSvsGTD_Avalonia.Models.ArmDb
{
    public class ArmDbContext
    {
        public string TNVED { get; set; } //код тнвэд
        public string DeclNumber { get; set; } //номер декларации
        public decimal Weight { get; set; } //вес
        public int NumberOfSeats { get; set; } //количество мест
        public decimal Price { get; set; } //стоимость
        public string CompanyName { get; set; } //наименование компании
        public string Currency { get; set; } //валюта
    }
}
