using PrisonersDilemma.Agents;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    class Game<TAgent1, TAgent2> 
        where TAgent1 : Agent 
        where TAgent2 : Agent
    {
        public readonly IDictionary<(GameAction, GameAction), int> scoreProfile;
        private readonly int numRounds;
        public readonly Agent agent1;
        public readonly Agent agent2;

        public Game(IDictionary<(GameAction, GameAction), int> scoreProfile, int numRounds)
        {
            this.scoreProfile = scoreProfile;
            this.numRounds = numRounds;
            agent1 = (TAgent1)Activator.CreateInstance(typeof(TAgent1), scoreProfile);
            agent2 = (TAgent2)Activator.CreateInstance(typeof(TAgent2), scoreProfile);
            agent1.Opponent = agent2;
            agent2.Opponent = agent1;
        }

        public (int, int) Play()
        {
            int totalScore1 = 0, totalScore2 = 0;
            //Console.WriteLine($"{agent1.GetType().Name.PadLeft(15)} | {agent2.GetType().Name.PadRight(15)}");
            for (int i = 0; i < numRounds; i++)
            {
                GameAction action1 = agent1.TakeAction();
                GameAction action2 = agent2.TakeAction();
                int score1 = agent1.GetOutcomeScore(action1, action2);
                int score2 = agent2.GetOutcomeScore(action2, action1);
                totalScore1 += score1;
                totalScore2 += score2;

                //Console.WriteLine($"{string.Format("{0} ({1})", action1, score1).PadLeft(15)} | {string.Format("{0} ({1})", action2, score2).PadRight(15)}");

                agent1.ActionHistory.Add(action1);
                agent2.ActionHistory.Add(action2);
            }

            //Console.WriteLine("".PadRight(33, '-'));
            //Console.WriteLine($"{string.Format("Total: {0}", totalScore1).PadLeft(15)} | {string.Format("Total: {0}", totalScore2).PadRight(15)}");
            return (totalScore1, totalScore2);
        }
    }
}
