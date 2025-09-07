using EntityEngine;
using EntityEngine.Entities;
using EntityEngine.Inventories.Items;
using FightEngine;
using FightEngine.Skills;
using System.ComponentModel.Design;

namespace FightEngine
{
    public class FightTurns
    {
        /// <summary>
        /// L'Arène où se passe le combat
        /// </summary>
        Arena Arena { get; set; }
        /// <summary>
        /// Nombre de trours
        /// </summary>
        int CptTours { get; set; }

        
        /// <summary>
        /// Création d'une arène
        /// </summary>
        /// <param name="fighter1">Le combatant 1</param>
        /// <param name="fighter2">Le combatant 2</param>
        public FightTurns(IEntity fighter1, IEntity fighter2)
        {
            Arena = new Arena(fighter1, fighter2);
            CptTours = 0;
        }

        /// <summary>
        /// Execute un tour du combat
        /// </summary>
        /// <param name="">Le move choisit par fighter1</param>
        /// <param name="">Le move choisit par fighter2</param>
        /// <return>-1 si le fighter1 à perdu, 1 si figther 2 à perdu, 0 si le combat n'est pas fini</return>
        public int Turn(MoveAction moveF1, MoveAction moveF2)
        {
            if (Arena.FirstFighter.Speed >= Arena.SecondFighter.Speed)
            {
                var moveResult = MakeMove(Arena.FirstFighter, moveF1);

                if (moveResult < 0) return -1;

                moveResult = MakeMove(Arena.SecondFighter, moveF2);

                if (moveResult < 0) return 1;
            }
            else
            {
                var moveResult = MakeMove(Arena.SecondFighter, moveF2);

                if (moveResult < 0) return -1;

                moveResult = MakeMove(Arena.FirstFighter, moveF1);

                if (moveResult < 0) return 1;
            }

            ProcessEffect(Arena.FirstFighter);
            ProcessEffect(Arena.SecondFighter);

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


        /// <summary>
        /// Appliques les effets donnez au entité (éxécuter à la fin du tour)
        /// </summary>
        /// <param name="entity">L'entité sur laquelle appliquer les effets</param>
        private void ProcessEffect(IEntity entity)
        {
            foreach (var status in entity.Status)
            {
                switch (status.Key)
                {
                    case Status.RAGE:
                        entity.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(entity, status.Key);
                        }
                        break;
                    case Status.BURN:
                        entity.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(entity, status.Key);
                        }
                        else
                        {
                            ApplyStatusDamage(entity, status.Key);
                        }
                        break;
                    case Status.POISONED:
                        entity.Status[status.Key] = status.Value - 1;
                        if (status.Value == 0)
                        {
                            RemovedStatus(entity, status.Key);
                        }
                        else
                        {
                            ApplyStatusDamage(entity, status.Key);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Effectue une action à une entité
        /// </summary>
        /// <param name="user">L'utilisateur de l'action</param>
        /// <param name="move">L'action</param>
        /// <returns>-1 si le joueur à fuits avec succès</returns>
        private int MakeMove(IEntity user, MoveAction move)
        {
            if (user.Status.ContainsKey(Status.PARALYSED)) return 0;
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
                    if (!CanFlee(user.Luck, user.Speed, move.Target.Speed)) return -1;
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Retire un status à une entité
        /// </summary>
        /// <param name="entity">L'entité à qui l'on enlève le status</param>
        /// <param name="status">Le status à enlever</param>
        private void RemovedStatus(IEntity entity, Status status)
        {
            entity.Status.Remove(status);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="status"></param>
        private void ApplyStatusDamage(IEntity entity, Status status)
        {
            int hurt = 7 * entity.MaxHealthPoint / 100;
            entity.HealthPoint =- hurt;
        }

        /// <summary>
        /// Regarde si l'entité peut fuire
        /// </summary>
        /// <param name="userLuck">La chance de l'entité</param>
        /// <param name="userSpeed">La vitesse de l'entité</param>
        /// <param name="opponentSpeed">La vitesse de l'adversaire</param>
        /// <returns>retourne true si il peut fuir</returns>
        private bool CanFlee(int userLuck, int userSpeed, int opponentSpeed)
        {
            Random rand = new Random();
            int luckFlee = rand.Next(1, 101);
            return luckFlee > userLuck || userSpeed <= opponentSpeed;
        }
    }

}
