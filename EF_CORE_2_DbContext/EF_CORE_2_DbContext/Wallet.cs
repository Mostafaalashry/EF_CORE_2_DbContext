using System;
namespace EF_CORE_2_DbContext
{
	public class Wallet
	{
		public int Id { get; set; }
        public string Holder { get; set; } = null!;
        public decimal Balance { get; set; }

        public override string ToString()
        {
            return $" ID = {Id} , Holder = {Holder} , Balance = {Balance}";
        }
    }
}

