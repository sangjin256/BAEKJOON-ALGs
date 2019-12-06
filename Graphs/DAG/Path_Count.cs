//노드 a에서 노드 b로 가는 경로의 개수 구하기
//노드 a에서 노드 x로 가는 경로의 개수를 paths(x)로 나타낼 때(paths(a) = 1) 다음과 같은
//점화식을 사용한다.
//paths(x) = paths(x1) + paths(x2) + ... + paths(sk)
//위상정렬의 순서대로 paths의 값 계산하면 됨
//여기서는 1번노드에서 6번노드로 가는 문제로 가정
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//인접 리스트(Adjacency list)로 표현
	static List<int>[] adj;
	
	//위상정렬이 가능한지 체크
	static bool Impossible = false;

    static List<int> topol = new List<int>();

    static int[] paths = new int[7];

    public static void Main(String[] args){
        adj = new List<int>[7];
        for(int i = 0; i < 7; i++){
            adj[i] = new List<int>();
        }
        adj[1].Add(2);
        adj[1].Add(4);
        adj[2].Add(3);
        adj[2].Add(6);
        adj[4].Add(5);
        adj[3].Add(6);
        adj[5].Add(2);
		for(int i = 1; i < 7; i++){
			MakeTopol(i);
		}
		
		topol.Reverse();
		
		if(Impossible){
        	Console.WriteLine("사이클 존재 -> 위상정렬 불가");
        	return;
		}
        
        //1에서 1로 가는 경로 수는 1
        paths[1] = 1;

        foreach(var c in topol){
            foreach(var u in adj[c]){
                paths[u] += paths[c];
            }
        }

        Console.WriteLine(paths[6]);
    }
    //사이클이 있으면 위상정렬 불가 그 판단을 위한 bool배열
    //처리되는 중인 상태의 노드를 만나게 되면 사이클이 존재한다는 뜻
    static bool[] processing = new bool[7];
    static bool[] visited = new bool[7];
    public static void MakeTopol(int s){
        if(visited[s]) return;
        visited[s] = true;
        processing[s] = true;
        foreach(var u in adj[s]){
            if(processing[u]){
            	Impossible = true;
                break;
            }
            MakeTopol(u);
        }
        //처리가 끝난 노드를 리스트에 넣어준다.
        topol.Add(s);
        processing[s] = false;
    }
}