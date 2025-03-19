namespace NumberTypeSuggester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            minValLabel = new Label();
            maxValueLabel = new Label();
            suggestedTypeLabel = new Label();
            resultTypeLabel = new Label();
            minValTextbox = new TextBox();
            maxValTextbox = new TextBox();
            integralCheck = new CheckBox();
            preciseCheck = new CheckBox();
            SuspendLayout();
            // 
            // minValLabel
            // 
            minValLabel.AutoSize = true;
            minValLabel.Location = new Point(102, 86);
            minValLabel.Name = "minValLabel";
            minValLabel.Size = new Size(62, 15);
            minValLabel.TabIndex = 0;
            minValLabel.Text = "Min Value:";
            // 
            // maxValueLabel
            // 
            maxValueLabel.AutoSize = true;
            maxValueLabel.Location = new Point(102, 115);
            maxValueLabel.Name = "maxValueLabel";
            maxValueLabel.Size = new Size(63, 15);
            maxValueLabel.TabIndex = 1;
            maxValueLabel.Text = "Max Value:";
            // 
            // suggestedTypeLabel
            // 
            suggestedTypeLabel.AutoSize = true;
            suggestedTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            suggestedTypeLabel.Location = new Point(63, 230);
            suggestedTypeLabel.Name = "suggestedTypeLabel";
            suggestedTypeLabel.Size = new Size(101, 15);
            suggestedTypeLabel.TabIndex = 4;
            suggestedTypeLabel.Text = "Suggested Type: ";
            // 
            // resultTypeLabel
            // 
            resultTypeLabel.AutoSize = true;
            resultTypeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            resultTypeLabel.Location = new Point(170, 230);
            resultTypeLabel.Name = "resultTypeLabel";
            resultTypeLabel.Size = new Size(98, 15);
            resultTypeLabel.TabIndex = 5;
            resultTypeLabel.Text = "not enough data";
            // 
            // minValTextbox
            // 
            minValTextbox.Location = new Point(170, 83);
            minValTextbox.Name = "minValTextbox";
            minValTextbox.Size = new Size(493, 23);
            minValTextbox.TabIndex = 6;
            minValTextbox.TextChanged += TextBox_TextChanged;
            minValTextbox.KeyPress += Textbox_KeyPress;
            // 
            // maxValTextbox
            // 
            maxValTextbox.Location = new Point(170, 112);
            maxValTextbox.Name = "maxValTextbox";
            maxValTextbox.Size = new Size(493, 23);
            maxValTextbox.TabIndex = 7;
            maxValTextbox.TextChanged += TextBox_TextChanged;
            maxValTextbox.KeyPress += Textbox_KeyPress;
            // 
            // integralCheck
            // 
            integralCheck.AutoSize = true;
            integralCheck.CheckAlign = ContentAlignment.TopRight;
            integralCheck.Checked = true;
            integralCheck.CheckState = CheckState.Checked;
            integralCheck.ImageAlign = ContentAlignment.MiddleRight;
            integralCheck.Location = new Point(90, 153);
            integralCheck.Name = "integralCheck";
            integralCheck.Size = new Size(94, 19);
            integralCheck.TabIndex = 8;
            integralCheck.Text = "Integral Only";
            integralCheck.UseVisualStyleBackColor = true;
            integralCheck.CheckedChanged += IntegralCheck_CheckedChanged;
            // 
            // preciseCheck
            // 
            preciseCheck.AutoSize = true;
            preciseCheck.CheckAlign = ContentAlignment.TopRight;
            preciseCheck.ImageAlign = ContentAlignment.MiddleRight;
            preciseCheck.Location = new Point(75, 178);
            preciseCheck.Name = "preciseCheck";
            preciseCheck.Size = new Size(109, 19);
            preciseCheck.TabIndex = 9;
            preciseCheck.Text = "Must Be Precise";
            preciseCheck.TextAlign = ContentAlignment.MiddleRight;
            preciseCheck.UseVisualStyleBackColor = true;
            preciseCheck.Visible = false;
            preciseCheck.CheckedChanged += PreciseCheck_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(750, 333);
            Controls.Add(preciseCheck);
            Controls.Add(integralCheck);
            Controls.Add(maxValTextbox);
            Controls.Add(minValTextbox);
            Controls.Add(resultTypeLabel);
            Controls.Add(suggestedTypeLabel);
            Controls.Add(maxValueLabel);
            Controls.Add(minValLabel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "C# Numeric Types";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label minValLabel;
        private Label maxValueLabel;
        private Label suggestedTypeLabel;
        private Label resultTypeLabel;
        private TextBox minValTextbox;
        private TextBox maxValTextbox;
        private CheckBox integralCheck;
        private CheckBox preciseCheck;
    }
}
