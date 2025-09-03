using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Sorcerer : IPlayer, IMagical
    {
        private int levels;
        private int xp;
        private List<Skill> skills;
        private Inventory inventory;
        private Status status;
        private int hp;
        private int attack;
        private int defence;
        private int mp;
        private string name;
        private int luck;

        public Sorcerer(int levels, int xp, int hp, int attack, int defence, int luck, int mp, string name)
        {
            this.levels = levels;
            this.xp = xp;
            this.hp = hp;
            this.mp = mp;
            this.attack = attack;
            this.defence = defence;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<Skill>();
            this.inventory = new Inventory(5);
        }

        List<Skill> IEntity.Skills { get => skills; set => skills = value; }
        int IPlayer.XP { get => xp; set => xp = value; }
        Inventory IPlayer.PlayerInventory { get => inventory; }
        int IEntity.Attack { get => attack; set => attack = value; }
        int IEntity.Defence { get => defence; set => defence = value; }
        int IEntity.Levels { get => levels; set => levels = value; }
        int IEntity.Chance { get => luck; set => luck = value; }
        int IEntity.HealthPoint { get => hp; set => hp = value; }
        string IEntity.Name { get => name; }
        Status IEntity.Status { get => status; set => status = value; }
        int IMagical.ManaPoint { get => mp; set => mp = value; }

        public string Stats()
        {
            throw new NotImplementedException();
        }
    }
}
