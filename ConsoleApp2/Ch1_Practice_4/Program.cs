namespace Ch1_Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // BMI = 체중 / 신장^2
            Console.Write("체중을 입력해주세요 : ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("신장을 입력해주세요 : ");
            float height = float.Parse(Console.ReadLine());

            //float bmi = weight / (height * height);
            double bmi = weight / Math.Pow(height / 100, 2);
            Console.WriteLine("결과 : " + bmi);
        }
    }
}