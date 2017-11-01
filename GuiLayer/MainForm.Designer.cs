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
            this.BinarySelectPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.EditSelectPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.DependencySelectPanel = new System.Windows.Forms.Panel();
            this.Dependency = new System.Windows.Forms.Label();
            this.AggregationSelectPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.CompositionSelectPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.GeneralizationSelectPanel = new System.Windows.Forms.Panel();
            this.Generalization = new System.Windows.Forms.Label();
            this.DeleteToolSelectPanel = new System.Windows.Forms.Panel();
            this.Delete = new System.Windows.Forms.Label();
            this.RedoSelectPanel = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.UndoSelectPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.MoveSelectPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.SaveSelectPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.OpenSelectPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.DiagramNameLabel = new System.Windows.Forms.Label();
            this.OptionsSelectPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.ClassIconPanel.SuspendLayout();
            this.BinarySelectPanel.SuspendLayout();
            this.EditSelectPanel.SuspendLayout();
            this.DependencySelectPanel.SuspendLayout();
            this.AggregationSelectPanel.SuspendLayout();
            this.CompositionSelectPanel.SuspendLayout();
            this.GeneralizationSelectPanel.SuspendLayout();
            this.DeleteToolSelectPanel.SuspendLayout();
            this.RedoSelectPanel.SuspendLayout();
            this.UndoSelectPanel.SuspendLayout();
            this.MoveSelectPanel.SuspendLayout();
            this.SaveSelectPanel.SuspendLayout();
            this.OpenSelectPanel.SuspendLayout();
            this.OptionsSelectPanel.SuspendLayout();
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
            this.ClassIconPanel.Size = new System.Drawing.Size(126, 55);
            this.ClassIconPanel.TabIndex = 0;
            this.ClassIconPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClassIconPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class";
            // 
            // BinarySelectPanel
            // 
            this.BinarySelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BinarySelectPanel.Controls.Add(this.label2);
            this.BinarySelectPanel.Location = new System.Drawing.Point(12, 178);
            this.BinarySelectPanel.Name = "BinarySelectPanel";
            this.BinarySelectPanel.Size = new System.Drawing.Size(126, 66);
            this.BinarySelectPanel.TabIndex = 1;
            this.BinarySelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BinarySelectPanel_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Binary";
            // 
            // EditSelectPanel
            // 
            this.EditSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.EditSelectPanel.Controls.Add(this.label3);
            this.EditSelectPanel.Location = new System.Drawing.Point(940, 53);
            this.EditSelectPanel.Name = "EditSelectPanel";
            this.EditSelectPanel.Size = new System.Drawing.Size(126, 47);
            this.EditSelectPanel.TabIndex = 0;
            this.EditSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EditSelectPanel_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Edit";
            // 
            // DependencySelectPanel
            // 
            this.DependencySelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DependencySelectPanel.Controls.Add(this.Dependency);
            this.DependencySelectPanel.Location = new System.Drawing.Point(12, 494);
            this.DependencySelectPanel.Name = "DependencySelectPanel";
            this.DependencySelectPanel.Size = new System.Drawing.Size(126, 71);
            this.DependencySelectPanel.TabIndex = 2;
            this.DependencySelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DependencySelectPanel_MouseUp);
            // 
            // Dependency
            // 
            this.Dependency.AutoSize = true;
            this.Dependency.Location = new System.Drawing.Point(10, 4);
            this.Dependency.Name = "Dependency";
            this.Dependency.Size = new System.Drawing.Size(68, 13);
            this.Dependency.TabIndex = 0;
            this.Dependency.Text = "Dependency";
            // 
            // AggregationSelectPanel
            // 
            this.AggregationSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AggregationSelectPanel.Controls.Add(this.label4);
            this.AggregationSelectPanel.Location = new System.Drawing.Point(12, 259);
            this.AggregationSelectPanel.Name = "AggregationSelectPanel";
            this.AggregationSelectPanel.Size = new System.Drawing.Size(126, 58);
            this.AggregationSelectPanel.TabIndex = 3;
            this.AggregationSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AggregationSelectPanel_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Aggregation";
            // 
            // CompositionSelectPanel
            // 
            this.CompositionSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CompositionSelectPanel.Controls.Add(this.label5);
            this.CompositionSelectPanel.Location = new System.Drawing.Point(12, 334);
            this.CompositionSelectPanel.Name = "CompositionSelectPanel";
            this.CompositionSelectPanel.Size = new System.Drawing.Size(126, 62);
            this.CompositionSelectPanel.TabIndex = 4;
            this.CompositionSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CompositionSelectPanel_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Composition";
            // 
            // GeneralizationSelectPanel
            // 
            this.GeneralizationSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.GeneralizationSelectPanel.Controls.Add(this.Generalization);
            this.GeneralizationSelectPanel.Location = new System.Drawing.Point(12, 413);
            this.GeneralizationSelectPanel.Name = "GeneralizationSelectPanel";
            this.GeneralizationSelectPanel.Size = new System.Drawing.Size(123, 65);
            this.GeneralizationSelectPanel.TabIndex = 5;
            this.GeneralizationSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GeneralizationSelectPanel_MouseUp);
            // 
            // Generalization
            // 
            this.Generalization.AutoSize = true;
            this.Generalization.Location = new System.Drawing.Point(6, 4);
            this.Generalization.Name = "Generalization";
            this.Generalization.Size = new System.Drawing.Size(74, 13);
            this.Generalization.TabIndex = 0;
            this.Generalization.Text = "Generalization";
            // 
            // DeleteToolSelectPanel
            // 
            this.DeleteToolSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DeleteToolSelectPanel.Controls.Add(this.Delete);
            this.DeleteToolSelectPanel.Location = new System.Drawing.Point(789, 53);
            this.DeleteToolSelectPanel.Name = "DeleteToolSelectPanel";
            this.DeleteToolSelectPanel.Size = new System.Drawing.Size(132, 47);
            this.DeleteToolSelectPanel.TabIndex = 6;
            this.DeleteToolSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DeleteToolSelectPanel_MouseUp);
            // 
            // Delete
            // 
            this.Delete.AutoSize = true;
            this.Delete.Location = new System.Drawing.Point(3, 4);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(38, 13);
            this.Delete.TabIndex = 0;
            this.Delete.Text = "Delete";
            // 
            // RedoSelectPanel
            // 
            this.RedoSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.RedoSelectPanel.Controls.Add(this.label6);
            this.RedoSelectPanel.Location = new System.Drawing.Point(647, 53);
            this.RedoSelectPanel.Name = "RedoSelectPanel";
            this.RedoSelectPanel.Size = new System.Drawing.Size(125, 47);
            this.RedoSelectPanel.TabIndex = 7;
            this.RedoSelectPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RedoSelectPanel_MouseDown);
            this.RedoSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RedoSelectPanel_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Redo";
            // 
            // UndoSelectPanel
            // 
            this.UndoSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UndoSelectPanel.Controls.Add(this.label7);
            this.UndoSelectPanel.Location = new System.Drawing.Point(493, 53);
            this.UndoSelectPanel.Name = "UndoSelectPanel";
            this.UndoSelectPanel.Size = new System.Drawing.Size(136, 47);
            this.UndoSelectPanel.TabIndex = 8;
            this.UndoSelectPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UndoSelectPanel_MouseDown);
            this.UndoSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UndoSelectPanel_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Undo";
            // 
            // MoveSelectPanel
            // 
            this.MoveSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.MoveSelectPanel.Controls.Add(this.label8);
            this.MoveSelectPanel.Location = new System.Drawing.Point(353, 53);
            this.MoveSelectPanel.Name = "MoveSelectPanel";
            this.MoveSelectPanel.Size = new System.Drawing.Size(123, 49);
            this.MoveSelectPanel.TabIndex = 9;
            this.MoveSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveSelectPanel_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Move";
            // 
            // SaveSelectPanel
            // 
            this.SaveSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SaveSelectPanel.Controls.Add(this.label9);
            this.SaveSelectPanel.Location = new System.Drawing.Point(144, 53);
            this.SaveSelectPanel.Name = "SaveSelectPanel";
            this.SaveSelectPanel.Size = new System.Drawing.Size(84, 47);
            this.SaveSelectPanel.TabIndex = 10;
            this.SaveSelectPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SaveSelectPanel_MouseDown);
            this.SaveSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SaveSelectPanel_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Save";
            // 
            // OpenSelectPanel
            // 
            this.OpenSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.OpenSelectPanel.Controls.Add(this.label10);
            this.OpenSelectPanel.Location = new System.Drawing.Point(234, 53);
            this.OpenSelectPanel.Name = "OpenSelectPanel";
            this.OpenSelectPanel.Size = new System.Drawing.Size(91, 47);
            this.OpenSelectPanel.TabIndex = 11;
            this.OpenSelectPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OpenSelectPanel_MouseDown);
            this.OpenSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OpenSelectPanel_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Open";
            // 
            // DiagramNameLabel
            // 
            this.DiagramNameLabel.AutoSize = true;
            this.DiagramNameLabel.Location = new System.Drawing.Point(137, 13);
            this.DiagramNameLabel.Name = "DiagramNameLabel";
            this.DiagramNameLabel.Size = new System.Drawing.Size(80, 13);
            this.DiagramNameLabel.TabIndex = 12;
            this.DiagramNameLabel.Text = "Diagram Name:";
            // 
            // OptionsSelectPanel
            // 
            this.OptionsSelectPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.OptionsSelectPanel.Controls.Add(this.label11);
            this.OptionsSelectPanel.Location = new System.Drawing.Point(940, 12);
            this.OptionsSelectPanel.Name = "OptionsSelectPanel";
            this.OptionsSelectPanel.Size = new System.Drawing.Size(126, 35);
            this.OptionsSelectPanel.TabIndex = 13;
            this.OptionsSelectPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OptionsSelectPanel_MouseDown);
            this.OptionsSelectPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OptionsSelectPanel_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 667);
            this.Controls.Add(this.OptionsSelectPanel);
            this.Controls.Add(this.DiagramNameLabel);
            this.Controls.Add(this.OpenSelectPanel);
            this.Controls.Add(this.SaveSelectPanel);
            this.Controls.Add(this.MoveSelectPanel);
            this.Controls.Add(this.UndoSelectPanel);
            this.Controls.Add(this.RedoSelectPanel);
            this.Controls.Add(this.DeleteToolSelectPanel);
            this.Controls.Add(this.GeneralizationSelectPanel);
            this.Controls.Add(this.CompositionSelectPanel);
            this.Controls.Add(this.AggregationSelectPanel);
            this.Controls.Add(this.DependencySelectPanel);
            this.Controls.Add(this.EditSelectPanel);
            this.Controls.Add(this.BinarySelectPanel);
            this.Controls.Add(this.ClassIconPanel);
            this.Controls.Add(this.DrawingPanel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ClassIconPanel.ResumeLayout(false);
            this.ClassIconPanel.PerformLayout();
            this.BinarySelectPanel.ResumeLayout(false);
            this.BinarySelectPanel.PerformLayout();
            this.EditSelectPanel.ResumeLayout(false);
            this.EditSelectPanel.PerformLayout();
            this.DependencySelectPanel.ResumeLayout(false);
            this.DependencySelectPanel.PerformLayout();
            this.AggregationSelectPanel.ResumeLayout(false);
            this.AggregationSelectPanel.PerformLayout();
            this.CompositionSelectPanel.ResumeLayout(false);
            this.CompositionSelectPanel.PerformLayout();
            this.GeneralizationSelectPanel.ResumeLayout(false);
            this.GeneralizationSelectPanel.PerformLayout();
            this.DeleteToolSelectPanel.ResumeLayout(false);
            this.DeleteToolSelectPanel.PerformLayout();
            this.RedoSelectPanel.ResumeLayout(false);
            this.RedoSelectPanel.PerformLayout();
            this.UndoSelectPanel.ResumeLayout(false);
            this.UndoSelectPanel.PerformLayout();
            this.MoveSelectPanel.ResumeLayout(false);
            this.MoveSelectPanel.PerformLayout();
            this.SaveSelectPanel.ResumeLayout(false);
            this.SaveSelectPanel.PerformLayout();
            this.OpenSelectPanel.ResumeLayout(false);
            this.OpenSelectPanel.PerformLayout();
            this.OptionsSelectPanel.ResumeLayout(false);
            this.OptionsSelectPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
        private System.Windows.Forms.Panel ClassIconPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel BinarySelectPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel EditSelectPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel DependencySelectPanel;
        private System.Windows.Forms.FlowLayoutPanel AggregationSelectPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel CompositionSelectPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel GeneralizationSelectPanel;
        private System.Windows.Forms.Label Generalization;
        private System.Windows.Forms.Label Dependency;
        private System.Windows.Forms.Panel DeleteToolSelectPanel;
        private System.Windows.Forms.Label Delete;
        private System.Windows.Forms.Panel RedoSelectPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel UndoSelectPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel MoveSelectPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel SaveSelectPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel OpenSelectPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label DiagramNameLabel;
        private System.Windows.Forms.Panel OptionsSelectPanel;
        private System.Windows.Forms.Label label11;
    }
}

