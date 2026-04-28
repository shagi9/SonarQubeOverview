namespace SonarQubeOverviewv2.Services
{
    public class BadServiceWithStandardAnalyzers
    {
        public void NullDereference(List<string>? items)
        {
            Console.WriteLine(items.Count); // ⚠️ Dereference of a possibly null reference
        }

        public void UnusedVariable()
        {
            int x = 42; // ⚠️ The variable 'x' is assigned but its value is never used
        }

    }
}
