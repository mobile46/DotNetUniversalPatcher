using DotNetUniversalPatcher.Utilities;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace DotNetUniversalPatcher.UI
{
    public partial class FrmAbout : Form
    {
        internal static FrmAbout Instance = new FrmAbout();

        internal string AboutScriptText;

        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AboutScriptText))
            {
                rtbAboutText.Text = AboutScriptText;
                btnShowAboutText.Visible = true;
            }
            else
            {
                rtbAboutText.Text = AboutDnupText();
                btnShowAboutText.Visible = false;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnShowAboutText_Click(object sender, EventArgs e)
        {
            if (btnShowAboutText.Text == "About DNUP")
            {
                btnShowAboutText.Text = "About Script";
                rtbAboutText.Text = AboutDnupText();
            }
            else
            {
                btnShowAboutText.Text = "About DNUP";
                rtbAboutText.Text = AboutScriptText;
            }
        }

        private void RtbAboutText_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch
            {
                // ignored
            }
        }

        private string AboutDnupText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Constants.TitleAndVersion);
            sb.AppendLine();
            sb.AppendLine("Author:");
            sb.AppendLine("Mobile46");
            sb.AppendLine();
            sb.AppendLine("Credits:");
            sb.AppendLine("0xd4d - dnlib");
            sb.AppendLine("ioncodes - dnpatch");
            sb.AppendLine("WiCKY Hu - Simple Assembly Explorer");
            sb.AppendLine("diablo2oo2 - dUP 2");
            sb.AppendLine("And many thanks to Yildo, Cyber, Forensic and You!");
            sb.AppendLine();
            sb.AppendLine("Github repo:");
            sb.AppendLine("https://github.com/mobile46/DotNetUniversalPatcher");
            sb.AppendLine();
            sb.AppendLine("Visit our Reverse Engineering forum:");
            sb.Append("http://decompile.us");

            return sb.ToString();
        }
    }
}