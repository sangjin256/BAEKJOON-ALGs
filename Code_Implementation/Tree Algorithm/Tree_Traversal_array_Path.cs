//트리 순회 배열(Tree traversal array)은 루트 트리의 노드를 루트 노드에서부터 
//깊이 우선 탐색으로 방문하는 순서대로 담은 배열.

//여기서는 노드의 값을 갱신하는 질의와 루트 노드부터 특정 노드까지 가는 경로의 합을 구하는 질의
//문제를 풀기 위해 트리 순회 배열을 만들고, 각 노드에 대해 노드의 번호, 서브트리의 크기,
//노드의 값의을 배열에 저장
//차이 배열을 이용하여 노드 값이 x 증가할 때 서브트리의 모든 값도 x만큼 증가하게 만들자.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{
    static List<int>[] adj;
    
    static int[] valtemp;
    public static void Main(string[] args) {
        //노드의 기본값들. index 0이 노드번호 1
        valtemp = new int[]{4,5,3,5,2,3,5,3,1};
        AdjacentInit(9);
        Add(1,2);
        Add(1,3);
        Add(1,4);
        Add(1,5);
        Add(2,6);
        Add(4,7);
        Add(4,8);
        Add(4,9);

        visited = new bool[10];
        num = new int[10];
        sizetemp = new int[10];
        size = new int[10];
        value = new int[10];

        Dfs(1);
        
        for(int i = 1; i < num.Length; i++){
        	size[i] = sizetemp[num[i]];
        	value[i] = valtemp[num[i]-1];
        }
        makeDiff(9);
        //전처리 완료
        
        foreach(var c in value){
        	Console.Write(c+ " ");
        }
        //4번 노드의 값 1 증가
        AddDiff(4, 1);
        Console.WriteLine();
        foreach(var c in value){
        	Console.Write(c+ " ");
        }
    }   

    //노드번호, 서브트리의 크기, 노드의 값
    static int[] num;
    static int[] size;
    static int[] value;
    //size배열에 담기 전 임시배열
    static int[] sizetemp;

    static bool[] visited;

    static int count = 1;
    //노드 번호 배열(트리순회배열)과 노드의 값 배열을 만드는 깊이우선탐색
    static void Dfs(int s){
        visited[s] = true;
        num[count] = s;
        sizetemp[s] = 1;
        count++;
        foreach(var u in adj[s]){
            if(visited[u]){
            	continue;
            }
            valtemp[u-1] += valtemp[s-1];
            Dfs(u);
            sizetemp[s]+=sizetemp[u];
        }
    }
    
    //차이 배열을 만든다.
    static int[] diff;
    static void makeDiff(int n){
    	diff = new int[n+1];
    	for(int i = 1; i < value.Length; i++){
    		diff[i] = value[i] - value[i-1];
    	}
    }
    
    static void AddDiff(int k, int x){
    	int pos = Array.IndexOf(num, k);
    	int sz = size[pos];
    	diff[pos] += x;
    	diff[pos+sz] -= x;
    	for(int i = pos; i <= pos+sz; i++){
    		value[i] = value[i-1]+diff[i];
    	}
    	
    }


    static void AdjacentInit(int n){
        adj = new List<int>[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
        }
    }
    static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}