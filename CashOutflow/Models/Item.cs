using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CashOutflow.Models
{
	public class Item	{
		[Key]
		public int Id { get; set; }
        public string Debtor { get; set; }
        public string Lender { get; set; }
        public string ItemName { get; set; }
    }
}

