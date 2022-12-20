![VERSION](https://img.shields.io/github/v/release/Thundermaker300/RoundReports?include_prereleases&style=for-the-badge)
![DOWNLOADS](https://img.shields.io/github/downloads/Thundermaker300/RoundReports/total?style=for-the-badge)

# Round Reports
 An SCP:SL Exiled plugin which generates reports at the end of each round, and shares them in your Discord server. Also includes end-of-round broadcasts, with support for over 20 different round statistics displayed in these broadcasts.  This plugin supports Serpent's Hand and UIU Rescue Squad, and will display stats accordingly.
  
This plugin uses [paste.ee](https://paste.ee/) for hosting reports. This service is not affiliated with RoundReports, and they have their own Terms of Service you must abide by when using this plugin. By default, reports automatically expire after 30 days; however, this can be configured, and reports can be saved with a simple tool like the [Wayback Machine](https://web.archive.org/).  
  
Note: Statistics from users with Do Not Track (DNT) enabled are treated differently, please see "Note on DNT Players" section below.

 ## Commands
 ### pausereport
 Permission: rr.pause  
 Disables reporting for the duration of the round. Automatically unpauses at the start of the next round.  

 ### addremark / remark
 Permission: rr.remark  
 Adds a remark to the report. Can be used to specify event rounds & etc.  
  
## Note on DNT Players
Players with Do Not Track enabled will never have their username present on reports. How their stats are handled is based on the `ExcludeDNTUsers` config. If this config is set to `true`, no stats at all will be recorded except for kill logs (in which case their name will be removed). If this config is set to `false`, their stats will still be included but their name will be removed. Do Not Track players will never be included in the MVP statistics, regardless of this setting's value.

## MVP Statistic Info
MVP is calculated by granting players points for specific actions. These points can also be taken away by other actions. There are two separate point systems, and as such two separate MVPs: One for SCPs, and one for humans. Full list of actions and the points they grant or remove below. (Configurable: Coming soon)

### Human Points

| **Action**                            | **Point Change** |
|---------------------------------------|------------------|
| Kill SCP                              | +10              |
| Sacrifice in Femur Breaker            | +6               |
| Escape                                | +5               |
| Press Femur Breaker Button            | +4               |
| Kill Scientist                        | +3               |
| Kill Player (Not Scientist)           | +2               |
| Open Warhead Panel (Surface)          | +2               |
| Die (Most Causes)                     | -1               |
| Die (Warhead, Decontamination, Tesla) | -2               |
| Take 3 Candies                        | -10              |
| Kill Teammate                         | -10              |


### SCP Points

| **Action**                            | **Point Change** |
|---------------------------------------|------------------|
| Level Up (SCP-079)                    | +5               |
| Kill Scientist                        | +3               |
| Kill Player (Not Scientist)           | +2               |
| Open Door (SCP-079)                   | +1-3\*\*         |
| Lockdown Room (SCP-079)               | +1\*             |
| Capture Player (SCP-106)              | +1               |
| Die (Most Causes)                     | -5               |
| Die (Warhead, Decontamination, Tesla) | -10              |

\*+1 for each player in the room. Does not include SCPs, Tutorials, and Serpent's Hand (if the plugin is installed).  
\*\*+1 if there is an SCP nearby. +2 if the door is a keycard door and there is an SCP nearby. +3 for keycarded gate with SCP nearby.

 ## Broadcast & Embed Arguments
 All of the following arguments can be used in end-of-round broadcasts, and the Discord embed footer config. Note that arguments must be surrounded by curly braces (`{}`, eg. `{HUMANMVP}`).
| **Key**           | **Stat Type** | **Description**                                                |
|-------------------|---------------|----------------------------------------------------------------|
| HUMANMVP          | string        | The human MVP of the round.                                    |
| SCPMVP            | string        | The SCP MVP of the round.                                      |
| TOTALKILLS        | number        | The total amount of kills in the round.                        |
| SCPKILLS          | number        | The total amount of SCP kills in the round.                    |
| MTFKILLS          | number        | The total amount of MTF kills in the round.                    |
| CLASSDKILLS       | number        | The total amount of Class-D kills in the round.                |
| CHAOSKILLS        | number        | The total amount of Chaos Insurgency kills in the round.       |
| SCIENTISTKILLS    | number        | The total amount of scientist kills in the round.              |
| HUMANKILLS        | number        | The total amount of human kills in the round.                  |
| TOTALDEATHS       | number        | The total amount of deaths.                                    |
| TOTALDAMAGE       | number        | The total amount of damage dealt.                              |
| WINTEAM           | string        | The winning team of the round.                                 |
| ROUNDTIME*        | string        | The total time of the round.                                   |
| STARTTIME*        | string        | The time that the round started.                               |
| PLAYERCOUNT       | number        | The total amount of players currently connected to the server. |
| TOTALDROPS        | number        | The total amount of items dropped.                             |
| KEYCARDSCANS      | number        | The total amount of keycard scans.                             |
| TOTALRESPAWNED    | number        | The total amount of respawned players.                         |
| TOTALRESPAWNWAVES | number        | The total amount of respawn waves.                             |
| TOTALSHOTSFIRED   | number        | The total amount of shots fired.                               |
| TOTALRELOADS      | number        | The total amount of firearm reloads.                           |
| DOORSOPENED       | number        | The total amount of open door interactions.                    |
| DOORSCLOSED       | number        | The total amount of close door interactions.                   |
| DOORSDESTROYED    | number        | The total amount of destroyed doors.                           |
| CANDIESTAKEN      | number        | The total amount of candies taken from SCP-330.                |
| 914ACTIVATIONS    | number        | The total amount of times SCP-914 was activated.               |

\* Arguments will be formatted as specified in the config file.

## Stat Types
The following values can be included in the "IgnoredStats" config to disable them in the report.

| **Key**                | **Description**                                                |
|------------------------|----------------------------------------------------------------|
| AdrenalinesConsumed    | TBA                                                            |
| AllActivations         | TBA                                                            |
| AllUpgrades            | TBA                                                            |
| ButtonUnlocked         | TBA                                                            |
| ButtonUnlocker         | TBA                                                            |
| CandiesByPlayer        | TBA                                                            |
| CandiesTaken           | TBA                                                            |
| ChaosKills             | TBA                                                            |
| DamageByPlayer         | TBA                                                            |
| DamageByType           | TBA                                                            |
| DClassKills            | TBA                                                            |
| Detonated              | TBA                                                            |
| DetonationTime         | TBA                                                            |
| DoorsClosed            | TBA                                                            |
| DoorsDestroyed         | TBA                                                            |
| DoorsOpened            | TBA                                                            |
| Drops                  | TBA                                                            |
| EndTime                | TBA                                                            |
| FirearmUpgrades        | TBA                                                            |
| First330Use            | TBA                                                            |
| First330User           | TBA                                                            |
| First914Activation     | TBA                                                            |
| First914Activator      | TBA                                                            |
| FirstWarheadActivator  | TBA                                                            |
| HumanMVP               | TBA                                                            |
| HumanPoints            | TBA                                                            |
| KeycardScans           | TBA                                                            |
| KeycardUpgrades        | TBA                                                            |
| KillsByPlayer          | TBA                                                            |
| KillsByType            | TBA                                                            |
| MedkitsConsumed        | TBA                                                            |
| MTFKills               | TBA                                                            |
| PainkillersConsumed    | TBA                                                            |
| PlayerDamage           | TBA                                                            |
| PlayerDoorsClosed      | TBA                                                            |
| PlayerDoorsOpened      | TBA                                                            |
| PlayerDrops            | TBA                                                            |
| PlayerKills            | TBA                                                            |
| PointLogs              | TBA                                                            |
| Respawns               | TBA                                                            |
| RoundTime              | TBA                                                            |
| ScientistKills         | TBA                                                            |
| Scp018sThrown          | TBA                                                            |
| Scp096Charges          | TBA                                                            |
| Scp096Enrages          | TBA                                                            |
| Scp106Teleports        | TBA                                                            |
| Scp173Blinks           | TBA                                                            |
| Scp1853Uses            | TBA                                                            |
| Scp207sDrank           | TBA                                                            |
| Scp268Uses             | TBA                                                            |
| SCP500sConsumed        | TBA                                                            |
| SCPKills               | TBA                                                            |
| SCPMVP                 | TBA                                                            |
| SCPPoints              | TBA                                                            |
| SerpentsHandKills      | TBA                                                            |
| SeveredHands           | TBA                                                            |
| SpawnWaves             | TBA                                                            |
| StartClassD            | TBA                                                            |
| StartFacilityGuard     | TBA                                                            |
| StartPlayers           | TBA                                                            |
| StartScientist         | TBA                                                            |
| StartSCP               | TBA                                                            |
| StartTime              | TBA                                                            |
| SurvivingPlayers       | TBA                                                            |
| Total914Activations    | TBA                                                            |
| TotalCandiesTaken      | TBA                                                            |
| TotalDamage            | TBA                                                            |
| TotalDeaths            | TBA                                                            |
| TotalDrops             | TBA                                                            |
| TotalItemUpgrades      | TBA                                                            |
| TotalKills             | TBA                                                            |
| TotalReloads           | TBA                                                            |
| TotalRespawnedPlayers  | TBA                                                            |
| TotalShotsFired        | TBA                                                            |
| TutorialKills          | TBA                                                            |
| UIUKills               | TBA                                                            |
| WinningTeam            | TBA                                                            |
