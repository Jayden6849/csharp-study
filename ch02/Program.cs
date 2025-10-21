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

            choice = 34;

            try
            {
                switch(choice)
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

        }
    }
}
