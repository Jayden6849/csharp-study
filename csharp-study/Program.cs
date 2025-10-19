using System.Diagnostics;

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

            // 데이터의 형식 =========================================================================

            // 1. 값 형식(Value Type)
            // 정수형 : byte, sbyte, short, ushort, int, uint, long, ulong
            // 실수형 : float, double, decimal
            // 논리형 : bool
            // 문자형 : char

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

            // 변수(데이터 바구니) ===================================================================
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

        }
    }
}
