//위상 정렬하는법
//DAG는 항상 위상정렬 가능
//처리가 완료된 노드부터 리스트에 넣음
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//인접 리스트(Adjacency list)로 표현
	static List<int>[] adj;

    static List<int> topol = new List<int>();

    public static void Main(String[] args){
        adj = new List<int>[7];
        for(int i = 0; i < 7; i++){
            adj[i] = new List<int>();
        }
        adj[1].Add(2);
        adj[2].Add(3);
        adj[4].Add(1);
        adj[4].Add(5);
        adj[5].Add(3);
        adj[3].Add(6);
        adj[5].Add(2);
		for(int i = 1; i < 7; i++){
			Dfs(i);
		}
		
		topol.Reverse();
		
        foreach(var c in topol){
            Console.WriteLine(c + " ");
        }
    }

    static bool[] visited = new bool[7];
    public static void Dfs(int s){
        if(visited[s]) return;
        visited[s] = true;
        foreach(var u in adj[s]){
            Dfs(u);
        }
        //처리가 끝난 노드를 리스트에 넣어준다.
        topol.Add(s);
    }
}