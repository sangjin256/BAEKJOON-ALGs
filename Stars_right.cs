/*
# 2439

첫째 줄에는 별 1개, 둘째 줄에는 별 2개, N번째 줄에는 별 N개를 찍는 문제

하지만, 오른쪽을 기준으로 정렬한 별

예제)
    *
   **
  ***
 ****
*****
 */

using System;
using System.IO;
using System.Collections.Generic;

public class t 
{
	public static void Main(string[] args) {
		int n = int.Parse(Console.ReadLine());
		for(int i = 0; i < n; i++){
			for(int j = n-i-1; j > 0; j--){
				Console.Write(" ");
			}
			
			for(int k = 0; k <= i; k++){
				Console.Write("*");
			}
			
			Console.WriteLine();
		}
	}
}