// 자주쓰는 using 문들은  프로젝트 / 프로젝트 속성 / 일반 / 전역 using에서 관리할 수 있다.
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("MyName is Hyunho");

            Console.WriteLine(10);
            Console.WriteLine(3.141592);
            Console.WriteLine(3 * 3);

            Console.Write("Hello!");
            Console.Write(" We are Learning");
            Console.WriteLine(" at Sparta");
        }
    }
}