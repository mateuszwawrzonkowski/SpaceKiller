namespace Space_Killer
{
    partial class SpaceKillerGame
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceKillerGame));
            this.MoveBgTimer = new System.Windows.Forms.Timer(this.components);
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.Score_label = new System.Windows.Forms.Label();
            this.LaserTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.EnemiesTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // MoveBgTimer
            // 
            this.MoveBgTimer.Enabled = true;
            this.MoveBgTimer.Interval = 10;
            this.MoveBgTimer.Tick += new System.EventHandler(this.MoveBgTimer_Tick);
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Enabled = true;
            this.LeftMoveTimer.Interval = 10;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Enabled = true;
            this.RightMoveTimer.Interval = 10;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // Score_label
            // 
            this.Score_label.AutoSize = true;
            this.Score_label.BackColor = System.Drawing.Color.Transparent;
            this.Score_label.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Score_label.ForeColor = System.Drawing.Color.Silver;
            this.Score_label.Location = new System.Drawing.Point(12, 9);
            this.Score_label.Name = "Score_label";
            this.Score_label.Size = new System.Drawing.Size(44, 18);
            this.Score_label.TabIndex = 0;
            this.Score_label.Text = "Score";
            // 
            // LaserTimer
            // 
            this.LaserTimer.Enabled = true;
            this.LaserTimer.Interval = 10;
            this.LaserTimer.Tick += new System.EventHandler(this.LaserTimer_Tick);
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerNameLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayerNameLabel.ForeColor = System.Drawing.Color.Silver;
            this.PlayerNameLabel.Location = new System.Drawing.Point(12, 41);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(44, 18);
            this.PlayerNameLabel.TabIndex = 1;
            this.PlayerNameLabel.Text = "Score";
            // 
            // EnemiesTimer
            // 
            this.EnemiesTimer.Enabled = true;
            this.EnemiesTimer.Interval = 15;
            this.EnemiesTimer.Tick += new System.EventHandler(this.EnemiesTimer_Tick);
            // 
            // SpaceKillerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.Score_label);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "SpaceKillerGame";
            this.Text = "Space Killer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Label Score_label;
        private System.Windows.Forms.Timer LaserTimer;
        private System.Windows.Forms.Timer MoveBgTimer;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Timer EnemiesTimer;
    }
}

