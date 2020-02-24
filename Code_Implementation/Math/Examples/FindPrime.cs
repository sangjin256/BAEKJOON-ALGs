// # 1978

// 주어진 수 N개 중에서 소수가 몇 개인지 찾아서 출력하는 프로그램을 작성하시오.

using System;
class Lecture{
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        int count = 0;
        for(int i = 0; i < arr.Length; i++){
            if(PrimeCheck(arr[i])) count++;
        }

        return count;
    }

    public static bool PrimeCheck(int n){
        if(n == 1) return false;

        for(int i = 2; i*i <= n ; i++){
            if(n % i == 0) return false;
        }

        return true;
    }
}