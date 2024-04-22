namespace Ch1_Practice_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("섭씨온도를 입력해주세요(C) : ");
            float celsius = float.Parse(Console.ReadLine());
            float fahrenheit = celsius * 9 / 5 + 32;
            Console.WriteLine("결과(F) : " + fahrenheit);
        }
    }
}