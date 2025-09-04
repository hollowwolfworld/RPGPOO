using FightEngine.Skills;

namespace EntityEngine.Entities.Enemies
{
    public class Wolf : IEnnemy
    {
        private List<ISkill> skills;
        private Dictionary<Status, int> status;
        private int maxHp;
        private int hp;
        private int attack;
        private int defence;
        private int speed;
        private int levels;
        private string name;
        private int luck;

        public Wolf(int hp, int attack, int defence, int speed, int luck, int levels, string name)
        {
            this.hp = hp;
            this.attack = attack;
            this.defence = defence;
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
        int IEntity.Chance
        {
            get => luck;
            set
            {
                if (value < 0) return;
                if (value > 100)
                {
                    luck = 100;
                    return;
                }
                luck = value;
            }
        }
        int IEntity.HealthPoint { get => hp; set => hp = value; }
        string IEntity.Name { get => name; }
        Dictionary<Status, int> IEntity.Status { get => status; set => status = value; }
        int IEntity.Speed { get => speed; set => speed = value; }

        public Move ChooseMove()
        {
            throw new NotImplementedException();
        }
    }
}
