namespace GuiLayer
{
    partial class EditLine
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
            this.LineThicknessTextBox = new System.Windows.Forms.TextBox();
            this.LineColorButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.LineColorDialog = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.SymbolSizeTextBox = new System.Windows.Forms.TextBox();
            this.SymbolFillColorButton = new System.Windows.Forms.Button();
            this.SymbolColorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line Thickness";
            // 
            // LineThicknessTextBox
            // 
            this.LineThicknessTextBox.Location = new System.Drawing.Point(16, 30);
            this.LineThicknessTextBox.Name = "LineThicknessTextBox";
            this.LineThicknessTextBox.Size = new System.Drawing.Size(117, 20);
            this.LineThicknessTextBox.TabIndex = 1;
            // 
            // LineColorButton
            // 
            this.LineColorButton.Location = new System.Drawing.Point(16, 171);
            this.LineColorButton.Name = "LineColorButton";
            this.LineColorButton.Size = new System.Drawing.Size(129, 23);
            this.LineColorButton.TabIndex = 2;
            this.LineColorButton.Text = "Change Line Color";
            this.LineColorButton.UseVisualStyleBackColor = true;
            this.LineColorButton.Click += new System.EventHandler(this.LineColorButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(98, 226);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptButton.TabIndex = 3;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Symbol Size";
            // 
            // SymbolSizeTextBox
            // 
            this.SymbolSizeTextBox.Location = new System.Drawing.Point(19, 83);
            this.SymbolSizeTextBox.Name = "SymbolSizeTextBox";
            this.SymbolSizeTextBox.Size = new System.Drawing.Size(114, 20);
            this.SymbolSizeTextBox.TabIndex = 5;
            // 
            // SymbolFillColorButton
            // 
            this.SymbolFillColorButton.Location = new System.Drawing.Point(19, 128);
            this.SymbolFillColorButton.Name = "SymbolFillColorButton";
            this.SymbolFillColorButton.Size = new System.Drawing.Size(126, 23);
            this.SymbolFillColorButton.TabIndex = 6;
            this.SymbolFillColorButton.Text = "Change Symbol Color";
            this.SymbolFillColorButton.UseVisualStyleBackColor = true;
            this.SymbolFillColorButton.Click += new System.EventHandler(this.SymbolFillColorButton_Click);
            // 
            // EditLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.SymbolFillColorButton);
            this.Controls.Add(this.SymbolSizeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.LineColorButton);
            this.Controls.Add(this.LineThicknessTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EditLine";
            this.Text = "EditLine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LineThicknessTextBox;
        private System.Windows.Forms.Button LineColorButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.ColorDialog LineColorDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SymbolSizeTextBox;
        private System.Windows.Forms.Button SymbolFillColorButton;
        private System.Windows.Forms.ColorDialog SymbolColorDialog;
    }
}