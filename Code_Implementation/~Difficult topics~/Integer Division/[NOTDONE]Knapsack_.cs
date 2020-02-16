//짐 싸기 문제의 제곱근 기법을 사용한 최적화 버전
//무게 목록 [w1,w2,...,wk]이 주어지고 w1+w2+...+wk = n일때
//서로 다른 무게는 정수 분할 기법에 의해 최대 O(√n)개이다.
//이것을 사용하여 무게가 같은 경우를 O(n)시간에 동시에 처리하도록 하면
//표준 알고리즘 O(nk)에서 O(n√n)이 된다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{   
    static int[] w;

    static bool[,] possible;
	public static void Main(string[] args) {
        //무게목록
        w = new int[]{3,3,4};
        //무게의 합
        int n = 0;
        for(int i = 0; i < w.Length; i++){
            n += w[i];
        }
        possible = new bool[n+1,w.Length+1];

        Knapsack(n);

        for(int i = 0; i < possible.Length; i++){
            if(possible[4,i] == true){
                Console.WriteLine(i);
            }
        }
    }

    public static void Knapsack(int n){
        int start = 0;
        int pointer = 0;
        int i = 0;
        //무조건 올림해야됨
        while(i <= (int)Math.Ceiling(Math.Sqrt(n))){    
            if(pointer >= w.Length) break;
            if(pointer + 1 < w.Length){
                while(w[pointer] == w[pointer+1]){
                    pointer++;
                }
            }
            for(int x = 0; x <= n; i++){
                
            }
            //pointer값을 +1해준다음 start에도 대입한다.
            start = ++pointer;
            i++;
        }
    }
}