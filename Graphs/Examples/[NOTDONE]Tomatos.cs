/*
# 7576

철수의 토마토 농장에서는 토마토를 보관하는 큰 창고를 가지고 있다. 토마토는 격자 모양

상자의 칸에 하나씩 넣어서 창고에 보관한다. 창고에 보관되는 토마토들 중에는 잘 익은 것도

있지만, 아직 익지 않은 토마토들도 있을 수 있다. 보관 후 하루가 지나면, 익은 토마토들의

인접한 곳에 있는 익지 않은 토마토들은 익은 토마토의 영향을 받아 익게 된다. 하나의

토마토의 인접한 곳은 왼쪽, 오른쪽, 앞, 뒤 네 방향에 있는 토마토를 의미한다. 대각선

방향에 있는 토마토들에게는 영향을 주지 못하며, 토마토가 혼자 저절로 익는 경우는 없다고

가정한다. 철수는 창고에 보관된 토마토들이 며칠이 지나면 다 익게 되는지, 그 최소 일수를

알고 싶어 한다. 토마토를 창고에 보관하는 격자모양의 상자들의 크기와 익은 토마토들과 익지

않은 토마토들의 정보가 주어졌을 때, 며칠이 지나면 토마토들이 모두 익는지, 그 최소 일수를

구하는 프로그램을 작성하라. 단, 상자의 일부 칸에는 토마토가 들어있지 않을 수도 있다.
*/
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//토마토가 들어있는 격자모양 창고
	static int[,] adj;
	//계산했는지를 판단
	static bool[,] visited;
	//몇일이 지났는지 count
	//이미 익은것부터 시작하는데 익은거는 날짜에 안치므로 ++해서 0이 되기 위해 -1로 시작한다.
	static int count = -1;
    //위아래양옆을 체크하기 위한 배열
	static int[] dx = {0,0,-1,1};
	static int[] dy = {1,-1,0,0};
	
	public static void Main(string[] args) {
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		adj = new int[arr[1],arr[0]];
		
		for(int i = 0; i < arr[1]; i++){
			string str = Console.ReadLine();
			for(int j = 0; j < str.Length; j++){
				adj[i,j] = int.Parse(str[j].ToString());
			}
		}
		
		for(int i = 0; i < adj.GetLength(0); i++){
			for(int j = 0; j < adj.GetLength(1); j++){
				if(adj[i,j]==1) dfs(i,j);
			}
		}
		
		Console.WriteLine(count);
	}
	
	public static void dfs(int x, int y){
		//adj가 범위를 벗어나지 않고 주변에 안익은 토마토가 있어서 익힐 수 있다면 count를 ++한다.
		if(x>=0&&y>=0&&x<adj.GetLength(0)&&y<adj.GetLength(1)){
			if(adj[x-1,y]==0||adj[x,y-1]==0||adj[x+1,y]==0||adj[x,y-1]==0)count++;
		}
		for(int i = 0; i < 4; i++){
			int nx = x + dx[i];
			int ny = x + dy[i];
			if(nx>=0&&ny>=0&&nx<adj.GetLength(0)&&ny<adj.GetLength(1)){
				if(adj[nx,ny] == 0){
					adj[nx,ny] = 1;
				}
				dfs(nx,ny);
			}
		}
	}
}