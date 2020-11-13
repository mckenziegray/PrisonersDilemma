using CsvHelper;
using PrisonersDilemma.Agents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrisonersDilemma
{
    public class Simulation
    {
        private class ResultData
        {
            public int NumRounds { get; set; }
            public int Trial { get; set; }
            public string Agent1 { get; set; }
            public string Agent2 { get; set; }
            public int Score1 { get; set; }
            public int Score2 { get; set; }
        }

        private class MachinatingResultData : ResultData
        {
            public int DefectRound1 { get; set; }
            public int DefectRound2 { get; set; }
        }

        private readonly Dictionary<(GameAction, GameAction), int> scoreProfile = new Dictionary<(GameAction, GameAction), int>
        {
            { (GameAction.Cooperate, GameAction.Cooperate), -1 },
            { (GameAction.Cooperate, GameAction.Defect), -3 },
            { (GameAction.Defect, GameAction.Cooperate), 0 },
            { (GameAction.Defect, GameAction.Defect), -2 },
        };

        private readonly List<Type> agentTypes = new List<Type>
        {
            typeof(RandomAgent),
            typeof(RationalAgent),
            typeof(GrimTriggerAgent),
            typeof(TitForTatAgent)
        };

        private int maxRounds;
        private int numTrials;

        public Simulation(int maxRounds, int numTrials)
        {
            this.maxRounds = maxRounds;
            this.numTrials = numTrials;
        }

        public void Run()
        {
            List<ResultData> results = new List<ResultData>();

            #region Random/Random
            Console.WriteLine($"{nameof(RandomAgent)}/{nameof(RandomAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RandomAgent, RandomAgent> game = new Game<RandomAgent, RandomAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RandomAgent),
                        Agent2 = nameof(RandomAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Random/Rational
            Console.WriteLine($"{nameof(RandomAgent)}/{nameof(RationalAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RandomAgent, RationalAgent> game = new Game<RandomAgent, RationalAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RandomAgent),
                        Agent2 = nameof(RationalAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Random/Grim Trigger
            Console.WriteLine($"{nameof(RandomAgent)}/{nameof(GrimTriggerAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RandomAgent, GrimTriggerAgent> game = new Game<RandomAgent, GrimTriggerAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RandomAgent),
                        Agent2 = nameof(GrimTriggerAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Random/TFT
            Console.WriteLine($"{nameof(RandomAgent)}/{nameof(TitForTatAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RandomAgent, TitForTatAgent> game = new Game<RandomAgent, TitForTatAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RandomAgent),
                        Agent2 = nameof(TitForTatAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Rational/Rational
            Console.WriteLine($"{nameof(RationalAgent)}/{nameof(RationalAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RationalAgent, RationalAgent> game = new Game<RationalAgent, RationalAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RationalAgent),
                        Agent2 = nameof(RationalAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Rational/Grim Trigger
            Console.WriteLine($"{nameof(RationalAgent)}/{nameof(GrimTriggerAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RationalAgent, GrimTriggerAgent> game = new Game<RationalAgent, GrimTriggerAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RationalAgent),
                        Agent2 = nameof(GrimTriggerAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Rational/TFT
            Console.WriteLine($"{nameof(RationalAgent)}/{nameof(TitForTatAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<RationalAgent, TitForTatAgent> game = new Game<RationalAgent, TitForTatAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(RationalAgent),
                        Agent2 = nameof(TitForTatAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Grim Trigger/Grim Trigger
            Console.WriteLine($"{nameof(GrimTriggerAgent)}/{nameof(GrimTriggerAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<GrimTriggerAgent, GrimTriggerAgent> game = new Game<GrimTriggerAgent, GrimTriggerAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(GrimTriggerAgent),
                        Agent2 = nameof(GrimTriggerAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region Grim Trigger/TFT
            Console.WriteLine($"{nameof(GrimTriggerAgent)}/{nameof(TitForTatAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<GrimTriggerAgent, TitForTatAgent> game = new Game<GrimTriggerAgent, TitForTatAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(GrimTriggerAgent),
                        Agent2 = nameof(TitForTatAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion

            #region TFT/TFT
            Console.WriteLine($"{nameof(TitForTatAgent)}/{nameof(TitForTatAgent)}");

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                for (int trial = 1; trial <= numTrials; trial++)
                {
                    Game<TitForTatAgent, TitForTatAgent> game = new Game<TitForTatAgent, TitForTatAgent>(scoreProfile, numRounds);
                    (int, int) scores = game.Play();

                    results.Add(new ResultData
                    {
                        NumRounds = numRounds,
                        Trial = trial,
                        Agent1 = nameof(TitForTatAgent),
                        Agent2 = nameof(TitForTatAgent),
                        Score1 = scores.Item1,
                        Score2 = scores.Item2
                    });
                }
            }
            #endregion
            
            using (var writer = new StreamWriter("results.csv"))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(results);
                }
            }
        }

        public void RunMachinating()
        {
            List<MachinatingResultData> results = new List<MachinatingResultData>();

            for (int numRounds = 1; numRounds <= maxRounds; numRounds++)
            {
                Console.WriteLine($"{numRounds} rounds...");
                for (int defectRound1 = 1; defectRound1 <= numRounds; defectRound1++)
                {
                    for (int defectRound2 = 1; defectRound2 <= numRounds; defectRound2++)
                    {
                        var game = new Game<MachinatingGrimTriggerAgent, MachinatingGrimTriggerAgent>(scoreProfile, numRounds);
                        ((MachinatingGrimTriggerAgent)game.agent1).defectStartRound = defectRound1;
                        ((MachinatingGrimTriggerAgent)game.agent2).defectStartRound = defectRound2;

                        (int, int) scores = game.Play();

                        results.Add(new MachinatingResultData
                        {
                            NumRounds = numRounds,
                            Score1 = scores.Item1,
                            Score2 = scores.Item2,
                            DefectRound1 = defectRound1,
                            DefectRound2 = defectRound2
                        });
                    }
                }
            }

            using (var writer = new StreamWriter("results.csv"))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(results);
                }
            }
        }
    }
}
