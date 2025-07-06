using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pools;
using InventorySystem.Items.Usables.Scp330;
using Scp914;

namespace RoundReports;

#pragma warning disable SA1600

public class SCPStats : IReportStat
{
    [Translation(nameof(Translation.ScpTitle))]
    public string Title => "SCP Statistics";

    public int Order => 7;

    /////////////////////////////////////////////////////////
    // SCPs (SCP Team)
    /////////////////////////////////////////////////////////

    [Header(nameof(Translation.ScpTitle))]
    [HideIfDefault]
    [Translation(nameof(Translation.Scp049Revives))]
    [BindStat(StatType.Scp049Revives)]
    public int Scp049Revives { get; set; } = 0;

    [HideIfDefault]
    [Translation(nameof(Translation.Scp079Tier))]
    [BindStat(StatType.Scp079Tier)]
    public int Scp079Tier { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp079CamerasUsed))]
    [BindStat(StatType.Scp079CamerasUsed)]
    public PercentInt Scp079CamerasUsed { get; set; } // Created by script

    [HideIfDefault]
    [Translation(nameof(Translation.Scp079MostUsedCamera))]
    [BindStat(StatType.Scp079MostUsedCamera)]
    public CameraType Scp079MostUsedCamera { get; set; } = CameraType.Unknown;

    [HideIfDefault]
    [Translation(nameof(Translation.Scp096Charges))]
    [BindStat(StatType.Scp096Charges)]
    public int Scp096Charges { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp096Enrages))]
    [BindStat(StatType.Scp096Enrages)]
    public int Scp096Enrages { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp106Teleports))]
    [BindStat(StatType.Scp106Teleports)]
    public int Scp106Teleports { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp173Blinks))]
    [BindStat(StatType.Scp173Blinks)]
    public int Scp173Blinks { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp173Tantrums))]
    [BindStat(StatType.Scp173Tantrums)]
    public int Scp173Tantrums { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp939Lunges))]
    [BindStat(StatType.Scp939Lunges)]
    public int Scp939Lunges { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp939Clouds))]
    [BindStat(StatType.Scp939Clouds)]
    public int Scp939Clouds { get; set; }

    /////////////////////////////////////////////////////////
    // SCP Items
    /////////////////////////////////////////////////////////

    [Header(nameof(Translation.ScpItemTitle))]
    [Translation(nameof(Translation.Scp018sThrown))]
    [BindStat(StatType.Scp018sThrown)]
    public int Scp018sThrown { get; set; }

    [Translation(nameof(Translation.Scp207sDrank))]
    [BindStat(StatType.Scp207sDrank)]
    public int Scp207sDrank { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp244sPlaced))]
    [BindStat(StatType.Scp244sPlaced)]
    public int Scp244sPlaced { get; set; }

    [Translation(nameof(Translation.Scp268Uses))]
    [BindStat(StatType.Scp268Uses)]
    public int Scp268Uses { get; set; }

    [Translation(nameof(Translation.Scp500sConsumed))]
    [BindStat(StatType.Scp500sConsumed)]
    public int Scp500sConsumed { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp1576Uses))]
    [BindStat(StatType.Scp1576Uses)]
    public int Scp1576Uses { get; set; }

    [Translation(nameof(Translation.Scp1853Uses))]
    [BindStat(StatType.Scp1853Uses)]
    public int Scp1853Uses { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.Scp2176sThrown))]
    [BindStat(StatType.Scp2176sThrown)]
    public int Scp2176sThrown { get; set; }

    /////////////////////////////////////////////////////////
    // SCP-330 (Candy)
    /////////////////////////////////////////////////////////

    [Header(nameof(Translation.Scp330Title))]
    [Translation(nameof(Translation.FirstUse))]
    [BindStat(StatType.First330Use)]
    public DateTime FirstUse { get; set; } = DateTime.MinValue;

    [Translation(nameof(Translation.FirstUser))]
    [BindStat(StatType.First330User)]
    public Player FirstUser { get; set; }

    [Translation(nameof(Translation.TotalCandiesTaken))]
    [BindStat(StatType.TotalCandiesTaken)]
    public int TotalCandiesTaken { get; set; }

    [HideIfDefault]
    [Translation(nameof(Translation.SeveredHands))]
    [BindStat(StatType.SeveredHands)]
    public int SeveredHands { get; set; }

    [Translation(nameof(Translation.CandiesTaken))]
    [BindStat(StatType.CandiesTaken)]
    public Dictionary<CandyKindID, int> CandiesTaken { get; set; }

    [Translation(nameof(Translation.CandiesByPlayer))]
    [BindStat(StatType.CandiesByPlayer)]
    public Dictionary<Player, int> CandiesByPlayer { get; set; }

    /////////////////////////////////////////////////////////
    // SCP-914 (Upgrades)
    /////////////////////////////////////////////////////////

    [Header(nameof(Translation.Scp914Title))]
    [Translation(nameof(Translation.FirstActivation))]
    [BindStat(StatType.First914Activation)]
    public DateTime FirstActivation { get; set; } = DateTime.MinValue;

    [Translation(nameof(Translation.FirstActivator))]
    [BindStat(StatType.First914Activator)]
    public Player FirstActivator { get; set; }

    [Translation(nameof(Translation.TotalActivations))]
    [BindStat(StatType.Total914Activations)]
    public int TotalActivations { get; set; }

    [Translation(nameof(Translation.TotalItemUpgrades))]
    [BindStat(StatType.TotalItemUpgrades)]
    public int TotalItemUpgrades { get; set; }

    [Translation(nameof(Translation.KeycardUpgrades))]
    [BindStat(StatType.KeycardUpgrades)]
    public int KeycardUpgrades { get; set; }

    [Translation(nameof(Translation.FirearmUpgrades))]
    [BindStat(StatType.FirearmUpgrades)]
    public int FirearmUpgrades { get; set; }

    [Translation(nameof(Translation.Activations))]
    [BindStat(StatType.AllActivations)]
    public Dictionary<Scp914KnobSetting, PercentInt> Activations { get; set; }

    [Translation(nameof(Translation.Upgrades))]
    [BindStat(StatType.AllUpgrades)]
    public Dictionary<ItemType, PercentInt> Upgrades { get; set; } = new();

    public void Setup()
    {
        CandiesTaken = DictionaryPool<CandyKindID, int>.Pool.Get();
        CandiesByPlayer = DictionaryPool<Player, int>.Pool.Get();
        Activations = DictionaryPool<Scp914KnobSetting, PercentInt>.Pool.Get();

        foreach (Scp914KnobSetting setting in (Scp914KnobSetting[])Enum.GetValues(typeof(Scp914KnobSetting)))
        {
            Activations.Add(setting, new(0, 0, () => MainPlugin.Reporter.GetStat<SCPStats>().TotalActivations));
        }

        Upgrades = DictionaryPool<ItemType, PercentInt>.Pool.Get();
    }

    public void Cleanup()
    {
        foreach (KeyValuePair<ItemType, PercentInt> kvp in Upgrades)
            PercentIntPool.Pool.Return(kvp.Value);

        DictionaryPool<CandyKindID, int>.Pool.Return(CandiesTaken);
        DictionaryPool<Player, int>.Pool.Return(CandiesByPlayer);
        DictionaryPool<Scp914KnobSetting, PercentInt>.Pool.Return(Activations);
        DictionaryPool<ItemType, PercentInt>.Pool.Return(Upgrades);

        if (Scp079CamerasUsed is not null)
            PercentIntPool.Pool.Return(Scp079CamerasUsed);
    }

    public void FillOutFinal()
    {
        if (MainPlugin.Handlers.UsedCameras.Count > 0)
        {
            var topCamera = MainPlugin.Handlers.UsedCameras.OrderByDescending(kvp => kvp.Value).FirstOrDefault();
            Scp079MostUsedCamera = topCamera.Key.Type;
        }
    }
}
#pragma warning restore SA1600

