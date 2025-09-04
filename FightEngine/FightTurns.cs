using EntityEngine;
using EntityEngine.Entities;
using EntityEngine.Entities.Enemies;
using EntityEngine.Inventories.Items;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine
{
    public class FightTurns
    {
        Arena Arena { get; set; }
        int CptTours { get; set; }

        public FightTurns(IEntity fighter1, IEntity fighter2)
        {
            Arena = new Arena(fighter1, fighter2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="">Le move choisit par fighter1</param>
        /// <param name="">Le move choisit par fighter2</param>
        /// <return>-1 si le fighter1 à perdu, 1 si figther 2 à perdu, 0 si le combat n'est pas fini</return>
        public int Turn(MoveAction moveF1, MoveAction moveF2) 
        {
            do
            {
            if (Arena.FirstFighter.Speed >= Arena.SecondFighter.Speed)
                // si P1 est plus rapide que P2 alors il commncera a attaquer en premier
                // utilisation d'une option de combat
            {
                if (moveF1.Move is ISkill skill)
                {
                    Arena.UseSkill(Arena.FirstFighter, moveF1.Target, skill);
                }
                else if (moveF1.Move is Item item) 
                {
                    Arena.UseItems(Arena.FirstFighter, moveF1.Target, item);
                }
                else if (moveF1.Move is SimpleMove)
                {
                    Arena.Hit(Arena.FirstFighter, moveF1.Target);
                }


                else if (moveF1.Move is Flee flee)
                {
                        if (Arena.FirstFighter.Speed > Arena.SecondFighter.Speed)
                        {

                        }
                }
                    // quiter la boucle si un joueur tomber a 0 pv
                    if (Arena.SecondFighter.HealthPoint <= 0 || Arena.FirstFighter.HealthPoint <= 0)
                    {
                        break;
                    }

                //utilisation d'une option de combat

                if (moveF2.Move is ISkill skill2)
                {
                    Arena.UseSkill(Arena.FirstFighter, moveF2.Target, skill2);
                }
                else if (moveF2.Move is Item item2)
                {
                    Arena.UseItems(Arena.FirstFighter, moveF2.Target, item2);
                }
                else if (moveF2.Move is SimpleMove)
                {
                    Arena.Hit(Arena.FirstFighter, moveF2.Target);
                }
                    // quiter la boucle si un joueur tomber a 0 pv
                    if (Arena.SecondFighter.HealthPoint <= 0 || Arena.FirstFighter.HealthPoint <= 0)
                    {
                        break;
                    }
                }
            else
            // si P2 est plus rapide que P1 alors il commncera a attaquer en premier
            {
                if (moveF2.Move is ISkill skill2)
                {
                    Arena.UseSkill(Arena.FirstFighter, moveF2.Target, skill2);
                }
                else if (moveF2.Move is Item item2)
                {
                    Arena.UseItems(Arena.FirstFighter, moveF2.Target, item2);
                }
                else if (moveF2.Move is SimpleMove)
                {
                    Arena.Hit(Arena.FirstFighter, moveF2.Target);
                }
                    // quiter la boucle si un joueur tomber a 0 pv
                    if (Arena.SecondFighter.HealthPoint <= 0 || Arena.FirstFighter.HealthPoint <= 0)
                    {
                        break;
                    }
                    //utilisation d'une option de combat

                    if (moveF1.Move is ISkill skill)
                {
                    Arena.UseSkill(Arena.FirstFighter, moveF1.Target, skill);
                }
                else if (moveF1.Move is Item item)
                {
                    Arena.UseItems(Arena.FirstFighter, moveF1.Target, item);
                }
                else if (moveF1.Move is SimpleMove)
                {
                    Arena.Hit(Arena.FirstFighter, moveF1.Target);
                }
                    // quiter la boucle si un joueur tomber a 0 pv
                    if (Arena.SecondFighter.HealthPoint <= 0 || Arena.FirstFighter.HealthPoint <= 0)
                    {
                        break;
                    }
                    //utilisation d'une option de combat
                }
            } while (Arena.FirstFighter.HealthPoint > 0 && Arena.SecondFighter.HealthPoint > 0);

            //retours d'une valeur celon le resultat du combat
            if (Arena.FirstFighter.HealthPoint <= 0)
            {
                return -1;
            }
            if (Arena.SecondFighter.HealthPoint <= 0)
            {
                return 1;
            }
            if (Arena.FirstFighter.HealthPoint > 0 && Arena.SecondFighter.HealthPoint > 0)
            {
                return 0;
            }
            throw new NotImplementedException();
        }
    }
}
