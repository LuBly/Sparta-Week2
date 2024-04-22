// 자주쓰는 using 문들은  프로젝트 / 프로젝트 속성 / 일반 / 전역 using에서 관리할 수 있다.
namespace Ch1_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("이름을 입력해주세요 : ");
            string name = Console.ReadLine();

            Console.Write("나이를 입력해주세요 : ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("이름 : " + name + "\n나이 : " + age);
        }
    }
}