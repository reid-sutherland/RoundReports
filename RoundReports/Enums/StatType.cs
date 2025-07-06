namespace RoundReports;

/// <summary>
/// Determines each stat type.
/// </summary>
public enum StatType
{
    // Start Stats
    StartTime,
    StartClassD,
    StartScientist,
    StartSCP,
    StartFacilityGuard,
    StartPlayers,

    // MVP Stats
    HumanMVP,
    SCPMVP,
    HumanPoints,
    SCPPoints,
    PointLogs,

    // Final Stats
    WinningTeam,
    EndTime,
    RoundTime,
    TotalDeaths,
    TotalKills,
    KillsByTeam,
    SurvivingPlayers,
    MostTalkativeHumanPlayer,
    MostTalkativeScpPlayer,
    TotalInteractions,

    //-- Warhead
    ButtonUnlocked,
    ButtonUnlocker,
    FirstWarheadActivator,
    Detonated,
    DetonationTime,

    //-- Doors
    DoorsOpened,
    DoorsClosed,
    DoorsDestroyed,
    PlayerDoorsOpened,
    PlayerDoorsClosed,

    // Misc Stats
    SpawnWaves,
    TotalRespawned,
    Respawns,

    TotalRooms,
    RoomsByZone,
    TotalCameras,
    TotalDoors,

    TotalTeslaGates,
    TeslaShocks,
    TeslaDamage,

    // Item Stats
    TotalDrops,
    Drops,
    PlayerDrops,
    KeycardScans,
    PainkillersConsumed,
    MedkitsConsumed,
    AdrenalinesConsumed,

    //-- Firearm
    TotalShotsFired,
    TotalReloads,
    AverageShotsPerFirearm,
    ShotsByFirearm,

    // SCP Stats
    Scp049Revives,
    Scp079Tier,
    Scp079CamerasUsed,
    Scp079MostUsedCamera,
    Scp096Charges,
    Scp096Enrages,
    Scp106Teleports,
    Scp173Blinks,
    Scp173Tantrums,
    Scp939Lunges,
    Scp939Clouds,

    //-- SCP Items
    Scp018sThrown,
    Scp207sDrank,
    Scp244sPlaced,
    Scp268Uses,
    Scp500sConsumed,
    Scp1576Uses,
    Scp1853Uses,
    Scp2176sThrown,

    //-- SCP-330
    First330Use,
    First330User,
    TotalCandiesTaken,
    SeveredHands,
    CandiesTaken,
    CandiesByPlayer,

    //-- SCP-914
    First914Activation,
    First914Activator,
    Total914Activations,
    TotalItemUpgrades,
    KeycardUpgrades,
    FirearmUpgrades,
    AllActivations,
    AllUpgrades,

    // Kill Stats
    KillsByType,
    KillsByPlayer,
    KillsByZone,
    PlayerKills,

    // Damage Stats
    TotalDamage,
    PlayerDamage,
    AverageDamagePerPlayer,
    DamageByPlayer,
    DamageByType,
}
