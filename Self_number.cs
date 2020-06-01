/*
# 4673

셀프 넘버는 1949년 인도 수학자 D.R. Kaprekar가 이름 붙였다.

양의 정수 n에 대해서 d(n)을 n과 n의 각 자리수를 더하는 함수라고 정의하자.

예를 들어, d(75) = 75+7+5 = 87이다.

n을 d(n)의 생성자라고 한다. 위의 수열에서 33은 39의 생성자이고, 39는 51의 생성자,

51은 57의 생성자이다. 생성자가 한 개보다 많은 경우도 있다.

예를 들어, 101은 생성자가 2개(91과 100) 있다. 

생성자가 없는 숫자를 셀프 넘버라고 한다. 10000보다 작거나 같은 셀프 넘버를

한 줄에 하나씩 출력하는 프로그램을 작성하시오.
 */
using System;
using System.IO;
using System.Collections.Generic;

public class r 
{
	static int[] selfnumber = new int[10001];
	public static void Main(string[] args) {
		for(int i = 1; i < 10001; i++){
			Self_num(i);
		}
		
		for(int i = 1; i < 10001; i++){
			if(selfnumber[i] != 1){
				Console.WriteLine(i);
			}
		}
	}
	
	// 에라토스테네스의 체 사용
    // 메모이제이션을 사용할 수 없어서 시간이 좀 오래걸리는 단점 존재
	static void Self_num(int n) {
		string str = n.ToString();
		int tmp = n;
		for(int i = 0; i < str.Length; i++){
			tmp += int.Parse(str[i].ToString());
		}
		if(tmp > 10000) return;
		
		selfnumber[tmp] = 1;
		Self_num(tmp);
	}
}