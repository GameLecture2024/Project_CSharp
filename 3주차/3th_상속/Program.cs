namespace _3th_상속
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 게임에 등장할 클래스를 만들어 봅니다. 

            // 아이템 클래스 여러분들이 생성해보세요.
            // AI를 사용하여서, 아이템 이름, 가격, 아이템의 타입을 분류를 해보세요.
            // 어떤 분류인가? (포션, 장착 가능한 것, 연금 재료 ....... )
            // 열거형 enum 사용하여서 Item 클래스를 생성하면 됩니다.
            // 14:15분 까지 Item 클래스를 위의 내용으로 생성해보세요.

            // 이 클래스를 재사용하는 방법을 배워봅니다.

            // Potion bluePotion = new Potion("블루포션", 100, ItemType.POTION);
            // Potion YellowPotion = new Potion("노란포션", 100, ItemType.POTION);
            // Weapon sword = new Weapon("칼", 500, ItemType.WEAPON);
            // Armor plateArmor = new Armor("판금 갑옷", 1500, ItemType.ARMOR);
            // RESOURCE iron = new RESOURCE("철", 50, ItemType.RESOURCE);
            //
            // List<Item> inventory = new List<Item>();
            // inventory.Add(bluePotion);
            // inventory.Add(YellowPotion);
            // inventory.Add(sword);
            // inventory.Add(plateArmor);
            // inventory.Add(iron);
            //
            // // 위의 Item 여러분들이 직접 생성한 아이템 데이터입니다. 게임 (콘솔)에서 사용할 수 있는 클래스를 만들어 봅니다.
            //
            // // ItemManager, Player  UseItem
            //
            // // 클래스의 다형성
            // Player player = new Player();
            //
            // foreach(var item in inventory)
            // {
            //     player.UseItem(item);
            // }
            //
            // //player.UseItem(plateArmor);
            // //player.UseItem(bluePotion);
            // //player.UseItem(sword);
            // //player.UseItem(iron);

            // 플레이어 생성 (초기 골드 100)
            Player player = new Player(100);

            // 상인 NPC 생성
            NPC weaponTrader = new NPC("무기 상인", ItemType.WEAPON);
            NPC potionTrader = new NPC("포션 상인", ItemType.POTION);

            // 아이템 생성 (플레이어가 구매할 아이템)
            Item cheapSword = new Weapon("낡은 검", 50, ItemType.WEAPON);
            Item cheapPotion = new Potion("작은 포션", 30, ItemType.POTION);

            Console.WriteLine("=== 게임 시작: 싸게 구매해서 비싸게 팔기! ===");

            // --- 1. 플레이어 아이템 구매 ---
            Console.WriteLine("\n--- 아이템 구매 ---");
            player.BuyItem(cheapSword, cheapSword.ItemPrice);
            player.BuyItem(cheapPotion, cheapPotion.ItemPrice);
            player.DisplayInventory();

            // --- 2. 플레이어 아이템 판매 ---
            Console.WriteLine("\n--- 아이템 판매 ---");

            // 낡은 검을 무기 상인에게 판매
            Console.WriteLine($"\n>> {weaponTrader.Name}에게 {cheapSword.ItemName}을(를) 판매합니다.");
            int swordSellingPrice = weaponTrader.GetSellingPrice(cheapSword);
            player.SellItem(cheapSword, swordSellingPrice);
            player.DisplayInventory();

            // 작은 포션을 포션 상인에게 판매
            Console.WriteLine($"\n>> {potionTrader.Name}에게 {cheapPotion.ItemName}을(를) 판매합니다.");
            int potionSellingPrice = potionTrader.GetSellingPrice(cheapPotion);
            player.SellItem(cheapPotion, potionSellingPrice);
            player.DisplayInventory();

            // --- 3. 가격 차이를 확인하기 위한 교차 판매 ---
            Console.WriteLine("\n--- 교차 판매 테스트 ---");
            player.BuyItem(cheapSword, cheapSword.ItemPrice); // 다시 구매
            player.DisplayInventory();

            // 낡은 검을 포션 상인에게 판매
            Console.WriteLine($"\n>> {potionTrader.Name}에게 {cheapSword.ItemName}을(를) 판매합니다.");
            int crossSellingPrice = potionTrader.GetSellingPrice(cheapSword);
            player.SellItem(cheapSword, crossSellingPrice);
            player.DisplayInventory();

            Console.WriteLine("\n=== 게임 종료 ===");
        }

        class Player
        {
            public List<Item> Inventory { get; private set; }
            public int Gold { get; private set; }

            public Player(int initialGold)
            {
                Gold = initialGold;
                Inventory = new List<Item>();
            }

            // 아이템 구매
            public bool BuyItem(Item item, int price)
            {
                if (Gold >= price)
                {
                    Gold -= price;
                    Inventory.Add(item);
                    Console.WriteLine($"{item.ItemName}을(를) {price} 골드에 구매했습니다.");
                    return true;
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                    return false;
                }
            }

            // 아이템 판매
            public void SellItem(Item item, int price)
            {
                if (Inventory.Contains(item))
                {
                    Inventory.Remove(item);
                    Gold += price;
                    Console.WriteLine($"{item.ItemName}을(를) {price} 골드에 판매했습니다.");
                }
                else
                {
                    Console.WriteLine("인벤토리에 해당 아이템이 없습니다.");
                }
            }

            // 인벤토리 확인
            public void DisplayInventory()
            {
                Console.WriteLine("\n--- 현재 인벤토리 ---");
                if (Inventory.Count == 0)
                {
                    Console.WriteLine("비어있습니다.");
                }
                else
                {
                    foreach (var item in Inventory)
                    {
                        Console.WriteLine($"- {item.ItemName} (타입: {item.Type}, 가격: {item.ItemPrice})");
                    }
                }
                Console.WriteLine($"현재 골드: {Gold}");
            }

            public void UseItem(Item item)
            {
                //Console.WriteLine($" {item.ItemName} - 가격 : {item.ItemPrice} - 아이템 분류 : {item.Type} ");
                //Console.WriteLine("이 아이템을 사용했습니다.");

                item.Use();
            }
        }
    }
}
