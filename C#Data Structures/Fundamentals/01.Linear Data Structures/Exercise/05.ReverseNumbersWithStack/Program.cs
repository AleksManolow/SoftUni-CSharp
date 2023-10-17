namespace _05.ReverseNumbersWithStack
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            ReverseNumbers(numbers);
        }

        private static void ReverseNumbers(int[] numbers)
        {
            Stack<int> revNumbers = new Stack<int>();
            foreach (var item in numbers)
            {
                revNumbers.Push(item);
            }
            Console.WriteLine(string.Join(" ", revNumbers));
        }
    }
}