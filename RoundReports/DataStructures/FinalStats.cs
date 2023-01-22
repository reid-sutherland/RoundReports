﻿namespace RoundReports
{
#pragma warning disable SA1600
    using System;
    using System.Collections.Generic;
    using Exiled.API.Features;
    using Exiled.API.Features.Pools;

    public class FinalStats : IReportStat
    {
        [Translation(nameof(Translation.FinalStatsTitle))]
        public string Title => "Final Statistics";

        public int Order => 2;

        [Header(nameof(Translation.EndofRoundSummary))]
        [Translation(nameof(Translation.WinningTeam))]
        [BindStat(StatType.WinningTeam)]
        public string WinningTeam { get; set; }

        [Translation(nameof(Translation.EndTime))]
        [BindStat(StatType.EndTime)]
        public DateTime EndTime { get; set; }

        [Translation(nameof(Translation.RoundTime))]
        [BindStat(StatType.RoundTime)]
        public TimeSpan RoundTime { get; set; }

        [Translation(nameof(Translation.TotalDeaths))]
        [BindStat(StatType.TotalDeaths)]
        public int TotalDeaths { get; set; }

        [Translation(nameof(Translation.TotalKills))]
        [BindStat(StatType.TotalKills)]
        public int TotalKills { get; set; }

        [Translation(nameof(Translation.ScpKills))]
        [BindStat(StatType.SCPKills)]
        public int SCPKills { get; set; }

        [Translation(nameof(Translation.DClassKills))]
        [BindStat(StatType.DClassKills)]
        public int DClassKills { get; set; }

        [Translation(nameof(Translation.ScientistKills))]
        [BindStat(StatType.ScientistKills)]
        public int ScientistKills { get; set; }

        [Translation(nameof(Translation.MtfKills))]
        [BindStat(StatType.MTFKills)]
        public int MTFKills { get; set; }

        [Translation(nameof(Translation.ChaosKills))]
        [BindStat(StatType.ChaosKills)]
        public int ChaosKills { get; set; }

        [HideIfDefault]
        [Translation(nameof(Translation.SerpentsHandKills))]
        [BindStat(StatType.SerpentsHandKills)]
        public int SerpentsHandKills { get; set; }

        [HideIfDefault]
        [Translation(nameof(Translation.UiuKills))]
        [BindStat(StatType.UIUKills)]
        public int UIUKills { get; set; }

        [HideIfDefault]
        [Translation(nameof(Translation.TutorialKills))]
        [BindStat(StatType.TutorialKills)]
        public int TutorialKills { get; set; }

        [Translation(nameof(Translation.SurvivingPlayers))]
        [BindStat(StatType.SurvivingPlayers)]
        public List<string> SurvivingPlayers { get; set; }

        [Header(nameof(Translation.WarheadStatsTitle))]
        [Translation(nameof(Translation.ButtonUnlocked))]
        [BindStat(StatType.ButtonUnlocked)]
        public bool ButtonUnlocked { get; set; } = false;

        [Translation(nameof(Translation.ButtonUnlocker))]
        [BindStat(StatType.ButtonUnlocker)]
        public Player ButtonUnlocker { get; set; }

        [Translation(nameof(Translation.FirstActivator))]
        [BindStat(StatType.FirstWarheadActivator)]
        public Player FirstActivator { get; set; }

        [Translation(nameof(Translation.Detonated))]
        [BindStat(StatType.Detonated)]
        public bool Detonated { get; set; } = false;

        [Translation(nameof(Translation.DetonationTime))]
        [BindStat(StatType.DetonationTime)]
        public DateTime DetonationTime { get; set; } = DateTime.MinValue;

        [Header(nameof(Translation.DoorStatsTitle))]
        [Translation(nameof(Translation.DoorsOpened))]
        [BindStat(StatType.DoorsOpened)]
        public int DoorsOpened { get; set; }

        [Translation(nameof(Translation.DoorsClosed))]
        [BindStat(StatType.DoorsClosed)]
        public int DoorsClosed { get; set; }

        [Translation(nameof(Translation.DoorsDestroyed))]
        [BindStat(StatType.DoorsDestroyed)]
        public int DoorsDestroyed { get; set; }

        [Translation(nameof(Translation.PlayerDoorsOpened))]
        [BindStat(StatType.PlayerDoorsOpened)]
        public Dictionary<Player, int> PlayerDoorsOpened { get; set; }

        [Translation(nameof(Translation.PlayerDoorsClosed))]
        [BindStat(StatType.PlayerDoorsClosed)]
        public Dictionary<Player, int> PlayerDoorsClosed { get; set; }

        [Translation(nameof(Translation.TotalInteractions))]
        [BindStat(StatType.TotalInteractions)]
        public int TotalInteractions { get; set; }

        public void Setup()
        {
            SurvivingPlayers = ListPool<string>.Pool.Get();
            PlayerDoorsOpened = DictionaryPool<Player, int>.Pool.Get();
            PlayerDoorsClosed = DictionaryPool<Player, int>.Pool.Get();
            WinningTeam = MainPlugin.Translations.NoData;
            RoundTime = TimeSpan.Zero;
            EndTime = DateTime.MinValue;
        }

        public void Cleanup()
        {
            ListPool<string>.Pool.Return(SurvivingPlayers);
            DictionaryPool<Player, int>.Pool.Return(PlayerDoorsOpened);
            DictionaryPool<Player, int>.Pool.Return(PlayerDoorsClosed);
        }
    }
#pragma warning restore SA1600
}
