/*
# 1967

트리(tree)는 사이클이 없는 무방향 그래프이다. 트리에서는 어떤 두 노드를 선택해도

둘 사이에 경로가 항상 하나만 존재하게 된다. 트리에서 어떤 두 노드를 선택해서

양쪽으로 쫙 당길 때, 가장 길게 늘어나는 경우가 있을 것이다. 이럴 때 트리의 모든

노드들은 이 두 노드를 지름의 끝 점으로 하는 원 안에 들어가게 된다.

이런 두 노드 사이의 경로의 길이를 트리의 지름이라고 한다. 정확히 정의하자면 트리에

존재하는 모든 경로들 중에서 가장 긴 것의 길이를 말한다. 입력으로 루트가 있는

트리를 가중치가 있는 간선들로 줄 때, 트리의 지름을 구해서 출력하는 프로그램을

작성하시오. 아래와 같은 트리가 주어진다면 트리의 지름은 45가 된다.
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
        for(int i = 0; i < n-1; i++){
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            Adj_Add(temp[0],temp[1],temp[2]);
        }

        distance = new int[n+1];
        visited = new bool[n+1];

        //임의의 노드 a를 선택하고 a에서 가장 먼 노드 b를 찾는다. 그리고
        //b에서 가장 먼 노드 c와 b의 거리가 지름이 된다.
        //임의의 노드 a = 1로 가정
        Dfs(1);
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
        adj[b].Add((a,w));
    }
}