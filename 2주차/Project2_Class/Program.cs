namespace Project2_Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 게임을 ai로 만들기 (복습)   
            // 아무 ai 사이트에 들어가서 만들고 싶은 게임을 검색하는 방법
            // C#으로 만들어라. 구체적인 정보를 전달해야 ai 원하는 결과물을 도출할 수 있다.
            // 테트리스 게임, 블록4개, .. 조건 만들어줘.

            // 게임을 만들어 달라고 질문했을 때의 단점
            // - 여러분이 게임에 추가하고 싶은 콘텐츠를 스스로 추가하기가 어렵다.
            // 남이 만들어 놓은 규칙에서 추가해야 되기 때문에 ( 작성된 코드를 이해를 하지 못한 경우)
            // 프로그래밍 언어 문법이 존재하는데, 이 문법을 이해하지 못하고 사용하면 에러가 발생한다.( 네이밍 문제 )

            // 2. 게임의 구성 요소를 ai에게 작성해달라고 요청해보기.
            // 게임을 작은 구성 요소를 나누어야 할 필요성을 느끼셨다면.. 
            // 어떻게 나눌 것인가? -> Class 객체 지향 프로그래밍 
            // class를 생성하는 것. 클래스의 관계를 설계하는 것.
            // 객체들 : 플레이어 ( player) , 목적, 방해 요소(enemy, trap, environment)

            // 플레이어가 처음에 소지금을 가지고 게임을 시작합니다. 이 플레이어는 특정 기간마다 빚을 변제해야 합니다.
            // 플레이어는 아이템을 특정한 소비자에게 판매할 수 있습니다. 소비자는 아이템의 선호도가 존재해서, 소비자만 판매할 수 잇는
            // 금액이 다릅니다. (정보)  위의 내용으로 게임을 만든다고 가정했을 때, 이 게임에 필요한 클래스를 아래에 정의를 해보세요.
            // 객체 : 플레이어 ( 소지금, 남은 빚 변제 기간, 만난 고객 정보)
            // 빚   ( 수치, 이벤트)
            // 고객 ( 등급, 소지금 )
            // 아이템 (고객마다 원하는 종류가 다양하다) 

            // 3. 게임에 등장할 요소(클래스) 어느 정도 구현하였으면, 게임에 등장시켜야 합니다.
            // 어디에 그 코드를 작성하는가? main함수에서 코드가 실행된다. 만들어 놓은 클래스를 이 함수에서 다시 호출한다.
            // 4가지 클래스를 사용해서 게임을 메인함수에 플레이가 되도록 만들어줘


            // 1. 게임 시작: 플레이어와 빚 설정
            int initialMoney = 5000;
            int initialDebtAmount = 10000;
            int debtPaymentTerm = 7; // 빚 변제 기한: 7일
            Debt initialDebt = new Debt(initialDebtAmount, debtPaymentTerm);
            Player player = new Player(initialMoney, initialDebt);

            Console.WriteLine("=== 게임 시작 ===");
            Console.WriteLine($"플레이어 소지금: {player.Money}원");
            Console.WriteLine($"총 빚: {player.CurrentDebt.Amount}원, 남은 기간: {player.CurrentDebt.DaysRemaining}일\n");

            // 2. 아이템 및 고객 생성
            Item magicWand = new Item("마법 지팡이", "마법", 1000);
            Item healingPotion = new Item("힐링 포션", "회복", 500);
            Item ironSword = new Item("철검", "무기", 800);

            Customer wizard = new Customer("마법사 루카스", 3, 4000, "마법");
            Customer knight = new Customer("기사 아서", 5, 5000, "무기");
            Customer healer = new Customer("치유사 리아", 2, 2000, "회복");

            // 3. 게임 진행 시뮬레이션
            for (int day = 1; day <= 10; day++)
            {
                Console.WriteLine($"\n--- {day}일차 ---");

                // 날짜 경과
                player.CurrentDebt.PassDay();

                // 아이템 판매
                if (day == 1)
                {
                    player.SellItem(magicWand, wizard); // 마법 지팡이 판매
                }
                else if (day == 2)
                {
                    player.SellItem(ironSword, knight); // 철검 판매
                }
                else if (day == 3)
                {
                    player.SellItem(healingPotion, healer); // 힐링 포션 판매
                }

                // 빚 변제 기한 확인 및 변제
                if (player.CurrentDebt.DaysRemaining == 0 && player.CurrentDebt.Amount > 0)
                {
                    Console.WriteLine("🚨 빚 변제 기한이 만료되었습니다. 패널티가 발생합니다.");
                    // 예시 패널티: 빚이 20% 증가
                    player.CurrentDebt.Pay(-player.CurrentDebt.Amount / 5);
                }

                // 주기적인 빚 변제
                if (day % 5 == 0) // 5일마다 빚을 갚으려고 시도
                {
                    Console.WriteLine("✅ 5일차 빚 변제 시도");
                    player.PayDebt(2000);
                }

                Console.WriteLine($"\n현재 소지금: {player.Money}원");
                Console.WriteLine($"남은 빚: {player.CurrentDebt.Amount}원, 남은 변제 기간: {player.CurrentDebt.DaysRemaining}일");
            }

            Console.WriteLine("\n=== 게임 종료 ===");
            Console.WriteLine($"최종 소지금: {player.Money}원");
            Console.WriteLine($"최종 빚: {player.CurrentDebt.Amount}원");
            Console.WriteLine($"만난 고객: {string.Join(", ", player.MetCustomers)}");
        }
    }
}
