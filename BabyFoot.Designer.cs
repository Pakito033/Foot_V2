namespace baby_foot
{
    partial class BabyFoot
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            area = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            score = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)area).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(score);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(area);
            splitContainer1.Size = new Size(1379, 1185);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 0;
            // 
            // area
            // 
            area.BackColor = Color.SeaGreen;
            area.Location = new Point(50, 0);
            area.Name = "area";
            area.Size = new Size(713, 1054);
            area.TabIndex = 0;
            area.TabStop = false;
            area.Paint += area_Paint;
            // 
            // score
            // 
            score.AutoSize = true;
            score.Location = new Point(79, 300);
            score.Name = "score";
            score.Size = new Size(297, 32);
            score.TabIndex = 0;
            score.Text = "Joueur 1 : 0     Joueur 2 : 0";
            // 
            // BabyFoot
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1379, 1185);
            Controls.Add(splitContainer1);
            Name = "BabyFoot";
            Text = "Baby Foot";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)area).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox area;
        private System.Windows.Forms.Timer timer1;
        private Label score;
    }
}