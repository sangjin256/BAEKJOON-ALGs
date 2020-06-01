//히어홀처 알고리즘 : 그래프의 오일러 회로를 찾는 효율적인 방법.
//이 알고리즘은 여러 단계로 구성되어 있으며, 단계마다 회로에 새로운 간선을 추가함
//(물론 그래프에 오일러 회로가 있다고 가정. 그렇지 않은 경우 오일러 회로를 찾을 수 없음)

//노드가 하나 있고 간선이 없는 빈 회로에서 알고리즘을 시작하고 부분회로를 추가하는 식으로 회로를 한 단계씩 확장
//이 과정을 모든 간선이 회로에 추가될 때까지 진행.
//회로를 확장하기 위해서는 회로에 속한 노드 중 회로에 포함되지 않은 진출 간선이 있는 노드 x를 찾는다.
//그리고 노드 x에서 시작하여 아직 회로에 포함되지 않은 간선으로 이루어진 경로를 구성
//언젠가는 이 경로가 노드 x로 돌아오게 되는데, 이 경로가 부분 회로가 된다.

//오일러 회로가 아닌 오일러 경로가 있는 경우에도 히어홀처 알고리즘을 적용 가능한데,
//새로운 간선을 그래프에 추가하고 오일러 회로를 찾은 뒤, 그 간선을 제거하면 됨.
//ex) 무방향 그래프에서는 차수가 홀수인 두 노드를 잇는 새로운 간선을 추가하면 됨
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class zxcv 
{
    static List<int>[] adj;
    //처음에 노드만 하나 있고 간선이 없는 빈 회로를 만들 그래프
    static List<int>[] nadj;
    
    //차수의 개수
    static int[] degree;
    public static void Main(string[] args) {
        AdjacencyInit(7);
        AddNode(1,2);
        AddNode(1,3);
        AddNode(2,3);
        AddNode(2,5);
        AddNode(2,6);
        AddNode(3,4);
        AddNode(3,6);
        AddNode(4,7);
        AddNode(5,6);
        AddNode(6,7);

        for(int i = 1; i < adj.Length; i++){
            if(!(adj[i].Count == degree[i])) Dfs(i, i);
        }
        
		for(int i = 1; i < nadj.Length; i++){
        	Console.WriteLine(degree[i]);
        	Console.Write(i + " : ");
        	
        	foreach(var c in nadj[i]){
        		Console.Write(c + " ");
        	}
        	Console.WriteLine();
        }
    }

    public static void Dfs(int s, int x){
        foreach(var u in adj[s]){
            if(nadj[u].Contains(s) || nadj[s].Contains(u)) continue;
            nadj[s].Add(u);
            //각각 간선이 생기므로 차수를 1개씩 올려준다.
            degree[s]++; degree[u]++;
            if(!(u==x)) Dfs(u, x);
            return;
        }
    }
    
    public static void AdjacencyInit(int n){
        degree = new int[n+1];
        adj = new List<int>[n+1];
        nadj = new List<int>[n+1];
        for(int i = 1; i < adj.Length; i++){
            adj[i] = new List<int>();
            nadj[i] = new List<int>();
        }
    }

    public static void AddNode(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}