using System.Collections.Generic;
using System.Linq;

namespace PrisonersDilemma.Agents
{
    class TitForTatAgent : Agent
    {
        public TitForTatAgent(IDictionary<(GameAction, GameAction), int> scores) : base(scores) { }

        protected override GameAction ChooseAction()
        {
            return Opponent.ActionHistory.Count > 0 ? Opponent.ActionHistory.Last() : GetSuperrationalStrategy();
        }
    }
}
