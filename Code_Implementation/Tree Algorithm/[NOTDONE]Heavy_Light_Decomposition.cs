//헤비 라이트 분해(HLD)
//트리의 노드를 여러 경로의 집합으로 나누는 방법이며, 각 경로를 무거운 경로라고 부름
//이 기법을 이용하면 트리의 경로 상의 노드를 배열의 원소처럼 다룰 수 있게 된다.
//각 경로가 O(logn)개의 무거운 경로로 이루어져 있고, 각각의 무거운 경로를 O(logn)시간에
//처리할 수 있기 때문에 질의에 O((logn)^2)시간이 걸림.
//가중치가 포함된 HLD법은 http://blog.naver.com/PostView.nhn?blogId=kks227&logNo=221413353934 참고

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class yn 
{
    static List<(int,int)>[] adj;
    public static void Main(string[] args) {
        AdjacencyInit(8);
        Add(1,2);
        Add(1,3);
        Add(1,4);
        Add(2,5);
        Add(2,6);
        Add(6,8);
        Add(4,7);
        
        size = new int[9];
    }

    public static void HeavyLightDecomp(){
        
    }


    //헤비라이트 분해에 사용할 DFS함수. 서브트리의 개수를 구함
    static int[] size;
    public static int GetSize(int here, int parent){
        size[here] = 1;
        foreach(var there in adj[here]){
            if(there == here) continue;
            size[here] += GetSize(there, here);
        }
        return size[here];
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