using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Class
{
    public class Customer
    {
        public string Name { get; private set; }
        public int Grade { get; private set; } // 등급 (예: 1~5)
        public int Money { get; private set; }
        public string PreferredItemType { get; private set; }

        public Customer(string name, int grade, int money, string preferredItemType)
        {
            Name = name;
            Grade = grade;
            Money = money;
            PreferredItemType = preferredItemType;
        }

        // 아이템 구매 의사 결정
        public bool CanAfford(Item item)
        {
            // 선호하는 아이템 종류에 따라 더 높은 가격으로 구매할 수 있음
            int price = item.BasePrice;
            if (item.Type == PreferredItemType)
            {
                price = item.BasePrice * (1 + Grade / 2); // 등급이 높을수록 선호 아이템에 더 많은 금액을 지불
            }
            return Money >= price;
        }

        // 아이템 구매
        public int BuyItem(Item item)
        {
            int price = item.BasePrice;
            if (item.Type == PreferredItemType)
            {
                price = item.BasePrice * (1 + Grade / 2);
            }
            if (Money >= price)
            {
                Money -= price;
                return price;
            }
            return 0; // 구매 실패
        }
    }
}
