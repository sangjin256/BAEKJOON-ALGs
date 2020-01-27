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
    static int[,] adjWeight;
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
        
    }

    //용량 조절 알고리즘을 이용한 경로 찾기
    //경로 찾기 결과가 false가 되면 더 이상 만들 수 있는 경로가 없는 것이므로
    //알고리즘을 종료한다.
    static List<(int,int)> temp = new List<(int,int)>();
    static void FordFulkerson(){
        while(value > 0){
            //항상 소스 노드에서 시작해서 싱크 노드에서 끝나야함
            Dfs(1, 0, 6);
            if(possible == false) value = value / 2;
            int min = 1000;
            foreach(var c in temp){
                if(c.Item2 < min){
                    min = c.Item2;
                }
            }
            
          
            if(temp.Count != 0){
            	int Forref = 1;
            	foreach(var u in temp){
                	SubWeight(ref Forref, u.Item1, min);
            	}
                temp.Clear();
                possible = false;
            }
            
        }
    }

    //기준값. 처음에는 적당히 큰 값
    static int value = 10;
    
    static bool possible = false;
    
    static void Dfs(int s, int prev, int e){
        if(s == e){
            possible = true;
            return;
        }
        foreach(var u in adj[s]){
            if(u.Item2 > value && prev != u.Item1){
                temp.Add((u.Item1, u.Item2));
                //Console.WriteLine(u.Item1 + " " +  u.Item2);
                Dfs(u.Item1, s, e);
                if(possible == true) return; 
                temp.Remove((u.Item1, u.Item2));
            }
        }
        return;
    }

    static void AdjInit(int n){
        adj = new List<(int,int)>[n+1];
        adjWeight = new int[n+1,n+1];
        for(int i = 1; i < n+1; i++){
            adj[i] = new List<(int,int)>();
        }
    }

    //가중치를 최소값만큼 빼고 반대편 가중치를 올리는 함수
    static void SubWeight(ref int x, int y, int min){
        int newXYWeight = adjWeight[x,y] - min;
        int newYXWeight = adjWeight[y,x] + min;
        adj[x][adj[x].IndexOf((y,adjWeight[x,y]))] = (y,newXYWeight);
        adj[y][adj[y].IndexOf((x,adjWeight[y,x]))] = (x,newYXWeight);
        adjWeight[x,y] = newXYWeight;
        adjWeight[y,x] = newYXWeight;
        x = y;
    }
    
    //a에서 b로 가는 가중치 w인 간선을 추가하는 함수
    //그 반대는 가중치를 0으로 해서 추가한다.
    static void Add(int a, int b, int w){
        adj[a].Add((b,w));
        adj[b].Add((a,0));
        adjWeight[a,b] = w;
        adjWeight[b,a] = 0;
    }
}