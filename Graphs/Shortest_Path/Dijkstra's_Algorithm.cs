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
    static int[] distance = new int[6];
    //처리했는지를 체크하는 배열
    static bool[] processed = new bool[6];
	public static void Main(string[] args) {
        //1~5까지 넣기 위해 5+1
        adj = new List<(int,int)>[6];
        //배열 하나씩 초기화해준다.
        for(int i = 0; i < 6; i++){
            adj[i] = new List<(int,int)>();
        }

        adj[1].Add((2,5));
        adj[1].Add((4,9));
        adj[1].Add((5,1));
        adj[2].Add((3,2));
        adj[2].Add((1,5));
        adj[3].Add((2,2));
        adj[3].Add((4,7));
        adj[4].Add((1,9));
        adj[4].Add((3,7));
        adj[4].Add((5,2));
        adj[5].Add((1,1));
        adj[5].Add((4,2));

        for(int i = 0; i < 6; i++){
            //제일큰 가중치보다 조금 더 크게 설정한다.
            distance[i] = 10;
        }
        //시작간선은 1로 설정
        distance[1] = 0;
        //1까지 가는 간선의 길이가 0이라는 의미
        asc.Add((0,1));
        while(asc.Count != 0){
            int a = asc[0].Item2; asc.RemoveAt(0);
            if(processed[a]) continue;
            processed[a] = true;
            foreach(var u in adj[a]){
                int b = u.Item1, w = u.Item2;
                if(distance[a] + w < distance[b]){
                    distance[b] = distance[a] + w;
                    asc.Add((distance[b],b));
                    //우선순위 큐가 아니므로 sort는 필수다.
                    asc.Sort((x,y) => y.Item1.CompareTo(x.Item1));
                }
            }
        }

        for(int i = 0; i < 6; i++){
            Console.WriteLine(i + " : " +distance[i]);
        }
    }
}