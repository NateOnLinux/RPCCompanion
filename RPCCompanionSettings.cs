using System;
using StreamCompanionTypes.Interfaces.Services;
using StreamCompanionTypes.DataTypes;
using System.Text.RegularExpressions;
using StreamCompanionTypes.Enums;
using static System.Net.WebRequestMethods;

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
            profileLinkTb.Text = _settings.Get<string>(_RPCConfig.ProfileLink);
            //profileLinkTb.Text = _settings.Get<object>(_RPCConfig.ProfileLink).ToString() is not null ? _settings.Get<object>(_RPCConfig.ProfileLink).ToString() : "https://osu.ppy.sh/users/";
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

        private void profileLinkTb_TextChanged(object sender, EventArgs e)
        {
            CheckURL(@"^(((http|https)://)((old|osu).ppy.sh/users/)(\d+))$", profileLinkTb);
        }

        private void CheckURL(string check, TextBox tb)
        {
            Regex regex = new Regex(check);
            if (regex.IsMatch(tb.Text))
            {
                tb.ForeColor = Color.Green;
                _settings.Add(_RPCConfig.ProfileLink.Name, tb.Text);
            }
            else
                tb.ForeColor = Color.Red;
        }
    }

    public sealed class RPCConfig
    {
        public readonly ConfigEntry enableRPC = new ConfigEntry("Enable RPC", false);
        public readonly ConfigEntry Detailed = new ConfigEntry("Detailed", true);
        public readonly ConfigEntry ProfileLink = new ConfigEntry("Profile Link", "https://osu.ppy.sh/");
    }
}
