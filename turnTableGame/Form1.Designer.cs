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
            restart = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            gunAttack = new TextBox();
            label4 = new Label();
            health = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // playersNum
            // 
            playersNum.Location = new Point(156, 62);
            playersNum.Name = "playersNum";
            playersNum.Size = new Size(82, 30);
            playersNum.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(40, 59);
            label1.Name = "label1";
            label1.Size = new Size(110, 31);
            label1.TabIndex = 1;
            label1.Text = "参赛人数";
            // 
            // startGame_btn
            // 
            startGame_btn.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            startGame_btn.Location = new Point(706, 53);
            startGame_btn.Name = "startGame_btn";
            startGame_btn.Size = new Size(141, 47);
            startGame_btn.TabIndex = 2;
            startGame_btn.Text = "开始游戏";
            startGame_btn.UseVisualStyleBackColor = true;
            startGame_btn.Click += startGame_btn_Click;
            // 
            // fire_btn
            // 
            fire_btn.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 134);
            fire_btn.ForeColor = SystemColors.ActiveCaptionText;
            fire_btn.Location = new Point(853, 12);
            fire_btn.Name = "fire_btn";
            fire_btn.Size = new Size(166, 88);
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
            deadbox.Size = new Size(309, 748);
            deadbox.TabIndex = 5;
            // 
            // restart
            // 
            restart.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            restart.Location = new Point(706, 12);
            restart.Name = "restart";
            restart.Size = new Size(141, 47);
            restart.TabIndex = 6;
            restart.Text = "重新开始";
            restart.UseVisualStyleBackColor = true;
            restart.Click += restart_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label2.Location = new Point(1055, 877);
            label2.Name = "label2";
            label2.Size = new Size(117, 28);
            label2.TabIndex = 7;
            label2.Text = "游戏规则：";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            textBox1.Location = new Point(1055, 904);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 204);
            textBox1.TabIndex = 8;
            textBox1.Text = "输入玩家数量n，点击开始游戏则会有n个玩家参加游戏。每次点击开枪会有1/3的概率打出子弹，若打出子弹则对应位置的玩家淘汰。当场上只剩一名玩家时该玩家获得本场游戏胜利。";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label3.Location = new Point(253, 59);
            label3.Name = "label3";
            label3.Size = new Size(110, 31);
            label3.TabIndex = 10;
            label3.Text = "子弹伤害";
            // 
            // gunAttack
            // 
            gunAttack.Location = new Point(369, 62);
            gunAttack.Name = "gunAttack";
            gunAttack.Size = new Size(82, 30);
            gunAttack.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label4.Location = new Point(460, 59);
            label4.Name = "label4";
            label4.Size = new Size(134, 31);
            label4.TabIndex = 12;
            label4.Text = "玩家生命值";
            // 
            // health
            // 
            health.Location = new Point(600, 62);
            health.Name = "health";
            health.Size = new Size(82, 30);
            health.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1397, 1149);
            Controls.Add(label4);
            Controls.Add(health);
            Controls.Add(label3);
            Controls.Add(gunAttack);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(restart);
            Controls.Add(deadbox);
            Controls.Add(pictureBox1);
            Controls.Add(fire_btn);
            Controls.Add(startGame_btn);
            Controls.Add(label1);
            Controls.Add(playersNum);
            Name = "Form1";
            Text = "TURN TABLE GAME";
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
        private Button restart;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox gunAttack;
        private Label label4;
        private TextBox health;
    }
}
