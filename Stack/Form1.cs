namespace Stack
{
    public partial class Form1 : Form
    {
        //char[] operChar = new char[] { '+', '-', '*', '/', '=' };
        //List<string> expressList = new List<string>();//存放操作数和操作符
        Stack<double> numbers = new Stack<double>();
        Stack<char> operators = new Stack<char>();
        public Form1()
        {
            InitializeComponent();
        }

        private void compute_btn_Click(object sender, EventArgs e)
        {
            string exp = InputBox.Text;
            double res = EvaluateExpression(exp);
            outputBox.Text = res +"";
        }

         double EvaluateExpression(string expression)
        {
            

            int i = 0;
            while (i < expression.Length)
            {
                if (expression[i] == ' ')
                {
                    i++; // 忽略空格
                }
                else if (char.IsDigit(expression[i]))
                {
                    double num = 0;
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        num = num * 10 + (expression[i] - '0');
                        i++;
                    }
                    numbers.Push(num);
                }
                else if (IsOperator(expression[i]))
                {
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(expression[i]))
                    {
                        ApplyOperator(numbers, operators);
                    }
                    operators.Push(expression[i]);
                    i++;
                }
                else
                {
                    throw new ArgumentException($"无效的字符: {expression[i]}");
                }
            }

            while (operators.Count > 0)
            {
                ApplyOperator(numbers, operators);
            }

            if (numbers.Count == 1 && operators.Count == 0)
            {
                return numbers.Pop();
            }
            else
            {
                throw new ArgumentException("无效的表达式");
            }
        }

         bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }

         int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    throw new ArgumentException($"无效的操作符: {op}");
            }
        }

         void ApplyOperator(Stack<double> numbers, Stack<char> operators)
        {
            double b = numbers.Pop();
            double a = numbers.Pop();
            char op = operators.Pop();
            double result;
            switch (op)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    if (b == 0)
                    {
                        throw new DivideByZeroException("除数不能为零");
                    }
                    result = a / b;
                    break;
                default:
                    throw new ArgumentException($"无效的操作符: {op}");
            }
            numbers.Push(result);
        }
    }
}
