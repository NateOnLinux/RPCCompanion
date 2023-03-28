using System;
using System.Diagnostics;
using StreamCompanionTypes.Interfaces.Services;
using StreamCompanionTypes.DataTypes;

namespace RPCCompanion
{
    public partial class RPCCompanionSettings : UserControl
    {
        private readonly RPCConfig _RPCConfig = new RPCConfig();
        private ISettings _settings;
        private bool init = true;
        public RPCCompanionSettings(ISettings settings)
        {
            _settings = settings;
            InitializeComponent();
            checkBox_EnableRPC.Checked = _settings.Get<bool>(_RPCConfig.enableRPC);
            radioButton_Detailed.Checked = _settings.Get<bool>(_RPCConfig.Detailed);
            radioButton_Minimal.Checked = !radioButton_Detailed.Checked;
            radioButton_Akatsuki.Checked = (_settings.Get<string>(_RPCConfig.Server) == "Akatsuki");
            radioButton_Ripple.Checked = (_settings.Get<string>(_RPCConfig.Server) == "Ripple");
            radioButton_Bancho.Checked = (_settings.Get<string>(_RPCConfig.Server) == "Bancho");
            if (int.Parse(Tokens.AllTokens["osuIsRunning"].Value.ToString()!) == 0) { label_NotRunningWarn.Visible = true; }
            init = false;
        }

        private void checkBox_EnableRPC_CheckedChanged(object sender, EventArgs e) //read checkbox state (default false)
        {
            if (init) return;
            _settings.Add(_RPCConfig.enableRPC.Name, checkBox_EnableRPC.Checked);
        }

        private void radioButton_Detailed_CheckedChanged(object sender, EventArgs e) //read radiobutton state (default "Detailed"). This is not scalable but it works
        {
            if (init) return;
            _settings.Add(_RPCConfig.Detailed.Name, radioButton_Detailed.Checked);
        }

        private void radioButtons_Server_CheckChanged(object sender, EventArgs e)
        {
            var server = (RadioButton)sender;
            switch (server.Tag)
            {
                case ("Akatsuki"):
                    _settings.Add(_RPCConfig.Server.Name, "Akatsuki");
                    break;
                case ("Ripple"):
                    _settings.Add(_RPCConfig.Server.Name, "Ripple");
                    break;
                case ("Bancho"):
                default:
                    _settings.Add(_RPCConfig.Server.Name, "Bancho");
                    break;
            }
        }

        private void versionLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/NateOnLinux/RPCCompanion/releases/tag/Latest");
        }

        private void bugLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/NateOnLinux/RPCCompanion/issues");
        }
    }

    public sealed class RPCConfig
    {
        public readonly ConfigEntry enableRPC = new ConfigEntry("Enable RPC", false);
        public readonly ConfigEntry Detailed = new ConfigEntry("Detailed", true);
        public readonly ConfigEntry Server = new ConfigEntry("Server", "Bancho");
        public readonly ConfigEntry ProfileLink = new ConfigEntry("Profile Link", "https://osu.ppy.sh/");
    }
}
