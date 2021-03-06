/*
# 11399

사람들이 줄을 서는 순서에 따라서, 돈을 인출하는데 필요한 시간의 합이 달라지게 된다.

예를 들어, 총 5명이 있고, P1 = 3, P2 = 1, P3 = 4, P4 = 3, P5 = 2 인 경우를 생각해보자.

줄을 [2, 5, 1, 4, 3] 순서로 줄을 서면, 2번 사람은 1분만에, 5번 사람은 1+2 = 3분,

1번 사람은 1+2+3 = 6분, 4번 사람은 1+2+3+3 = 9분, 3번 사람은 1+2+3+3+4 = 13분이

걸리게 된다. 각 사람이 돈을 인출하는데 필요한 시간의 합은 1+3+6+9+13 = 32분이다.

이 방법보다 더 필요한 시간의 합을 최소로 만들 수는 없다.

줄을 서 있는 사람의 수 N과 각 사람이 돈을 인출하는데 걸리는 시간 Pi가 주어졌을 때,

각 사람이 돈을 인출하는데 필요한 시간의 합의 최솟값을 구하는 프로그램을 작성하시오.
*/

using System;
using System.IO;
using System.Collections.Generic;

class c 
{
	public static void Main(string[] args) {
		//첫째 줄에 사람의 수(1부터 1000까지) 둘째줄에는 각 사람이 돈을 인출하는데 걸리는 시간이 주어짐
		int n = int.Parse(Console.ReadLine());
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		
		//각 사람이 돈을 인출하는데 필요한 시간의 합의 최솟값은
		//시간이 가장 적게 걸리는 순서대로 나열했을때 더한 값이 최솟값이다.
		Array.Sort(arr);
		for(int i = 1; i < n; i++){
			arr[i] += arr[i-1]; 
		}
		
		int result = 0;
		for(int i = 0; i < n; i++){
			result += arr[i];
		}
		
		Console.WriteLine(result);
	}
}