/*
#9251

 */
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		string str1 = Console.ReadLine();
		string str2 = Console.ReadLine();
		
		//행과 열은 비교할 각 문자열
		/*
		dp[0,0]은 비교할게 없으므로 0이고
		str1[i-1]와 str2[j-1]가 같을 때 dp[i,j]은 dp[i-1,j-1] + 1이다.(같은 현재값을 제외한 바로 전값까지의 최댓값 +1)
		str1의 한 위치의 값과 str2의 한 위치의 값이 다르면 str1의 한칸전값과 str2의 현재값의 최댓값, str1의 현재값과 str2의 한칸 전값의 최댓값을 비교해서 더 큰값을 넣는다.
		*/
		long[,] dp = new long[1001,1001];
		
		for(int i = 1; i <= str1.Length; i++){
			for(int j = 1; j <= str2.Length; j++){
				if(str1[i-1] == str2[j-1]){
					dp[i,j] = dp[i-1,j-1] + 1;
				} else{
					dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
				}
			}
		}
		//str1의 길이와 str2의 길이가 다를 수 있음에 주의!
		Console.WriteLine(dp[str1.Length,str2.Length]);
	}
}