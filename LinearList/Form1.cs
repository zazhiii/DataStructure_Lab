using System;

namespace LinearList
{
    public partial class LinearList : Form
    {
        public class Node
        {//�ڵ���
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
        int count; //ά��Ԫ�ظ���
        int[] a;
        Node p0;
        public LinearList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //������������
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
        //��̬������������
        private void PrintArr(TextBox tb)
        {
            String s = "";
            for (int i = 0; i < count; i++) s += (a[i] + " ");
            tb.Text = s;
        }
        //������̬����
        private void ArrBtn_Click(object sender, EventArgs e)
        {
            String[] s = InputBox.Text.Split(" ");//������������
            a = new int[20];//��ʼ����20
            count = 0;
            for (int i = 0; i < s.Length; i++) //ת��Ϊ��������
            {
                try
                {
                    a[i] = int.Parse(s[i]);
                }
                catch
                {
                    createdText.Text = "�����ʽ����ȷ����";
                    createdText.ForeColor = Color.Red;
                }
                count++;
                if (count == a.Length)
                {//����
                    int[] b = new int[a.Length * 2];
                    Array.Copy(a, b, a.Length);
                    a = b;
                }
            }
            createdText.Text = "�Ѵ�������";
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
        //��������
        private void ListCreated_Click(object sender, EventArgs e)
        {
            String[] s = InputBox.Text.Split(" ");//������������
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
                    createdText.Text = "�����ʽ����ȷ����";
                    createdText.ForeColor = Color.Red;
                }
                Node p = new Node(value, prev, null);
                prev.next = p;
                prev = p;
                count++;
            }
            createdText.Text = "�Ѵ�������";
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
                getEle_Text.Text = "δ���ҵ�Ԫ�أ���";
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
                getEle_Text.Text = "δ���ҵ�Ԫ�أ���";
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
            getId_Text.Text = "δ���ҵ�Ԫ�أ���";
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
            getId_Text.Text = "δ���ҵ�Ԫ�أ���";
            getId_Text.ForeColor = Color.Red;
        }

        private void insert_arr_btn_Click(object sender, EventArgs e)
        {
            int idx = int.Parse(insertIndex.Text);
            int ele = int.Parse(insertEle.Text);
            if (idx < 1 || idx > count)
            {
                insertedText.Text = "����λ�ò���ȷ";
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
                insertedText.Text = "����λ�ò���ȷ";
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
                deleteLable.Text = "ɾ��λ�ò���ȷ";
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
            deleteLable.Text = "ɾ���ɹ���";
            deleteLable.ForeColor = Color.Green;
        }

        private void delete_List_btn_Click(object sender, EventArgs e)
        {
            int idx = int.Parse(deleteIndex.Text);
            if (idx < 1 || idx > count)
            {
                deleteLable.Text = "ɾ��λ�ò���ȷ";
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
            deleteLable.Text = "ɾ���ɹ���";
            deleteLable.ForeColor = Color.Green;
        }
    }
}
