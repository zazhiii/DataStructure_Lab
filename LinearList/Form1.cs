using System;

namespace LinearList
{
    public partial class LinearList : Form
    {
        public class Node
        {//节点类
            public int value;
            public Node next;
            public Node prev;
            public Node(int value, Node prev, Node next)
            {
                this.value = value;
                this.prev = prev;
                this.next = next;
            }

        }
        int count; //维护元素个数
        int[] a;
        Node p0;
        public LinearList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //链表的输出函数
        private void PrintList(TextBox tb)
        {
            String s = "";
            Node p = p0.next;
            while (p != null)
            {
                s += p.value + " ";
                p = p.next;
            }
            tb.Text = s;
        }
        //动态数组的输出函数
        private void PrintArr(TextBox tb)
        {
            String s = "";
            for (int i = 0; i < count; i++) s += (a[i] + " ");
            tb.Text = s;
        }
        //创建动态数组
        private void ArrBtn_Click(object sender, EventArgs e)
        {
            String[] s = InputBox.Text.Split(" ");//解析输入数字
            a = new int[20];//初始长度20
            count = 0;
            for (int i = 0; i < s.Length; i++) //转换为整数数组
            {
                try
                {
                    a[i] = int.Parse(s[i]);
                }
                catch
                {
                    createdText.Text = "输入格式不正确！！";
                    createdText.ForeColor = Color.Red;
                }
                count++;
                if (count == a.Length)
                {//扩容
                    int[] b = new int[a.Length * 2];
                    Array.Copy(a, b, a.Length);
                    a = b;
                }
            }
            createdText.Text = "已创建链表！";
            createdText.ForeColor = Color.Green;
            getEleById_arr.ForeColor = Color.Black;
            getIdByEle_arr.ForeColor = Color.Black;
            insert_arr_btn.ForeColor = Color.Black;
            delete_arr_btn.ForeColor = Color.Black;
            getEleById_List.ForeColor = Color.DarkGray;
            getIdByEle_List.ForeColor = Color.DarkGray;
            insert_List_btn.ForeColor = Color.DarkGray;
            delete_List_btn.ForeColor= Color.DarkGray;
            PrintArr(OutputText);
        }
        //创建链表
        private void ListCreated_Click(object sender, EventArgs e)
        {
            String[] s = InputBox.Text.Split(" ");//解析输入数字
            count = 0;
            p0 = new Node(0, null, null);
            Node prev = p0;
            for (int i = 0; i < s.Length; i++)
            {
                int value = 0;
                try
                {
                    value = int.Parse(s[i]);
                }
                catch
                {
                    createdText.Text = "输入格式不正确！！";
                    createdText.ForeColor = Color.Red;
                }
                Node p = new Node(value, prev, null);
                prev.next = p;
                prev = p;
                count++;
            }
            createdText.Text = "已创建链表！";
            createdText.ForeColor = Color.Green;
            getEleById_List.ForeColor = Color.Black;
            getIdByEle_List.ForeColor = Color.Black;
            insert_List_btn.ForeColor = Color.Black;
            delete_List_btn.ForeColor = Color.Black;
            getEleById_arr.ForeColor = Color.DarkGray;
            getIdByEle_arr.ForeColor = Color.DarkGray;
            insert_arr_btn.ForeColor= Color.DarkGray;
            delete_arr_btn.ForeColor= Color.DarkGray;
            PrintList(OutputText);
        }

        private void length_Click(object sender, EventArgs e)
        {
            lenText.Text = count + "";
        }

        private void getEleById_arr_Click(object sender, EventArgs e)
        {
            int index = int.Parse(getEleById_TextBox.Text);
            if (index <= 0 || index > count)
            {
                getEle_Text.Text = "未查找到元素！！";
                getEle_Text.ForeColor = Color.Red;
            }
            else
            {
                getEle_Text.Text = a[index - 1] + "";
            }
        }

        private void getEleById_List_Click(object sender, EventArgs e)
        {
            int index = int.Parse(getEleById_TextBox.Text);
            if (index <= 0 || index > count)
            {
                getEle_Text.Text = "未查找到元素！！";
                getEle_Text.ForeColor = Color.Red;
            }
            else
            {
                Node p = p0.next;
                int cnt = 0;
                while (p != null)
                {
                    cnt++;
                    if (cnt == index) getEle_Text.Text = p.value + "";
                    p = p.next;
                }
            }
        }

        private void getIdByEle_arr_Click(object sender, EventArgs e)
        {
            int ele = int.Parse(getIdByEle_TextBox.Text);
            for (int i = 0; i <= count - 1; i++)
            {
                if (a[i] == ele)
                {
                    getId_Text.Text = (i + 1) + "";
                    return;
                }
            }
            getId_Text.Text = "未查找到元素！！";
            getId_Text.ForeColor = Color.Red;
        }

        private void getIdByEle_List_Click(object sender, EventArgs e)
        {
            int ele = int.Parse(getIdByEle_TextBox.Text);
            int idx = 0;
            Node p = p0.next;
            while (p != null)
            {
                idx++;
                if (p.value == ele)
                {
                    getId_Text.Text = idx + "";
                    return;
                }
                p = p.next;
            }
            getId_Text.Text = "未查找到元素！！";
            getId_Text.ForeColor = Color.Red;
        }

        private void insert_arr_btn_Click(object sender, EventArgs e)
        {
            int idx = int.Parse(insertIndex.Text);
            int ele = int.Parse(insertEle.Text);
            if (idx < 1 || idx > count)
            {
                insertedText.Text = "插入位置不正确";
                return;
            }
            for (int i = count; i >=idx; i--) a[i] = a[i - 1];
            a[idx-1] = ele;
            count++;
            PrintArr(insertedText);
        }

        private void insert_List_btn_Click(object sender, EventArgs e)
        {
            int idx = int.Parse(insertIndex.Text);
            int ele = int.Parse(insertEle.Text);
            if (idx < 1 || idx > count)
            {
                insertedText.Text = "插入位置不正确";
                return ;
            }
                int cnt = 0;
            Node p = p0.next;
            Node prev = p0;
            while(p != null)
            {
                cnt++;
                if (cnt == idx) {
                    Node newP = new Node(ele, prev, p);
                    prev.next = newP;
                }
                prev = p;
                p = p.next;
            }
            count++;
            PrintList(insertedText);
        }

        private void delete_arr_btn_Click(object sender, EventArgs e)
        {
            int idx = int.Parse(deleteIndex.Text);
            if (idx < 1 || idx > count)
            {
                deleteLable.Text = "删除位置不正确";
                deleteLable.ForeColor = Color.Red;
                return;
            }
            for(int i  = idx-1; i<=count-2; i++)
            {
                a[i] = a[i+1];
            }
            a[count] = 0;
            count--;
            PrintArr(deleteText);
            deleteLable.Text = "删除成功！";
            deleteLable.ForeColor = Color.Green;
        }

        private void delete_List_btn_Click(object sender, EventArgs e)
        {
            int idx = int.Parse(deleteIndex.Text);
            if (idx < 1 || idx > count)
            {
                deleteLable.Text = "删除位置不正确";
                deleteLable.ForeColor = Color.Red;
                return;
            }
                int cnt = 0;
            Node p = p0.next;
            Node prev = p0;
            while(p != null)
            {
                cnt++; 
                if (cnt == idx) 
                {
                    prev.next = p.next;
                    count--;
                    break;
                }
                prev = p;
                p = p.next;
            }
            PrintList(deleteText);
            deleteLable.Text = "删除成功！";
            deleteLable.ForeColor = Color.Green;
        }
    }
}
