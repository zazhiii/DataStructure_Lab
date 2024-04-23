
namespace LinearList
{
    partial class LinearList
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
            label1 = new Label();
            label2 = new Label();
            ArrCreat_Btn = new Button();
            label3 = new Label();
            ListCreated = new Button();
            OutputText = new TextBox();
            createdText = new Label();
            label4 = new Label();
            length = new Button();
            lenText = new TextBox();
            getEleById_arr = new Button();
            getEle_Text = new TextBox();
            label5 = new Label();
            getEleById_TextBox = new TextBox();
            getEleById_List = new Button();
            getIdByEle_List = new Button();
            getIdByEle_TextBox = new TextBox();
            label6 = new Label();
            getId_Text = new TextBox();
            getIdByEle_arr = new Button();
            insert_List_btn = new Button();
            insertEle = new TextBox();
            label7 = new Label();
            insertedText = new TextBox();
            insert_arr_btn = new Button();
            insertIndex = new TextBox();
            label8 = new Label();
            deleteIndex = new TextBox();
            label9 = new Label();
            delete_List_btn = new Button();
            deleteText = new TextBox();
            delete_arr_btn = new Button();
            deleteLable = new Label();
            SuspendLayout();
            // 
            // InputBox
            // 
            InputBox.Location = new Point(271, 62);
            InputBox.Name = "InputBox";
            InputBox.Size = new Size(625, 30);
            InputBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 65);
            label2.Name = "label2";
            label2.Size = new Size(208, 24);
            label2.TabIndex = 1;
            label2.Text = "输入元素（用空格隔开）";
            // 
            // ArrCreat_Btn
            // 
            ArrCreat_Btn.Location = new Point(271, 108);
            ArrCreat_Btn.Name = "ArrCreat_Btn";
            ArrCreat_Btn.Size = new Size(239, 36);
            ArrCreat_Btn.TabIndex = 2;
            ArrCreat_Btn.Text = "创建链表（动态数组实现）";
            ArrCreat_Btn.UseVisualStyleBackColor = true;
            ArrCreat_Btn.Click += ArrBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(772, 114);
            label3.Name = "label3";
            label3.Size = new Size(0, 24);
            label3.TabIndex = 4;
            // 
            // ListCreated
            // 
            ListCreated.Location = new Point(516, 108);
            ListCreated.Name = "ListCreated";
            ListCreated.Size = new Size(239, 36);
            ListCreated.TabIndex = 5;
            ListCreated.Text = "创建链表（链表实现）";
            ListCreated.UseVisualStyleBackColor = true;
            ListCreated.Click += ListCreated_Click;
            // 
            // OutputText
            // 
            OutputText.BackColor = SystemColors.GradientInactiveCaption;
            OutputText.BorderStyle = BorderStyle.FixedSingle;
            OutputText.Location = new Point(271, 170);
            OutputText.Name = "OutputText";
            OutputText.Size = new Size(625, 30);
            OutputText.TabIndex = 6;
            // 
            // createdText
            // 
            createdText.AutoSize = true;
            createdText.ForeColor = SystemColors.ButtonShadow;
            createdText.Location = new Point(793, 114);
            createdText.Name = "createdText";
            createdText.Size = new Size(64, 24);
            createdText.TabIndex = 8;
            createdText.Text = "未创建";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(169, 172);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 9;
            label4.Text = "输出链表";
            // 
            // length
            // 
            length.Location = new Point(139, 250);
            length.Name = "length";
            length.Size = new Size(112, 34);
            length.TabIndex = 10;
            length.Text = "求链表长度";
            length.UseVisualStyleBackColor = true;
            length.Click += length_Click;
            // 
            // lenText
            // 
            lenText.BackColor = SystemColors.GradientInactiveCaption;
            lenText.BorderStyle = BorderStyle.FixedSingle;
            lenText.Location = new Point(271, 251);
            lenText.Name = "lenText";
            lenText.Size = new Size(625, 30);
            lenText.TabIndex = 11;
            // 
            // getEleById_arr
            // 
            getEleById_arr.Location = new Point(29, 322);
            getEleById_arr.Name = "getEleById_arr";
            getEleById_arr.Size = new Size(222, 34);
            getEleById_arr.TabIndex = 12;
            getEleById_arr.Text = "根据序号查找元素(数组）";
            getEleById_arr.UseVisualStyleBackColor = true;
            getEleById_arr.Click += getEleById_arr_Click;
            // 
            // getEle_Text
            // 
            getEle_Text.BackColor = SystemColors.GradientInactiveCaption;
            getEle_Text.BorderStyle = BorderStyle.FixedSingle;
            getEle_Text.Location = new Point(271, 342);
            getEle_Text.Name = "getEle_Text";
            getEle_Text.Size = new Size(239, 30);
            getEle_Text.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(516, 342);
            label5.Name = "label5";
            label5.Size = new Size(82, 24);
            label5.TabIndex = 14;
            label5.Text = "输入序号";
            // 
            // getEleById_TextBox
            // 
            getEleById_TextBox.Location = new Point(604, 338);
            getEleById_TextBox.Name = "getEleById_TextBox";
            getEleById_TextBox.Size = new Size(292, 30);
            getEleById_TextBox.TabIndex = 15;
            // 
            // getEleById_List
            // 
            getEleById_List.ForeColor = SystemColors.ControlText;
            getEleById_List.Location = new Point(29, 362);
            getEleById_List.Name = "getEleById_List";
            getEleById_List.Size = new Size(222, 34);
            getEleById_List.TabIndex = 16;
            getEleById_List.Text = "根据序号查找元素(链表）";
            getEleById_List.UseVisualStyleBackColor = true;
            getEleById_List.Click += getEleById_List_Click;
            // 
            // getIdByEle_List
            // 
            getIdByEle_List.Location = new Point(29, 475);
            getIdByEle_List.Name = "getIdByEle_List";
            getIdByEle_List.Size = new Size(222, 34);
            getIdByEle_List.TabIndex = 21;
            getIdByEle_List.Text = "根据元素查找序号(链表）";
            getIdByEle_List.UseVisualStyleBackColor = true;
            getIdByEle_List.Click += getIdByEle_List_Click;
            // 
            // getIdByEle_TextBox
            // 
            getIdByEle_TextBox.Location = new Point(604, 451);
            getIdByEle_TextBox.Name = "getIdByEle_TextBox";
            getIdByEle_TextBox.Size = new Size(292, 30);
            getIdByEle_TextBox.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(516, 455);
            label6.Name = "label6";
            label6.Size = new Size(82, 24);
            label6.TabIndex = 19;
            label6.Text = "输入元素";
            // 
            // getId_Text
            // 
            getId_Text.BackColor = SystemColors.GradientInactiveCaption;
            getId_Text.BorderStyle = BorderStyle.FixedSingle;
            getId_Text.Location = new Point(271, 455);
            getId_Text.Name = "getId_Text";
            getId_Text.Size = new Size(239, 30);
            getId_Text.TabIndex = 18;
            // 
            // getIdByEle_arr
            // 
            getIdByEle_arr.ImageAlign = ContentAlignment.BottomLeft;
            getIdByEle_arr.Location = new Point(29, 435);
            getIdByEle_arr.Name = "getIdByEle_arr";
            getIdByEle_arr.Size = new Size(222, 34);
            getIdByEle_arr.TabIndex = 17;
            getIdByEle_arr.Text = "根据元素查找序号(数组）";
            getIdByEle_arr.UseVisualStyleBackColor = true;
            getIdByEle_arr.Click += getIdByEle_arr_Click;
            // 
            // insert_List_btn
            // 
            insert_List_btn.Location = new Point(29, 596);
            insert_List_btn.Name = "insert_List_btn";
            insert_List_btn.Size = new Size(222, 34);
            insert_List_btn.TabIndex = 26;
            insert_List_btn.Text = "插入元素（链表）";
            insert_List_btn.UseVisualStyleBackColor = true;
            insert_List_btn.Click += insert_List_btn_Click;
            // 
            // insertEle
            // 
            insertEle.Location = new Point(361, 596);
            insertEle.Name = "insertEle";
            insertEle.Size = new Size(206, 30);
            insertEle.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(271, 602);
            label7.Name = "label7";
            label7.Size = new Size(82, 24);
            label7.TabIndex = 24;
            label7.Text = "插入元素";
            // 
            // insertedText
            // 
            insertedText.BackColor = SystemColors.GradientInactiveCaption;
            insertedText.BorderStyle = BorderStyle.FixedSingle;
            insertedText.Location = new Point(271, 554);
            insertedText.Name = "insertedText";
            insertedText.Size = new Size(625, 30);
            insertedText.TabIndex = 23;
            // 
            // insert_arr_btn
            // 
            insert_arr_btn.ImageAlign = ContentAlignment.BottomLeft;
            insert_arr_btn.Location = new Point(29, 556);
            insert_arr_btn.Name = "insert_arr_btn";
            insert_arr_btn.Size = new Size(222, 34);
            insert_arr_btn.TabIndex = 22;
            insert_arr_btn.Text = "插入元素（数组）";
            insert_arr_btn.UseVisualStyleBackColor = true;
            insert_arr_btn.Click += insert_arr_btn_Click;
            // 
            // insertIndex
            // 
            insertIndex.Location = new Point(676, 597);
            insertIndex.Name = "insertIndex";
            insertIndex.Size = new Size(220, 30);
            insertIndex.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(588, 599);
            label8.Name = "label8";
            label8.Size = new Size(82, 24);
            label8.TabIndex = 27;
            label8.Text = "插入位置";
            // 
            // deleteIndex
            // 
            deleteIndex.Location = new Point(361, 724);
            deleteIndex.Name = "deleteIndex";
            deleteIndex.Size = new Size(206, 30);
            deleteIndex.TabIndex = 35;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(273, 728);
            label9.Name = "label9";
            label9.Size = new Size(82, 24);
            label9.TabIndex = 34;
            label9.Text = "删除位置";
            // 
            // delete_List_btn
            // 
            delete_List_btn.Location = new Point(29, 720);
            delete_List_btn.Name = "delete_List_btn";
            delete_List_btn.Size = new Size(222, 34);
            delete_List_btn.TabIndex = 33;
            delete_List_btn.Text = "删除元素（链表）";
            delete_List_btn.UseVisualStyleBackColor = true;
            delete_List_btn.Click += delete_List_btn_Click;
            // 
            // deleteText
            // 
            deleteText.BackColor = SystemColors.GradientInactiveCaption;
            deleteText.BorderStyle = BorderStyle.FixedSingle;
            deleteText.Location = new Point(271, 684);
            deleteText.Name = "deleteText";
            deleteText.Size = new Size(625, 30);
            deleteText.TabIndex = 30;
            // 
            // delete_arr_btn
            // 
            delete_arr_btn.ImageAlign = ContentAlignment.BottomLeft;
            delete_arr_btn.Location = new Point(29, 680);
            delete_arr_btn.Name = "delete_arr_btn";
            delete_arr_btn.Size = new Size(222, 34);
            delete_arr_btn.TabIndex = 29;
            delete_arr_btn.Text = "删除元素（数组）";
            delete_arr_btn.UseVisualStyleBackColor = true;
            delete_arr_btn.Click += delete_arr_btn_Click;
            // 
            // deleteLable
            // 
            deleteLable.AutoSize = true;
            deleteLable.ForeColor = SystemColors.AppWorkspace;
            deleteLable.Location = new Point(588, 725);
            deleteLable.Name = "deleteLable";
            deleteLable.Size = new Size(154, 24);
            deleteLable.TabIndex = 36;
            deleteLable.Text = "输入序号删除元素";
            // 
            // LinearList
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 1085);
            Controls.Add(deleteLable);
            Controls.Add(deleteIndex);
            Controls.Add(label9);
            Controls.Add(delete_List_btn);
            Controls.Add(deleteText);
            Controls.Add(delete_arr_btn);
            Controls.Add(insertIndex);
            Controls.Add(label8);
            Controls.Add(insert_List_btn);
            Controls.Add(insertEle);
            Controls.Add(label7);
            Controls.Add(insertedText);
            Controls.Add(insert_arr_btn);
            Controls.Add(getIdByEle_List);
            Controls.Add(getIdByEle_TextBox);
            Controls.Add(label6);
            Controls.Add(getId_Text);
            Controls.Add(getIdByEle_arr);
            Controls.Add(getEleById_List);
            Controls.Add(getEleById_TextBox);
            Controls.Add(label5);
            Controls.Add(getEle_Text);
            Controls.Add(getEleById_arr);
            Controls.Add(lenText);
            Controls.Add(length);
            Controls.Add(label4);
            Controls.Add(createdText);
            Controls.Add(OutputText);
            Controls.Add(ListCreated);
            Controls.Add(label3);
            Controls.Add(ArrCreat_Btn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(InputBox);
            Name = "LinearList";
            Text = "顺序表的实现";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox InputBox;
        private Label label1;
        private Label label2;
        private Button ArrCreat_Btn;
        private Label label3;
        private Button ListCreated;
        private TextBox OutputText;
        private Label createdText;
        private Label label4;
        private Button length;
        private TextBox lenText;
        private Button getEleById_arr;
        private TextBox getEle_Text;
        private Label label5;
        private TextBox getEleById_TextBox;
        private Button getEleById_List;
        private Button getIdByEle_List;
        private TextBox getIdByEle_TextBox;
        private Label label6;
        private TextBox getId_Text;
        private Button getIdByEle_arr;
        private Button insert_List_btn;
        private TextBox insertEle;
        private Label label7;
        private TextBox insertedText;
        private Button insert_arr_btn;
        private TextBox insertIndex;
        private Label label8;
        private TextBox deleteIndex;
        private Label label9;
        private Button delete_List_btn;
        private TextBox deleteText;
        private Button delete_arr_btn;
        private Label deleteLable;
    }
}
