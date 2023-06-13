using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baby_foot {

    public partial class BabyFoot : Form {

        public Match match;
        public Ball ball;
        public Team[] teams;
        public Goal[] goals;

        public BabyFoot() {
            InitializeComponent();
            this.ball = new Ball(this);
            this.Load += new System.EventHandler(this.BabyFoot_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BabyFootKeyDown);
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
        }

        public BabyFoot(Match match) : this() {
            this.match = match;
            score.Text = match.Participates[0].Name + ": " + match.Participates[0].Point 
            + "    " + match.Participates[1].Name + ": " + match.Participates[1].Point;
            InitTeams();
            InitGoals();
        }

        public void InitTeams() {
            this.teams = new Team[2];
            this.teams[0] = new Team(this, match.Participates[0], Brushes.Brown, 0);
            this.teams[1] = new Team(this, match.Participates[1], Brushes.Black, 1);
        }

        public void InitGoals() {
            this.goals = new Goal[2];
            this.goals[0] = new Goal(this, this.teams[1], area.Width / 2 - 50, 0, 100, 10);
            this.goals[1] = new Goal(this, this.teams[0], area.Width / 2 - 50, area.Height - 10, 100, 10);
        }

        public Point GetOrigin() {
            return new Point(area.Location.X, area.Location.Y);
        }

        public int GetWidthArea() {
            return area.Width;
        }

        public int GetHeightArea() {
            return area.Height;
        }

        // Create a timer with a two second interval.
        private void BabyFoot_Load(object sender, EventArgs e) {
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            try {    
                ball.Move();
                foreach (Goal goal in goals) {
                    if (goal.IsInGoal(ball)) {
                        goal.Team.owner.AddPoint();
                        score.Text = match.Participates[0].Name + ": " + match.Participates[0].Point + "    " + match.Participates[1].Name + ": " + match.Participates[1].Point;
                        ball.Reset();
                    }
                }
                area.Invalidate();
            } catch (GameOverException gameOver) {
                timer1.Stop();
                gameOver.winner.Win();
                match.Insert();
                MessageBox.Show(gameOver.winner.Name + " a gagné " + match.Prime + " Ariary");
                this.Close();
            }
        }

        private void area_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            // Create an area soccer
            g.FillRectangle(Brushes.White, 0, area.Height / 2 - 5, area.Width, 10);
            g.FillEllipse(Brushes.White, area.Width / 2 - 50, area.Height / 2 - 50, 100, 100);
            // Create a player
            foreach (Team team in teams) {
                int position = 0;
                foreach (BabyFootPlayer player in team.players) {
                    if (position == team.Position) g.FillPolygon(Brushes.LightGray, player.GetCurser());
                    g.FillEllipse(player.color, player.X, player.Y, player.GetDiametre(), player.GetDiametre());
                    position++;
                }
            }

            teams[0].reverseGoal();
            teams[1].reverseGoal();

            // Create Goals
            foreach (Goal goal in goals) g.FillRectangle(Brushes.Black, goal.X, goal.Y, goal.Width, goal.Height);
            // Create a ball
            g.FillEllipse(Brushes.Gray, (int) ball.X, (int) ball.Y, ball.GetDiametre(), ball.GetDiametre());
        }

        public void BabyFootKeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.M:
                    teams[0].ChangeCurser();
                    break;
                case Keys.Up:
                    teams[0].GetPlayersWithCurser().MoveVertical(-1);
                    break;
                case Keys.Down:
                    teams[0].GetPlayersWithCurser().MoveVertical(1);
                    break;
                case Keys.Right:
                    teams[0].GetPlayersWithCurser().MoveHorizontal(1);
                    break;
                case Keys.Left:
                    teams[0].GetPlayersWithCurser().MoveHorizontal(-1);
                    break;
                case Keys.S:
                    teams[1].GetPlayersWithCurser().MoveVertical(1);
                    break;
                case Keys.Z:
                    teams[1].GetPlayersWithCurser().MoveVertical(-1);
                    break;
                case Keys.Q:
                    teams[1].GetPlayersWithCurser().MoveHorizontal(-1);
                    break;
                case Keys.D:
                    teams[1].GetPlayersWithCurser().MoveHorizontal(1);
                    break;
                case Keys.Y:
                    teams[1].ChangeCurser();
                    break;
                case Keys.L:
                    teams[0].Move(0);
                    break;
                case Keys.T:
                    teams[1].Move(0);
                    break;
                case Keys.R:
                    teams[1].Move(1);
                    break;
                case Keys.K:
                    teams[0].Move(1);
                    break;
                // case Keys.N:
                //     teams[0].tiges[0].Number++;
                //     teams[0].tiges[0].players = teams[0].tiges[0].CreateBabyPlayerFoot();
                //     break;
                // case Keys.V:
                //     teams[1].tiges[0].Number++;
                //     teams[1].tiges[0].players = teams[1].tiges[0].CreateBabyPlayerFoot();
                //     break;
            }
        }
    }

}