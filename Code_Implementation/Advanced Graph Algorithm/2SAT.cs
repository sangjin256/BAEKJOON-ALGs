//2SAT문제
//2SAT에서 제시되는 식을 함의 그래프로 나타낼 수 있음
//수식이 참이 되도록 모든 변수에 값을 할당하는 것이 가능한지 여부는 함의 그래프
//구조에 따라 결정되는데,
//xi노드와 ㄱxi노드가 같은 강결합 컴포넌트에 속하는 일이 없는 경우와 동치
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

    //같은 강결합 컴포넌트에 속해있는 노드
    static int[] sn;

    //강결합 컴포넌트가 들어갈 리스트
    static List<int>[] sc;

    static List<int> tmp = new List<int>();

    //sc 리스트에 쓸 count
    static int count = 0;
    public static void Main(){
        int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        AdjacencyInit(10000*2);
        
        for(int i = 0; i < temp[1]; i++){
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            //양수냐 음수냐에 따라 각 정점 번호를 새로 매김
            //x_k : (k-1)*2, not x_k : (k-1)*2-1
            int a = (arr[0] < 0 ? -(arr[0]+1)*2 : arr[0]*2-1);
            int b = (arr[1] < 0 ? -(arr[1]+1)*2 : arr[1]*2-1);
            adj[Oppo(a)].Add(b);
            adj[Oppo(b)].Add(a);
            tmp.Add(Oppo(a));
            tmp.Add(b);
            tmp.Add(Oppo(b));
            tmp.Add(a);
        }
 
        Kosaraju();
        
        for(int i = 0; i < temp[0]; i++){
            if(sn[i*2] == sn[i*2+1]){
                Console.WriteLine(0);
                return;
            }
        }
        Console.WriteLine(1);
    }

    public static int Oppo(int n){
        return Convert.ToBoolean(n%2) ? n-1 : n+1;
    }

#region Kosaraju
    //강결합 컴포넌트를 생성하는 코사리주 알고리즘 코드를 가져온다.
    public static void Kosaraju(){
        visited = new bool[adj.Length];
        //첫번째 깊이우선탐색
        for(int i = 0; i < tmp.Count; i++){
            if(!visited[tmp[i]]) Dfs(tmp[i]);
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
        sn[s] = count;
        sc[count].Add(s);
    }

    

    public static void ReverseAdj(){
        for(int i = 0; i < adj.Length; i++){
            foreach(var u in adj[i]){
                nadj[u].Add(i);
            }
        }
    }

    public static void AdjacencyInit(int n){
        sn = new int[n+1];
        adj = new List<int>[n+1];
        nadj = new List<int>[n+1];
        sc = new List<int>[n+1];
        for(int i = 0; i <= n; i++){
            adj[i] = new List<int>();
            nadj[i] = new List<int>();
            sc[i] = new List<int>();
        }
    }
#endregion

}