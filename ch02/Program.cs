using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
        static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        static int AddNum(int num1, int num2, int num3 = 0)
        {
            return num1 + num2 + num3;
        }

        static float AddNum(float num1, float num2, float num3 = 0.0f, float num4 = 0.0f, float num5 = 0.0f)
        {
            return num1 + num2 + num3 + num4 + num5;
        }

        static void AddOne(ref int number)
        {
            number++;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void DivideNum(int num1, int num2, out int result1, out int result2)
        {
            result1 = num1 / num2;
            result2 = num1 % num2;
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

            // =============== 메서드 ===============
            // 기본적으로 Java와 유사하지만 몇 가지 차이점 존재
            // C#에서는 메서드가 클래스 내부에 정의되어야 함
            // 메서드 오버로딩 지원
            // 접근 제한자: public, protect, private, internal, protected internal, private protected
            //   - 차이: default 없으며 접근 제한자를 명시하지 않으면 기본적으로 private
            // static 키워드: 정적 메서드 (인스턴스 생성 없이 호출 가능) == 메모리 공간을 공유하는 클래스 메서드
            // 반환형: void (반환값 없음), int, string 등 다양한 자료형 가능
            // 메서드 이름: 대문자로 시작하는 파스칼 케이스 권장
            //   - 차이: 파스칼케이스 == 클래스, 메서드, 속성, 이벤트, 네임스페이스, enum멤버 등
            //   - 차이: 카멜케이스 == 지역변수, 매개변수, 멤버변수(필드) 등
            //   - 차이: 어퍼케이스 == 상수
            //   - 차이: 스네이크케이스 == C# 내부에서는 사용하지 않음 (파일명, URL, DB 필드명 등 외부 API에만 사용)
            //   - 차이: 케밥케이스 == C# 내부에서는 사용하지 않음 (파일명, URL, CSS 클래스명, JSON 등 외부 API에만 사용)
            // 매개변수: 자료형과 변수명으로 구성, 여러 개일 경우 쉼표로 구분
            // 메서드 본문: 중괄호로 감싸여 있으며, 메서드가 수행할 작업을 정의
            // 반환문: return 키워드로 반환값 지정 (void 메서드의 경우 생략 가능)

            Program.HelloWorld(); // 메인 메서드 밖에 정의된 static 메서드를 호출

            int numA = 10;
            int numB = 22;
            int result = Program.AddNum(numA, numB);
            Console.WriteLine(result);

            // 복사에 의한 전달 (Call by Value)
            // 참조에 의한 전달 (Call by Reference) - ref, out 키워드 사용

            // 포인터를 쓰지 않고도 ref 키워드를 통해 참조에 의한 전달 가능
            // * 중요: ref 키워드는 메서드 정의와 호출 시 모두 명시해야 함
            int numC = 0;
            Program.AddOne(ref numC);
            Console.WriteLine(numC);

            // ref 키워드가 있어서 변수의 실제 메모리 주소를 전달할 수 있음 (call by reference)
            // 즉, 메서드가 밖에 있는 변수의 값을 직접 변경 가능하다는 장점이 존재 (Java의 경우 절대 불가능)
            // 원래 포인터로 해야 할 일을 ref 키워드로 간단히 처리 가능
            int num1 = 10;
            int num2 = 20;

            Program.Swap(ref num1, ref num2);
            Console.WriteLine($"num1: {num1}, num2: {num2}");

            // out 키워드: ref 키워드와 유사하지만 메서드 내부에서 반드시 값을 할당해야 함
            // 이것도 역시 call by reference 방식으로 동작
            // 주로 메서드에서 여러 개의 값을 반환하고자 할 때 사용 (Java에서는 배열, 클래스, 컬렉션 등으로만 여러 개 빼올 수 있음)
            // 정리: ref는 메서드 호출 전에 초기화가 필요하지만, out은 초기화가 필요 없음
            int numX = 10;
            int numY = 3;

            // 숫자 2개를 나누고 몫과 나머지를 각각 result1, result2에 담아 각각 반환 (이게 가능하다고? C#)
            Program.DivideNum(numX, numY, out int result1, out int result2);
            Console.WriteLine(result1);
            Console.WriteLine(result2);

            // ==================== 메서드 오버로딩 ====================
            // 메서드 오버로딩: 동일한 이름의 메서드를 여러 개 정의하는 것 == 이름의 재사용
            // 조건: 메서드 이름이 동일하며, 매개변수의 자료형, 개수, 순서 중 적어도 하나는 달라야 함
            // cf. C#에서는 연산자 오버로딩도 지원 (Java에서는 불가능)

            // Default Parameter: C#에서는 기본 매개변수 값을 지정할 수 있음 (C++에서는 가능 / Java에서는 불가능)
            // 매개변수가 많아졌을 때 메서드를 정의하기도 쉽고 호출하기도 쉬워짐 (가독성 UP)
            // 또한 C++ 보다 발전된 기능 제공 (매개변수를 지정해서 호출 가능: named argument)

            int intSum = Program.AddNum(10, 20); // 기본 매개변수 값 (num3 = 0) 사용
            int intSumWithDefault = Program.AddNum(10, 20, 5); 
            float floatSum = Program.AddNum(10.5f, 20.3f, num5: 2.0f);
            Console.WriteLine($"intSum: {intSum}, intSumWithDefault: {intSumWithDefault}, floatSum: {floatSum}");

            // ==================== 응용 ====================
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            int ret = Factorial(5);
            Console.WriteLine($"5! = {ret}");

            // 팩토리얼은 반복문, 재귀문 두 가지 방식으로 구현 가능
            static int Factorial(int n)
            {
                if (n <= 1)
                    return 1;
                else
                    return n * Factorial(n - 1);
            }

            // ==================== 메인 메서드 종료 ====================
        }
    }
}
