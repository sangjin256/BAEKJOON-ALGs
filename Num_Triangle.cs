/*
#1932

        7
      3   8
    8   1   0
  2   7   4   4
4   5   2   6   5
위 그림은 크기가 5인 정수 삼각형의 한 모습이다.

맨 위층 7부터 시작해서 아래에 있는 수 중 하나를 선택하여 아래층으로 내려올 때,

이제까지 선택된 수의 합이 최대가 되는 경로를 구하는 프로그램을 작성하라. 아래층에 있는

수는 현재 층에서 선택된 수의 대각선 왼쪽 또는 대각선 오른쪽에 있는 것 중에서만 선택할 수

있다. 삼각형의 크기는 1 이상 500 이하이다. 삼각형을 이루고 있는 각 수는 모두 정수이며,

범위는 0 이상 9999 이하이다. 
*/

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		//삼각형의 크기가 주어짐(1~500)
		int n = int.Parse(Console.ReadLine());
		
		int[,] nums = new int[n+1,501];
		
		for(int i = 1; i <= n; i++){
			int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
			for(int j = 1; j <= i; j++){
				nums[i,j] = arr[j-1];
			}
		}
		
		int[,] dp = new int[n+1,501];
		
		//dp[i,j]는 i층에 있는 i번째 숫자를 뜻한다.
		//i층 첫번째 숫자를 처리할 경우 그 숫자는 윗층 첫 숫자랑밖에 계산할 수 없다.
		//i층 마지막 숫자를 처리할 경우 그 숫자는 윗층 마지막 숫자랑밖에 계산할 수 없다.
		//나머지 중간 숫자들은 왼쪽 대각선 위와 오른쪽 대각선 위랑 계산할 수 있으므로 그 둘중 최댓값과 계산해준다.
		int mx = 0;
		for(int i = 1; i <= n; i++){
			for(int j = 1; j <= i; j++){
				if(j == 1) dp[i,j] = dp[i-1,j] + nums[i,j];
				else if(j == i) dp[i,j] = dp[i-1,j-1] + nums[i,j];
				else dp[i,j] = Math.Max(dp[i-1,j-1] + nums[i,j], dp[i-1,j] + nums[i,j]);
				if(mx < dp[i,j]) mx = dp[i,j];
			}
		}
		
		Console.WriteLine(mx);
		
	}
}