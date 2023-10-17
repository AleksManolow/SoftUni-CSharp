namespace _06.CalculateSequenceWithQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> q = new Queue<int>();
            q.Enqueue(n);
            int x, y, z;
            for (int i = 0; i < 50; i++)
            {   
                int temp = q.Dequeue();
                Console.Write(temp + " ");
                q.Enqueue(temp + 1);
                q.Enqueue(2 * temp + 1);
                q.Enqueue(temp + 2);
            }
            
        }
    }
}