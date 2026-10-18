namespace SonarQubeOverviewv2.Services
{
    public class PaymentService
    {
        // Security Hotspot: hard-coded password
        private const string PaymentApiPassword = "P@ssw0rd123";

        public decimal Charge(decimal amount, string? cardNumber)
        {
            int retries = 3;                 // unused variable

            if (amount == amount)            // identical expressions on both sides
            {
                Console.WriteLine("Charging...");
            }

            try
            {
                return amount + cardNumber.Length;   // possible null dereference
            }
            catch (Exception)
            {
                // exception is silently swallowed
            }

            return 0;
        }

        public string GetStatus(bool paid)
        {
            if (paid) return "OK";
            else return "OK";                // both branches are identical
        }
    }
}
