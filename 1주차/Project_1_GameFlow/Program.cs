namespace Project_1_GameFlow
{
    internal class Program
    {
        static public void Method()
        {
            int playerHP = 100;
            string playerName = "영웅";
            Console.WriteLine(playerName);
            Console.WriteLine(playerHP);
        }

        // 인자로 내가 작성한 문자열을 특정 색상으로 바꾸는 기능
        public static void SetTextColor(string color)
        {
            // 입력된 색상 문자열을 소문자로 변환하여 비교합니다.
            switch (color.ToLower())
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    // 지원하지 않는 색상일 경우 기본 색상(흰색)으로 설정합니다.
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("지원하지 않는 색상입니다. 기본값으로 설정합니다.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            #region 프로그래밍 언어의 기본 문법 - 변수

            // 변수 : 특정 타입의 데이터를 메모리에 저장해서 다시 사용하는 데이터. 
            // 정수, 실수(부동소수점), 문자
            // 타입뒤에 변수를 구분하기 위한 이름을 지어준다.

            // 내가 정수를 사용하고 싶다. int
            // 내가 실수를 사용하고 싶다. float
            // 내가 문자열을 사용하고 싶다. string
            // 내가 문자를 사용하고 싶다. char

            // 정수의 이름 : playerHP
            // 실수의 이름 : 시간을 초단위로 표현 Time
            // 문자열의 이름 : content
            // 문자의 이름 : myChar

            // 변수의 선언 및 초기화

            // (1) AI 만들어준 데이터를 다른 데이터로 바꾸어 보세요.
            // (2) AI 질문을 할 때 변수의 이름과 타입을 지정해서 질문하세요.
            // ex) 플레이어의 체력과 공격력의 변수의 이름은 playerHP, playerATK 타입 int, float, string, char

            int num1 = 10;
            float numfloat1 = 1.1f;
            string myString = "안녕!";
            char myChar = 'A';

            int playerHP = 50;
            float Time = 30.5f;
            string title = "테트리스";
            char myChar2 = 'B';



            #endregion

            #region 프로그래밍 언어의 기본 문법 - 메소드(함수)

            // 기본 형태
            // 접근지정자 리턴타입 함수이름(타입 변수이름)
            // public void MethodName(int num)

            // C#에서의 특징
            // 1. 메소드는 클래스 안에서 정의되어야 한다.
            // 2. 메소드의 선언과 사용 방식이 다르다.
            // 2-1 선언은 구현되지 않은 내용을 직접 정의하는 것이다. 범위로 표현을 해준다.
            // 함수 선언 이후 중괄호로 내용을 표시한다.
            // 2-2 정의된 함수를 사용하기 위해서는 함수의 이름과 소괄호를 함께 호출한다.

            // 함수를 만들어줘. 접근 지정자를 public, 반환 타입을 void로 함수 이름을 ShowTitle 만들어줘. 매개 인자를 누락

            // 콘솔 환경, 언어는 C#, 특정 문자열의 색상을 다른 색상으로 변경해주는 함수를 만들어줘.
            // 접근 지정자는 public, 반환 값은 너가 정해줘, 함수의 이름 SetTextColor로, 매개 변수를 색상의 이름으로 받을 수 있도록 타입을 string 변수 이름 color로 만들어줘


            #endregion

            #region 게임 개발 영역
            // 주석 : 컴퓨터가 읽지 못하는 영역입니다.
            // 내용을 정리하거나, 코드를 읽는 다른 사람을 배려해서 작성하는 영역입니다.

            // 단축키
            // ctrl + k + c  범위 주석 활성화
            // ctrl + k + u  범위 주석 비활성화
            // shift + alt + 키보드 방향이 위,아래

            #region 타이틀
            // "C# 작성을 할 것이다. 콘솔 환경에서 타이틀을 만들어줘. 
            // 콘솔 창의 타이틀을 설정합니다.
            // 타이틀은 게임 화면에 이미지와 게임 시작 버튼으로 이루어 져있는 영역이에요.
            // 콘솔 화면을 깨끗하게 지웁니다.
            Console.Clear();

            // 타이틀 로고 (ASCII 아트)
            Console.ForegroundColor = ConsoleColor.Yellow; // 색상 변경
            Console.WriteLine(@"
    =================================================
    |                                               |
    |      ★★★★★★★★★★★★★★★★★★★★★★      |
    |      ★    MY AWESOME CONSOLE GAME    ★      |
    |      ★★★★★★★★★★★★★★★★★★★★★★      |
    |                                               |
    =================================================
        ");
            Console.ResetColor(); // 색상 초기화

            // 시작 버튼 및 옵션
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n");
            Console.WriteLine("             [ 아무 키나 눌러서 게임 시작 ]             ");
            Console.ResetColor();

            // 사용자 입력 대기
            Console.ReadKey();
            #endregion

            // 게임 시작
            // 아래 내용이 에러가 있습니다.
            //StartGame();
            #region 캐릭터

            // 2. 캐릭터
            // 캐릭터는 체력, 공격력 존재한다. UI
            // 게임 캐릭터의 체력과 공격력을 설정한 후 콘솔환경에서 UI로 화면에 떠오르게 만들어줘
            // 캐릭터 정보 설정
            float playerHealth = 100.5f;
            int playerAttack = 15;

            // 콘솔 화면 설정
            Console.Title = "게임 정보 UI";
            Console.Clear();

            // UI를 그리는 함수 호출
            DrawUI(playerHealth, playerAttack);

            // 게임 진행 시뮬레이션
            Console.SetCursorPosition(0, 5); // UI 아래에 메시지 출력
            Console.WriteLine("게임이 시작되었습니다!");
            Console.WriteLine("몬스터를 만났습니다!");
            Console.WriteLine("공격을 시작하세요.");

            Method();
            SetTextColor("red");

            // 사용자 입력 대기
            Console.ReadKey();
            #endregion
            #region 전투
            // 3. 전투 
            #endregion

            #region 보상
            // 4. 보상 
            #endregion

            #region 성장
            // 5. 성장 
            #endregion

            #region 스토리
            // 6. 스토리  
            #endregion
            #endregion
        }

        static void DrawUI(float health, int attack)
        {
            // UI 테두리 그리기
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("========================================");
            Console.WriteLine("|                                      |");
            Console.WriteLine("========================================");

            // 체력 정보 출력
            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"HP: {health}");
            Console.ResetColor();

            // 공격력 정보 출력
            Console.SetCursorPosition(20, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"ATTACK: {attack}");
            Console.ResetColor();
        }
    }
}
