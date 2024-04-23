namespace Ch3
{
    internal class Program
    {
        class Person
        {
            private string name;
            private int age;

            // 매개변수가 없는 디폴트 생성자
            public Person()
            {
                name = "Unknown";
                age = 0;
            }

            // 매개변수를 받는 생성자
            public Person(string newName, int newAge)
            {
                name = newName;
                age = newAge;
            }

            // 자동적으로 소멸될 때
            ~Person()
            {
                Console.WriteLine("Person 객체 소멸");
            }

            public void PrintInfo()
            {
                Console.WriteLine($"Name: {name}, Age: {age}");
            }
        }

        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person("A", 25);

            person2.PrintInfo();
        }
    }
}