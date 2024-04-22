namespace Ch1_Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("두 숫자를 입력하세요(띄어쓰기) : ");
            string[] nums = Console.ReadLine().Split(' ');
            int num1 = int.Parse(nums[0]);
            int num2 = int.Parse(nums[1]);

            Console.WriteLine("더하기 : " + (num1 + num2));
            Console.WriteLine("빼기 : " + (num1 - num2));
            Console.WriteLine("곱하기 : " + (num1 * num2));
            Console.WriteLine("나누기 : " + (num1 / num2));
        }
    }
}