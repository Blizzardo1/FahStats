#region Header
// FahStats >FahStats >Api.cs\n Copyright (C) Adonis Deliannis, 2020\nCreated 25 03, 2020
#endregion

using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace FahStats {
    public static class Api {

        private static async Task< dynamic > Call(string api, Dictionary< string, object > args = null) =>
            await Config.Instance.BaseUrl.AppendPathSegment(api).SetQueryParams(args ?? new Dictionary< string, object >()).GetJsonAsync();

        public static async Task< dynamic >
            GetDonors(SearchType type, string name, int team = 0, string passkey = "") =>
            await Call("api/donors",
                       new Dictionary< string, object > {
                           {"search_type", type.GetString()},
                           {"name", name},
                           {"passkey", passkey},
                           {"team", team}
                       });

        public static async Task< dynamic >
            GetMonthlyDonors(SearchType type, string name, int team, int month, int year, string passkey = "") =>
            await Call("api/donors-monthly",
                       new Dictionary< string, object > {
                           {"search_type", type.GetString()},
                           {"name", name},
                           {"passkey", passkey},
                           {"team", team},
                           {"month", month},
                           {"year", year}
                       });

        public static async Task< dynamic >
            GetDonor(int donor) =>
            await Call($"api/donor/{donor}");
        
        public static async Task< dynamic >
            GetTeams(SearchType type, string name, int team = 0, string passkey = "") =>
            await Call("api/teams",
                       new Dictionary< string, object > {
                           {"search_type", type.GetString()},
                           {"name", name},
                           {"passkey", passkey},
                           {"team", team}
                       });

        public static async Task< dynamic >
            GetMonthlyTeams(SearchType type, string name, int team, int month, int year, string passkey = "") =>
            await Call("api/teams-monthly",
                       new Dictionary< string, object > {
                           {"search_type", type.GetString()},
                           {"name", name},
                           {"passkey", passkey},
                           {"team", team},
                           {"month", month},
                           {"year", year}
                       });

        public static async Task< dynamic >
            GetTeam(int team) =>
            await Call($"api/team/{team}");

        public static async Task< dynamic >
            GetOs() =>  await Call("api/os");

    }
}