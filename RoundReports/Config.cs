﻿using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EBroadcast = Exiled.API.Features.Broadcast;

namespace RoundReports
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is active.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not to show debug logs.")]
        public bool Debug { get; set; } = false;

        [Description("Your Paste.ee key. Get this from https://paste.ee/account/api after creating a paste.ee account. The plugin cannot function without a valid Pastee key!")]
        public string PasteKey { get; set; } = "";

        [Description("Time until reports expire. Valid values: Never, 1H, 12H, 1D, 3D, 7D, 14D, 1M, 2M, 3M, 6M, 1Y, 2Y")]
        public string ExpiryTime { get; set; } = "1M";

        [Description("Provide a Discord webhook to send reports to.")]
        public string DiscordWebhook { get; set; } = string.Empty;
        [Description("Send report links in server console when compiled?")]
        public bool SendInConsole { get; set; } = true;
        [Description("If set to true, users with Do Not Track enabled will be excluded from all stats entirely. If set to false, they will be included with a removed name (including in round remarks). See the plugin's GitHub page for more information.")]
        public bool ExcludeDNTUsers { get; set; } = false;
        [Description("If set to true, stats from tutorial users will be entirely ignored. Does not affect Serpent's Hand (if installed).")]
        public bool ExcludeTutorials { get; set; } = true;

        [Description("Hint to show to a player when they gain points (MVP system).")]
        public Hint MvpAddHint { get; set; } = new Hint
        {
            Content = "+{POINTS} points\nReason: {REASON}",
            Duration = 2f,
            Show = true,
        };

        [Description("Hint to show to a player when they lose points (MVP system).")]
        public Hint MvpRemoveHint { get; set; } = new Hint
        {
            Content = "-{POINTS} points\nReason: {REASON}",
            Duration = 2f,
            Show = true,
        };

        [Description("Broadcast(s) to show at the end of the round. A full list of arguments are available on the plugin's GitHub page. Set to [] (or set broadcast's show value to false) to disable. Additional broadcasts can be added and removed.")]
        public List<EBroadcast> EndingBroadcasts { get; set; } = new List<EBroadcast> { new("<b>{HUMANMVP}</b> was the human MVP of this round!", duration: 3), new("<b>{SCPMVP}</b> was the SCP MVP of this round!", duration: 3), new("View the end-of-round report on our Discord server!", duration: 3) };

        [Description("Name of the server, without any formatting tags, as it will be shown in the report.")]
        public string ServerName { get; set; } = string.Empty;

        [Description("Settings for the Discord message.")]
        public DiscordConfig DiscordSettings { get; set; } = new();

        [Description("Determines the format of timestamps.")]
        public string FullTimeFormat { get; set; } = "MMMM dd, yyyy hh:mm:ss tt";
        public string ShortTimeFormat { get; set; } = "HH:mm:ss";
        [Description("Determine which statistics are NOT included in the report. Some stats will only be shown if applicable (eg. Serpent's Hand kills will only show if the server has Serpent's Hand installed).")]
        public List<StatType> IgnoredStats { get; set; } = new();
        [Description("A list of players (by user id) who will be ignored from stats, regardless of their do not track setting. For single-player stats (eg. warhead button opener) and kill logs, they will be shown as a do not track player.")]
        public List<string> IgnoredUsers { get; set; } = new() { "12345@steam" };
    }
}
