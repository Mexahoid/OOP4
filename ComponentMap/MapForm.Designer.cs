﻿namespace ComponentMap
{
    partial class MapForm
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
            this.CtrlPanel = new System.Windows.Forms.Panel();
            this.CtrlTxB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CtrlPanel
            // 
            this.CtrlPanel.Location = new System.Drawing.Point(0, 0);
            this.CtrlPanel.Name = "CtrlPanel";
            this.CtrlPanel.Size = new System.Drawing.Size(852, 560);
            this.CtrlPanel.TabIndex = 0;
            this.CtrlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlPanel_MouseDown);
            this.CtrlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPanel_MouseMove);
            // 
            // CtrlTxB
            // 
            this.CtrlTxB.Location = new System.Drawing.Point(858, 0);
            this.CtrlTxB.Multiline = true;
            this.CtrlTxB.Name = "CtrlTxB";
            this.CtrlTxB.Size = new System.Drawing.Size(144, 560);
            this.CtrlTxB.TabIndex = 1;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 560);
            this.Controls.Add(this.CtrlTxB);
            this.Controls.Add(this.CtrlPanel);
            this.Name = "MapForm";
            this.Text = "Карта мира";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapForm_FormClosed);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CtrlPanel;
        private System.Windows.Forms.TextBox CtrlTxB;
    }
}