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
            //w가 10 이하의 자연수라고 명시되어있으므로 그것보다 큰 11로 만들어준다.
            distance[i] = 11;
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
                    asc.Sort((x,y) => y.Item1.CompareTo(x.Item1));
                }
            }
        }
        
        for(int i = 1; i < arr[0] + 1; i++){
            //경로가 없다는 것은 거리가 한번도 줄어들지 않았다는 뜻이므로 11이면 INF로 표시
            if(distance[i] == 11){
                Console.WriteLine("INF");
            }
            else{
                Console.WriteLine(distance[i]);
            }
        }
    }
}