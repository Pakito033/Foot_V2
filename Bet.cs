using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baby_foot
{
    public partial class Bet : Form
    {
        public Bet()
        {
            InitializeComponent();

            Player[] players = Player.GetAll();

            comboBoxJoueur1.AccessibleRole = AccessibleRole.None;
            comboBoxJoueur1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJoueur1.FormattingEnabled = true;
            comboBoxJoueur1.DisplayMember = "name";
            comboBoxJoueur1.DataSource = players;

            comboBoxJoueur2.BindingContext = new BindingContext();
            comboBoxJoueur2.AccessibleRole = AccessibleRole.None;
            comboBoxJoueur2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJoueur2.FormattingEnabled = true;
            comboBoxJoueur2.DisplayMember = "name";
            comboBoxJoueur2.DataSource = players;
        }

        private void AddMatch(object sender, EventArgs e)
        {
            try {
                string[] bets = {textBoxJoueur1.Text, textBoxJoueur2.Text};
                Player[] players = {(Player) comboBoxJoueur1.SelectedItem,(Player) comboBoxJoueur2.SelectedItem};
                Match match = new Match(bets, players);
                BabyFoot baby = new BabyFoot(match);
                baby.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddPlayer(object sender, EventArgs e)
        {
            try {
                FormPlayer newplayer = new FormPlayer();
                Thread newPlayerFormThread = new Thread(delegate() {
                    Application.Run(newplayer);
                });
                newPlayerFormThread.SetApartmentState(ApartmentState.STA);
                newPlayerFormThread.Start();
                Thread.Sleep(300);
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
