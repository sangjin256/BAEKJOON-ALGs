/*
# 1167

트리의 지름이란, 트리에서 임의의 두 점 사이의 거리 중 가장 긴 것을 말한다.

트리의 지름을 구하는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static List<(int,int)>[] adj;
    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        Adj_Initializaion(n);
        for(int i = 0; i < n; i++){
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            for(int j = 1; j < temp.Length -1; j++){
                if( j%2==1 ) Adj_Add(temp[0], temp[j], temp[j+1]);
            }
        }

        distance = new int[n+1];
        visited = new bool[n+1];

        //임의의 노드 a를 선택하고 a에서 가장 먼 노드 b를 찾는다. 그리고
        //b에서 가장 먼 노드 c와 b의 거리가 지름이 된다.
        //임의의 노드 a = 1로 가정
        Dfs(2);
        int fardist = 0;
        int far = 0;
        for(int i = 0; i < distance.Length; i++){
        	if(fardist < distance[i]){
        		fardist = distance[i];
        		far = i;
        	}
        }
        Array.Clear(distance, 0, distance.Length);
        Array.Clear(visited, 0, visited.Length);
        Dfs(far);
        int mx = 0;
        for(int i = 0; i < distance.Length; i++){
        	mx = Math.Max(mx, distance[i]);
        }
        Console.WriteLine(mx);
    }

    static int[] distance;
    static bool[] visited;

    public static void Dfs(int s){
        visited[s] = true;
        foreach(var u in adj[s]){
            if(visited[u.Item1]) continue;
            distance[u.Item1] = Math.Max(distance[u.Item1], distance[s]+u.Item2);
            Dfs(u.Item1);
        }
    }
    //인접 리스트 초기화
    public static void Adj_Initializaion(int n){
        adj = new List<(int,int)>[n+1];
        for(int i = 1; i < adj.Length; i++){
            adj[i] = new List<(int,int)>();
        }
    }

    public static void Adj_Add(int a, int b, int w){
        adj[a].Add((b,w));
    }
}