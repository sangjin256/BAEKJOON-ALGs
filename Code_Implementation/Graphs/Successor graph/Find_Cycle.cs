//후속 노드 그래프는 다른말로 함수형 그래프(Functional graph)
//후속 노드 그래프는 모든 노드의 진출 차수가 1
//사이클을 찾기 위해서는 플로이드 알고리즘을 사용
//시간복잡도는 일반 사이클 찾기 알고리즘과 똑같은 O(n)이나 메모리를 O(1)만 사용
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//인접 리스트(Adjacency list)로 표현
	static List<int>[] adj;

    //후속 노드 보여줄 배열
    static int[] succ = new int[7];

    public static void Main(String[] args){
        adj = new List<int>[7];
        for(int i = 0; i < 7; i++){
            adj[i] = new List<int>();
        }
        adj[1].Add(2);
        adj[3].Add(4);
        adj[6].Add(4);
        adj[4].Add(5);
        adj[2].Add(3);
        adj[5].Add(6);

        for(int i = 1; i < 7; i++){
            succ[i] = adj[i][0];
        }

        int a = succ[1];
        int b = succ[succ[1]];
        while(a != b){
            a = succ[a];
            b = succ[succ[b]];
        }

        a = 1;
        while(a != b){
            a = succ[a];
            b = succ[b];
        }
        //처음 만나는 사이클의 노드
        int first = a;

        //사이클 길이 계산
        b = succ[a];
        int length = 1;
        while (a!=b){
            b = succ[b];
            length++;
        }

        Console.WriteLine(first + ", " + length);
    }
}