﻿namespace MultiLaunch
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
            this.btnRunningProcs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRunningProcs
            // 
            this.btnRunningProcs.Location = new System.Drawing.Point(650, 415);
            this.btnRunningProcs.Name = "btnRunningProcs";
            this.btnRunningProcs.Size = new System.Drawing.Size(138, 23);
            this.btnRunningProcs.TabIndex = 0;
            this.btnRunningProcs.Text = "Open running processes";
            this.btnRunningProcs.UseVisualStyleBackColor = true;
            this.btnRunningProcs.Click += new System.EventHandler(this.btnRunningProcs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRunningProcs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Scuffed Taskbar";
            this.Activated += new System.EventHandler(this.form_LoseFocus);
            this.Deactivate += new System.EventHandler(this.form_LoseFocus);
            this.SizeChanged += new System.EventHandler(this.form_Resize);
            this.Leave += new System.EventHandler(this.form_LoseFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRunningProcs;
    }
}

