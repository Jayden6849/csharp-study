namespace ch02
{
    class Program
    {
        static void Main(string[] args)
        {
            // =============== 생사 판정 ===============

            int hp = 100;
            bool isDead = hp <= 0;

            if (isDead)
            {
                Console.WriteLine("Game Over");
            }
            else
            {
                Console.WriteLine("You are alive");
            }

            // =============== 가위바위보 if ===============

            byte choice = 1; // 0 == rock, 1 == paper, 2 == scissors
            try
            {
                if (choice == 0)
                {
                    Console.WriteLine("바위입니다.");
                }
                else if (choice == 1)
                {
                    Console.WriteLine("보입니다.");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("가위입니다.");
                }
                else
                {
                    throw new ArgumentException("입력이 잘못되었습니다. 0, 1, 2 중 하나를 입력하세요.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // =============== 가위바위보 switch ===============

            choice = 2;

            try
            {
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("바위입니다.");
                        break;
                    case 1:
                        Console.WriteLine("보입니다.");
                        break;
                    case 2:
                        Console.WriteLine("가위입니다");
                        break;
                    default:
                        throw new ArgumentException("입력이 잘못되었습니다. 0, 1, 2 중 하나를 입력하세요.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // =============== 삼항 연산자 ===============

            int number = 25;
            bool isPair = (number % 2 == 0) ? true : false;

            Console.WriteLine(isPair ? "짝수" : "홀수");

            // =============== 가위바위보 게임 ===============

            // 0: 가위, 1: 바위, 2: 보

            Random random = new Random();

            while(true)
            {
                int aiChoice = random.Next(0, 3); // 0 ~ 2 중 랜덤값 하나를 반환 (int)
                
                Console.Write("가위(0), 바위(1), 보(2) 중 하나를 입력하세요: ");
                int myChoice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (aiChoice)
                    {
                        case 0:
                            Console.WriteLine("AI가 낸 것: 가위");
                            break;
                        case 1:
                            Console.WriteLine("AI가 낸 것: 바위");
                            break;
                        case 2:
                            Console.WriteLine("AI가 낸 것: 보");
                            break;
                        default:
                            throw new ArgumentException("입력이 잘못되었습니다. 0, 1, 2 중 하나를 입력하세요.");
                    }

                    switch (myChoice)
                    {
                        case 0:
                            Console.WriteLine("내가 낸 것: 가위");
                            break;
                        case 1:
                            Console.WriteLine("내가 낸 것: 바위");
                            break;
                        case 2:
                            Console.WriteLine("내가 낸 것: 보");
                            break;
                        default:
                            throw new ArgumentException("입력이 잘못되었습니다. 0, 1, 2 중 하나를 입력하세요.");
                    }

                    if (aiChoice == myChoice)
                    {
                        Console.WriteLine("무승부");
                    }
                    else if ((aiChoice == 0 && myChoice == 1) || (aiChoice == 1 && myChoice == 2) || (aiChoice == 2 && myChoice == 0))
                    {
                        Console.WriteLine("승리");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("패배");
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

        }
    }
}
