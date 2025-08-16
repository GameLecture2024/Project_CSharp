using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Class
{
    public class Debt
    {
        public int Amount { get; private set; }
        public int DaysRemaining { get; private set; }

        public Debt(int amount, int daysToPay)
        {
            Amount = amount;
            DaysRemaining = daysToPay;
        }

        // 빚 변제
        public void Pay(int payment)
        {
            if (payment > 0)
            {
                Amount -= payment;
                if (Amount < 0)
                {
                    Amount = 0;
                }
            }
        }

        // 남은 기간 감소
        public void PassDay()
        {
            if (DaysRemaining > 0)
            {
                DaysRemaining--;
            }
        }

        // 빚 변제 기한 만료 이벤트 (과금, 패널티 등)
        public bool IsOverdue()
        {
            return Amount > 0 && DaysRemaining <= 0;
        }
    }
}
