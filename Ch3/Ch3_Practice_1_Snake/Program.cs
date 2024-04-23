using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 게임 속도를 조절하기 위한 변수. 숫자가 클 수록 느려진다.
        int gameSpeed = 200;
        // 먹은 음식의 수
        int foodCount = 0;

        // 벽 그리기
        DrawWalls();

        // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
        Point p = new Point(4, 5, '*');
        Snake snake = new Snake(p, 5, Direction.RIGHT);
        snake.Draw();

        // 음식의 위치를 무작위로 생성하고, 그립니다. (답안 참고 width_가로, length_세로)
        FoodCreator foodCreator = new FoodCreator(80, 20, '$');
        Point food = foodCreator.CreateFood();
        food.Draw();

        // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
        while (true)
        {
            // 키 입력이 있는 경우에만 방향을 변경합니다.
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        snake.direction = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        snake.direction = Direction.DOWN;
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.direction = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        snake.direction = Direction.RIGHT;
                        break;
                }
            }

            if(snake.Eat(food))
            {
                foodCount++; // 먹은 음식 수 증가
                food.Draw(); // 바뀐 Sym으로 다시 그리기 = 뱀 길이 증가

                // 새로운 food 생성
                food = foodCreator.CreateFood();
                food.Draw();
                if(gameSpeed > 10) // 음식 먹으면 게임 점점 빠르게
                {
                    gameSpeed -= 10;
                }
            }
            else
                // 뱀이 음식을 먹은게 아니면 그냥 이동
                snake.Move();

            
            Thread.Sleep(gameSpeed); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)
            
            //벽이나 자신의 몸에 부딪히면 게임 종료
            if (snake.isHitWall() || snake.isHitTail()) break;

            // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)
            Console.SetCursorPosition(0, 21); // 커서 위치 설정
            Console.WriteLine($"먹은 음식 수 : {foodCount}"); // 먹은 음식 수 출력
        }

        // 게임 종료
        WriteGameOver();
    }

    static void WriteGameOver()
    {
        int xOffset = 25;
        int yOffset = 22;
        Console.SetCursorPosition(xOffset, yOffset++);
        WriteText("============================", xOffset, yOffset++);
        WriteText("         GAME OVER", xOffset, yOffset++);
        WriteText("============================", xOffset, yOffset++);
    }

    static void WriteText(string text, int xOffset, int yOffset)
    {
        Console.SetCursorPosition(xOffset, yOffset);
        Console.WriteLine(text);
    }

    static void DrawWalls()
    {
        // 상하 벽 그리기
        for(int x = 0; x < 80; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("#");

            Console.SetCursorPosition(x, 20);
            Console.Write("#");
        }

        // 좌우 벽 그리기
        for(int y = 0; y < 20; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("#");

            Console.SetCursorPosition(80, y);
            Console.Write("#");
        }
    }
}
public class FoodCreator
{
    public int width;
    public int length;
    public char sym;

    Random random = new Random();

    public FoodCreator(int width, int length, char sym)
    {
        this.width = width;
        this.length = length;
        this.sym = sym;
    }

    public Point CreateFood()
    {
        int x = random.Next(2, width - 2);
        // x 좌표를 2단위로 맞추기 위해 짝수로 만들기 *
        x = (x % 2 == 0) ? x : x + 1;
        int y = random.Next(2, length - 2);

        return new Point(x, y, sym);
    }
}
public class Snake
{
    public List<Point> body;
    public Direction direction;

    //List *(tail(0)) * * *(head(last))
    public Snake(Point tail, int length, Direction _direction)
    {
        direction = _direction;
        body = new List<Point>();
        for(int i = 0; i < length; i++)
        {
            Point p = new Point(tail.x, tail.y, '*');
            body.Add(p);
            tail.x += 2; // *
        }
    }

    public void Draw()
    {
        foreach(Point p in body)
        {
            p.Draw();
        }
    }
    public bool Eat(Point food)
    {
        Point head = GetNextPoint();
        if (head.IsHit(food))
        {
            food.sym = head.sym;
            body.Add(food);
            return true;
        }
        else
            return false;
    }

    // 뱀이 이동하는 메서드
    public void Move()
    {
        Point tail = body.First();
        body.Remove(tail);

        Point head = GetNextPoint();
        body.Add(head);

        tail.Clear();
        head.Draw();
    }

    public Point GetNextPoint()
    {
        Point head = body.Last();
        Point nextPoint = new Point(head.x, head.y, head.sym);

        switch(direction)
        {
            case Direction.LEFT:
                nextPoint.x -= 2;
                break;
            case Direction.RIGHT:
                nextPoint.x += 2;
                break;
            case Direction.UP:
                nextPoint.y -= 1;
                break;
            case Direction.DOWN:
                nextPoint.y += 1;
                break;
        }

        return nextPoint;
    }
    // 뱀이 자신의 꼬리에 부딪혔는지 확인하는 메서드
    public bool isHitTail()
    {
        Point head = body.Last();
        for(int i = 0; i < body.Count - 2; i++)
        {
            if (head.IsHit(body[i]))
            {
                return true;
            }
        }
        return false;
    }

    // 뱀이 벽에 부딪혔는지 확인하는 메서드
    public bool isHitWall()
    {
        Point head = body.Last();
        if (head.x <= 0 || head.x >= 80 || head.y <= 0 || head.y >= 20)
            return true;

        return false;
    }
}

public class Point
{
    public int x { get; set; }
    public int y { get; set; }
    public char sym { get; set; }

    // Point 클래스 생성자
    public Point(int _x, int _y, char _sym)
    {
        x = _x;
        y = _y;
        sym = _sym;
    }

    // 점을 그리는 메서드
    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(sym);
    }

    // 점을 지우는 메서드
    public void Clear()
    {
        sym = ' ';
        Draw();
    }

    // 두 점이 같은지 비교하는 메서드
    public bool IsHit(Point p)
    {
        return p.x == x && p.y == y;
    }
}
// 방향을 표현하는 열거형입니다.
public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}