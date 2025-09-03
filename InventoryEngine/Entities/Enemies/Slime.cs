using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Enemies
{
    public class Slime : IEnnemy, IMagical
    {
        private List<ISkill> skills;
        private Status status;
        private int hp;
        private int mp;
        private int attack;
        private int defence;
        private int levels;
        private string name;
        private int luck;

        public Slime(int hp, int mp, int attack, int defence, int luck, int levels, string name)
        {
            this.hp = hp;
            this.attack = attack;
            this.defence = defence;
            this.levels = levels;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<ISkill>();
        }

        List<ISkill> IEntity.Skills { get => skills; set => skills = value; }
        int IEntity.Attack { get => attack; set => attack = value; }
        int IEntity.Defence { get => defence; set => defence = value; }
        int IEntity.Levels { get => levels; set => levels = value; }
        int IEntity.Chance { get => luck; set => luck = value; }
        int IEntity.HealthPoint { get => hp; set => hp = value; }
        int IMagical.ManaPoint { get => mp; set => mp = value; }
        string IEntity.Name { get => name; }
        Status IEntity.Status { get => status; set => status = value; }
    }
}
