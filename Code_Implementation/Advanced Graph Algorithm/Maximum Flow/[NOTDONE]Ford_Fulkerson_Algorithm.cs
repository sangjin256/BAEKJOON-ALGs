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
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

public class Lecture 
{
    static List<(int,int)>[] adj;
    //가중치를 넣을 배열. 리스트로는 가중치만 따로 빼기가 힘들고 배열만 쓰면 Dfs가 애로하므로 배열과 리스트를 따로 만들었다.
    static int[,] adjWeight;
    
    //x부터 y까지 가는 간선의 최대 용량을 넣을 배열
    static int[,] adjFull;
    
    static bool[] visited;
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

        FordFulkerson();
        
        for(int i = 0; i < adjWeight.GetLength(0); i++){
            for(int j = 0; j < adjWeight.GetLength(0); j++){
                Console.WriteLine(i + " " + j + " : " + adjWeight[i,j]);
            }
        }
    }
    //기준값. 처음에는 적당히 큰 값
    static int value = 20;  
    
    //용량 조절 알고리즘을 이용한 경로 찾기
    //경로 찾기 결과가 false가 되면 더 이상 만들 수 있는 경로가 없는 것이므로
    //알고리즘을 종료한다.
    static List<(int,int,int)> temp = new List<(int,int,int)>();
    static void FordFulkerson(){
        while(value > 0){
            Console.WriteLine("  " + value);
            
            if(!Dfs(1,6)){
                value = value / 2;
                continue;
            }
            
            //선택한 경로에 포함된 간선의 가중치 중 가장 작은 가중치를 선택하고
            //경로의 모든 간선에 이 값을 빼고, 반대간선에 이 값을 더함 
            if(temp.Count != 0){
                int min = 1000;
                foreach(var u in temp){
                    min = Math.Min(min, u.Item3);
                }
                if(min != 1000) SubWeight(min);
                temp.Clear();
            }
            Array.Clear(visited, 0, visited.Length);
        }
    }


    static bool Dfs(int s, int e){
        if(s == e){
            return true;
        }
        
        foreach(var u in adj[s]){
            Console.WriteLine(s + " " + u.Item1);             
            if(visited[u.Item1]) continue;
            if(u.Item2 >= value){
               visited[s] = true;
                if(Dfs(u.Item1, e)){
                    temp.Add((s, u.Item1, u.Item2));
                    return true;
                }
            }
            visited[s] = false;
        }

        return false;
    }

    static void AdjInit(int n){
        adj = new List<(int,int)>[n+1];
        adjFull = new int[n+1,n+1];
        visited = new bool[n+1];
        adjWeight = new int[n+1,n+1];
        for(int i = 1; i < n+1; i++){
            adj[i] = new List<(int,int)>();
        }
    }
    
    //가중치를 최소값만큼 빼고 반대편 가중치를 올리는 함수
    static void SubWeight(int min){
        int newXYWeight;
        int newYXWeight;
        int x, y, w;
        if(temp.Count != 0){
            for(int i = temp.Count - 1; i >= 0; i--){
                x = temp[i].Item1; y = temp[i].Item2; w = temp[i].Item3;
                int XIndex = adj[x].IndexOf((y,w));
                int YIndex = adj[y].IndexOf((x,adjWeight[y,x]));
                newXYWeight = adjWeight[x,y] - min;
                newYXWeight = adjWeight[y,x] + min;
                adj[x][XIndex] = (y,newXYWeight);
                adj[y][YIndex] = (x,newYXWeight);
                adjWeight[x,y] = newXYWeight;
                adjWeight[y,x] = newYXWeight;
            }
        }
    }
    
    //a에서 b로 가는 가중치 w인 간선을 추가하는 함수
    //그 반대는 가중치를 0으로 해서 추가한다.
    static void Add(int a, int b, int w){
        adj[a].Add((b,w));
        adj[b].Add((a,0));
        adjFull[a,b] = w;
        adjFull[b,a] = w;
        adjWeight[a,b] = w;
        adjWeight[b,a] = 0;
    }
}