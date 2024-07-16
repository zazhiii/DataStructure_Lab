using System;
using System.ComponentModel.DataAnnotations;
class Hello
{
    //递推
    static int fib1(int n)
    {
        if (n <= 2) return 1;
        int a = 1, b = 1;
        int tmp = 0;
        for (int i = 3; i <= n; i++)
        {
            tmp = a + b;
            a = b;
            b = tmp;
        }
        return tmp;
    }
    //递归
    static int fib2(int n)
    {
        if (n <= 2) return 1;
        return fib2(n - 1) + fib1(n - 2);
    }
    //尾递归
    static int fib3(int n, int first, int second)
    {
        if (n <= 2) return 1;
        if (n == 3) return first + second;
        return fib3(n - 1, second, first + second);
    }
    static void Main(string[] args)
    {
        // 定义不同大小的数据
        int[] dataSizes = { 10, 20, 30, 40, 50 };

        for(int i = 0; i < dataSizes.Length; i++) 
        {
            DateTime startTime = DateTime.Now;
            fib1(dataSizes[i]);
            DateTime endTime = DateTime.Now;
            Console.Write("地推：" + (endTime - startTime).TotalMilliseconds + " ");
            startTime = DateTime.Now;
            fib2(dataSizes[i]);
            endTime = DateTime.Now;
            Console.Write("递归" + (endTime - startTime).TotalMilliseconds + " ");
            startTime = DateTime.Now;
            fib3(dataSizes[i], 1, 1);
            endTime = DateTime.Now;
            Console.Write("尾递归" + (endTime - startTime).TotalMilliseconds + "\n");
        }
    }
}