using FightEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightEngine;
using FightEngine.Entities;
using FightEngine.Entities.Enemies;
using FightEngine.Entities.Players;

namespace FightEngine
{
    public class LetFight
    {
        public void InflictDamage(Entity from, Entity to)
        {
            double damage = .0;
            int _base = from.Attack - to.Defence/2;
            var rand = new Random();
            double variance = _base * rand.Next(9,12)/10.0;
            int luck = 10 + from.Chance;
            int luckCrit = rand.Next(0,101);
            if (luckCrit <= luck)
            {
                damage = variance * 1.5;
            }
            else
            {
                damage = variance;
            }

            damage = Math.Max(1, Math.Floor(damage));

            int result = Convert.ToInt32(damage);

            to.HealthPoint -= result;
            
        }
    }
}
