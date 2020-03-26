#region Header
// FahStats >FahStats >Extensions.cs\n Copyright (C) Adonis Deliannis, 2020\nCreated 25 03, 2020
#endregion

using System;

namespace FahStats {
    public static class Extensions {
        
        /// <summary>
        /// Gets the string within the <see cref="SearchType"/> enumeration
        /// </summary>
        /// <param name="searchType"></param>
        /// <returns></returns>
        public static string GetString(this SearchType searchType) => searchType switch {
            SearchType.Exact => "exact",
            SearchType.Prefix => "prefix",
            SearchType.Like => "like",
            _ => ""
        };
    }
}