/*
# 2292

위의 그림과 같이 육각형으로 이루어진 벌집이 있다. 그림에서 보는 바와 같이 중앙의 방 1부터

시작해서 이웃하는 방에 돌아가면서 1씩 증가하는 번호를 주소로 매길 수 있다.

숫자 N이 주어졌을 때, 벌집의 중앙 1에서 N번 방까지 최소 개수의 방을 지나서 갈 때 몇 개의

방을 지나가는지(시작과 끝을 포함하여)를 계산하는 프로그램을 작성하시오. 예를 들면,

13까지는 3개, 58까지는 5개를 지난다.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        //앞쪽 범위의 sum
        int sumf = 0;
        //뒤쪽 범위의 sum
        int suml = 0;
        if(n == 1){
        	Console.WriteLine(1);
        	return;
        }
        for(int i = 0; i < n; i++){
        	sumf += 6*i;
        	suml = sumf+2+6*(i+1);
        	if(n >= sumf+2 && n < suml){
        		Console.WriteLine(i+2);
        		return;
        	}
        }
    }
}