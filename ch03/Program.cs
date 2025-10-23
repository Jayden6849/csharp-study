using Microsoft.Extensions.Configuration;
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

            // appsettings.json 읽기
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Serilog 구성
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();

            // ILogger 구현체 생성
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
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
