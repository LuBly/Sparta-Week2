namespace Ch2_2_TicTacToeGame   
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // board 생성 (3,3) = 0 : 빈칸, 1 : 컴퓨터, 2 : Player
            int[,] board = new int[3, 3];
            // 우선권 정하기 (가위바위보)
            // 이겼을 경우 Player 먼저, 졌을경우 컴퓨터 먼저
            bool isPlayer = (RockScissorPaper())? true : false;

            bool isTurnEnd = true;

            while (true)
            {
                // 게임 시작 (끝이 아닐 경우)
                // 보드 출력
                if (isTurnEnd)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            Console.Write(board[y, x] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                // 게임이 끝났는지 체크(승리자가 정해짐 || 판이 모두 찼을때)
                if (isGameOver(board))
                {
                    break;
                }
                
                // 내차례인 경우
                if (isPlayer)
                {
                    // 놓을 자리 x,y 값 입력
                    Console.WriteLine("놓을 자리를 선택해 주세요. [y , x]");
                    string[] pos = Console.ReadLine().Split(',');
                    int y = int.Parse(pos[0]);
                    int x = int.Parse(pos[1]);
                    // 빈 자리에 잘 놨을 경우
                    if (board[y,x] == 0)
                    {
                        board[y,x] = 2;
                        isPlayer = false;
                        isTurnEnd = true;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 자리입니다. 다시 놔주세요");
                        isTurnEnd = false;
                    }
                }
                // 컴퓨터가 차례인 경우
                else
                {
                    int y = new Random().Next(0, 2);
                    int x = new Random().Next(0, 2);
                    // 빈 자리에 잘 놨을 경우
                    if (board[y,x] == 0)
                    {
                        // 빈자리를 찾을때까지 random 선택
                        // 놓을 자리 x,y 값 입력 (랜덤 선택)
                        Console.WriteLine("컴퓨터 좌표 : [{0}][{1}]", y, x);
                        board[y,x] = 1;
                        isPlayer = true;
                        isTurnEnd = true;
                    }
                    else
                    {
                        isTurnEnd = false;
                    }
                }
            }
            // 게임 종료시 결과 출력
        }

        public static bool RockScissorPaper()
        {
            string[] choices = { "가위", "바위", "보" };
            string playerChoice = "";
            string computerChoice = choices[new Random().Next(0, 3)];

            while (true)
            {
                Console.Write("가위, 바위, 보 중 하나를 선택하세요: ");
                playerChoice = Console.ReadLine();

                Console.WriteLine("컴퓨터: " + computerChoice);

                if (playerChoice == computerChoice)
                {
                    Console.WriteLine("비겼습니다!");
                    continue;
                }
                else if ((playerChoice == "가위" && computerChoice == "보") ||
                         (playerChoice == "바위" && computerChoice == "가위") ||
                         (playerChoice == "보" && computerChoice == "바위"))
                {
                    Console.WriteLine("플레이어 승리!");
                    return true;
                }
                else
                {
                    Console.WriteLine("컴퓨터 승리!");
                    return false;
                }
            }
        }
        
        public static bool isGameOver(int[,] board)
        {
            bool isGameOver = false;
            // 가로 확인
            for(int y = 0; y < 3; y++)
            {
                // 컴퓨터 승리
                if((board[y, 0] == 1 && board[y, 1] == 1) && (board[y, 1] == 1 && board[y, 2] == 1))
                {
                    isGameOver = true;
                    Console.WriteLine("컴퓨터 승리!");
                    break;
                }
                // 플레이어 승리
                else if((board[y, 0] == 2 && board[y, 1] == 2) && (board[y, 1] == 2 && board[y, 2] == 2))
                {
                    isGameOver = true;
                    Console.WriteLine("플레이어 승리!");
                    break;
                }
            }
            // 세로 확인
            if (!isGameOver)
            {
                for (int x = 0; x < 3; x++)
                {
                    // 컴퓨터 승리
                    if ((board[0, x] == 1 && board[1, x] == 1) && (board[1, x] == 1 && board[2, x] == 1))
                    {
                        isGameOver = true;
                        Console.WriteLine("컴퓨터 승리!");
                        break;
                    }
                    // 플레이어 승리
                    else if ((board[0, x] == 2 && board[1, x] == 2) && (board[1, x] == 2 && board[2, x] == 2))
                    {
                        isGameOver = true;
                        Console.WriteLine("플레이어 승리!");
                        break;
                    }
                }
            }
            // 대각선 확인
            if (!isGameOver)
            {
                if ((board[0, 0] == 1 && board[1, 1] == 1) && (board[1, 1] == 1 && board[2, 2] == 1))
                {
                    isGameOver = true;
                    Console.WriteLine("컴퓨터 승리!");
                }
                else if ((board[0, 0] == 2 && board[1, 1] == 2) && (board[1, 1] == 2 && board[2, 2] == 2))
                {
                    isGameOver = true;
                    Console.WriteLine("플레이어 승리!");
                }
            }
            if (!isGameOver)
            {
                if ((board[2, 0] == 1 && board[1, 1] == 1) && (board[1, 1] == 1 && board[0, 2] == 1))
                {
                    isGameOver = true;
                    Console.WriteLine("컴퓨터 승리!");
                }
                else if ((board[2, 0] == 2 && board[1, 1] == 2) && (board[1, 1] == 2 && board[0, 2] == 2))
                {
                    isGameOver = true;
                    Console.WriteLine("플레이어 승리!");
                }
            }

            return isGameOver;
        }
    }
}