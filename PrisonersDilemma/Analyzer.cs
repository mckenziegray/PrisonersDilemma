using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrisonersDilemma
{
    public static class Analyzer
    {
        public static void Analyze()
        {
            IDictionary<(GameAction, GameAction), int> scores = new Dictionary<(GameAction, GameAction), int>
            {
                { (GameAction.Cooperate, GameAction.Cooperate), -1 },
                { (GameAction.Cooperate, GameAction.Defect), -3 },
                { (GameAction.Defect, GameAction.Cooperate), 0 },
                { (GameAction.Defect, GameAction.Defect), -2 },
            };

            using (var writer = new StreamWriter("results.txt"))
            {
                for (int i = 0; i < 100; i++)
                {
                    writer.Write($"\tDefect Round: {i}");
                }
                writer.WriteLine();

                for (int numRounds = 1; numRounds <= 100; numRounds++)
                {
                    writer.Write($"Total Rounds: {numRounds}");

                    for (int defectRound = 1; defectRound <= numRounds; defectRound++)
                    {
                        writer.Write('\t');
                        writer.Write(ExpectedPayout(scores, numRounds, defectRound));
                    }

                    writer.WriteLine();
                }
            }
        }

        public static double ExpectedPayout(IDictionary<(GameAction, GameAction), int> scores, int numRounds, int defectTurn)
        {
            int payoutSum = 0;

            for (int i = 1; i <= numRounds; i++)
            {
                payoutSum += ExpectedPayout(scores, numRounds, defectTurn, i);
            }

            return (double)payoutSum / numRounds;
        }

        public static int ExpectedPayout(IDictionary<(GameAction, GameAction), int> scores, int numRounds, int defectTurn1, int defectTurn2)
        {
            int firstDefectTurn = Math.Min(defectTurn1, defectTurn2);

            int payout = scores[(GameAction.Cooperate, GameAction.Cooperate)] * (firstDefectTurn - 1);

            if (defectTurn1 < defectTurn2)
                payout += scores[(GameAction.Defect, GameAction.Cooperate)];
            else if (defectTurn1 > defectTurn2)
                payout += scores[(GameAction.Cooperate, GameAction.Defect)];
            else
                payout += scores[(GameAction.Defect, GameAction.Defect)];

            payout += scores[(GameAction.Defect, GameAction.Defect)] * (numRounds - firstDefectTurn);

            return payout;
        }
    }
}
