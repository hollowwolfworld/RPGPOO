using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Thieft : IPlayer
    {
        protected Thieft(int XP, int hp, int attack, int defence, int levels, string name)
        {

        }

        private List<Skill> skills;
        private Inventory inventory;
        private Status status;
        private int xp;
        private int hp;
        private int attack;
        private int defence;
        private int mp;
        private int levels;
        private string name;
        private int luck;
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

        public string Stats()
        {
            throw new NotImplementedException();
        }
    }
}
