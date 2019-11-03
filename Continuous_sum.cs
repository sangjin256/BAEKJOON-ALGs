/*
# 1912

n개의 정수로 이루어진 임의의 수열이 주어진다.

우리는 이 중 연속된 몇 개의 수를 선택해서 구할 수 있는 합 중 가장 큰 합을 구하려고 한다.

단, 수는 한 개 이상 선택해야 한다. 예를 들어서 10, -4, 3, 1, 5, 6, -35, 12, 21, -1

이라는 수열이 주어졌다고 하자. 여기서 정답은 12+21인 33이 정답이 된다.
*/
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		//정수 1<=n<=100000이 주어짐
		int n = int.Parse(Console.ReadLine());
		//N개의 정수로 이루어진 수열이 주어짐(-1000~1000)
		int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		
		int[] dp = new int[n+1];
		
		dp[0] = numbers[0];
		for(int i = 1; i < n; i++){
			dp[i] = Math.Max(dp[i-1] + numbers[i], numbers[i]);
		}
		//수가 음수로만 이루어질 수도 있다. 따라서 mx를 0으로 놓으면 틀린 답이 나온다.
		int mx = -1001;
		for(int i = 0; i < n; i++){
			mx = Math.Max(mx, dp[i]);
		}
		
		Console.WriteLine(mx);
	}
}