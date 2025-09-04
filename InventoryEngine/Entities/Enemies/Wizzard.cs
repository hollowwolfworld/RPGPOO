using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Enemies
{
    public class Wizzard : IEnnemy, IMagical
    {
        private List<ISkill> skills;
        private Dictionary<Status, int> status;
        private int maxHp;
        private int hp;
        private int maxMp;
        private int mp;
        private int attack;
        private int defence;
        private int speed;
        private int levels;
        private string name;
        private int luck;
        
        public Wizzard(int maxHp, int hp, int maxMp, int attack, int defence, int speed, int luck, int mp, int levels, string name)
        {
            this.maxHp = maxHp;
            this.hp = hp;
            this.maxMp = maxMp;
            this.mp = mp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.levels = levels;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<ISkill>();
            this.status = new Dictionary<Status, int>();
        }

        public int MaxHealthPoint { get => maxHp; set => maxHp = value; }
        List<ISkill> IEntity.Skills { get => skills; set => skills = value; }
        int IEntity.Attack { get => attack; set => attack = value; }
        int IEntity.Defence { get => defence; set => defence = value; }
        int IEntity.Levels { get => levels; set => levels = value; }
        int IEntity.Chance { get => luck; set => luck = value; }
        int IEntity.HealthPoint { get => hp; set => hp = value; }
        string IEntity.Name { get => name; }
        Dictionary<Status, int> IEntity.Status { get => status; set => status = value; }
        int IMagical.ManaPoint { get => mp; set => mp = value; }
        int IEntity.Speed { get => speed; set => speed = value; }
        int IMagical.MaxManaPoint { get => maxMp; set => maxMp = value; }
        
        public Move ChooseMove()
        {
            throw new NotImplementedException();
        }
    }
}
