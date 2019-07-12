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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRunningProcsList = new System.Windows.Forms.Button();
            this.btnRunningProcs = new System.Windows.Forms.Button();
            this.btnSavedButtons = new System.Windows.Forms.Button();
            this.btnRefreshSaved = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRunningProcsList
            // 
            this.btnRunningProcsList.Location = new System.Drawing.Point(689, 415);
            this.btnRunningProcsList.Name = "btnRunningProcsList";
            this.btnRunningProcsList.Size = new System.Drawing.Size(99, 23);
            this.btnRunningProcsList.TabIndex = 0;
            this.btnRunningProcsList.Text = "Open process list";
            this.btnRunningProcsList.UseVisualStyleBackColor = true;
            this.btnRunningProcsList.Click += new System.EventHandler(this.btnRunningProcsList_Click);
            // 
            // btnRunningProcs
            // 
            this.btnRunningProcs.Location = new System.Drawing.Point(545, 415);
            this.btnRunningProcs.Name = "btnRunningProcs";
            this.btnRunningProcs.Size = new System.Drawing.Size(138, 23);
            this.btnRunningProcs.TabIndex = 1;
            this.btnRunningProcs.Text = "Open running processes";
            this.btnRunningProcs.UseVisualStyleBackColor = true;
            this.btnRunningProcs.Click += new System.EventHandler(this.btnRunningProcs_Click);
            // 
            // btnSavedButtons
            // 
            this.btnSavedButtons.Location = new System.Drawing.Point(401, 415);
            this.btnSavedButtons.Name = "btnSavedButtons";
            this.btnSavedButtons.Size = new System.Drawing.Size(138, 23);
            this.btnSavedButtons.TabIndex = 2;
            this.btnSavedButtons.Text = "Open saved buttons";
            this.btnSavedButtons.UseVisualStyleBackColor = true;
            this.btnSavedButtons.Click += new System.EventHandler(this.btnSavedButtons_Click);
            // 
            // btnRefreshSaved
            // 
            this.btnRefreshSaved.Location = new System.Drawing.Point(257, 415);
            this.btnRefreshSaved.Name = "btnRefreshSaved";
            this.btnRefreshSaved.Size = new System.Drawing.Size(138, 23);
            this.btnRefreshSaved.TabIndex = 3;
            this.btnRefreshSaved.Text = "Refresh saved buttons";
            this.btnRefreshSaved.UseVisualStyleBackColor = true;
            this.btnRefreshSaved.Click += new System.EventHandler(this.btnRefreshSaved_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRefreshSaved);
            this.Controls.Add(this.btnSavedButtons);
            this.Controls.Add(this.btnRunningProcs);
            this.Controls.Add(this.btnRunningProcsList);
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

        private System.Windows.Forms.Button btnRunningProcsList;
        private System.Windows.Forms.Button btnRunningProcs;
        private System.Windows.Forms.Button btnSavedButtons;
        private System.Windows.Forms.Button btnRefreshSaved;
    }
}

