//그래프의 지름은 두 노드 간 경로의 길이 중 최댓값을 나타냄
//두 가지 방법을 알아볼텐데 동적계획법을 쓰는 알고리즘과 깊이 우선 탐색을 2번 진행하는
//알고리즘이 있다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static List<int>[] adj;
    static int[] toLeaf;
    static int[] maxLength;
	public static void Main(string[] args) {
        Adj_Initializaion(7);
        Adj_Add(5,2);
        Adj_Add(6,2);
        Adj_Add(2,1);
        Adj_Add(1,3);
        Adj_Add(1,4);
        Adj_Add(4,7);

    }

    //동적계획법을 활용한 알고리즘
    //임의의 노드를 루트로 지정한 다음 각 서브트리에 대해 따로따로 문제를 품
    //s는 루트노드를 의미
    public static int Diameter_Dynamic(int s){
        toLeaf = new int[8];
        maxLength = new int[8];
    }

    public static void Dfs(int s){
        foreach(var u in adj[s]){
        }
    }

    //인접 리스트 초기화
    public static void Adj_Initializaion(int n){
        adj = new List<int>[n+1];
        for(int i = 0; i < adj.Length; i++){
            adj[i] = new List<int>();
        }
    }

    //양방향 그래프이므로 양쪽 다 받아준다.
    public static void Adj_Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}