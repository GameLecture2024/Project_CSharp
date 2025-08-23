using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3th_상속
{
    class NPC
    {
        public string Name { get; private set; }
        public ItemType PreferredType { get; private set; }

        public NPC(string name, ItemType preferredType)
        {
            Name = name;
            PreferredType = preferredType;
        }

        // 아이템 판매 가격 계산
        public int GetSellingPrice(Item item)
        {
            int price = item.ItemPrice;
            if (item.Type == PreferredType)
            {
                // 선호하는 아이템은 2배 가격으로 구매
                price = item.ItemPrice * 2;
                Console.WriteLine($"🎉 {Name}은(는) {item.ItemName}을(를) 선호합니다! 특별 가격으로 구매합니다.");
            }
            else
            {
                // 선호하지 않는 아이템은 절반 가격으로 구매
                price = item.ItemPrice / 2;
                Console.WriteLine($"😔 {Name}은(는) {item.ItemName}을(를) 선호하지 않습니다. 낮은 가격으로 구매합니다.");
            }
            return price;
        }
    }
}
