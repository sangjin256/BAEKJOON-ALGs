/*
#10817

세 정수 A, B, C가 주어진다. 이때, 두 번째로 큰 정수를 출력하는 프로그램을 작성하시오. 
 */

using System;
using System.IO;
using System.Collections.Generic;

public class k 
{
	public static void Main(string[] args) {
		int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		int a = numbers[0];
		int b = numbers[1];
		int c = numbers[2];
		Console.WriteLine(b < a ? ( a < c ? a : (b > c ? b : c)) : (b < c ? b :(c < a ? a : c)));
	}
}