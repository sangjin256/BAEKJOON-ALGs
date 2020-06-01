/*
# 2748

n번째 피보나치 수를 구하는 문제

이 방법 말고 queue를 사용해 푸는 방법도 존재
*/

using System;
using System.IO;
using System.Collections.Generic;

public class rc 
{
	public static void Main(string[] args) {
		//n번째 피보나치 수, n은 90보다 작거나 같은 자연수
		int n = int.Parse(Console.ReadLine());
		Console.WriteLine(fibonacci(n));
	}
	
	//이렇게 길게 반복되는 값들은 메모이제이션 필수!
	static bool[] processed = new bool[91];
	static long[] value = new long[91];
	static long fibonacci(int n){
		if(processed[n]) return value[n];
		if(n == 0) return 0;
		if(n == 1) return 1;
		long result = fibonacci(n-1) + fibonacci(n-2);
		value[n] = result;
		processed[n] = true;
		return result;
	}
}