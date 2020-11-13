using System.Collections.Generic;

namespace PrisonersDilemma.Agents
{
    public class RationalAgent : Agent
    {
        public RationalAgent(IDictionary<(GameAction, GameAction), int> scores) : base(scores)
        {
        }

        protected override GameAction ChooseAction()
        {
            return GetRationalStrategy();
        }
    }
}
