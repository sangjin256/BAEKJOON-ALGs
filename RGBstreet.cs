/*
# 1149

RGB거리에 사는 사람들은 집을 빨강, 초록, 파랑중에 하나로 칠하려고 한다.

또한, 그들은 모든 이웃은 같은 색으로 칠할 수 없다는 규칙도 정했다.

집 i의 이웃은 집 i-1과 집 i+1이고, 첫 집과 마지막 집은 이웃이 아니다.

각 집을 빨강으로 칠할 때 드는 비용, 초록으로 칠할 때 드는 비용, 파랑으로 드는 비용이 주어질 때,

모든 집을 칠하는 비용의 최솟값을 구하는 프로그램을 작성하시오.
 */

using System;
using System.IO;
using System.Collections.Generic;

public class o 
{
	public static void Main(string[] args) {
		// 첫째 줄에 집의 수 N이 주어진다. N은 1,000보다 작거나 같다. 둘째 줄부터 N개의 줄에 각 집을 빨강으로, 초록으로, 파랑으로 칠하는 비용이 주어진다. 비용은 1,000보다 작거나 같은 자연수이다.
		int n = int.Parse(Console.ReadLine());
		int[,] colors = new int[n,3];
		for(int i = 0; i < n; i++){
			int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
			colors[i,0] = tmp[0];
			colors[i,1] = tmp[1];
			colors[i,2] = tmp[2];
		}
		
		// 동적계획법을 사용하기 위한 배열(dynamic programming)을 만들어준다.
		// 빨강, 초록, 파랑을 선택했을 경우를 각각 따로 다룬다.
		int[,] dp = new int[n,3];
		dp[0,0] = colors[0,0];
		dp[0,1] = colors[0,1];
		dp[0,2] = colors[0,2];
		
		// 현재 빨강을 선택했을 경우 이전단계가 파랑이었을때의 최솟값 또는 초록이었을때 최솟값
		// 현재 파랑과 현재 초록도 같은 방식이다.
		for(int i = 1; i < n; i++){
			dp[i,0] = colors[i,0] + Math.Min(dp[i-1,1], dp[i-1,2]);
			dp[i,1] = colors[i,1] + Math.Min(dp[i-1,0], dp[i-1,2]);
			dp[i,2] = colors[i,2] + Math.Min(dp[i-1,0], dp[i-1,1]);
		}
		
		Console.WriteLine(Min_(dp[n-1,0], dp[n-1,1], dp[n-1,2]));
		
		
	}
	
	// 색이 3개이므로 3개의 최댓값을 한번에 비교할 수 있는 함수를 만들어준다.
	static int Min_(int a, int b, int c){
		return (a < b && a < c) ? a : (b < c) ? b : c;
	}
}