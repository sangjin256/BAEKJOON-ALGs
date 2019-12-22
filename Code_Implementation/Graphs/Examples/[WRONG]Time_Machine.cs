/*
# 11657

N개의 도시가 있다. 그리고 한 도시에서 출발하여 다른 도시에 도착하는 버스가 M개 있다.

각 버스는 A, B, C로 나타낼 수 있는데, A는 시작도시, B는 도착도시, C는 버스를 타고

이동하는데 걸리는 시간이다. 시간 C가 양수가 아닌 경우가 있다. C = 0인 경우는 순간 이동을

하는 경우, C < 0인 경우는 타임머신으로 시간을 되돌아가는 경우이다.

1번 도시에서 출발해서 나머지 도시로 가는 가장 빠른 시간을 구하는 프로그램을 작성하시오.

만약 1번 도시에서 출발해 어떤 도시로 가는 과정에서 시간을 무한히 오래 전으로 되돌릴 수

있다면 첫째 줄에 -1을 출력한다. 그렇지 않다면 N-1개 줄에 걸쳐 각 줄에 1번 도시에서

출발해 2번 도시, 3번 도시, ..., N번 도시로 가는 가장 빠른 시간을 순서대로 출력한다.

만약 해당 도시로 가는 경로가 없다면 대신 -1을 출력한다.
*/
using System;
using System.IO;
using System.Collections.Generic;
public class Lecture 
{
	static List<(int,int)>[] adj;
	static long[] distance;
	public static void Main(string[] args) {
        //arr[0] = 도시의 개수(노드) arr[1] = 버스 노선의 개수(간선)
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        adj = new List<(int,int)>[arr[0]+1];
        for(int i = 0; i <= arr[0]; i++){
            adj[i] = new List<(int,int)>();
        }
        for(int i = 0; i < arr[1]; i++){
            int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            adj[tmp[0]].Add((tmp[1],tmp[2]));
        }
        
        distance = new long[arr[0]+1];

        for(int i = 1; i < arr[0]+1; i++){
            //거리는 간선의 가중치의 최댓값에 노드의 개수를 곱한거에 +1한 값을 넣자.
            distance[i] = 10000*(arr[0])+1;
        }
        //시작노드가 1이고 1에서 1로의 거리는 0
        distance[1] = 0;
        //음수 사이클 확인
        bool cycle = false;
        //음수 사이클이 있는 경우 그 노드를 배열에 넣음
        List<int> mcycle = new List<int>();
        //라운드
        for(int i = 1; i <= arr[0]; i++){
            //노드
            for(int j = 1; j <= arr[0]; j++){
                if(adj[j] != null){
                	//그 노드에서 이어지는 간선 수
                	foreach(var u in adj[j]){
                    	int b = u.Item1;
                    	int w = u.Item2;
                    	if(distance[b] > distance[j] + w){
                    		//최댓값 + 가중치는 최댓값이므로 계산하지 않는다.
                        	if(distance[j] != 10000*(arr[0])+1){
                        		distance[b] = distance[j] + w;
                        	}
                        	//마지막 라운드에서 거리가 줄어들면 음수사이클ㅇ이므로 저장
                    		if(i == arr[0]){
                            	mcycle.Add(j);
                        	}
                		}
                	}
                }
            }
        }
        //1부터가는 경로에 음수 사이클이 포함되어있으면 -1출력
        if(mcycle.Count != 0){
            foreach(var u in adj[1]){
                int b = u.Item1;
                foreach(var c in mcycle){
                    if(b == c){
                        Console.WriteLine("-1");
                        return;
                	}
                }
            }
        }
        for(int i = 2; i <= arr[0]; i++){
        	//경로가 없으면 -1 출력
            if(distance[i] == 10000*(arr[0])+1){
                Console.WriteLine("-1");
            }
            else Console.WriteLine(distance[i]);
        }
	}
}