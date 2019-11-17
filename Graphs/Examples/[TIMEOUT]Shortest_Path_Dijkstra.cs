//백준에서 시간초과로 틀렸다고 나온다. 답은 맞지만 더 효율적인 알고리즘 고려해야됨
//SPFA(Shortest Path Faster Algorithm)에 따르면 deque를 써서 현재 큐의 맨 앞의 거리값보다 작으면
//앞에 넣어주고 크면 뒤에 넣어주면 되지만 c#에는 deque가 없다. priorityQueue도 없고 다없다.
/*
# 1753

방향그래프가 주어지면 주어진 시작점에서 다른 모든 정점으로의 최단 

경로를 구하는 프로그램을 작성하시오. 단, 모든 간선의 가중치는 10 이하의 자연수이다.

첫째 줄에 정점의 개수 V와 간선의 개수 E가 주어진다. (1≤V≤20,000, 1≤E≤300,000) 모든

정점에는 1부터 V까지 번호가 매겨져 있다고 가정한다. 둘째 줄에는 시작 정점의 번호

K(1≤K≤V)가 주어진다. 셋째 줄부터 E개의 줄에 걸쳐 각 간선을 나타내는 세 개의 정수

(u, v, w)가 순서대로 주어진다. 이는 u에서 v로 가는 가중치 w인 간선이 존재한다는 뜻이다.

u와 v는 서로 다르며 w는 10 이하의 자연수이다. 서로 다른 두 정점 사이에 여러 개의 간선이

존재할 수도 있음에 유의한다.
*/

using System;
using System.IO;
using System.Collections.Generic;
public class Lecture 
{
    // 인접 리스트의 형태로 그래프를 저장해준다.
    static List<(int,int)>[] adj;
    // c#에는 우선순위 큐가 없으므로 list의 sort로 그 일을 대신한다. 
	static List<(int,int)> asc = new List<(int,int)>();
    //거리를 담아줄 배열
    static int[] distance;
    //처리했는지를 체크하는 배열
    static bool[] processed;
	public static void Main(string[] args) {
        //정점의 개수 arr[0]와 간선의 개수 arr[1]
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        //시작 노드
        int start = int.Parse(Console.ReadLine());

        //배열들 초기화
        adj = new List<(int,int)>[arr[0]+1];
        for(int i = 0; i < arr[0]+1; i++){
            adj[i] = new List<(int,int)>();
        }
        distance = new int[arr[0]+1];
        processed = new bool[arr[0]+1];

        //셋째줄부터는 (a,b,w)를 받는다.
        for(int i = 0; i < arr[1]; i++){
            int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            adj[tmp[0]].Add((tmp[1],tmp[2]));
        }

        for(int i = 1; i < arr[0]+1; i++){
            //w가 10이하의 자연수라고 명시되어있다. 그렇다고 11로 하면 안되는데
            //그 이유는 시작노드에서 가장 먼 노드까지 갈때 최단거리가 11이 넘을 수 있기 때문이다.
            //따라서 최대한 큰 숫자를 넣어주자.
            distance[i] = 200001;
        }

        //시작노드에서 시작노드로의 거리는 0
        distance[start] = 0;
        asc.Add((0,start));
        while(asc.Count != 0){
            int a = asc[0].Item2; asc.RemoveAt(0);
            if(processed[a]) continue;
            processed[a] = true;
            foreach(var u in adj[a]){
                int b = u.Item1; int w = u.Item2;
                if(distance[a] + w < distance[b]){
                    distance[b] = distance[a] + w;
                    asc.Add((distance[b],b));
                    //정렬 순서 조심
                    asc.Sort((x,y) => x.Item1.CompareTo(y.Item1));
                }
            }
        }
        
        for(int i = 1; i < arr[0] + 1; i++){
            //경로가 없다는 것은 거리가 한번도 줄어들지 않았다는 뜻이므로 11이면 INF로 표시
            if(distance[i] == 200001){
                Console.WriteLine("INF");
            }
            else{
                Console.WriteLine(distance[i]);
            }
        }
    }
}