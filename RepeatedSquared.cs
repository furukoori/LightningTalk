using System;

//èàóùåvë™ https://qiita.com/Kosen-amai/items/81efaf815b48ab9ffbb6
//åJÇËï‘ÇµÅ@https://math.nakaken88.com/textbook/cp-binary-exponentiation-and-recursive-function/
//åJÇËï‘ÇµC# https://webbibouroku.com/Blog/Article/cs-exponentiation-by-squaring
//mod https://qiita.com/drken/items/3b4fdf0a78e7a138cd9a
namespace RepeatedSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            int p = (int)Math.Pow(10, 8);

            CSPowStart(n, p);
            Console.WriteLine();
            LoopStart(n, p);
            Console.WriteLine();
            PowStart(n, p);
            Console.WriteLine();

            var ans = Math.Pow(2, 100000000);
            Console.WriteLine("2ÇÃ100,000,000èÊ = " + ans);

            Console.WriteLine();
            ModSample();

            Console.WriteLine();
            Console.WriteLine(TestPow());
            Console.WriteLine(Math.Log(10));
        }
        static public int Mod = 1000000007;
        static public void LoopStart(int n, int p)
        {
            Console.WriteLine("Loop");
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            long v = Loop(n, p);
            sw.Stop();
            Console.WriteLine(v + "(" + sw.Elapsed.TotalSeconds + ")ïb");
        }
        static public long Loop(int n, int p)
        {
            long x = 1;
            for (int i = 0; i < p; i++)
            {
                x *= n;
                x %= Mod;
            }
            return x;
        }
        static public void PowStart(int n, int p)
        {
            Console.WriteLine("RepeatedSquares");
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            long v = RepeatedSquares(n, p);
            sw.Stop();
            Console.WriteLine(v + "(" + sw.Elapsed.TotalSeconds + ")ïb");
        }

        static long RepeatedSquares(long n, long p)
        {
            if (p == 0) return 1; // nÇÃ0èÊÇÕ1
            else if (p % 2 == 0)
            {
                var x = RepeatedSquares(n, p / 2);
                return (x * x) % Mod;
            }
            else
            {
                return RepeatedSquares(n, p - 1) * n % Mod;
            }
        }

        static long TestPow(int n = 2, int p = 8)
        {
            Console.WriteLine("n = " + n + ", p = " + p);
            if (p == 0) return 1;Å@//0èÊÇ…Ç‡ëŒâûÇ∑ÇÈèÍçá
            if (p == 1) return n;
            var x = TestPow(n, p / 2);
            return (x * x);
        }

        static public void CSPowStart(int n, int p)
        {
            Console.WriteLine("RepeatedSquares");
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            long v = CSPow(n, p);
            sw.Stop();
            Console.WriteLine(v + "(" + sw.Elapsed.TotalSeconds + ")ïb");
        }
        //n=2, p = 100,000,000
        //Mod=1000000007
        static long CSPow(long n, long p)
        {
            //2 ^ 100,000,000 ÇãÅÇﬂÇÈ
            var ans = (long)Math.Pow(n, p);

            //ÇªÇÃåãâ Ç Mod Ç≈äÑÇ¡Çƒó]ÇËÇãÅÇﬂÇÈ
            ans %= Mod;
            return ans;
        }
        static public void ModSample()
        {

            var v1 = ModSample1();
            Console.WriteLine("ModSample1 = " + v1);
            var v2 = ModSample2();
            Console.WriteLine("ModSample2 = " + v2);
        }
        static public int mod = 100;
        static public int ModSample1(int n = 2, int p = 10)
        {
            var v = (int)Math.Pow(n, p);
            return v % mod;
        }
        static public int ModSample2(int n = 2, int p = 10)
        {
            int v = 1;
            for (int i = 0; i < p; i++)
            {
                v *= 2;
                v %= mod;
            }
            return v;
        }
    }
}
