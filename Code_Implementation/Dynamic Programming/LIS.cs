//최장 증가 부분 수열
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    public static void Main(string[] args) {
        int[] arr = new int[]{6,2,5,1,7,4,8,3};
        int[] dp = new int[arr.Length];
        for(int i = 0; i < arr.Length; i++){
            dp[i] = 1;
            for(int k = 0; k < i; k++){
                if(arr[k] < arr[i]){
                    dp[i] = Math.Max(dp[i], dp[k]+1);
                }
            }
        }
        int mx = 0;
        for(int i = 0; i < arr.Length; i++){
        	mx = Math.Max(mx, dp[i]);
        }
        Console.WriteLine(mx);
    }
}