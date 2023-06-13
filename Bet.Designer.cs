namespace baby_foot
{
    partial class Bet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxJoueur1 = new TextBox();
            textBoxJoueur2 = new TextBox();
            comboBoxJoueur1 = new ComboBox();
            comboBoxJoueur2 = new ComboBox();
            start = new Button();
            newplayer = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBoxJoueur1
            // 
            textBoxJoueur1.Location = new Point(52, 236);
            textBoxJoueur1.Name = "textBoxJoueur1";
            textBoxJoueur1.Size = new Size(242, 39);
            textBoxJoueur1.TabIndex = 2;
            // 
            // textBoxJoueur2
            // 
            textBoxJoueur2.Location = new Point(503, 236);
            textBoxJoueur2.Name = "textBoxJoueur2";
            textBoxJoueur2.Size = new Size(242, 39);
            textBoxJoueur2.TabIndex = 3;
            // 
            // comboBoxJoueur1
            // 
            comboBoxJoueur1.FormattingEnabled = true;
            comboBoxJoueur1.Location = new Point(52, 167);
            comboBoxJoueur1.Name = "comboBoxJoueur1";
            comboBoxJoueur1.Size = new Size(242, 40);
            comboBoxJoueur1.TabIndex = 0;
            // 
            // comboBoxJoueur2
            // 
            comboBoxJoueur2.FormattingEnabled = true;
            comboBoxJoueur2.Location = new Point(503, 167);
            comboBoxJoueur2.Name = "comboBoxJoueur2";
            comboBoxJoueur2.Size = new Size(242, 40);
            comboBoxJoueur2.TabIndex = 4;
            // 
            // start
            // 
            start.Location = new Point(420, 350);
            start.Name = "start";
            start.Size = new Size(213, 46);
            start.TabIndex = 5;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += AddMatch;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(330, 64);
            label1.Name = "label1";
            label1.Size = new Size(185, 32);
            label1.TabIndex = 6;
            label1.Text = "New Match";
            // 
            // new_player
            //
            newplayer.Location = new Point(180, 350);
            newplayer.Name = "newplayer";
            newplayer.Size = new Size(213, 46);
            newplayer.TabIndex = 7;
            newplayer.Text = "new player";
            newplayer.UseVisualStyleBackColor = true;
            newplayer.Click += AddPlayer;
            // 
            // Bet
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(start);
            Controls.Add(comboBoxJoueur2);
            Controls.Add(textBoxJoueur2);
            Controls.Add(textBoxJoueur1);
            Controls.Add(comboBoxJoueur1);
            Controls.Add(newplayer);
            Name = "Bet";
            Text = "Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxJoueur1;
        private TextBox textBoxJoueur2;
        private ComboBox comboBoxJoueur1;
        private ComboBox comboBoxJoueur2;
        private Button start;
        private Button newplayer;
        private Label label1;
    }
}