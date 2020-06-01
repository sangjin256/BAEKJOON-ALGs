/*
#11053

수열 A가 주어졌을 때, 가장 긴 증가하는 부분 수열을 구하는 프로그램을 작성하시오.

예를 들어, 수열 A = {10, 20, 10, 30, 20, 50} 인 경우에 가장 긴 증가하는 부분 수열은

A = {10, 20, 30, 50} 이고, 길이는 4이다.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class v 
{
	public static void Main(string[] args) {
		//수열 arr의 크기 n(1<=n<=1000)이 주어짐
		int n = int.Parse(Console.ReadLine());
		//수열 arr을 이루고 있는 a(i)가 주어짐
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		
		int[] dp = new int[n+1];
		//i < k 이고 arr[i] < arr[k]인 k값
		//dp[i]는 위의 조건을 만족하는 dp[i-1] +1 또는 자기 자신 1개
		dp[0] = 1;
		for(int i = 1; i < n; i++){
			dp[i] = 1;
			for(int k = 0; k < i; k++){
				if(arr[k] <arr[i]){
					dp[i] = Math.Max(dp[k] + 1, dp[i]);
				}
			}
		}
		
        //dp배열중 최댓값 찾고 출력
		int mx = 0;
		for(int i = 0; i < n; i++){
			mx = Math.Max(mx, dp[i]);
		}
		Console.WriteLine(mx);
	}
}