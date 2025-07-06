using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pools;

namespace RoundReports;

public class OrganizedKillsStats : IReportStat
{
    [Translation(nameof(Translation.OrganizedKillsTitle))]
    public string Title => "Kills";

    public int Order => 50;

    [Translation(nameof(Translation.KillsbyType))]
    [BindStat(StatType.KillsByType)]
    public Dictionary<DamageType, int> KillsByType { get; set; }

    [Translation(nameof(Translation.KillsByPlayer))]
    [BindStat(StatType.KillsByPlayer)]
    public Dictionary<Player, PercentInt> KillsByPlayer { get; set; }

    [Translation(nameof(Translation.KillsByZone))]
    [BindStat(StatType.KillsByZone)]
    public Dictionary<ZoneType, PercentInt> KillsByZone { get; set; }

    [Translation(nameof(Translation.PlayerKills))]
    [BindStat(StatType.PlayerKills)]
    public List<string> PlayerKills { get; set; }

    public void Setup()
    {
        KillsByType = DictionaryPool<DamageType, int>.Pool.Get();
        KillsByPlayer = DictionaryPool<Player, PercentInt>.Pool.Get();
        KillsByZone = DictionaryPool<ZoneType, PercentInt>.Pool.Get();
        PlayerKills = ListPool<string>.Pool.Get();
    }

    public void Cleanup()
    {
        foreach (KeyValuePair<Player, PercentInt> kvp in KillsByPlayer)
            PercentIntPool.Pool.Return(kvp.Value);

        foreach (KeyValuePair<ZoneType, PercentInt> kvp in KillsByZone)
            PercentIntPool.Pool.Return(kvp.Value);

        DictionaryPool<DamageType, int>.Pool.Return(KillsByType);
        DictionaryPool<Player, PercentInt>.Pool.Return(KillsByPlayer);
        DictionaryPool<ZoneType, PercentInt>.Pool.Return(KillsByZone);
        ListPool<string>.Pool.Return(PlayerKills);
    }

    public void FillOutFinal()
    {
    }
}
