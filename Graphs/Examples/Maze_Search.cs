/*
# 2178

N×M크기의 배열로 표현되는 미로가 있다.

1	0	1	1	1	1
1	0	1	0	1	0
1	0	1	0	1	1
1	1	1	0	1	1
미로에서 1은 이동할 수 있는 칸을 나타내고, 0은 이동할 수 없는 칸을 나타낸다.

이러한 미로가 주어졌을 때, (1, 1)에서 출발하여 (N, M)의 위치로 이동할 때 지나야 하는

최소의 칸 수를 구하는 프로그램을 작성하시오. 한 칸에서 다른 칸으로 이동할 때,

서로 인접한 칸으로만 이동할 수 있다. 위의 예에서는 15칸을 지나야 (N, M)의 위치로 이동할

수 있다. 칸을 셀 때에는 시작 위치와 도착 위치도 포함한다.
*/
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//미로를 표현하기 위한 배열
	static int[,] adj;
    //지나야 하는 칸 수
	static int[,] distance;
    //그 땅을 이미 계산했는지 확인하기 위한 배열
	static bool[,] visited;
	//bfs에서 사용할 큐
	static Queue<(int,int)> q = new Queue<(int,int)>();
    //위아래양옆을 체크하기 위한 배열
	static int[] dx = {0,0,-1,1};
	static int[] dy = {1,-1,0,0};

	public static void Main(string[] args) {
		//arr[0]*arr[1]크기의 미로
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		adj = new int[arr[0]+1,arr[1]+1];
		visited = new bool[arr[0]+1,arr[1]+1];
		distance = new int[arr[0]+1,arr[1]+1];
		
		for(int i = 1; i <= arr[0]; i++){
			string str = Console.ReadLine();
			for(int j = 1; j <= str.Length; j++){
				adj[i,j] = int.Parse(str[j-1].ToString());
			}
		}	
		bfs(1,1);
		
		Console.WriteLine(distance[arr[0],arr[1]]);
	}
		
	
	
	public static void bfs(int x, int y){
		visited[x,y] = true;
		//시작위치와 도착위치도 포함한다고 명시했으므로 distance는 1로 시작
		distance[x,y] = 1;
		q.Enqueue((x,y));
		while(!(q.Count==0))
        {
			int v = q.Peek().Item1;
			int z = q.Peek().Item2;
			q.Dequeue();
			
			if((v == adj.GetLength(0)-1)&&(z == adj.GetLength(1)-1)) break;
			
			for(int i = 0; i < 4; i++){
				int nx = v + dx[i];
				int ny = z + dy[i];
				
				if(nx>=1&&ny>=1&&nx<adj.GetLength(0)&&ny<adj.GetLength(1)){
					if(!visited[nx,ny]&&adj[nx,ny]==1){
						distance[nx,ny] = distance[v,z] + 1;
						visited[nx,ny] = true;
						q.Enqueue((nx,ny));
					}
				}
			}
        }
    }
}