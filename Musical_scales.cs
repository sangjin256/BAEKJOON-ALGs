/*
# 2920

다장조는 c d e f g a b C, 총 8개 음으로 이루어져있다.

이 문제에서 8개 음은 다음과 같이 숫자로 바꾸어 표현한다.

c는 1로, d는 2로, ..., C를 8로 바꾼다. 1부터 8까지 차례대로 연주한다면 ascending,

8부터 1까지 차례대로 연주한다면 descending, 둘 다 아니라면 mixed 이다.

연주한 순서가 주어졌을 때, 이것이 ascending인지, descending인지,

아니면 mixed인지 판별하는 프로그램을 작성하시오.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class l 
{
	public static void Main(string[] args) {
		// 첫째 줄에 8개 숫자가 일렬로 주어짐 1~8까지의 숫자 한번씩 등장
		int[] scales = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		
		// 현재자리수와 오름차순한 자리수가 같으면 asc++ 내림차순과 같으면 dec++
		int asc = 0;
		int dec = 0;
		for(int i = 1; i <= 8; i++){
			if(scales[i-1] == i){
				asc++;
			}
			else if(scales[i-1] == 8-i+1){
				dec++;
			}
		}
		
		// asc가 8이면 ascending 자리수와 일치하는것이고 dec가 8이면 descending자리수와 일치
		if(asc == 8){
			Console.WriteLine("ascending");
		}
		else if(dec == 8){
			Console.WriteLine("descending");
		}
		else
			Console.WriteLine("mixed");
	}
}