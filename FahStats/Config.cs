#region Header
// FahStats >FahStats >Config.cs\n Copyright (C) Adonis Deliannis, 2020\nCreated 25 03, 2020
#endregion

using System;
using System.IO;
using System.Threading.Tasks;

namespace FahStats {
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Config
    {
        [JsonProperty("base-url")]
        public string BaseUrl { get; set; }

        [JsonProperty("base-team")]
        public int BaseTeam { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public partial class Config {
        private const string DefaultFile = "settings.json";

        private static Config _instance;
        internal static Config Instance => _instance;

        public Config() {
            _instance = this;
        }

        private static Config FromJson(string json) => JsonConvert.DeserializeObject<Config>(json, Converter.Settings);

        public static void New(string filename = DefaultFile) {
            new Config {Username = "Username", BaseTeam = 0, BaseUrl = "https://API/Url"}.Save();
        }
        
        public static async Task NewAsync(string filename = DefaultFile) {
            await new Config {Username = "Username", BaseTeam = 0, BaseUrl = "https://API/Url"}.SaveAsync();
        }

        [Obsolete("Consider using LoadAsync")]
        public static Config Load(string filename = DefaultFile) {
            if (!File.Exists(filename)) New();
            using var reader = new StreamReader(filename);
            string json = reader.ReadToEnd();
            if(json == null) throw new ArgumentNullException(nameof(json), "No Data");
            return FromJson(json);
        }

        public static async Task<Config> LoadAsync(string filename = DefaultFile) {
            if (!File.Exists(filename)) await NewAsync();
            using var reader = new StreamReader(filename);
            string json = await reader.ReadToEndAsync();
            if(json == null) throw new ArgumentNullException(nameof(json), "No Data");
            return FromJson(json);
        }

        public void Save(string filename = DefaultFile) {
            using var writer = new StreamWriter(filename);
            string json = this.ToJson();
            writer.WriteLine(json);
        }
        
        public async Task SaveAsync(string filename = DefaultFile) {
            await using var writer = new StreamWriter(filename);
            string json = this.ToJson();
            await writer.WriteLineAsync(json);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Config self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Formatting = Formatting.Indented,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}