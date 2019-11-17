using System;
using System.IO;
using System.Collections.Generic;
public class Lecture 
{
	static List<(int,int,int)> edges = new List<(int,int,int)>();
	static long[] distance;
	public static void Main(string[] args) {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        for(int i = 0; i < arr[1]; i++){
            int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            edges.Add((tmp[0],tmp[1],tmp[2]));
        }
        
        distance = new long[arr[0]+1];

        for(int i = 1; i < arr[0]+1; i++){
            //거리는 간선의 가중치의 최댓값에 노드의 개수를 곱한거에 +1한 값을 넣자.
            distance[i] = 10000*(arr[0])+1;
        }
        //시작노드가 1이고 1에서 1로의 거리는 0
        distance[1] = 0;
        //음수 사이클 있는지 판단
        bool cycle = false;
        for(int i = 1; i <= arr[0]; i++){
            //계산 시간을 단축하기 위해 한 라운드동안 줄어드는 거리가 없으면 종료한다.
            int count = 0;
            foreach(var e in edges){
                (int a, int b, int w) ed = e;
                long temp = Math.Min(distance[ed.b], distance[ed.a] + ed.w);
                if(temp == distance[ed.b]){
                    count++;
                }

                if(temp < distance[ed.b]){
                    distance[ed.b] = temp;
                    //마지막 라운드에서도 거리가 줄어들면 그래프의 음수 사이클이 있는것(무한)
                    if(i == arr[0]){
                        cycle = true;
                    }
                }
            }
            if(count == arr[1]) break;
        }

        if(cycle == true){
        	Console.WriteLine("-1");
        } else{
            for(int i = 2; i <= arr[0]; i++){
                //경로가 없으면 -1 출력
                if(distance[i] == 10000*(arr[0])+1){
                    Console.WriteLine("-1");
                }
                else Console.WriteLine(distance[i]);
            } 
        }
    }
}