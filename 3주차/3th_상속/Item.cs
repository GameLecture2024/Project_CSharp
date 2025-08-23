using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3th_상속
{
    enum ItemType
    {
        POTION, WEAPON, ARMOR, RESOURCE, COSUMABLE
    }

    class Item
    {
        public string ItemName;
        public int ItemPrice;
        public ItemType Type;

        public Item(string itemName, int itemPrice, ItemType type)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            Type = type;
        }

        public virtual void Use()
        {
            Console.WriteLine($" {ItemName} - 가격 : {ItemPrice} - 아이템 분류 : {Type} ");
        }
    }

    // 포션 클래스는 Item의 기능을 상속받겠다. (상속 , inheritance)
    class Potion : Item
    {
        public Potion(string itemName, int itemPrice, ItemType type) : base(itemName, itemPrice, type)
        {
        }

        public override void Use() // 재정의하다. 
        {
            // 부모에 있는 Use함수의 원본을 실행한다.
            base.Use();
            Console.WriteLine("포션을 사용했습니다.");
        }
    }

    class Weapon : Item
    {
        public Weapon(string itemName, int itemPrice, ItemType type) : base(itemName, itemPrice, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("무기를 사용했습니다.");
        }
    }

    class Armor : Item
    {
        public Armor(string itemName, int itemPrice, ItemType type) : base(itemName, itemPrice, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("방어구를 사용했습니다.");
        }
    }

    class RESOURCE : Item
    {
        public RESOURCE(string itemName, int itemPrice, ItemType type) : base(itemName, itemPrice, type)
        {
        }

        public override void Use()
        {
            base.Use();
            Console.WriteLine("자원을 사용했습니다.");
        }
    }


    // 14:30분에 생성한 클래스를 Main함수에서 실행하는 방법 진행하겠습니다.
}
