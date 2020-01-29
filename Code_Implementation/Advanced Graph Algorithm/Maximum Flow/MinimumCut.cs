//포드 풀커슨 알고리즘을 이용해 최대 유량을 찾았다면 그 결과에서 최소컷을 찾을 수 있음
//포드 풀커슨 알고리즘을 실행한 이후의 그래프에 대해 A를 소스에서 가중치가 양수인 간선으로
//갈 수 있는 노드의 집합이라 할 때, 최소컷은 원래 그래프에서 A에 속한 노드에서 A에 속하지 않은
//노드로 가는 간선으로 구성되며. 그러한 간선의 용량은 최대 유량을 구할 때 모두 사용되었다.
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

        MaximumFlow();
        
        Console.WriteLine(MinCut());
    }
#region FordFulkerson
    //기준값. 처음에는 적당히 큰 값
    static int value = 20;  
    
    //용량 조절 알고리즘을 이용한 경로 찾기
    //경로 찾기 결과가 false가 되면 더 이상 만들 수 있는 경로가 없는 것이므로
    //알고리즘을 종료한다.
    static List<(int,int,int)> temp = new List<(int,int,int)>();

    static int MaximumFlow(){
        while(value > 0){
            Array.Clear(visited, 0, visited.Length);
            
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
            
        }
        
        int max = 0;
        foreach(var u in adj[6]){
            max += u.Item2;
        }
        
        return max;
    }


    static bool Dfs(int s, int e){
        if(s == e){
            return true;
        }
        
        visited[s] = true;
        
        foreach(var u in adj[s]){
            if(visited[u.Item1]) continue;
            if(u.Item2 >= value){
                if(Dfs(u.Item1, e)){
                    temp.Add((s, u.Item1, u.Item2));
                    return true;
                }
                //실패하면 다시 다른곳에서 돌아올 수 있으므로 u.Item1을 false해준다.
                visited[u.Item1] = false;
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
#endregion

    //소스에서 갈수 있는 노드의 집합 A를 만들기 위한 리스트
    static List<int> list = new List<int>();
    static int MinCut(){
        //먼저 집합 A를 만들어준다.
        Dfs_MC(1,0);

        int sum = 0;
        foreach(var s in list){
            foreach(var u in adj[s]){
                if(!list.Contains(u.Item1)){
                    //A에 속한 노드에서 A에 속하지 않은 노드로 가는 간선의 용량은
                    //최대유량을 구할 때 다 썼으므로 당연히 0이며 그 반대 유량을 더하면
                    //최소컷이다. 항상 최소컷 == 최대 유량이다.
                    sum += adj[u.Item1][adj[u.Item1].IndexOf((s,adjFull[s,u.Item1]))].Item2;
                }
            }
        }

        return sum;
    }

    static void Dfs_MC(int s,int e){
        list.Add(s);
        visited[s] = true;
        Console.WriteLine(s);
        foreach(var u in adj[s]){
            if((!visited[u.Item1]) && u.Item2 > 0){
                Dfs_MC(u.Item1, s);
            }
        }
    }
}