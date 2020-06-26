namespace WinForms.Forms.Games
{
    partial class MathTimedGame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathTimedGame));
            this.doneButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.answerPlusBox = new System.Windows.Forms.TextBox();
            this.aPlusLabel = new System.Windows.Forms.Label();
            this.plusLabel = new System.Windows.Forms.Label();
            this.bPlusLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.aMinusLabel = new System.Windows.Forms.Label();
            this.bMinusLabel = new System.Windows.Forms.Label();
            this.minusLabel = new System.Windows.Forms.Label();
            this.AnswerMinusBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            resources.ApplyResources(this.doneButton, "doneButton");
            this.doneButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.doneButton.Name = "doneButton";
            this.doneButton.UseVisualStyleBackColor = false;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            resources.ApplyResources(this.startButton, "startButton");
            this.startButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.startButton.Name = "startButton";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // answerPlusBox
            // 
            this.answerPlusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            resources.ApplyResources(this.answerPlusBox, "answerPlusBox");
            this.answerPlusBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.answerPlusBox.Name = "answerPlusBox";
            this.answerPlusBox.ShortcutsEnabled = false;
            this.answerPlusBox.TextChanged += new System.EventHandler(this.answerBox_TextChanged);
            // 
            // aPlusLabel
            // 
            resources.ApplyResources(this.aPlusLabel, "aPlusLabel");
            this.aPlusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.aPlusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.aPlusLabel.Name = "aPlusLabel";
            // 
            // plusLabel
            // 
            resources.ApplyResources(this.plusLabel, "plusLabel");
            this.plusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.plusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.plusLabel.Name = "plusLabel";
            // 
            // bPlusLabel
            // 
            resources.ApplyResources(this.bPlusLabel, "bPlusLabel");
            this.bPlusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.bPlusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.bPlusLabel.Name = "bPlusLabel";
            // 
            // timerLabel
            // 
            resources.ApplyResources(this.timerLabel, "timerLabel");
            this.timerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.timerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Click += new System.EventHandler(this.timerLabel_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // aMinusLabel
            // 
            resources.ApplyResources(this.aMinusLabel, "aMinusLabel");
            this.aMinusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.aMinusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.aMinusLabel.Name = "aMinusLabel";
            // 
            // bMinusLabel
            // 
            resources.ApplyResources(this.bMinusLabel, "bMinusLabel");
            this.bMinusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.bMinusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.bMinusLabel.Name = "bMinusLabel";
            // 
            // minusLabel
            // 
            resources.ApplyResources(this.minusLabel, "minusLabel");
            this.minusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.minusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.minusLabel.Name = "minusLabel";
            // 
            // AnswerMinusBox
            // 
            this.AnswerMinusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            resources.ApplyResources(this.AnswerMinusBox, "AnswerMinusBox");
            this.AnswerMinusBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.AnswerMinusBox.Name = "AnswerMinusBox";
            this.AnswerMinusBox.ShortcutsEnabled = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label8.Name = "label8";
            // 
            // MathTimedGame
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AnswerMinusBox);
            this.Controls.Add(this.minusLabel);
            this.Controls.Add(this.aMinusLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.bPlusLabel);
            this.Controls.Add(this.plusLabel);
            this.Controls.Add(this.aPlusLabel);
            this.Controls.Add(this.answerPlusBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.bMinusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MathTimedGame";
            this.Load += new System.EventHandler(this.MathTimedGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox answerPlusBox;
        private System.Windows.Forms.Label aPlusLabel;
        private System.Windows.Forms.Label plusLabel;
        private System.Windows.Forms.Label bPlusLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label aMinusLabel;
        private System.Windows.Forms.Label bMinusLabel;
        private System.Windows.Forms.Label minusLabel;
        private System.Windows.Forms.TextBox AnswerMinusBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}