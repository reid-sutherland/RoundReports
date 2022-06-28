﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Exiled.API.Features;
using NorthwoodLib.Pools;
using System.ComponentModel;
using MEC;
using UnityEngine.Networking;

namespace RoundReports
{
    public class Reporter
    {
        public SortedSet<IReportStat> Stats { get; set; }
        private string _webhook;
        public bool HasSent { get; private set; } = false;

        public Reporter(string webhookUrl)
        {
            _webhook = webhookUrl;
            Stats = new SortedSet<IReportStat>();
        }

        public string BuildReport()
        {
            var builder = StringBuilderPool.Shared.Rent();

            // First Row
            builder.AppendLine($"{MainPlugin.Singleton.Config.ServerName} - Round #{Round.UptimeRounds} | Start Time: {Round.StartedTime.ToString("MMMM dd, yyyy HH:mm:ss")} | Length: {Round.ElapsedTime.Minutes}m{Round.ElapsedTime.Seconds}s");

            // Stats
            foreach (var stat in Stats)
            {
                Type type = stat.GetType();
                builder.AppendLine();
                builder.AppendLine($"{stat.Title}:");
                foreach (PropertyInfo pinfo in type.GetProperties())
                {
                    if (pinfo.Name == "Title") continue;
                    var attr = pinfo.GetCustomAttribute<DescriptionAttribute>();
                    if (attr is not null)
                    {
                        builder.AppendLine($"{attr.Description}: {pinfo.GetValue(stat)}");
                    }
                }
            }

            Stats.Clear();

            // Conclude
            string result = builder.ToString();
            StringBuilderPool.Shared.Return(builder);
            return result;
        }

        public void SendReport()
        {
            HasSent = true;
            Timing.RunCoroutine(_SendReport());
        }

        private IEnumerator<float> _SendReport()
        {
            var pasteWWW = UnityWebRequest.Put("http://hastebin.com/documents", BuildReport());
            pasteWWW.method = "POST";
            yield return Timing.WaitUntilDone(pasteWWW.SendWebRequest());
            if (!pasteWWW.isHttpError && !pasteWWW.isNetworkError)
            {
                Log.Info("Report posted! " + pasteWWW.downloadHandler.text);
            }
            else
            {
                Log.Warn($"Report failed to post! {pasteWWW.error}");
            }
        }
    }
}
