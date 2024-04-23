namespace IUsable
{
    internal class Program
    {
        public interface IUsable
        {
            void Use();
        }

        // 아이템 클래스
        public class Item : IUsable
        {
            public string Name { get; set; }

            public void Use()
            {
                Console.WriteLine("아이템 {0}을 사용했습니다.", Name);
            }
        }

        // 플레이어 클래스
        public class Player
        {
            public void UseItem(IUsable item)
            {
                item.Use();
            }
        }

        // 게임 실행
        static void Main()
        {
            Player player = new Player();
            Item item = new Item { Name = "Health Potion" };
            player.UseItem(item);
        }
    }
}