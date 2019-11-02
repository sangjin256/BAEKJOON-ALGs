/*
# 2579

계단 오르기 게임은 계단 아래 시작점부터 계단 꼭대기에 위치한 도착점까지 가는 게임이다.

각각의 계단에는 일정한 점수가 쓰여 있는데 계단을 밟으면 그 계단에 쓰여 있는 점수를 얻게 된다.

계단 오르는 데는 다음과 같은 규칙이 있다.

1. 계단은 한 번에 한 계단씩 또는 두 계단씩 오를 수 있다.
즉, 한 계단을 밟으면서 이어서 다음 계단이나, 다음 다음 계단으로 오를 수 있다.
2. 연속된 세 개의 계단을 모두 밟아서는 안 된다. 단, 시작점은 계단에 포함되지 않는다.
3. 마지막 도착 계단은 반드시 밟아야 한다.

따라서 첫 번째 계단을 밟고 이어 두 번째 계단이나, 세 번째 계단으로 오를 수 있다.

하지만, 첫 번째 계단을 밟고 이어 네 번째 계단으로 올라가거나, 첫 번째, 두 번째,

세 번째 계단을 연속해서 모두 밟을 수는 없다.

각 계단에 쓰여 있는 점수가 주어질 때 이 게임에서 얻을 수 있는 총 점수의 최댓값을

구하는 프로그램을 작성하시오.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		//계단의 개수 입력, 300 이하의 자연수
		int n = int.Parse(Console.ReadLine());
		//각 계단의 점수 입력, 10,000점 이하의 자연수
		int[] stairs = new int[n+1];
		for(int i = 0; i < n; i++){
			stairs[i] = int.Parse(Console.ReadLine());
		}
		
		
		int[] dp = new int[301];
		
        // index == 0은 1칸 움직였을때 최댓값 (1칸가는 방법은 1개만 존재)
        // index == 1은 2칸 움직였을때 최댓값
        // index == 2는 3칸 움직였을때 최대값 (1칸+2칸, 2칸+1칸 총 2개 존재)
		dp[0] = stairs[0];
		dp[1] = stairs[0] + stairs[1];
		dp[2] = Math.Max(stairs[0] + stairs[2], stairs[1] + stairs[2]);
		
		// dp[i]까지 방법은 연속 3칸이 안되므로 2칸전까지의 최댓값(dp[i-2]) + 현재값 또는 전전전칸의 최댓값 + 1칸전값 + 현재값이다.
		for(int i = 3; i < n; i++){
			dp[i] = Math.Max(dp[i-2] + stairs[i], dp[i-3] + stairs[i-1] + stairs[i]);
		}
		
		Console.WriteLine(dp[n-1]);
		
	}
}