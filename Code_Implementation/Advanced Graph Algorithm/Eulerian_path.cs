//오일러 경로 : 그래프의 각 간선을 정확히 한 번씩 지나가는 경로
//그러한 경로의 시작과 끝이 같은 노드인 경우 오일러 회로라고 한다.
//일반 양방향 그래프에서 모든 노드의 차수(Degree)가 짝수이거나(오일러 회로) 정확히 두 노드의 차수가 홀수이고,
//다른 모든 노드의 차수가 짝수이면 오일러 경로가 된다.

//방향 그래프에서는 모든 간선이 같은 강결합 컴포넌트에 속하고 모든 노드의 진입 차수와 진출 차수가 같거나(오일러 회로),
//한 노드의 진입 차수가 진출 차수보다 1 크고, 다른 한 노드의 진출 차수가 진입 차수보다 1 크며, 나머지 노드는 진입 차수와
//진출 차수가 같으면 오일러 경로가 된다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{
    static List<int>[] adj;
    public static void Main(string[] args) {
        AdjacencyInit(5);
        AddNode(1,2);
        AddNode(1,4);
        AddNode(2,5);
        AddNode(4,2);
        AddNode(2,3);
        AddNode(5,3);

        if(IsEulerianPath()){
            if(EvenOddCount[0] == adj.Length - 1){
                Console.WriteLine("오일러 회로");
            }
            else Console.WriteLine("오일러 경로");
        }
        else Console.WriteLine("오일러 경로가 아님");
    }
    
    static int[] EvenOddCount;

    public static bool IsEulerianPath(){
        //index = 0은 짝수의 개수 1은 홀수의 개수를 뜻함
        EvenOddCount = new int[2];
        int[] degree = new int[adj.Length];

        for(int i = 1; i < adj.Length; i++){
            foreach(var c in adj[i]){
                degree[i]++;
            }
            //degree[i]가 짝수면 EvenOddCount[0]의 개수를 ++하고 홀수면 반대로 한다.
            EvenOddCount[degree[i]%2]++;
        }

        //모든 노드의 차수가 짝수이거나, 정확히 두 노드의 차수가 홀수이고 다른 모든 노드의 차수가 짝수이면 오일러 회로.(전자는 오일러 회로가 됨)
        if((EvenOddCount[0] == adj.Length - 1) || ((adj.Length - 1 - EvenOddCount[0]) == 2)){
            return true;
        }
        return false;
    }
    public static void AdjacencyInit(int n){
        adj = new List<int>[n+1];
        for(int i = 1; i < adj.Length; i++){
            adj[i] = new List<int>();
        }
    }

    public static void AddNode(int a, int b){
        adj[a].Add(b);
        adj[b].Add(b);
    }


}