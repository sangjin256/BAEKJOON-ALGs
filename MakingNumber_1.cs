/*
# 1463

정수 X에 사용할 수 있는 연산은 다음과 같이 세 가지 이다.

1. X가 3으로 나누어 떨어지면, 3으로 나눈다.
2. X가 2로 나누어 떨어지면, 2로 나눈다.
3. 1을 뺀다.

정수 N이 주어졌을 때, 위와 같은 연산 세 개를 적절히 사용해서 1을 만들려고 한다.

연산을 사용하는 횟수의 최솟값을 출력하시오.

*/

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		// 1보다 크거나 같고, 10^6보다 작거나 같은 정수 N이 주어진다.
		long n = long.Parse(Console.ReadLine());
		
		long[] dp = new long[1000001];
		// 인풋이 1이면 답은 1이 아니라 0!!!
		dp[1] = 0;
		dp[2] = 1;
		dp[3] = 1;
		
		// n이 3 이하일때는 미리 끝내준다.
		if(n < 4){
			Console.WriteLine(dp[n]);
			return;
		}
		
		for(int i = 4; i <= n; i++){
			if(i%3 == 0)
				dp[i] = Math.Min(dp[i-1] + 1, dp[i/3] + 1);
			else if(i%2 == 0)
				dp[i] = Math.Min(dp[i-1] + 1, dp[i/2] + 1);
			else
				dp[i] = dp[i-1] + 1;
		}
		
		Console.WriteLine(dp[n]);
	}
}