using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	public static void Main(string[] args) {
		// 몇번째 피보나치 수열을 출력할지를 입력받는다. (n을 집어넣으면 n+1값이 나옴)
		int n = int.Parse(Console.ReadLine());
		int[,] origin = new int[,]{{0,1}, {1,1}};
		int[,] first = new int[,]{{0},{1}};
		int[,] result = square(modpow(origin, n), first);
		
		Console.WriteLine(result[1,0]);
		
	}
	
	//거듭제곱을 효율적으로 연산
	static int[,] modpow(int[,] x, int n){
		if(n == 0 || n == 1) return x;
		int[,] u = modpow(x, n/2);
		u = repeted_squared(u, u);
		if(n%2 == 1) u = repeted_squared(u, x);
		return u;
	}
	
	//f(0)과 f(1)이 들어있는 초깃값에 행렬의 거듭제곱값을 곱할때 사용
	static int[,] square(int[,] a, int[,] b){
		int[,] c = new int[2,2];
		for(int i = 0; i < 2; i++){
			for(int j = 0; j < 1; j++){
				for(int k = 0; k < 2; k++){
					c[i,j] += a[i,k] * b[k,j];
				}
			}
		}
		return c;
	}
	//행렬을 거듭제곱하기위한 함수
	static int[,] repeted_squared(int[,] x, int[,] y){
		int n = x.GetLength(0);
		int[,] c = new int[n,n];
		for(int i = 0; i < n; i++){
			for(int j = 0; j < n; j++){
				for(int k = 0; k < n; k++){
					c[i,j] += x[i,k] * y[k,j];
				}
			}
		}
		return c;
	}
}