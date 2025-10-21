namespace ch02
{
    class Program
    {
        enum Choice
        {
            Scissors = 0,
            Rock = 1,
            Paper = 2
        }

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

            // 상수 선언 : 가독성을 위해 의미있는 이름을 부여 (대문자 스네이크) + 재할당 방지
            // C#에서는 const 키워드를 사용 (final 아님에 유의)
            //const int SCISSORS = 0;
            //const int ROCK = 1;
            //const int PAPER = 2;

            // 가위, 바위, 보는 연관된 값이므로 enum으로 선언하는 것이 더 적절

            while (true)
            {
                try
                {
                    int aiChoice = random.Next(0, 3); // 0 ~ 2 중 랜덤값 하나를 반환 (int)

                    Console.Write("가위(0), 바위(1), 보(2) 중 하나를 입력하세요: ");
                    string input = Console.ReadLine() ?? "";
                    int myChoice = -1;

                    // TryParse로 안전하게 변환
                    if (!int.TryParse(input, out myChoice) || myChoice < 0 || myChoice > 2)
                    {
                        Console.WriteLine("잘못된 입력입니다. 0, 1, 2 중 하나를 입력하세요.\n");
                        continue;
                    }

                    switch (aiChoice)
                    {
                        case (int)Choice.Scissors:
                            Console.WriteLine("AI가 낸 것: 가위");
                            break;
                        case (int)Choice.Rock:
                            Console.WriteLine("AI가 낸 것: 바위");
                            break;
                        case (int)Choice.Paper:
                            Console.WriteLine("AI가 낸 것: 보");
                            break;
                        default:
                            throw new ArgumentException("입력이 잘못되었습니다. 0, 1, 2 중 하나를 입력하세요.");
                    }

                    switch (myChoice)
                    {
                        case (int)Choice.Scissors:
                            Console.WriteLine("내가 낸 것: 가위");
                            break;
                        case (int)Choice.Rock:
                            Console.WriteLine("내가 낸 것: 바위");
                            break;
                        case (int)Choice.Paper:
                            Console.WriteLine("내가 낸 것: 보");
                            break;
                        default:
                            throw new ArgumentException("입력이 잘못되었습니다. 0, 1, 2 중 하나를 입력하세요.");
                    }

                    if (aiChoice == myChoice)
                    {
                        Console.WriteLine("무승부");
                    }
                    else if ((aiChoice == (int)Choice.Scissors && myChoice == (int)Choice.Rock) || (aiChoice == (int)Choice.Rock && myChoice == (int)Choice.Paper) || (aiChoice == (int)Choice.Paper && myChoice == (int)Choice.Scissors))
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
                catch (FormatException)
                {
                    Console.WriteLine("숫자만 입력 가능합니다!");
                    continue;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("알 수 없는 오류가 발생했습니다: 프로그램을 종료합니다.");
                    return;
                }
            }

            // =============== while, do-while, for ===============

            byte cnt = 0;
            while (cnt < 5)
            {
                cnt++;
                Console.WriteLine($"반복 횟수: {cnt}회");
            }

            cnt = 0;
            do
            {
               cnt++;
               Console.WriteLine($"반복 횟수: {cnt}회");
            } while (cnt < 5);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"반복 횟수: {i + 1}회");
            }

            // =============== 거울아거울아 ===============

            string answer;

            do
            {
                Console.Write("거울아 거울아, 세상에서 네가 제일 이쁘니? (y/n) ");
                answer = Console.ReadLine() ?? "";
            } while (!answer.Equals("y", StringComparison.OrdinalIgnoreCase));

            // =============== 소수의 판별 ===============
            // 소수 : 1과 자기 자신으로만 나누어 떨어지는 수

            int numberToCheck = 29;
            bool isPrime = numberToCheck >= 2;

            for (int i = 2; i <= Math.Sqrt(numberToCheck); i++)
            {
                if (numberToCheck % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine(isPrime ? "소수입니다." : "소수가 아닙니다.");

            // =============== 디버그 툴 활용 ===============
            // 프로시저 단위 디버깅: F10 (메서드를 만나면 안으로 들어감)
            // 줄 단위 디버깅: F11 (메서드를 만나도 안으로 들어가지는 않음) 
            // 종료: Shift + F11

            /*
             * ## 파티원에게 버프를 제공하는 기능 구현 시나리오 ##
             * 1. 주변에 있는 모든 인원을 서치함
             * 2. 우리 파티원이 아니라면 패스
             * 3. 우리 파티원이라면 버프를 제공
             */

            for (int i = 0; i < 10; i++)
            {
                if (i % 3 != 0)
                    continue;
                
                Console.WriteLine($"3으로 나뉘는 숫자 발견 : {i}");
            }

            // ==================== 메인 메서드 종료 ====================
        }
    }
}
