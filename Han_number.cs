/*어떤 양의 정수 X의 자리수가 등차수열을 이룬다면, 그 수를 한수라고 한다.
/*
#1065

어떤 양의 정수 X의 자리수가 등차수열을 이룬다면, 그 수를 한수라고 한다.

등차수열은 연속된 두 개의 수의 차이가 일정한 수열을 말한다. N이 주어졌을 때,

1보다 크거나 같고, N보다 작거나 같은 한수의 개수를 출력하는 프로그램 작성하시오
*/

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		// 1000보다 작거나 같은 자연수 n 입력
		int n = int.Parse(Console.ReadLine());
		if(n < 100){
			Console.WriteLine(n);
			return;
		}
		
		// 100보다 작으면 전부 한수이므로 99로 지정해놓고 시작
		int count = 99;
		
		for(int i = 100; i <= n; i++){
			string str = i.ToString();
			// 첫번째자리수와 두번째자리수를 뺀 값과 두번째자리수와 세번째자리수를 뺀 값이 같으면 등차수열이므로 한수
			// 확실하지는 않지만 string[n]은 n번째 자리값을 char로 가져다주는데 char에서 바로 int로 바꾸는법이 없는것 같다. 따라서 string으로 바꾸고 다시 int로 바꾼다.
			if(int.Parse(str[0].ToString()) - int.Parse(str[1].ToString()) == int.Parse(str[1].ToString()) - int.Parse(str[2].ToString()))
				count++;
		}
		
		Console.WriteLine(count);
		
	}
}