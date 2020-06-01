/*
# 1546

세준이는 기말고사를 망쳤다. 세준이는 점수를 조작해서 집에 가져가기로 했다.

일단 세준이는 자기 점수 중에 최댓값을 골랐다. 이 값을 M이라고 한다.

그리고 나서 모든 점수를 점수/M*100으로 고쳤다. 예를 들어,

세준이의 최고점이 70이고, 수학점수가 50이었으면 수학점수는 50/70*100이 되어

71.43점이 된다.세준이의 성적을 위의 방법대로 새로 계산했을 때, 새로운 평균을

구하는 프로그램을 작성하시오.
 */

using System;
using System.IO;
using System.Collections.Generic;

public class d 
{
	public static void Main(string[] args) {
		//시험 본 과목의 개수 N, 1000보다 작거나 같음
		int n = int.Parse(Console.ReadLine());
		
		
		//현재 성적, 100보다 작거나 음이아닌 정수 + 적어도 하나의 값은 0보다 큼
		double[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), s => Double.Parse(s));
		
		//자기 점수의 최댓값 찾기
		double mx = 0.0;
		for(int i = 0; i < n; i++){
			if(mx < scores[i]){
				mx = scores[i];
			}
		}
		
		double sum = 0.0;
		for(int i = 0; i < n; i++){
			scores[i] = (scores[i]/mx) * 100;
			sum += scores[i];
		}
		
		Console.WriteLine("{0:F2}", sum/n);
	}
}