namespace Ch2_1_MatchNumberGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetNum = new Random().Next(1, 101);
            int guess;
            int count = 1;

            Console.WriteLine("1~100 사이의 숫자를 맞춰보세요?");

            while (true)
            {
                Console.Write("추측한 숫자를 입력해주세요 : ");
                guess = int.Parse(Console.ReadLine());
                if(targetNum == guess)
                {
                    Console.WriteLine("축하합니다. 정답입니다.");
                    Console.WriteLine("시도한 횟수 : " + count);
                    break;
                }

                if(targetNum > guess)
                {
                    Console.WriteLine("좀 더 큰 숫자를 입력하세요.");
                }
                else
                {
                    Console.WriteLine("좀 더 작은 숫자를 입력하세요.");
                }
                count++;
                Console.WriteLine();
            }
        }
    }
}