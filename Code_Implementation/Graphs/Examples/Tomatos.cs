using System;
using System.IO;
using System.Collections.Generic;

public class ei 
{
	//토마토가 들어있는 격자모양 창고
	static int[,] adj;
	//몇일이 지났는지 count
	static int count = 0;
    //위아래양옆을 체크하기 위한 배열
	static int[] dx = {0,0,-1,1};
	static int[] dy = {1,-1,0,0};
	//bfs에 사용할 큐
	static Queue<(int,int)> q = new Queue<(int,int)>();
	
	public static void Main(string[] args) {
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		adj = new int[arr[1],arr[0]];
		
		for(int i = 0; i < arr[1]; i++){
			string[] str = Console.ReadLine().Split(' ');
			for(int j = 0; j < str.Length; j++){
				adj[i,j] = int.Parse(str[j].ToString());
				//1(다 익은)인 토마토들의 주변을 전부 확인해봐야 하므로 바로 큐에 집어넣어준다.
				if(adj[i,j] == 1) q.Enqueue((i,j));
			}
		}
		
		while(!(q.Count == 0)){
			bfs(q.Peek().Item1,q.Peek().Item2);
			q.Dequeue();
		}
		
		//익어있지 않는 토마토가 있다면 -1을 출력한다.
		for(int i = 0; i < adj.GetLength(0);i++){
			for(int j = 0; j < adj.GetLength(1); j++){
				if(adj[i,j] == 0){
					Console.WriteLine("-1");
					return;
				}
				count = Math.Max(count, adj[i,j]);
			}
		}
		Console.WriteLine(count-1);
	}
	
	//visit 배열을 사용하지 않고 다음 순서에 바로 +1을 함으로서 순서를 나타낸다.
	static void bfs(int x, int y){
		for(int i = 0; i < 4; i++){
			int nx = x + dx[i];
			int ny = y + dy[i];
			if(nx>=0&&ny>=0&&nx<adj.GetLength(0)&&ny<adj.GetLength(1)){
				if(adj[nx,ny] == 0){
					adj[nx,ny] = adj[x,y] + 1;
					q.Enqueue((nx,ny));
				}
			}
		}
	}
}