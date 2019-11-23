/*
# 11404
n(1 ≤ n ≤ 100)개의 도시가 있다. 그리고 한 도시에서 출발하여 다른 도시에 도착하는

m(1 ≤ m ≤ 100,000)개의 버스가 있다. 각 버스는 한 번 사용할 때 필요한 비용이 있다.

모든 도시의 쌍 (A, B)에 대해서 도시 A에서 B로 가는데 필요한 비용의 최솟값을 구하는

프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
public class Lecture 
{
	static List<(int,int)>[] adj;
	static long[,] dist;
	public static void Main(string[] args) {
        //도시의 개수
        int n = int.Parse(Console.ReadLine());
        //버스의 개수
        int k = int.Parse(Console.ReadLine());
        adj = new List<(int,int)>[n+1];
        for(int i = 0; i <= n; i++){
            adj[i] = new List<(int,int)>();
        }
        dist = new long[n+1,n+1];
        for(int i = 0; i < k; i++){
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            adj[arr[0]].Add((arr[1],arr[2]));
        }
        //dist 배열 초기화
        for(int i = 1; i <= n; i++){
            for(int j = 1; j <= n; j++){
                dist[i,j] = 100000 * k + 1;
            }
        }
        for(int i = 1; i <= n; i++){
            //자기자신과의 만남은 없으므로 -1로 둔다.
            dist[i,i] = 0;
            foreach(var u in adj[i]){
                int b = u.Item1; long w = u.Item2;
                dist[i,b] = Math.Min(dist[i,b], w);
            }
        }
        

        //계산
        for(int t = 1; t <= n; t++){
            for(int i = 1; i <= n; i++){
                for(int j = 1; j <= n; j++){
                	if(dist[i,t] != (100000 * k + 1) && dist[t,j] != (100000 * k + 1))
                    	dist[i,j] = Math.Min(dist[i,j],dist[i,t] + dist[t,j]);
                }
            }
        }

        //출력
        for(int i = 1; i <= n; i++){
            for(int j = 1; j <= n; j++){
            	if(dist[i,j] == (100000 * k + 1)) Console.Write(0 + " ");
                else Console.Write(dist[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
}