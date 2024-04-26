namespace turnTableGame
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
            playersNum = new TextBox();
            label1 = new Label();
            startGame_btn = new Button();
            fire_btn = new Button();
            pictureBox1 = new PictureBox();
            deadbox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // playersNum
            // 
            playersNum.Location = new Point(164, 62);
            playersNum.Name = "playersNum";
            playersNum.Size = new Size(420, 30);
            playersNum.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 65);
            label1.Name = "label1";
            label1.Size = new Size(118, 24);
            label1.TabIndex = 1;
            label1.Text = "输入参赛人数";
            // 
            // startGame_btn
            // 
            startGame_btn.Location = new Point(609, 62);
            startGame_btn.Name = "startGame_btn";
            startGame_btn.Size = new Size(164, 30);
            startGame_btn.TabIndex = 2;
            startGame_btn.Text = "开始游戏";
            startGame_btn.UseVisualStyleBackColor = true;
            startGame_btn.Click += startGame_btn_Click;
            // 
            // fire_btn
            // 
            fire_btn.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            fire_btn.Location = new Point(839, 37);
            fire_btn.Name = "fire_btn";
            fire_btn.Size = new Size(115, 55);
            fire_btn.TabIndex = 3;
            fire_btn.Text = "开枪";
            fire_btn.UseVisualStyleBackColor = true;
            fire_btn.Click += fire_btn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(40, 106);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(996, 1002);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // deadbox
            // 
            deadbox.FormattingEnabled = true;
            deadbox.ItemHeight = 24;
            deadbox.Location = new Point(1055, 106);
            deadbox.Name = "deadbox";
            deadbox.Size = new Size(274, 988);
            deadbox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1397, 1149);
            Controls.Add(deadbox);
            Controls.Add(pictureBox1);
            Controls.Add(fire_btn);
            Controls.Add(startGame_btn);
            Controls.Add(label1);
            Controls.Add(playersNum);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox playersNum;
        private Label label1;
        private Button startGame_btn;
        private Button fire_btn;
        public PictureBox pictureBox1;
        public ListBox deadbox;
    }
}
