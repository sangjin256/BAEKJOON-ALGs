using System;

//기본 피보나치
class Fibo{
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        int[] dp = new int[n+1];
        dp[0] = 0;
        dp[1] = 1;

        for(int i = 2; i <= n; i++){
            dp[i] = dp[i-1]+dp[i-2];
        }

        Console.WriteLine(dp[n]);
    }
}
// 기본 피보나치
class Fibo_Original{
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Fibonacci(n));
    }

    public static int Fibonacci(int n){
        if(n == 0) return 0;
        if(n == 1) return 1;
        return Fibonacci(n-1) + Fibonacci(n-2);
    }
}