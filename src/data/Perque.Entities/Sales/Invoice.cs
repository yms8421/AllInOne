using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perque.Entities.Sales
{
    [Table("Invoices", Schema = "Sales")]
    public class Invoice : EntityBase
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        //TODO: customer
    }
}
