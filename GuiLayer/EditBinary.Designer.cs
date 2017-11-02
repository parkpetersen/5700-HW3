namespace GuiLayer
{
    partial class EditBinary
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
            this.label1 = new System.Windows.Forms.Label();
            this.LabelTextBox = new System.Windows.Forms.TextBox();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.LineColorDialog = new System.Windows.Forms.ColorDialog();
            this.ArrowColorDialog = new System.Windows.Forms.ColorDialog();
            this.LineColorButton = new System.Windows.Forms.Button();
            this.ArrowColorButton = new System.Windows.Forms.Button();
            this.DirectionCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LineThicknessTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Relationship Label:";
            // 
            // LabelTextBox
            // 
            this.LabelTextBox.Location = new System.Drawing.Point(13, 32);
            this.LabelTextBox.Name = "LabelTextBox";
            this.LabelTextBox.Size = new System.Drawing.Size(197, 20);
            this.LabelTextBox.TabIndex = 1;
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(98, 226);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 2;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // LineColorButton
            // 
            this.LineColorButton.Location = new System.Drawing.Point(12, 110);
            this.LineColorButton.Name = "LineColorButton";
            this.LineColorButton.Size = new System.Drawing.Size(141, 23);
            this.LineColorButton.TabIndex = 3;
            this.LineColorButton.Text = "Change Line Color";
            this.LineColorButton.UseVisualStyleBackColor = true;
            this.LineColorButton.Click += new System.EventHandler(this.LineColorButton_Click);
            // 
            // ArrowColorButton
            // 
            this.ArrowColorButton.Location = new System.Drawing.Point(12, 139);
            this.ArrowColorButton.Name = "ArrowColorButton";
            this.ArrowColorButton.Size = new System.Drawing.Size(141, 23);
            this.ArrowColorButton.TabIndex = 4;
            this.ArrowColorButton.Text = "Change Arrow Color";
            this.ArrowColorButton.UseVisualStyleBackColor = true;
            this.ArrowColorButton.Click += new System.EventHandler(this.ArrowColorButton_Click);
            // 
            // DirectionCheckBox
            // 
            this.DirectionCheckBox.AutoSize = true;
            this.DirectionCheckBox.Location = new System.Drawing.Point(16, 177);
            this.DirectionCheckBox.Name = "DirectionCheckBox";
            this.DirectionCheckBox.Size = new System.Drawing.Size(138, 17);
            this.DirectionCheckBox.TabIndex = 5;
            this.DirectionCheckBox.Text = "Change Arrow Direction";
            this.DirectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Line Thickness";
            // 
            // LineThicknessTextBox
            // 
            this.LineThicknessTextBox.Location = new System.Drawing.Point(13, 76);
            this.LineThicknessTextBox.Name = "LineThicknessTextBox";
            this.LineThicknessTextBox.Size = new System.Drawing.Size(197, 20);
            this.LineThicknessTextBox.TabIndex = 7;
            // 
            // EditBinary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LineThicknessTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DirectionCheckBox);
            this.Controls.Add(this.ArrowColorButton);
            this.Controls.Add(this.LineColorButton);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.LabelTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EditBinary";
            this.Text = "EditBinary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LabelTextBox;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ColorDialog LineColorDialog;
        private System.Windows.Forms.ColorDialog ArrowColorDialog;
        private System.Windows.Forms.Button LineColorButton;
        private System.Windows.Forms.Button ArrowColorButton;
        private System.Windows.Forms.CheckBox DirectionCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LineThicknessTextBox;
    }
}