using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace csharp_study
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello ");
            Console.WriteLine("World!");

            string creator = "Jayden";
            Console.WriteLine($"Made By {creator}");


            // 실행 단축키 : F5 (디버그 모드), Ctrl + F5 (디버그 모드 아님)

            // 실행파일 위치
            // repository : bin - Debug - .exe 파일 존재

            // =========================================================================================

            // 기본 개념 : 데이터(RAM) + 로직(CPU)

            // 단일 행 주석

            /*
             * 여러 줄 주석
             */

            /**
             * 문서화 주석
             */

            // =================== 데이터의 형식 ===================

            // 1. 값 형식(Value Type)
            // 정수형 : byte(1), sbyte(1), short(2), ushort(2), int(4), uint(4), long(8), ulong(8) (u == unsigned :: 부호가 없는, s == signed :: 부호가 있는)
            // 실수형 : float(4), double(8), decimal
            // 논리형 : bool(1)
            // 문자형 : char(2)

            // 2. 참조 형식(Reference Type)
            // 문자열형(string) : "Hello"
            // 배열형(array) : int[]{1,2,3}
            // 클래스형(class) : class Person{}
            // 인터페이스형(interface) : interface Animal{}
            // 델리게이트형(delegate) : delegate void MyDelegate();
            // 열거형(enum) : enum Days{Sunday, Monday, TuesDay, Wednesday, Thursday, Friday, Saturday}
            // 구조체형(struct) : struct MyPoint{ public int x; public int y; }

            // 3. 포인터 형식(Pointer Type) - unsafe 코드에서 사용
            // 포인터형(pointer) : int* p = &x;

            // 4. Nullable 형식(Nullable Type)
            // Nullable<T> : int? a = null; Nullable<int> b = 5;

            // 5. 튜플 형식(Tuple Type)
            // 튜플형(tuple) : (int, string) myTuple = (1, "Hello");

            // =================== 변수(데이터 바구니) ===================
            int number = 10; // 정수형 변수 선언 및 초기화
            string message = "C# Study"; // 문자열형 변수 선언 및 초기화
            bool isActive = true; // 논리형 변수 선언 및 초기화

            Console.WriteLine(number);
            Console.WriteLine(message);
            Console.WriteLine(isActive);

            int hp = 100;
            int MAX_HP = 100;
            Console.WriteLine($"현재 체력 : {hp} / 최대 체력 : {MAX_HP}");

            string demon = "악마";
            int damageOfDemon = 2;
            Console.WriteLine($"{demon}에 의해 {damageOfDemon}의 데미지를 입었습니다.");

            hp -= damageOfDemon;
            Console.WriteLine($"현재 체력 : {hp} / 최대 체력 : {MAX_HP}");

            // =================== 2진법, 8진법, 10진법, 16진법 ===================
            // ob00, 0b01, 0b10, 0b11 (2진법)
            // 0o0, 0o1, 0o2, 0o3 (8진법)
            // 0, 1, 2, 3 (10진법)
            // 0x0, 0x1, 0x2, 0x3 (16진법) : 2진법을 4자리씩 끊어서 16진법으로 표현할 수 있음

            // 2의 보수법을 채택하고 있기 때문에 signed 형식의 가장 첫번째 비트는 부호 비트로 사용됨
            // ex. 10000000 (2진법) => -128 (10진법)

            float moveSpeed = 3.5f; // float : 소수점 이하 7자리까지 표현하기 때문에 근사값임을 항상 기억하고 있어야 함
            double preciseMoveSpeed = 3.521592653589793; // double : 소수점 이하 15자리까지 표현 가능

            Console.WriteLine($"이동 속도 : {moveSpeed}");
            Console.WriteLine($"정확한 이동 속도 : {preciseMoveSpeed}");

            // =================== char / string 형식 ===================
            // 문자 : C++ 에서는 1바이트, C#, Java에서는 2바이트 (유니코드 사용)
            // 문자열 : C++ 에서는 char 배열, Java에서는 String 형식, C#에서는 string 형식 (소문자임에 유의)

            // ASCII 코드 : 0 ~ 127 (7비트) : 65 ~ 90 (대문자 A ~ Z), 97 ~ 122 (소문자 a ~ z), 32 (공백), 48 ~ 57 (숫자 0 ~ 9)
            // 대문자 + 32 = 소문자 : char 는 사실 숫자 형식이기 때문에 산술 연산 가능함이 중요

            // 이스케이프 시퀀스 : \n (개행), \t (탭), \\ (역슬래시), \' (작은 따옴표), \" (큰 따옴표), \0 (널 문자)

            // =================== bool 형식 ===================
            bool autoPlay = false;
            Console.WriteLine($"상태 : {(autoPlay ? "자동사냥on" : "자동사냥off")}");

            // bool 타입이 메모리에서 차지하는 크기는 1바이트이지만, 실제로는 1비트만 사용됨
            // Boolean 이 아님에 유의

            // 데이터 형식 간 변환
            // ex. int to float, float to int, string to int, int to string 등 여러가지 변환 방법이 존재
            // 안전 : 더 작은 타입을 큰 타입으로 변환할 때는 암시적 형변환이 가능
            // 위험 : 더 큰 타입을 작은 타입으로 변환할 때는 명시적 형변환(casting)이 필요 (왜? 데이터 손실이 발생할 수 있기 때문)
            int damage = 10;
            float damageFloat = damage; // 암시적 형변환 == 업캐스팅

            float health = 100f;
            int healthInt = (int)health; // 명시적 형변환 == 다운캐스팅

            // string은 기본타입이 아닌 참조타입이기 때문에 형변환이 자유롭지는 않음
            //Console.WriteLine("메뉴를 선택해주세요.");

            //Console.Write("선택 : ");

            //string inputStr;
            //inputStr = Console.ReadLine() ?? ""; // null 병합 연산자 (??) : null 일 경우에 "" 빈 문자열 반환
            //inputStr = inputStr.Trim();

            //if (int.TryParse(inputStr, out int selectedNumber)) // 예외가 뜨면 false 반환, 성공하면 selectedNumber 에 값 할당
            //{
            //    Console.WriteLine($"{selectedNumber}를 선택하였습니다.");
            //}
            //else
            //{
            //    Console.WriteLine("⚠️ 숫자를 입력해주세요!");
            //}

            int level = 5;
            string strLevel = level.ToString(); // int to string

            // 숫자 -> 문자열 : int.Parse(), float.Parse(), double.Parse(), bool.Parse() 등 존재
            // 문자열 -> 숫자 : int.ToString(), float.ToString(), double.ToString(), bool.ToString() 등 존재

            strLevel = (level) + ""; // Java와 완전하게 형변환을 다룰 수 있음(메서드 활용 방식만 다를 뿐)
            Console.WriteLine($"현재 레벨 : {strLevel}");

            // =================== 스트링 인터폴레이션 vs 스트링 포맷팅 ===================

            hp = 72;
            MAX_HP = 100;

            // 두 가지 방법은 완전히 동일하게 동작함
            String hpNotice = $"당신의 현재 체력은 {hp}/{MAX_HP}입니다."; // 스트링 인터폴레이션
            Console.WriteLine(hpNotice);

            hpNotice = string.Format("당신의 현재 체력은 {0}/{1}입니다.", hp, MAX_HP); // 스트링 포맷팅
            Console.WriteLine(hpNotice);

            // =================== 산술 연산 ===================
            // + - * / %
            // += -= *= /= %=
            // ++ --

            // 연산자 우선 순위는 Java와 동일

            // Math.Pow(a, b) : a의 b제곱
            // Math.Sqrt(a) : a의 제곱근

            // % 는 음수 연산에서만 살짝 주의해주면 됨
            // 0으로 나누었을 때 예외 발생 (DivideByZeroException, ArithmeticException)

            // 체력 회복 아이템 사용 예시
            int smallHealthPotion = 20;
            String samllHealthPotionName = "작은 체력 포션";

            Console.Write($"({samllHealthPotionName}) 사용 : ");
            hp = (hp + smallHealthPotion) > MAX_HP ? MAX_HP : (hp + smallHealthPotion); // 삼항 연산자

            hpNotice = $"당신의 현재 체력은 {hp}/{MAX_HP}입니다.";
            Console.WriteLine(hpNotice);

            // =================== 비교 연산, 논리 연산 ===================
            // > >= < <= == !=
            // && || !

            level = 5;
            bool canEnterDemonZone = (level >= 5); // 레벨이 5 이상이어야 입장 가능
            Console.WriteLine($"악마의 영역 입장 가능 여부 : {(canEnterDemonZone ? "가능" : "불가능")}");

            bool isAlive = hp > 0;
            Console.WriteLine($"생존 여부 : {(isAlive ? "생존" : "비생존")}");

            bool gender = true;
            Console.WriteLine($"당신의 성별은 {(gender ? "남성" : "여성")}입니다.");

            int intelligence = 80;
            Console.WriteLine($"당신의 지력은 {intelligence}입니다.");
            bool isSmart = (intelligence >= 70);

            bool isEligibleForMaleModel = isSmart && gender;
            Console.WriteLine($"남성 모델 지원 가능 여부 : {(isEligibleForMaleModel ? "가능" : "불가능")}");

            // =================== 비트 연산 ===================
            // &  : AND
            // |  : OR
            // ^  : XOR
            // ~  : NOT
            // << : Left shift
            // >> : Right shift
            //
            // Java와 거의 동일하게 동작
            // 주로 플래그(Flags) 설정이나 비트 마스크 처리에 사용됨

            // =================== 변수 var ===================
            // 자동 추론 변수
            var autoInt = 10;
            var autoString = "자동 추론 변수";

            Console.WriteLine(autoInt);
            Console.WriteLine(autoString);

            // 반드시 선언과 동시에 초기화가 이루어져야 함 -> 컴파일러가 타입을 추론할 수 있도록
            // 지역 변수로만 사용 가능 (멤버 변수로는 사용 불가)
            // 동적 타이핑(dynamic typing)이 아님에 유의 - 컴파일 타임에 타입이 결정됨
            // JavaScript의 let 키워드와 유사한 역할을 한다고 생각하면 됨

            // 그런데 var를 굳이 사용할 필요가 없음. 가독성 차원에서 굉장히 불리함

        }
    }
}
