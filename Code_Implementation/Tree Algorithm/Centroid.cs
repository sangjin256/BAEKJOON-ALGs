//센트로이드 분해 O(nlogn)
//센트로이드는 노드가 n개인 트리의 노드 중 하나로, 그 노드를 삭제하면 노드가 최대 n/2
//개인 서브트리로 나뉜다는 특징을 만족하는 노드
//트리에서 길이가 x인 경로의 수를 구하는 문제등등을 풀 수 있음
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class us 
{
    static List<int>[] adj;
    public static void Main(string[] args) {
        AdjacencyInit(8);
        Add(1,2);
        Add(2,5);
        Add(5,6);
        Add(3,5);
        Add(3,4);
        Add(6,7);
        Add(6,8);
        size = new int[9];

        int root = 1;
        GetSize(root, -1);
        int center = GetCentroid(1,-1,size[root]/2);
    }

    //서브트리의 크기를 담을 배열
    static int[] size;
    //서브트리 크기 구하기
    public static int GetSize(int here, int parent){
        size[here] = 1;
        foreach(var there in adj[here]){
            if(there == parent) continue;
            size[here] += GetSize(there, here);
        }
        return size[here];
    }

    public static int GetCentroid(int here, int parent, int cap){
        //cap = (tree size) / 2
        foreach(var there in adj[here]){
            if(there == parent) continue;
            if(size[there] > cap) return GetCentroid(there, here, cap);
        }
        return here;
    }


    //초기화
    public static void AdjacencyInit(int n){
        adj = new List<int>[n+1];
        for(int i = 1; i < n+1; i++){
            adj[i] = new List<int>();
        }
    }
    public static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}