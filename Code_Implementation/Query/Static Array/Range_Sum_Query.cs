using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class tj 
{
    //누적 합 배열
    static int[] sum;
	public static void Main(string[] args) {
        int[] arr = new int[]{1,3,4,8,6,1,4,2};
        sum = new int[arr.Length];
        //누적 합 배열 구하기
        sum[0] = arr[0];
        for(int i = 1; i < arr.Length; i++){
            sum[i] = sum[i-1] + arr[i];
        }
        //sum(a,b) = sum(0,b) - sum(0,a-1)이 된다.
        Console.WriteLine(Sum(3,6));
    }
    
    public static int Sum(int a, int b){
        //sum(0,-1)은 0으로 정의하면 a = 0일때도 성립한다.
        if(a == 0) return sum[b];
        return sum[b] - sum[a-1];
    }
}