namespace GuiLayer
{
    partial class EditDiagram
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
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.BackgroundColorButton = new System.Windows.Forms.Button();
            this.ForegroundColorButton = new System.Windows.Forms.Button();
            this.ClassColorButton = new System.Windows.Forms.Button();
            this.BackgroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.ForegroundColorDialog = new System.Windows.Forms.ColorDialog();
            this.ClassColorDialog = new System.Windows.Forms.ColorDialog();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Diagram Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(16, 29);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(200, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // BackgroundColorButton
            // 
            this.BackgroundColorButton.Location = new System.Drawing.Point(12, 69);
            this.BackgroundColorButton.Name = "BackgroundColorButton";
            this.BackgroundColorButton.Size = new System.Drawing.Size(147, 23);
            this.BackgroundColorButton.TabIndex = 2;
            this.BackgroundColorButton.Text = "Change Background Color";
            this.BackgroundColorButton.UseVisualStyleBackColor = true;
            this.BackgroundColorButton.Click += new System.EventHandler(this.BackgroundColorButton_Click);
            // 
            // ForegroundColorButton
            // 
            this.ForegroundColorButton.Location = new System.Drawing.Point(12, 109);
            this.ForegroundColorButton.Name = "ForegroundColorButton";
            this.ForegroundColorButton.Size = new System.Drawing.Size(147, 23);
            this.ForegroundColorButton.TabIndex = 3;
            this.ForegroundColorButton.Text = "Change Foreground Color";
            this.ForegroundColorButton.UseVisualStyleBackColor = true;
            this.ForegroundColorButton.Click += new System.EventHandler(this.ForegroundColorButton_Click);
            // 
            // ClassColorButton
            // 
            this.ClassColorButton.Location = new System.Drawing.Point(12, 150);
            this.ClassColorButton.Name = "ClassColorButton";
            this.ClassColorButton.Size = new System.Drawing.Size(147, 23);
            this.ClassColorButton.TabIndex = 4;
            this.ClassColorButton.Text = "Default Class Color";
            this.ClassColorButton.UseVisualStyleBackColor = true;
            this.ClassColorButton.Click += new System.EventHandler(this.ClassColorButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(135, 226);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(123, 23);
            this.AcceptButton.TabIndex = 5;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // EditDiagram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 261);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.ClassColorButton);
            this.Controls.Add(this.ForegroundColorButton);
            this.Controls.Add(this.BackgroundColorButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "EditDiagram";
            this.Text = "EditDiagram";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button BackgroundColorButton;
        private System.Windows.Forms.Button ForegroundColorButton;
        private System.Windows.Forms.Button ClassColorButton;
        private System.Windows.Forms.ColorDialog BackgroundColorDialog;
        private System.Windows.Forms.ColorDialog ForegroundColorDialog;
        private System.Windows.Forms.ColorDialog ClassColorDialog;
        private System.Windows.Forms.Button AcceptButton;
    }
}