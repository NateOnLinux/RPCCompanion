using StreamCompanionTypes.Interfaces;
using StreamCompanionTypes.Enums;
using StreamCompanionTypes.Interfaces.Services;
using StreamCompanionTypes.Interfaces.Consumers;
using StreamCompanionTypes.Interfaces.Sources;
using StreamCompanionTypes.DataTypes;
using DiscordRPC;

namespace RPCCompanion
{
    public class RPCCompanion : IPlugin, ITokensSource, IMapDataConsumer, ISettingsSource
    {
        public string Description => "Provides detailed Rich Presence for osu! (Game invites not supported)";
        public string Name => "RPCCompanion v230324.01";
        public string Author => "NateOnLinux";
        public string Url => "https://github.com/NateOnLinux/rpcCompanion";
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
                discordClient.Update(PresenceBuilder(_settings.Get<bool>(_rpcConfig.Detailed), TokenParser("status")));
                Thread.Sleep(1000); //This can be any number
            }
            return Task.CompletedTask;
        }
        
        private protected string TokenParser(string tknName)
        {
            if (Tokens.AllTokens.TryGetValue(tknName, out var token))
            {
                if (token.Value is not null)
                    return token.Value.ToString();
                else
                    return "No token data found";
            }
            else
                return "Invalid token name";
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
            int? circles = int.Parse(TokenParser("circles"));
            int? sliders = int.Parse(TokenParser("sliders"));
            int? spinners = int.Parse(TokenParser("spinners"));
            string acc = TokenParser("acc") + "%";
            string c100 = TokenParser("c100");
            string c50 = TokenParser("c50");
            string miss = TokenParser("miss");
            string currentMaxCombo = TokenParser("currentMaxCombo") + "x";
            string mBpm = TokenParser("mBpm");
            string mods = TokenParser("mods").Replace("None", "NoMod");
            string diff = TokenParser("mapDiff");
            string mapArtistTitle = TokenParser("mapArtistTitle");
            string username = TokenParser("username");
            string gameMode = TokenParser("gameMode");
            string ppIfMapEndsNow = TokenParser("ppIfMapEndsNow");
            string? details;
            string? state;
            string largeImageKey = "osupng";
            string largeImageText;
            string smallImageKey;
            string smallImageText;
            string rpcProfileLink = TokenParser("rpcProfileLink");
            string dl = TokenParser("dl");
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
                { Detailed: true, Status: "Listening" } => RawStatusMapping(rawStatusMapping, TokenParser("rawStatus")),
                { Detailed: false, Status: "Listening" } => RawStatusMapping(rawStatusMapping, TokenParser("rawStatus")),
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
            if (TokenParser("rawStatus") != "NotRunning" || TokenParser("rawStatus") is not null)
                smallImageKey = status switch
                {
                    "Listening" => "idle",
                    _ => gameMode.ToLower()
                };
            else
            {
                smallImageText = "Not running";
                smallImageKey = "idle";
            }
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
