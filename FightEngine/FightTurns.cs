using EntityEngine;
using EntityEngine.Entities;
using EntityEngine.Inventories.Items;
using FightEngine.Skills;
using System.ComponentModel.Design;

namespace FightEngine
{
    public class FightTurns
    {
        Arena Arena { get; set; }
        int CptTours { get; set; }

        

        public FightTurns(IEntity fighter1, IEntity fighter2)
        {
            Arena = new Arena(fighter1, fighter2);
            CptTours = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="">Le move choisit par fighter1</param>
        /// <param name="">Le move choisit par fighter2</param>
        /// <return>-1 si le fighter1 à perdu, 1 si figther 2 à perdu, 0 si le combat n'est pas fini</return>
        public int Turn(MoveAction moveF1, MoveAction moveF2)
        {
            // si P1 est plus rapide que P2 alors il commncera a attaquer en premier
            // utilisation d'une option de combat
            if (Arena.FirstFighter.Speed >= Arena.SecondFighter.Speed)
            {
                if(!Arena.FirstFighter.Status.ContainsKey(Status.PARALYSED))
                {
                    var nameLaterWithBetterName = MakeMove(Arena.FirstFighter, moveF1);

                    if (nameLaterWithBetterName < 0) return -1;
                }
                if(!Arena.SecondFighter.Status.ContainsKey(Status.PARALYSED) && Arena.SecondFighter.HealthPoint > 0)
                {
                    var nameLaterWithBetterName = MakeMove(Arena.SecondFighter, moveF2);

                    if (nameLaterWithBetterName < 0) { return 1; }
                }
            }
            // si P2 est plus rapide que P1 alors il commncera a attaquer en premier
            else
            {
                if (!Arena.FirstFighter.Status.ContainsKey(Status.PARALYSED))
                {
                    var nameLaterWithBetterName = MakeMove(Arena.FirstFighter, moveF1);

                    if (nameLaterWithBetterName < 0) return -1;
                }
                if (!Arena.SecondFighter.Status.ContainsKey(Status.PARALYSED) && Arena.FirstFighter.HealthPoint > 0)
                {
                    var nameLaterWithBetterName = MakeMove(Arena.SecondFighter, moveF2);

                    if (nameLaterWithBetterName < 0) { return 1; }
                }
                //utilisation d'une option de combat
            }

            //Appliquez les status
            foreach (var status in Arena.FirstFighter.Status)
            {
                switch(status.Key)
                {
                    case Status.BURN:
                        break;
                    case Status.POISONED:
                        break;
                }
            }

            foreach (var status in Arena.FirstFighter.Status)
            {
                switch (status.Key)
                {
                    case Status.RAGE:
                        Arena.FirstFighter.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(Arena.FirstFighter, status.Key);
                        } 
                        break;
                    case Status.BURN:
                        Arena.FirstFighter.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(Arena.FirstFighter, status.Key);
                        }
                        break;
                    case Status.POISONED:
                        Arena.FirstFighter.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(Arena.FirstFighter, status.Key);
                        }
                        break;
                }
            }

            foreach (var status in Arena.SecondFighter.Status)
            {
                switch (status.Key)
                {
                    case Status.RAGE:
                        Arena.SecondFighter.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(Arena.SecondFighter, status.Key);
                        }
                        break;
                    case Status.BURN:
                        Arena.SecondFighter.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(Arena.SecondFighter, status.Key);
                        }
                        break;
                    case Status.POISONED:
                        Arena.SecondFighter.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(Arena.SecondFighter, status.Key);
                        }
                        break;
                }
            }

            //retours d'une valeur celon le resultat du combat
            if (Arena.FirstFighter.HealthPoint <= 0)
            {
                return -1;
            }
            if (Arena.SecondFighter.HealthPoint <= 0)
            {
                return 1;
            }

            CptTours++;

            return 0;
        }

        private int MakeMove(IEntity user, MoveAction move)
        {
            switch (move.Move)
            {
                case ISkill skill:
                    Arena.UseSkill(user, move.Target, skill!);
                    break;
                case UsableItem item:
                    Arena.UseItems(user, move.Target, item);
                    break;
                case SimpleMove:
                    Arena.Hit(user, move.Target);
                    break;
                case Flee flee:
                    if (user.Speed > flee.Opponent.Speed)
                    {
                        return -1;
                    }

                    Random rand = new Random();
                    int luckFlee = rand.Next(1, 101);

                    if (luckFlee <= Arena.FirstFighter.Chance)
                    {
                        return -1;
                    }
                    break;
            }

            return 0;
        }

        private void RemovedStatus(IEntity entity, Status status)
        {
            entity.Status.Remove(status);
        }
    }

}
