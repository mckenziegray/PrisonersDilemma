using System;
using System.Collections.Generic;

namespace PrisonersDilemma.Agents
{
    public class RandomAgent : Agent
    {
        private Random random;

        public RandomAgent(IDictionary<(GameAction, GameAction), int> scores) : base(scores)
        {
            random = new Random();
        }

        protected override GameAction ChooseAction()
        {
            var actions = Enum.GetValues(typeof(GameAction));
            return (GameAction)actions.GetValue(random.Next(actions.Length));
        }
    }
}
