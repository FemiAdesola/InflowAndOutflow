using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CashOutflow.Models
{
	public class Items
	{
		[Key]
		public int Id { get; set; }
        public string Debtor { get; set; }
	}
}

