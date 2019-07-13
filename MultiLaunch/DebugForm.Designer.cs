namespace MultiLaunch
{
    partial class DebugForm
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
            this.btnClearSaved = new System.Windows.Forms.Button();
            this.btnSavedButtons = new System.Windows.Forms.Button();
            this.btnRunningProcs = new System.Windows.Forms.Button();
            this.btnRunningProcsList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClearSaved
            // 
            this.btnClearSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSaved.Location = new System.Drawing.Point(52, 187);
            this.btnClearSaved.Name = "btnClearSaved";
            this.btnClearSaved.Size = new System.Drawing.Size(138, 23);
            this.btnClearSaved.TabIndex = 7;
            this.btnClearSaved.Text = "Clear saved buttons";
            this.btnClearSaved.UseVisualStyleBackColor = true;
            this.btnClearSaved.Click += new System.EventHandler(this.btnClearSaved_Click);
            // 
            // btnSavedButtons
            // 
            this.btnSavedButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavedButtons.Location = new System.Drawing.Point(52, 158);
            this.btnSavedButtons.Name = "btnSavedButtons";
            this.btnSavedButtons.Size = new System.Drawing.Size(138, 23);
            this.btnSavedButtons.TabIndex = 6;
            this.btnSavedButtons.Text = "Open saved buttons";
            this.btnSavedButtons.UseVisualStyleBackColor = true;
            this.btnSavedButtons.Click += new System.EventHandler(this.btnSavedButtons_Click);
            // 
            // btnRunningProcs
            // 
            this.btnRunningProcs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunningProcs.Location = new System.Drawing.Point(52, 129);
            this.btnRunningProcs.Name = "btnRunningProcs";
            this.btnRunningProcs.Size = new System.Drawing.Size(138, 23);
            this.btnRunningProcs.TabIndex = 5;
            this.btnRunningProcs.Text = "Open running processes";
            this.btnRunningProcs.UseVisualStyleBackColor = true;
            this.btnRunningProcs.Click += new System.EventHandler(this.btnRunningProcs_Click);
            // 
            // btnRunningProcsList
            // 
            this.btnRunningProcsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunningProcsList.Location = new System.Drawing.Point(52, 100);
            this.btnRunningProcsList.Name = "btnRunningProcsList";
            this.btnRunningProcsList.Size = new System.Drawing.Size(138, 23);
            this.btnRunningProcsList.TabIndex = 4;
            this.btnRunningProcsList.Text = "Open process list";
            this.btnRunningProcsList.UseVisualStyleBackColor = true;
            this.btnRunningProcsList.Click += new System.EventHandler(this.btnRunningProcsList_Click);
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 376);
            this.Controls.Add(this.btnClearSaved);
            this.Controls.Add(this.btnSavedButtons);
            this.Controls.Add(this.btnRunningProcs);
            this.Controls.Add(this.btnRunningProcsList);
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClearSaved;
        private System.Windows.Forms.Button btnSavedButtons;
        private System.Windows.Forms.Button btnRunningProcs;
        private System.Windows.Forms.Button btnRunningProcsList;
    }
}