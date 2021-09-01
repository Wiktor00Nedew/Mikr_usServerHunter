using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MikrusHunter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NotifyIcon notify = new NotifyIcon();

        private void Form1_Load(object sender, EventArgs e)
        {
            Visible = false;
            bool isServerExisting = false;
            Client webClient = new Client();

            //webClient.getFile("https://mikr.us/recykling.txt");

            isServerExisting = webClient.checkForServer();

            if (isServerExisting)
            {
                setMessageContent("Serwer dostępny", "Serwer 3.0, któremu zostało więcej niż 180 dni jest dostępny!");
            }
            else
            {
                setMessageContent("Serwer niedostępny", "Brak szukanego serwera 3.0");
            }

            notify.Visible = true;
            notify.ShowBalloonTip(30000);

            Application.Exit();
        }

        private void setMessageContent(string title, string text)
        {
            notify.Icon = SystemIcons.Information;
            notify.BalloonTipTitle = title;
            notify.BalloonTipText = text;
            notify.BalloonTipIcon = ToolTipIcon.Info;
        }
    }
}
