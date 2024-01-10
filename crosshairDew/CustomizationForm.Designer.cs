namespace WinFormsApp1
{
    partial class CustomizationForm
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
            colorDialog1 = new ColorDialog();
            btnOK = new Button();
            btnCancel = new Button();
            btnChooseColor = new Button();
            txtSize = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // colorDialog1
            // 
            colorDialog1.AnyColor = true;
            colorDialog1.Color = Color.Chocolate;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(12, 167);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 0;
            btnOK.Text = "Confirm";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(228, 167);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnChooseColor
            // 
            btnChooseColor.BackColor = SystemColors.Control;
            btnChooseColor.Location = new Point(12, 138);
            btnChooseColor.Name = "btnChooseColor";
            btnChooseColor.Size = new Size(75, 23);
            btnChooseColor.TabIndex = 2;
            btnChooseColor.Text = "Choose";
            btnChooseColor.UseVisualStyleBackColor = false;
            btnChooseColor.Click += btnChooseColor_Click_1;
            // 
            // txtSize
            // 
            txtSize.Location = new Point(45, 84);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(44, 23);
            txtSize.TabIndex = 3;
            txtSize.Text = "20";
            txtSize.TextAlign = HorizontalAlignment.Center;
            txtSize.TextChanged += txtSize_TextChanged_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(27, 15);
            label1.TabIndex = 4;
            label1.Text = "Size";
            // 
            // CustomizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 202);
            Controls.Add(label1);
            Controls.Add(txtSize);
            Controls.Add(btnChooseColor);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Name = "CustomizationForm";
            Text = "Customize Crosshair";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ColorDialog colorDialog1;
        private Button btnOK;
        private Button btnCancel;
        private Button btnChooseColor;
        private TextBox txtSize;
        private Label label1;
    }
}