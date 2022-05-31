using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class GoalComponentSettings : UserControl
    {

        public Color BackgroundColor { get; set; }

        public Color TextColor { get; set; }

        public Font TextFont { get; set; }

        public LayoutMode Mode { get; set; }

        public LiveSplitState CurrentState { get; set; }

        public GoalComponentSettings()
        {
            InitializeComponent();

            BackgroundColor = Color.FromArgb(0, 0, 0);
            TextColor = Color.FromArgb(255, 255, 255);

            button1.DataBindings.Add("BackColor", this, "BackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            button2.DataBindings.Add("BackColor", this, "TextColor", false, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void GoalComponentSettings_Load(object sender, EventArgs e)
        {

            if (Mode == LayoutMode.Horizontal)
            {

            }
            else
            {

            }

        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0.0") ^
            SettingsHelper.CreateSetting(document, parent, "BackgroundColor", BackgroundColor) ^
            SettingsHelper.CreateSetting(document, parent, "TextColor", TextColor);
        }

        internal XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        internal void SetSettings(XmlNode node)
        {
            var element = (XmlElement) node;
            BackgroundColor = SettingsHelper.ParseColor(element["BackgroundColor"]);
            TextColor = SettingsHelper.ParseColor(element["TextColor"]);
        }

        public int GetSettingsHashCode() => CreateSettingsNode(null, null);

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsHelper.ColorButtonClick((Button) sender, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SettingsHelper.ColorButtonClick((Button) sender, this);
        }
    }
}
