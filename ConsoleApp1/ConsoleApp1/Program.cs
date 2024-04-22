namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.클래스, 메서드, 변수 등의 이름을 입력할 때 일부를 입력하고, Tab 키를 눌러 나머지를 자동 완성합니다.
            //-Console.WriteLine을 작성할 때, Console.까지 입력하고 Tab 키를 누르면 자동으로 WriteLine이 완성됩니다.
            Console.WriteLine("use Tab");
            //-메서드나 변수를 입력하는 도중에 Ctrl +Space를 눌러 IntelliSense를 호출하면, 해당 메서드나 변수에 대한 정보와 예제를 볼 수 있습니다.
            Console.WriteLine("use Ctrl + Space");
            //2.코드 템플릿을 사용하여 코드를 더 빠르게 작성합니다.
            //-예를 들어, for문을 작성할 때, for 키워드를 입력하고, 두 번 Tab 키를 누르면 for문의 기본적인 코드 템플릿이 자동으로 생성됩니다.
            /*
            for (int i = 0; i < length; i++)
            {

            }
            */
            Console.WriteLine("Hello, World!");
        }
    }
}