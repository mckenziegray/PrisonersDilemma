using System.Collections.Generic;

namespace PrisonersDilemma.Agents
{
    public class GrimTriggerAgent : Agent
    {
        public GrimTriggerAgent(IDictionary<(GameAction, GameAction), int> scores) : base(scores)
        {
        }

        protected override GameAction ChooseAction()
        {
            return Opponent.ActionHistory.Contains(GameAction.Defect) ? GetRationalStrategy() : GetSuperrationalStrategy();
        }
    }
}
