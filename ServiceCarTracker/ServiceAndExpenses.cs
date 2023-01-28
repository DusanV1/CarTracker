using System;
namespace ServiceCarTracker
{
	public class ServiceAndExpenses
	{
		public string ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public double ExpensePrice { get; set; }
        public int ExpenseCarMilage { get; set; }
        public string ExpenseNote { get; set; }

        public ServiceAndExpenses()
		{
		}
	}
}

