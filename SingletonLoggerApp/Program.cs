using static SingletonLoggerApp.SingletonLogger;

namespace SingletonLoggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInstance();
            int k = 56;

            int c(int q)
            {
                return q;
            }

            int z(int a, int b)
            {
                int v = a + b;
                return v;
            }

            double p = 2.12566;

            PushToLogTrace("k is " + k);
            PushToLogTrace("c(k) is " + c(4789));
            PushToLogTrace("z is " + z(147,23));
            PushToLogTrace("p is " + p);
            PushToLogTrace("Hello world!");
        }
    }
}
