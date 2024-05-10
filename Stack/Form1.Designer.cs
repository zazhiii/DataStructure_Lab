namespace Stack
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
            InputBox = new TextBox();
            compute_btn = new Button();
            label1 = new Label();
            outputBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // InputBox
            // 
            InputBox.Location = new Point(140, 151);
            InputBox.Multiline = true;
            InputBox.Name = "InputBox";
            InputBox.Size = new Size(741, 45);
            InputBox.TabIndex = 0;
            // 
            // compute_btn
            // 
            compute_btn.Location = new Point(940, 151);
            compute_btn.Name = "compute_btn";
            compute_btn.Size = new Size(157, 45);
            compute_btn.TabIndex = 1;
            compute_btn.Text = "计算";
            compute_btn.UseVisualStyleBackColor = true;
            compute_btn.Click += compute_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(140, 124);
            label1.Name = "label1";
            label1.Size = new Size(354, 24);
            label1.TabIndex = 2;
            label1.Text = "输入计算表达式，例如：2+3-4*8-4+20/4";
            // 
            // outputBox
            // 
            outputBox.Location = new Point(140, 254);
            outputBox.Multiline = true;
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(219, 45);
            outputBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 227);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 4;
            label2.Text = "计算结果";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1308, 712);
            Controls.Add(label2);
            Controls.Add(outputBox);
            Controls.Add(label1);
            Controls.Add(compute_btn);
            Controls.Add(InputBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputBox;
        private Button compute_btn;
        private Label label1;
        private TextBox outputBox;
        private Label label2;
    }
}
