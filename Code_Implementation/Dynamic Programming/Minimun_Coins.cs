//coins = {c1,c2,c3,...,ck}와 만들어야 하는 목표액스 n이 있을 때
//가장 적은 수의 동전을 사용하여 합이 n이 되도록 하는 동전 수 구하기
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] coins;
	public static void Main(string[] args) {
        coins = new int[]{1,3,4};
        processed = new bool[7];
        value = new int[7];
        Console.WriteLine(Solve(6));

        //재귀가 아니라 반복문을 이용해 구현하기(젤 빠름)
        Array.Clear(value,0,value.Length);
        value[0] = 0;
        for(int i = 1; i <= 6; i++){
            value[i] = 1000000;
            foreach(var c in coins){
                if(i-c >= 0){
                    value[i] = Math.Min(value[i], value[i-c]+1);
                }
            }
        }
        Console.WriteLine(value[6]);

        //그 값이 어떻게 만들어지는 표현
        int[] first = new int[7];
        Array.Clear(value,0,value.Length);
        value[0] = 0;
        for(int i = 1; i <= 6; i++){
            value[i] = 1000000;
            foreach(var c in coins){
                if(i-c >= 0 && value[i-c] + 1 < value[i]){
                    value[i] = value[i-c] + 1;
                    first[i] = c;
                }
            }
        }
        int n = 6;
        while(n > 0){
            Console.Write(first[n] + " ");
            n -= first[n];
        }
    }

    //메모이제이션
    static bool[] processed;
    static int[] value;
    public static int Solve(int x){
        if(x < 0) return 1000000;
        if(x == 0) return 0;
        if(processed[x]) return value[x];
        int best = 1000000;
        foreach(var c in coins){
            best = Math.Min(best, Solve(x-c)+1);
        }
        processed[x] = true;
        value[x] = best;
        return value[x];
    }
}