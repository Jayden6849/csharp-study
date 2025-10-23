using Microsoft.Extensions.Logging;
using Serilog;

namespace ch03
{
    class Program
    {
        private static ILogger<Program> _logger = null!;

        static void Print(int value)
        {
            Console.WriteLine(value);
            _logger.LogDebug("Print 호출: {Value}", value);
        }
        static int Add(int a, int b)
        {
            int ret = a + b;
            _logger.LogDebug("Add 호출: a={A}, b={B}, ret={Ret}", a, b, ret);
            Print(ret);
            return ret;
        }


        static void Main(string[] args)
        {
            // 디버깅 및 다음 브레이크 포인트로 이동 : F5
            // 브레이크 포인트 설정 : F9
            // 브레이크 포인트 중지 : Ctrl + F9
            // 조건부 브레이크 포인트 설정할 수 있음
            // 브레이크 포인트를 드래그하여 위치를 변경할 수 있음

            // Step Over : F10 (메소드 속으로 파고 들어가진 않음) == 내가 작성하지 않은 코드를 실행할 때 유용
            // Step Into : F11 (메소드 속으로 파고 들어감) == 내가 작성한 코드를 직접 디버깅할 때 유용
            // Step out : Shift + F11 (메소드 속에서 빠져나옴)

            // cf. 코드 탐색 단축키
            // Go to Definition : F12

            // Serilog 구성
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() // 최소 로그 레벨 설정
                .WriteTo.Console() // 기존 콘솔 출력
                .WriteTo.File("logs/myapp.log", // 로그 파일 경로
                    rollingInterval: RollingInterval.Day, // 하루 단위로 파일 분리
                    retainedFileCountLimit: 7, // 보관할 파일 개수
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}") // 로그 형식
                .CreateLogger();

            // ILogger 구현체 생성
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(); // Serilog 등록
            });
            _logger = loggerFactory.CreateLogger<Program>();

            _logger.LogInformation("프로그램 시작");

            int ret = Program.Add(10, 20);
            ret++;
            _logger.LogDebug("Main에서 ret 증가 후 값: {Ret}", ret);
            Console.WriteLine(ret);

            _logger.LogInformation("프로그램 종료");
        }
    }
}
