//포드 풀커슨 알고리즘은 그래프의 최대 유량을 찾는 알고리즘이다.
//유량이 0인 상태에서 알고리즘을 시작하고, 단계마다 소스에서 싱크로 가는 경로 중
//유량을 늘릴 수 있는 경로를 찾는다. 더는 유량을 늘릴 수 없을 때의 값이 최대 유량이 된다.

//여러 라운드로 구성되어 있는데, 라운드마다 소스에서 싱크로 가는 경로 중 모든 간선의
//가중치가 양수인 경로를 찾고 선택한 경로에 포함된 간선의 가중치 최솟값이 x라면 유량을
//x라면 유량을 x만큼 증가시킬 수 있다.

//경로 찾는 방법은 에드몬드 카프 알고리즘과 용량 조절 알고리즘이 있는데 용량 조절 알고리즘으로 해결하겠음
//에드몬드 카프 알고리즘(Edmonds Karp Algorithm) - 너비 우선 탐색을 이용
//용량 조절 알고리즘(Capacity Scaling Algorithm) - 깊이 우선 탐색을 이용
//   이때 각 간선의 가중치가 지정된 값 이상이어야 함. 처음에는 기준값을 적당히 큰 값으로
//   설정하는데 예를 들어 그래프의 모든 간선의 가중치의 합으로 설정 가능
//   경로를 찾을 수 없는 경우 기준값을 2로 나누고 기준값이 0이 되면 알고리즘 종료

//에드몬드-카프 알고리즘 사용
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Lecture 
{
    static List<(int,int)>[] adj;
    
    //최대 용량을 넣을 배열. a -> b 간선과 b -> a간선의 가중치를 더하면 adjFull[a,b]의 값이 나온다.
    static int[,] adjFull;
    
    static bool[] visited;

    static int source, sink;
    public static void Main(string[] args) {
    	AdjInit(6);
        Add(1,2,5);
        Add(1,4,4);
        Add(4,2,3);
        Add(4,5,1);
        Add(2,3,6);
        Add(3,5,8);
        Add(3,6,5);
        Add(5,6,2);

        source = 1; sink = 6;
        Console.WriteLine(MaximumFlow());
        
        for(int i = 1; i < 7; i++){
            foreach(var u in adj[i]){
                Console.WriteLine(i + " " + u.Item1 + " " + u.Item2);
            }
        }
    }
    //기준값. 처음에는 적당히 큰 값
    static int value = 20;  
    
    //용량 조절 알고리즘을 이용한 경로 찾기
    //경로 찾기 결과가 false가 되면 더 이상 만들 수 있는 경로가 없는 것이므로
    //알고리즘을 종료한다.
    static List<(int,int,int)> temp = new List<(int,int,int)>();
    static int MaximumFlow(){
        while(value > 0){
            Array.Clear(visited, 0, visited.Length);

            if(!Bfs()){
                value = value / 2;
                continue;
            }

            //선택한 경로에 포함된 간선의 가중치 중 가장 작은 가중치를 선택하고
            //경로의 모든 간선에 이 값을 빼고, 반대간선에 이 값을 더함 
            if(temp.Count != 0){
                int min = 1000;
                foreach(var u in temp){
                    //Console.WriteLine(u.Item1 + " " + u.Item2 + " " + u.Item3);
                    min = Math.Min(min, u.Item3);
                }
                if(min != 1000) SubWeight(min);
                temp.Clear();
            }
        }
        
        int max = 0;
        foreach(var u in adj[6]){
            max += u.Item2;
        }
        
        return max;
    }

    //에드몬드 카프 알고리즘을 위한 BFS
    static Queue<int> q = new Queue<int>();
    static bool Bfs(){
        q.Enqueue(source);
        visited[source] = true;
        
        while(q.Count != 0){
            int s = q.Dequeue();
            foreach(var u in adj[s]){
                if((!visited[u.Item1]) && (adjFull[s,u.Item1] - u.Item2 >= 0)){
                    visited[u.Item1] = true;
                    q.Enqueue(u.Item1);
                    temp.Add((s, u.Item1, u.Item2));
                    if(u.Item1 == sink) return true;
                } 
            }
        }
        return false;
    }

    static void AdjInit(int n){
        adj = new List<(int,int)>[n+1];
        adjFull = new int[n+1,n+1];
        visited = new bool[n+1];
        for(int i = 1; i < n+1; i++){
            adj[i] = new List<(int,int)>();
        }
    }
    
    //가중치를 최소값만큼 빼고 반대편 가중치를 올리는 함수
    static void SubWeight(int min){
        int x, y, w;
        if(temp.Count != 0){
            for(int i = temp.Count - 1; i >= 0; i--){
                x = temp[i].Item1; y = temp[i].Item2; w = temp[i].Item3;
                int XIndex = adj[x].IndexOf((y,w));
                int YIndex = adj[y].IndexOf((x,(adjFull[x,y] - adj[x][XIndex].Item2)));
                adj[x][XIndex] = (y,adj[x][XIndex].Item2 - min);
                adj[y][YIndex] = (x,adj[y][YIndex].Item2 + min);
            }
        }
    }
    
    //a에서 b로 가는 가중치 w인 간선을 추가하는 함수
    //그 반대는 가중치를 0으로 해서 추가한다.
    static void Add(int a, int b, int w){
        adj[a].Add((b,w));
        adj[b].Add((a,0));
        adjFull[a,b] = w;
    }
}