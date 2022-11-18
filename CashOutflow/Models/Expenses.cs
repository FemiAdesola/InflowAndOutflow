using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CashOutflow.Models
{
	public class Expenses
	{

		public int Id { get; set; }

        [DisplayName("Expenses")]
        public string ExpensesName { get; set; }
        public int Amount { get; set; }

        
        

        
	}
}

