//후속 노드 그래프는 다른말로 함수형 그래프(Functional graph)
//후속 노드 그래프는 모든 노드의 진출 차수가 1
//succ(x,k)는 노드 x에서 시작하여 다음 노드로 이동하는 과정을 k번 반복했을 때 도착하는 노드

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//인접 리스트(Adjacency list)로 표현
	static List<int>[] adj;

    //후속 노드 보여줄 배열
    //최대 11번만 이동할 예정이므로 12
    static int[,] succ = new int[10,12];

    public static void Main(String[] args){
        adj = new List<int>[10];
        for(int i = 0; i < 10; i++){
            adj[i] = new List<int>();
        }
        adj[9].Add(3);
        adj[1].Add(3);
        adj[3].Add(7);
        adj[7].Add(1);
        adj[6].Add(2);
        adj[4].Add(6);
        adj[8].Add(6);
        adj[2].Add(5);
        adj[5].Add(2);

        //이동하는 최대 횟수를 u라고 할때 succ(x,k)의 값을 k가 2의 거듭제곱이고 u 이하인
        //모든 경우에 대해 미리 계산함으로서 succ(x,k)의 값을 O(logk)시간에 계산 가능
        for(int x = 1; x <= 9; x++){
            succ[x,0] = x;
            succ[x,1] = adj[x][0];
        }
        for(int x = 1; x < 10; x++){
            for(int k = 2; k <= 11; k<<=1){
                succ[x,k] = succ[succ[x,k/2],k/2];
            }
        }
        
        //실제로 원하는 값 계산 4에서 11칸 움직이기
        int temp = 4;
        int n = 11;
        for(int i = 1; n != 0; i++){
        	//정수 x의 모든 비트를 0으로 바꾸되 비트 1 중에서 제일 오른쪽 것 하나만
        	//남기는 공식
        	int k = n&(-n);
        	temp = succ[temp,k];
        	n = n-k;
        	
        }
        Console.WriteLine(temp);
    }
}