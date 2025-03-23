namespace RoundReports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.API.Features.Doors;
    using Exiled.API.Features.Pools;

    public class FinalStats : IReportStat
    {
        [Translation(nameof(Translation.FinalStatsTitle))]
        public string Title => "Final Statistics";

        public int Order => 2;

        public int ScpKills => KillsByTeam.ContainsKey(CustomTeam.SCPs) ? KillsByTeam[CustomTeam.SCPs].Value : 0;

        public int MtfKills => KillsByTeam.ContainsKey(CustomTeam.FoundationForces) ? KillsByTeam[CustomTeam.FoundationForces].Value : 0;

        public int ChaosKills => KillsByTeam.ContainsKey(CustomTeam.ChaosInsurgency) ? KillsByTeam[CustomTeam.ChaosInsurgency].Value : 0;

        public int ScientistKills => KillsByTeam.ContainsKey(CustomTeam.Scientists) ? KillsByTeam[CustomTeam.Scientists].Value : 0;

        public int DClassKills => KillsByTeam.ContainsKey(CustomTeam.ClassD) ? KillsByTeam[CustomTeam.ClassD].Value : 0;

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

        [Translation(nameof(Translation.KillsByTeam))]
        [BindStat(StatType.KillsByTeam)]
        public Dictionary<CustomTeam, PercentInt> KillsByTeam { get; set; }

        [Translation(nameof(Translation.SurvivingPlayers))]
        [BindStat(StatType.SurvivingPlayers)]
        public List<string> SurvivingPlayers { get; set; }

        [Translation(nameof(Translation.MostTalkativeHumanPlayer))]
        [BindStat(StatType.MostTalkativeHumanPlayer)]
        public string MostTalkativeHumanPlayer { get; set; }

        [Translation(nameof(Translation.MostTalkativeScpPlayer))]
        [BindStat(StatType.MostTalkativeScpPlayer)]
        public string MostTalkativeScpPlayer { get; set; }

        [Translation(nameof(Translation.TotalInteractions))]
        [BindStat(StatType.TotalInteractions)]
        public int TotalInteractions { get; set; }

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
        public TimeSpan DetonationTime { get; set; }

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
        public Dictionary<Player, PercentInt> PlayerDoorsOpened { get; set; }

        [Translation(nameof(Translation.PlayerDoorsClosed))]
        [BindStat(StatType.PlayerDoorsClosed)]
        public Dictionary<Player, PercentInt> PlayerDoorsClosed { get; set; }

        public void Setup()
        {
            WinningTeam = MainPlugin.Translations.NoData;
            EndTime = DateTime.MinValue;
            RoundTime = TimeSpan.Zero;
            KillsByTeam = DictionaryPool<CustomTeam, PercentInt>.Pool.Get();
            SurvivingPlayers = ListPool<string>.Pool.Get();
            PlayerDoorsOpened = DictionaryPool<Player, PercentInt>.Pool.Get();
            PlayerDoorsClosed = DictionaryPool<Player, PercentInt>.Pool.Get();
        }

        public void Cleanup()
        {
            foreach (KeyValuePair<CustomTeam, PercentInt> kvp in KillsByTeam)
                PercentIntPool.Pool.Return(kvp.Value);

            foreach (KeyValuePair<Player, PercentInt> kvp in PlayerDoorsOpened)
                PercentIntPool.Pool.Return(kvp.Value);

            foreach (KeyValuePair<Player, PercentInt> kvp in PlayerDoorsClosed)
                PercentIntPool.Pool.Return(kvp.Value);

            DictionaryPool<CustomTeam, PercentInt>.Pool.Return(KillsByTeam);
            ListPool<string>.Pool.Return(SurvivingPlayers);
            DictionaryPool<Player, PercentInt>.Pool.Return(PlayerDoorsOpened);
            DictionaryPool<Player, PercentInt>.Pool.Return(PlayerDoorsClosed);
        }

        public void FillOutFinal()
        {
            EndTime = DateTime.Now;
            RoundTime = Round.ElapsedTime;
            TotalInteractions = MainPlugin.Handlers.Interactions;
            DoorsDestroyed = Door.List.Count(d => d is BreakableDoor bd && bd.IsDestroyed);

            foreach (Player player in Player.Get(plr => plr.IsAlive && EventHandlers.ECheck(plr)))
                SurvivingPlayers.Add($"{Reporter.GetDisplay(player, typeof(Player))} ({EventHandlers.GetRole(player)})");

            MostTalkativeHumanPlayer = string.Empty;
            MostTalkativeScpPlayer = string.Empty;

            List<KeyValuePair<Player, float>> talkers = MainPlugin.Handlers.Talkers.OrderByDescending(r => r.Value).ToList();
            if (!talkers.IsEmpty())
            {
                foreach (KeyValuePair<Player, float> talker in talkers)
                {
                    if (talker.Key.IsHuman && string.IsNullOrEmpty(MostTalkativeHumanPlayer))
                    {
                        MostTalkativeHumanPlayer = $"{talker.Key.Nickname} ({Reporter.GetDisplay(TimeSpan.FromSeconds(talker.Value))})";
                    }
                    else if (talker.Key.IsScp && string.IsNullOrEmpty(MostTalkativeScpPlayer))
                    {
                        MostTalkativeScpPlayer = $"{talker.Key.Nickname} ({Reporter.GetDisplay(TimeSpan.FromSeconds(talker.Value))})";
                    }

                    if (!string.IsNullOrEmpty(MostTalkativeHumanPlayer) && !string.IsNullOrEmpty(MostTalkativeScpPlayer))
                    {
                        break;
                    }
                }
            }
            else
            {
                MostTalkativeHumanPlayer = "Dedicated Server (420ms)";
                MostTalkativeScpPlayer = "Dedicated Server (420ms)";
            }
        }
    }
}
