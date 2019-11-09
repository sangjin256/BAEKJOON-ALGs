/*
# 9461

오른쪽 그림과 같이 삼각형이 나선 모양으로 놓여져 있다.

첫 삼각형은 정삼각형으로 변의 길이는 1이다. 그 다음에는 다음과 같은 과정으로 정삼각형을

계속 추가한다. 나선에서 가장 긴 변의 길이를 k라 했을 때, 그 변에 길이가 k인 정삼각형을

추가한다. 파도반 수열 P(N)은 나선에 있는 정삼각형의 변의 길이이다.

P(1)부터 P(10)까지 첫 10개 숫자는 1, 1, 1, 2, 2, 3, 4, 5, 7, 9이다.

N이 주어졌을 때, P(N)을 구하는 프로그램을 작성하시오.
*/

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		//테스트 케이스의 개수
		int n = int.Parse(Console.ReadLine());
		Queue<long> q = new Queue<long>();
		
		
		for(int i = 0; i < n; i++){
		//1번째, 2번째 3번째 값
			q.Enqueue(1);
			q.Enqueue(1);
			q.Enqueue(1);
			int k = int.Parse(Console.ReadLine());
			long result = 0;
			for(int j = 1; j < k; j++){
				result = q.Dequeue() + q.Peek();
				q.Enqueue(result);
			}
			Console.WriteLine(q.Peek());
			//다음 차례를 위해 큐를 비운다.
			q.Clear();
		}
	}
}