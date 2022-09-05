﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundReports
{
    public class FinalStats : IReportStat
    {
        [Translation(nameof(Translation.FinalStatsTitle))]
        public string Title => "Final Statistics";
        public int Order => 1;

        [Translation(nameof(Translation.WinningTeam))]
        public string WinningTeam { get; set; }

        [Translation(nameof(Translation.EndTime))]
        public DateTime EndTime { get; set; }

        [Translation(nameof(Translation.RoundTime))]
        public TimeSpan RoundTime { get; set; }

        [Translation(nameof(Translation.TotalDeaths))]
        public int TotalDeaths { get; set; }

        [Translation(nameof(Translation.TotalKills))]
        public int TotalKills { get; set; }

        [Translation(nameof(Translation.ScpKills))]
        public int SCPKills { get; set; }

        [Translation(nameof(Translation.DClassKills))]
        public int DClassKills { get; set; }

        [Translation(nameof(Translation.ScientistKills))]
        public int ScientistKills { get; set; }

        [Translation(nameof(Translation.MtfKills))]
        public int MTFKills { get; set; }

        [Translation(nameof(Translation.ChaosKills))]
        public int ChaosKills { get; set; }

        [HideIfDefault]
        [Translation(nameof(Translation.SerpentsHandKills))]
        public int SerpentsHandKills { get; set; }

        [HideIfDefault]
        [Translation(nameof(Translation.UiuKills))]
        public int UIUKills { get; set; }

        [HideIfDefault]
        [Translation(nameof(Translation.TutorialKills))]
        public int TutorialKills { get; set; }

        [Translation(nameof(Translation.SurvivingPlayers))]
        public List<string> SurvivingPlayers { get; set; }
    }
}
