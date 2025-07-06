using System;

namespace RoundReports;

/// <summary>
/// Tells the reporter to not show a stat.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class HideAttribute : Attribute
{
}