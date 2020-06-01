using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class rt 
{
	public static void Main(string[] args) {
        int n = 20;
        sieve = new int[n+1];
        processed = new bool[n+1];
        sievef = new int[n+1];
        SieveOfEratosthenes(n);
        //배열의 인덱스는 2부터 봐야함
        for(int i = 2; i < n+1; i++){
            Console.Write(sieve[i]);
        }
        Console.WriteLine();
        
        EratosFactor(n);
        for(int i = 2; i < n+1; i++){
            Console.Write(sievef[i]);
        }
        Console.WriteLine();

        foreach(var c in Factors(n)){
            Console.Write(c + " ");
        }
    }

    //에라토스테네스의 체 생성 함수
    //에라토스테네스의 체는 2이상 n 이하의 정수 x가 소수인지를 효율적으로 판별할
    //수 있도록 sieve배열을 만드는 전처리 알고리즘
    //x가 소수이면 sieve[x] = false; 아니면 sieve[x] = true;
    //새로운 소수 x를 발견할 때마다 2x, 3x, 4x 등을 소수가 아니라고 기록
    static int[] sieve;
    public static void SieveOfEratosthenes(int n){
        for(int x = 2; x<= n; x++){
            if(Convert.ToBoolean(sieve[x])) continue;
            for(int u = 2*x; u <= n; u+=x){
                sieve[u] = 1;
            }
        }
    }

    //에라토스테네스의 체 확장
    //각각의 수 k에 대해 가장 작은 소인수를 넣어둠
    //그러면 이 배열을 이용하여 2이상 n이하의 모든 수를 효율적으로 소인수분해가능
    static bool[] processed;
    static int[] sievef;
    public static void EratosFactor(int n){
        for(int x = 2; x<= n; x++){
            if(processed[x]) continue;
            for(int u = x; u <= n; u += x){
                if(processed[u]) continue;
                sievef[u] = x;
                processed[u] = true;
            }
        }
    }

    //에라토스테네스의 체 확장을 사용하여 소인수분해하기
    public static List<int> Factors(int n){
        List<int> f = new List<int>();
        while(n > 1){
            f.Add(sievef[n]);
            n/=sievef[n];
        }
        return f;
    }
}