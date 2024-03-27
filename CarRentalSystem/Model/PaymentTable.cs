using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Model
{
	internal class PaymentTable 
	{
		private int paymentID;
		private int leaseID;
		private DateOnly paymentDate;
		private double amount;

		public int PaymentID { get { return paymentID; } set { paymentID = value; } }
		public int LeaseID { get { return leaseID; } set { leaseID = value; } }
		public DateOnly PaymentDate { get { return paymentDate; } set { paymentDate = value; } }
		public double Amount { get { return amount; } set { amount = value; } }

		public PaymentTable() : base()
		{
		}

        public override string ToString()
        {
			return $"{PaymentID} {LeaseID} {PaymentDate} {Amount}";
        }
    }
}

