using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Class
{
    public class Player
    {
        public int Money { get; private set; }
        public Debt CurrentDebt { get; private set; }
        public List<string> MetCustomers { get; private set; }

        public Player(int initialMoney, Debt initialDebt)
        {
            Money = initialMoney;
            CurrentDebt = initialDebt;
            MetCustomers = new List<string>();
        }

        // 소지금 증가
        public void AddMoney(int amount)
        {
            Money += amount;
        }

        // 아이템 판매
        public void SellItem(Item item, Customer customer)
        {
            if (customer.CanAfford(item))
            {
                int price = customer.BuyItem(item);
                if (price > 0)
                {
                    AddMoney(price);
                    // 만난 고객 정보 추가 (중복 방지)
                    if (!MetCustomers.Contains(customer.Name))
                    {
                        MetCustomers.Add(customer.Name);
                    }
                    Console.WriteLine($"아이템 '{item.Name}'을 {customer.Name}에게 {price}원에 판매했습니다.");
                }
            }
            else
            {
                Console.WriteLine($"{customer.Name}는 아이템 '{item.Name}'을 구매할 소지금이 부족합니다.");
            }
        }

        // 빚 변제
        public void PayDebt(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                CurrentDebt.Pay(amount);
                Console.WriteLine($"빚 {amount}원을 변제했습니다. 남은 빚: {CurrentDebt.Amount}");
            }
            else
            {
                Console.WriteLine("소지금이 부족하여 빚을 변제할 수 없습니다.");
            }
        }
    }
}
