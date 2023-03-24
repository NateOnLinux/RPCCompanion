using DiscordRPC;
using DiscordRPC.Logging;

namespace RPCCompanion
{
    internal class DiscordClient
    {
        private static DiscordRpcClient discordClient = new DiscordRpcClient("968383549399003169");
        public bool Initialized { get; private set; } = false;
        public void Init()
        {
            discordClient.Logger = new ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning };
            try
            {
                discordClient.Initialize();
                Initialized = true;
            }
            catch (Exception ex)
            {
                if(discordClient.IsInitialized) // Still trying to figure out what causes this state (RPC client is running, but Initialized = false). Happened a few times, this is just a bandaid
                {
                    RPCCompanion.Logger.Log("The client is already initialized. Error:" + ex, StreamCompanionTypes.Enums.LogLevel.Trace);
                    Initialized = true;
                }
            }
        }
        public void Kill() // Dispose RPC client & set Initialized = false so a new RPC client can be created later
        {
            discordClient.Dispose();
            Initialized = false;
        }
        public void Update(RichPresence rpcType) // Sends new rich presence data once. If failed then it just logs an Error and continues. 
        {
            try
            {
                discordClient.SetPresence(rpcType);
            }
            catch (Exception ex)
            {
                RPCCompanion.Logger.Log(ex, StreamCompanionTypes.Enums.LogLevel.Error);
            }
        }
    }
}