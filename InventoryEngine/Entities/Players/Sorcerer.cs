using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Sorcerer : IPlayer, IMagical
    {
        protected Sorcerer(int xp, int hp, int attack, int defence, int manaPoint, int levels, string name)
        {
            
        }

        List<Skill> IEntity.Skills { get; set; }
        int IPlayer.XP { get; set; }
        Inventory IPlayer.PlayerInventory { get; set; }
        int IEntity.Attack { get; set; }
        int IEntity.Defence { get; set; }
        int IEntity.Levels { get; set; }
        int IEntity.Chance { get ; set; }
        int IEntity.HealthPoint { get; set; }
        string IEntity.Name { get; set; }
        Status IEntity.Status { get; set; }
        int IMagical.ManaPoint { get; set; }

        public string Stats()
        {
            throw new NotImplementedException();
        }
    }
}
