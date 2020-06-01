/*
# 8958

"OOXXOXXOOO"와 같은 OX퀴즈의 결과가 있다. O는 문제를 맞은 것이고,

X는 문제를 틀린 것이다. 문제를 맞은 경우 그 문제의 점수는 그 문제까지

연속된 O의 개수가 된다. 예를 들어, 10번 문제의 점수는 3이 된다.

"OOXXOXXOOO"의 점수는 1+2+0+0+1+0+0+1+2+3 = 10점이다.

OX퀴즈의 결과가 주어졌을 때, 점수를 구하는 프로그램을 작성하시오.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class m 
{
	public static void Main(string[] args) {
		// 테스트 케이스의 개수 n개 입력
		int n = int.Parse(Console.ReadLine());
		
		for(int j = 0; j < n; j++){
			//OX문자열 입력
			string str = Console.ReadLine();
			//맞은 문제의 점수를 넣을 배열 생성 0 < 길이 < 80
			int[] count = new int[80];
			for(int i = 0; i < str.Length-1; i++){
				if(str[i] == 'O'){
					count[i] += 1;
				}
				if(str[i+1] == 'O' && str[i] == 'O'){
					count[i+1] += count[i];
				}
			}
			
			if(str[str.Length-1] == 'O'){
				count[str.Length-1]++;
			}
			
			int result = 0;
			foreach(var c in count){
				result += c;
			}
			Console.WriteLine(result);
		}
	}
}