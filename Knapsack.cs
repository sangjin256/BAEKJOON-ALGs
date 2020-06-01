/*
# 12865

이 문제는 아주 평범한 배낭에 관한 문제이다.

한 달 후면 국가의 부름을 받게 되는 준서는 여행을 가려고 한다.

세상과의 단절을 슬퍼하며 최대한 즐기기 위한 여행이기 때문에, 가지고 다닐 배낭 또한 최대한

가치 있게 싸려고 한다. 준서가 여행에 필요하다고 생각하는 N개의 물건이 있다.

각 물건은 무게 W와 가치 V를 가지는데, 해당 물건을 배낭에 넣어서 가면 준서가 V만큼 즐길

수 있다. 아직 행군을 해본 적이 없는 준서는 최대 K무게까지의 배낭만 들고 다닐 수 있다.

준서가 최대한 즐거운 여행을 하기 위해 배낭에 넣을 수 있는 물건들의 가치의 최댓값을 알려주자.
 */
using System;
using System.IO;
using System.Collections.Generic;

public class g 
{
	public static void Main(string[] args) {
		//첫 줄에 물품의 수 n(1~100)과 버틸수 있는 무게 k(1~100000)가 주어짐
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		int n = arr[0];
		int k = arr[1];
		//두번째 줄부터 n번째 줄까지 각 물건의 무게 weight(1~100000)와 해당 물건의 가치 value(0~1000)가 주어짐
		int[] weight = new int[n+1];
		int[] value = new int[n+1];
		for(int i = 1; i <= n; i++){
			int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
			weight[i] = tmp[0];
			value[i] = tmp[1];
		}
		
		/*
		dp[i,j]는 i개의 보석이 있고 배낭의 무게 한도가 j일때의 최적의 이익
		dp의 가능한 경우는
		1) dp가 i번째 보석 포함 X. dp는 i번째 보석을 뺀 나머지 i-1개의 보석 중 최적의 이익과 같음
		2) dp가 i번째 보석 포함 O. dp는 i-1개의 보석들 중 최적으로 고른 가격의 합에다가 보석i의 가격을 더한 것과 같음(단 i번째 보석을 넣었을때 배낭 터지면 안됨)
		*/
		int[,] dp = new int[101,100001];
		for(int i = 1; i <= n; i++){
			for(int j = 1; j <=k; j++){
				dp[i,j] = dp[i-1,j];
				if(j-weight[i] >= 0){
					dp[i,j] = Math.Max(dp[i,j], dp[i-1,j-weight[i]] + value[i]);
				}
			}
		}
		
		Console.WriteLine(dp[n,k]);
	}
}