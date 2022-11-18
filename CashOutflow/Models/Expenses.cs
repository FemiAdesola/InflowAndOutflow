using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CashOutflow.Models
{
	public class Expenses
	{
        [Key]
		public int Id { get; set; }

        [DisplayName("Expenses")]
        [Required]
        public string ExpensesName { get; set; }


        [DisplayName("Amount")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be higher than 0!")]
        public int Amount { get; set; }

        
        

        
	}
}

