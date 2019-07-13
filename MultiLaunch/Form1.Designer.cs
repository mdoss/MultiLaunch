namespace MultiLaunch
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerCheckRunning = new System.Windows.Forms.Timer(this.components);
            this.btnDebugButtons = new System.Windows.Forms.Button();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timerCheckRunning
            // 
            this.timerCheckRunning.Interval = 3000;
            this.timerCheckRunning.Tick += new System.EventHandler(this.timerCheckRunning_Tick);
            // 
            // btnDebugButtons
            // 
            this.btnDebugButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebugButtons.Location = new System.Drawing.Point(675, 415);
            this.btnDebugButtons.Name = "btnDebugButtons";
            this.btnDebugButtons.Size = new System.Drawing.Size(113, 23);
            this.btnDebugButtons.TabIndex = 9;
            this.btnDebugButtons.Text = "Open debug buttons";
            this.btnDebugButtons.UseVisualStyleBackColor = true;
            this.btnDebugButtons.Click += new System.EventHandler(this.btnDebugButtons_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloseAll.Location = new System.Drawing.Point(12, 415);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(57, 23);
            this.btnCloseAll.TabIndex = 10;
            this.btnCloseAll.Text = "Close all";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.btnDebugButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Scuffed Taskbar";
            this.Activated += new System.EventHandler(this.form_LoseFocus);
            this.Deactivate += new System.EventHandler(this.form_LoseFocus);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_closed);
            this.SizeChanged += new System.EventHandler(this.form_Resize);
            this.Leave += new System.EventHandler(this.form_LoseFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCheckRunning;
        private System.Windows.Forms.Button btnDebugButtons;
        private System.Windows.Forms.Button btnCloseAll;
    }
}

