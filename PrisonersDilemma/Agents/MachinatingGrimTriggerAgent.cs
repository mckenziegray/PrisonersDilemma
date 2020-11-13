using System.Collections.Generic;

namespace PrisonersDilemma.Agents
{
    class MachinatingGrimTriggerAgent : GrimTriggerAgent, IMachinating
    {
        public int? numRounds = null;
        public int defectStartRound = int.MaxValue;

        public MachinatingGrimTriggerAgent(IDictionary<(GameAction, GameAction), int> scores) : base(scores)
        {
        }

        public MachinatingGrimTriggerAgent(IDictionary<(GameAction, GameAction), int> scores, int numRounds, int numDefectRounds = 1) : base(scores)
        {
            this.numRounds = numRounds;
            defectStartRound = numRounds - numDefectRounds;
        }

        protected override GameAction ChooseAction()
        {
            if (ActionHistory.Count >= defectStartRound)
                return GetRationalStrategy();
            else
                return base.ChooseAction();
        }
    }
}
