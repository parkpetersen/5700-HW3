namespace GuiLayer
{
    partial class MainForm
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
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.ClassIconPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LineSelectPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ClassIconPanel.SuspendLayout();
            this.LineSelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.SystemColors.Window;
            this.DrawingPanel.Location = new System.Drawing.Point(144, 108);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(922, 547);
            this.DrawingPanel.TabIndex = 0;
            this.DrawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingPanel_MouseUp);
            // 
            // ClassIconPanel
            // 
            this.ClassIconPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClassIconPanel.Controls.Add(this.label1);
            this.ClassIconPanel.Location = new System.Drawing.Point(12, 108);
            this.ClassIconPanel.Name = "ClassIconPanel";
            this.ClassIconPanel.Size = new System.Drawing.Size(126, 74);
            this.ClassIconPanel.TabIndex = 0;
            this.ClassIconPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClassIconPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class";
            // 
            // LineSelectPanel
            // 
            this.LineSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LineSelectPanel.Controls.Add(this.label2);
            this.LineSelectPanel.Location = new System.Drawing.Point(12, 198);
            this.LineSelectPanel.Name = "LineSelectPanel";
            this.LineSelectPanel.Size = new System.Drawing.Size(126, 80);
            this.LineSelectPanel.TabIndex = 1;
            this.LineSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LineSelectPanel_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Line";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 667);
            this.Controls.Add(this.LineSelectPanel);
            this.Controls.Add(this.ClassIconPanel);
            this.Controls.Add(this.DrawingPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ClassIconPanel.ResumeLayout(false);
            this.ClassIconPanel.PerformLayout();
            this.LineSelectPanel.ResumeLayout(false);
            this.LineSelectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.Panel ClassIconPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel LineSelectPanel;
        private System.Windows.Forms.Label label2;
    }
}

