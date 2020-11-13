using System;
using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilemma.Agents
{
    public abstract class Agent
    {
        public IDictionary<(GameAction, GameAction), int> Scores { get; set; }
        public Agent Opponent { get; set; }
        public IList<GameAction> ActionHistory { get; protected set; }

        public Agent(IDictionary<(GameAction, GameAction), int> scores)
        {
            Scores = scores;
            ActionHistory = new List<GameAction>();
        }

        public GameAction TakeAction()
        {
            if (Opponent == null)
                throw new Exception("Opponent agent not set.");

            GameAction action = ChooseAction();
            return action;
        }

        protected abstract GameAction ChooseAction();

        public int GetOutcomeScore(GameAction myAction, GameAction opponentAction)
        {
            return Scores[(myAction, opponentAction)];
        }

        protected double GetAverageActionScore(GameAction myAction)
        {
            List<int> possibleScores = new List<int>();
            foreach(GameAction action in Enum.GetValues(typeof(GameAction)))
            {
                possibleScores.Add(GetOutcomeScore(myAction, action));
            }
            return possibleScores.Average();
        }

        protected GameAction GetRationalStrategy()
        {
            double optimalScore = double.NegativeInfinity;
            GameAction? optimalAction = null;

            foreach (GameAction action in Enum.GetValues(typeof(GameAction)))
            {
                double score = GetAverageActionScore(action);
                if (score > optimalScore)
                {
                    optimalScore = score;
                    optimalAction = action;
                }
            }

            return optimalAction.Value;
        }

        protected GameAction GetSuperrationalStrategy()
        {
            int optimalScore = int.MinValue;
            GameAction? optimalAction = null;

            foreach (GameAction action in Enum.GetValues(typeof(GameAction)))
            {
                int score = GetOutcomeScore(action, action);
                if (score > optimalScore)
                {
                    optimalScore = score;
                    optimalAction = action;
                }
            }

            return optimalAction.Value;
        }
    }
}
