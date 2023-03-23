using StreamCompanionTypes.Interfaces;
using StreamCompanionTypes.Enums;
using StreamCompanionTypes.Interfaces.Services;
using StreamCompanionTypes.Interfaces.Consumers;
using StreamCompanionTypes.Interfaces.Sources;
using StreamCompanionTypes.DataTypes;
using DiscordRPC;

//This plugin makes heavy use of discord-rpc-csharp by Lachee: https://github.com/Lachee/discord-rpc-csharp

namespace RPCCompanion
{
    public class RPCCompanion : IPlugin, ITokensSource, IMapDataConsumer, ISettingsSource
    {
        public string Description => "Provides detailed Rich Presence for osu! (Game invites not supported)";
        public string Name => "RPCCompanion v230323.00";
        public string Author => "NateOnLinux";
        public string Url => "https://github.com/NateOnLinux";
        public string SettingGroup => "Discord Rich Presence";

        private DiscordClient discordClient = new DiscordClient();
        private RPCCompanionSettings _rpcCompanionSettings;
        private Tokens.TokenSetter tokenSetter;
        private readonly RPCConfig _rpcConfig = new RPCConfig();
        private ISettings _settings;
        public static ILogger Logger;
        private protected string tkn { get; set; }
        Dictionary<string, string> rawStatusMapping = new Dictionary<string, string>() //map rawStatus token values to useful descriptions
            {
                { "MainMenu", "Main Menu" },
                { "SongSelect", "Song Select" },
                { "SongSelectEdit", "Editor Song Select" },
                { "OsuDirect", "Browsing osu!Direct" },
                { "MultiplayerRooms", "Multiplayer Lobby" },
                { "MultiplayerRoom", "Waiting for match to start" },
                { "MultiplayerResultsscreen", "Waiting for match to start" },
                { "MultiplayerSongSelect", "Waiting for match to start" }
            };

        public RPCCompanion(ISettings settings, ILogger logger)
        {
            _settings = settings;
            Logger = logger;
            tokenSetter = Tokens.CreateTokenSetter("RPCCompanion");
        }

        public Task CreateTokensAsync(IMapSearchResult map, CancellationToken cancellationToken)
        {
            tokenSetter("rpcPluginEnabled", _settings.Get<bool>(_rpcConfig.enableRPC), TokenType.Normal, null, "default value", OsuStatus.All);
            tokenSetter("rpcClientInitialized", discordClient.Initialized, TokenType.Normal, null, "default value", OsuStatus.All);
            tokenSetter("rpcDetailedMode", _settings.Get<bool>(_rpcConfig.Detailed), TokenType.Normal, null, "default value", OsuStatus.All);
            tokenSetter("rpcProfileLink", _settings.Get<string>(_rpcConfig.ProfileLink), TokenType.Normal, null, "default value", OsuStatus.All);
            return Task.CompletedTask;
        }

        public void Free()
        {
            _rpcCompanionSettings?.Dispose();
        }

        public object GetUiSettings()
        {
            if(_rpcCompanionSettings == null || _rpcCompanionSettings.IsDisposed)
                _rpcCompanionSettings = new RPCCompanionSettings(_settings);
            return _rpcCompanionSettings;
        }

        public Task SetNewMapAsync(IMapSearchResult map, CancellationToken cancellationToken)
        {
            if (discordClient.Initialized == false && _settings.Get<bool>(_rpcConfig.enableRPC) == true)
            {
                discordClient.Init();
                Logger.Log($@"RPC Initialized", LogLevel.Trace);
                Task.Run(() => RPCUpdater());
            }
            else if (discordClient.Initialized == true && _settings.Get<bool>(_rpcConfig.enableRPC) == false)
            {
                discordClient.Kill();
                Logger.Log($@"RPC Disposed", LogLevel.Trace);
            }
            return Task.CompletedTask;
        }

        private protected Task RPCUpdater()
        {
            while (discordClient.Initialized)
            {
                discordClient.Update(PresenceBuilder(_settings.Get<bool>(_rpcConfig.Detailed), Tkn("status")));
                Thread.Sleep(1000); //This can be any number
            }
            return Task.CompletedTask;
        }
        
        private protected string Tkn(string tknName)
        {
            if (tknName is null)
            {
                return "0";
            }
            else if(Tokens.AllTokens[tknName].Value is null)
            {
                return "0";
            }
            else
            {
                return Tokens.AllTokens[tknName].Value.ToString()!;
            }
        }
        public struct StateType
        {
            public StateType(bool detailed, string status) => (Detailed, Status) = (detailed, status);

            public bool Detailed { get; }
            public string Status { get; }
        }
        public string RawStatusMapping(IDictionary<string, string> mapping, string rawStatus) 
        {
            return mapping[rawStatus];
        }

        /// <summary>
        /// Creates the RichPresence object to be sent to Discord API
        /// </summary>
        /// <param name="detailed"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        private protected RichPresence PresenceBuilder(bool detailed, string status)
        {
            int? circles = int.Parse(Tkn("circles"));
            int? sliders = int.Parse(Tkn("sliders"));
            int? spinners = int.Parse(Tkn("spinners"));
            string acc = Tkn("acc") + "%";
            string c100 = Tkn("c100");
            string c50 = Tkn("c50");
            string miss = Tkn("miss");
            string currentMaxCombo = Tkn("currentMaxCombo") + "x";
            string mBpm = Tkn("mBpm");
            string mods = Tkn("mods").Replace("None", "NoMod");
            string diff = Tkn("mapDiff");
            string mapArtistTitle = Tkn("mapArtistTitle");
            string username = Tkn("username");
            string gameMode = Tkn("gameMode");
            string ppIfMapEndsNow = Tkn("ppIfMapEndsNow");
            string osu_mSSPP = Tkn("osu_mSSPP");
            string mania_m1_000_000PP = Tkn("mania_m1_000_000PP");
            string? details;
            string? state;
            string largeImageKey = "osupng";
            string largeImageText;
            string smallImageKey = "stopwatch";
            string smallImageText;
            string rpcProfileLink = Tkn("rpcProfileLink");
            string dl = Tkn("dl");
            StateType State = new StateType(detailed, status);
            details = status switch //Details - same for Detailed and Minimal
            {
                "Listening" => $"Listening to {mapArtistTitle}",
                "Editing" => $"Editing {mapArtistTitle} + {diff}",
                "Watching" => $"Spectating {username}", // Map info moved to State while spectating. To-do: Add check for "Watching" vs "Spectating" 
                _ => mapArtistTitle + diff
            };
            state = State switch // Struct allows changes based on combined detail and status (This will be relevant in future)
            {
                { Detailed: true, Status: "Listening" } => RawStatusMapping(rawStatusMapping, Tkn("rawStatus")),
                { Detailed: false, Status: "Listening" } => RawStatusMapping(rawStatusMapping, Tkn("rawStatus")),
                { Detailed: true, Status: "Editing" } => $"Objects: {circles + sliders + spinners}",
                { Detailed: false, Status: "Editing" } => $"Objects: {circles + sliders + spinners}",
                { Detailed: true, Status: "Watching" } => $"{mapArtistTitle} {diff}", // Map info moved to State while spectating
                { Detailed: false, Status: "Watching" } => $"{mapArtistTitle} {diff}",
                { Detailed: false, Status: "Playing" } => mods,
                _ => $"{mods} | {acc} | {c100}/{c50}/{miss} | {currentMaxCombo}"
            };
            largeImageText = status switch
            {
                "Watching" => $"Spectating {username}",
                "ResultsScreen" => $"Results Screen",
                _ => status
            };
            smallImageText = status switch
            {
                "Listening" => "Idle",
                "Editing" => mBpm + " BPM",
                _ => (Math.Round(Convert.ToDouble(ppIfMapEndsNow)))+ "pp"
            };
            DiscordRPC.Button myProfile = new DiscordRPC.Button() { Label = "My Profile", Url = rpcProfileLink };
            DiscordRPC.Button dlButton = new DiscordRPC.Button() { Label = "Map Link", Url = dl };

            if (detailed)
            {
                return new RichPresence()
                {
                    Details = details,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageText,
                        SmallImageKey = smallImageKey,
                        SmallImageText = smallImageText,
                    },
                    Buttons = new DiscordRPC.Button[]
                    {
                        myProfile,
                        dlButton
                    }
                };
            }
            else
            {
                return new RichPresence()
                {
                    Details = details,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = largeImageKey,
                        LargeImageText = largeImageText,
                        SmallImageKey = smallImageKey,
                        SmallImageText = smallImageText,
                    },
                };
            }
        }
    }
}
