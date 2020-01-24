//코사라주 알고리즘 : 그래프의 강결합 컴포넌트를 찾는 유용한 방법
//두 번의 깊이 우선 탐색 과정을 거치는데 첫번째 탐색에서 그래프의 구조에 따라 노드
//리스트를 만들고, 두번째 탐색에서 강결합 컴포넌트를 구함
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{
    static List<int>[] adj;

    //간선의 방향이 바뀐 새 그래프 생성
    static List<int>[] nadj;

    //강결합 컴포넌트가 들어갈 리스트
    static List<int>[] sc;

    //sc 리스트에 쓸 count
    static int count = 0;
    public static void Main(){
        AdjacencyInit(7);
        adj[1].Add(2);
        adj[1].Add(4);
        adj[2].Add(1);
        adj[2].Add(5);
        adj[3].Add(7);
        adj[3].Add(2);
        adj[5].Add(4);
        adj[6].Add(5);
        adj[6].Add(3);
        adj[7].Add(6);

        visited = new bool[8];
        //첫번째 깊이우선탐색
        for(int i = 1; i < adj.Length; i++){
        	if(!visited[i]) Dfs(i);
        }

        //두번째 깊이 우선 탐색을 쓰기 전에 모든 간선의 방향을 뒤집고,
        //만든 노드 리스트의 반대 순서로 노드를 살펴봐야한다.
        //모든 간선의 방향이 반대이기 때문에 컴포넌트에 속한 노드가 컴포넌트
        //바깥의 노드로 흐르지 않는다.
        ReverseAdj();
        //새로운 그래프의 방문체크
        nvisited = new bool[adj.Length];
        
        for(int i = list.Count-1; i >= 0; i--){
            if(!nvisited[list[i]]){
                Ndfs(list[i]);
                count++;
            }
        }
        
        for(int i = 0; i < sc.Length; i++){
            foreach(var u in sc[i]){
                Console.Write(u + " ");
            }
            Console.WriteLine();
        }
    }

    static bool[] nvisited;
    static bool[] visited;
    //첫번째 깊이우선탐색의 노드 리스트를 담을 리스트
    //처리가 '끝나면' 그 노드를 리스트에 추가해야한다.
    static List<int> list = new List<int>();
    public static void Dfs(int s){
        visited[s] = true;
        foreach(var u in adj[s]){
            if(visited[u]) continue;
            Dfs(u);
        }
        list.Add(s);
    }

    //두번째 단계에 쓸 깊이우선탐색
    public static void Ndfs(int s){
        nvisited[s] = true;
        foreach(var u in nadj[s]){
            if(nvisited[u]) continue;
            Ndfs(u);
        }
        sc[count].Add(s);
    }

    

    public static void ReverseAdj(){
        for(int i = 1; i < adj.Length; i++){
            foreach(var u in adj[i]){
                nadj[u].Add(i);
            }
        }
    }

    public static void AdjacencyInit(int n){
        adj = new List<int>[n+1];
        nadj = new List<int>[n+1];
        sc = new List<int>[n+1];
        for(int i = 0; i <= n; i++){
            adj[i] = new List<int>();
            nadj[i] = new List<int>();
            sc[i] = new List<int>();
        }
    }
}