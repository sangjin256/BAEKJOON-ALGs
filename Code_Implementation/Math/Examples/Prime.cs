// # 2581

// 자연수 M과 N이 주어질 때 M이상 N이하의 자연수 중 소수인 것을 모두 골라 이들 소수의 합과

// 최솟값을 찾는 프로그램을 작성하시오. 예를 들어 M=60, N=100인 경우 60이상 100이하의

// 자연수 중 소수는 61, 67, 71, 73, 79, 83, 89, 97 총 8개가 있으므로, 이들 소수의

// 합은 620이고, 최솟값은 61이 된다.
using System;
class Lecture{
    public static void Main(string[] args){
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int sum = 0;
        bool firstDone = false;
        int min = 10000;
        for(int k = x; k <= y; k++){
            if(PrimeCheck(k)){
                sum += k;
                if(!firstDone){
                    min = k;
                    firstDone = true;
                }
            }
        }

        if(sum == 0) Console.WriteLine(-1);
        else Console.WriteLine(sum + "\n" + min);
    }

    public static bool PrimeCheck(int n){
        if(n < 2) return false;
        for(int i = 2; i * i <= n; i++){
            if(n % i == 0) return false;
        }

        return true;
    }
}