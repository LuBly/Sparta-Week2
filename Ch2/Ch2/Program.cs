namespace Ch2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 플레이어의 공격력, 방어력, 체력, 스피드를 저장할 배열
            int[] playerStats = new int[4];

            // 능력치를 랜덤으로 생성하여 배열에 저장
            Random rand = new Random();
            for (int i = 0; i < playerStats.Length; i++)
            {
                playerStats[i] = rand.Next(1, 11);
            }

            // 능력치 출력
            Console.WriteLine("플레이어의 공격력:\t" + playerStats[0]);
            Console.WriteLine("플레이어의 방어력:\t" + playerStats[1]);
            Console.WriteLine("플레이어의 체력:\t" + playerStats[2]);
            Console.WriteLine("플레이어의 스피드:\t" + playerStats[3]);
        }
    }
}