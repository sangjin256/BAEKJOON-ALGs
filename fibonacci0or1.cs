//각 테스트마다 0이 출력되는 횟수와 1이 출력되는 횟수를 공백으로 구분해서 출력

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Lecture 
{
	static int count0;
	static int count1;
	
	public static void Main(string[] args) {
		
		int n = int.Parse(Console.ReadLine());
		for(int j = 0; j < n; j++){
			int[,] arr = new int[41,2];
			arr[0,0] = 1;
			arr[1,1] = 1;
			int test = int.Parse(Console.ReadLine());
			for(int i = 2; i <= test; i++){
				arr[i,0] = arr[i-1, 0] + arr[i-2, 0];S
				arr[i,1] = arr[i-1, 1] + arr[i-2, 1];
			}
			Console.WriteLine(arr[test, 0] + " " + arr[test, 1]);
		}
	}
}

/*
예제 입력
3
0
1
3

예제 출력
1 0
0 1
1 2 */