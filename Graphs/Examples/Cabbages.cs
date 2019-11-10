/*
# 1012

차세대 영농인 한나는 강원도 고랭지에서 유기농 배추를 재배하기로 하였다. 농약을 쓰지 않고

배추를 재배하려면 배추를 해충으로부터 보호하는 것이 중요하기 때문에, 한나는 해충 방지에

효과적인 배추흰지렁이를 구입하기로 결심한다. 이 지렁이는 배추근처에 서식하며 해충을 잡아

먹음으로써 배추를 보호한다. 특히, 어떤 배추에 배추흰지렁이가 한 마리라도 살고 있으면 이

지렁이는 인접한 다른 배추로 이동할 수 있어, 그 배추들 역시 해충으로부터 보호받을 수 있다.

(한 배추의 상하좌우 네 방향에 다른 배추가 위치한 경우에 서로 인접해있다고 간주한다)

한나가 배추를 재배하는 땅은 고르지 못해서 배추를 군데군데 심어놓았다. 배추들이 모여있는

곳에는 배추흰지렁이가 한 마리만 있으면 되므로 서로 인접해있는 배추들이 몇 군데에

퍼져있는지 조사하면 총 몇 마리의 지렁이가 필요한지 알 수 있다.

예를 들어 배추밭이 아래와 같이 구성되어 있으면 최소 5마리의 배추흰지렁이가 필요하다.

(0은 배추가 심어져 있지 않은 땅이고, 1은 배추가 심어져 있는 땅을 나타낸다.)
*/

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//땅을 표현하기 위한 배열
	static int[,] adj;
    //그 땅을 이미 계산했는지 확인하기 위한 배열
	static bool[,] visited;
    //위아래양옆을 체크하기 위한 배열
	static int[] dx = {0,0,-1,1};
	static int[] dy = {1,-1,0,0};

	public static void Main(string[] args) {
		//테스트 케이스의 개수 num
		int num = int.Parse(Console.ReadLine());
		
		for(int p = 0; p < num; p++){
			//배추들의 모여있는 곳의 수
			int count = 0;
			//가로길이와 세로길이를 받고 배열들을 초기화해준다.
			int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s=>int.Parse(s));
			adj = new int[arr[1],arr[0]];
			visited = new bool[arr[1],arr[0]];
			
			//배추의 위치를 받고 그 위치에 존재한다는 의미로서 1로 만들어준다.
			for(int i = 0; i < arr[2]; i++){
				int[] tp = Array.ConvertAll(Console.ReadLine().Split(' '), s=>int.Parse(s));
				adj[tp[1],tp[0]] = 1;
			}
			
			for(int i = 0; i < arr[1]; i++){
				for(int j = 0; j < arr[0]; j++){
					if(!visited[i,j]&&adj[i,j]==1){
						dfs(i,j);
						count++;
					} 
				}
			}
			
			Console.WriteLine(count);
			
		}
	}
	
	public static void dfs(int x, int y){
		visited[x,y] = true;
		for(int i = 0; i < 4; i++){
			int nx = x + dx[i];
			int ny = y + dy[i];
			if(nx>=0&&ny>=0&&nx<adj.GetLength(0)&&ny<adj.GetLength(1)){
				if(!visited[nx,ny]&&adj[nx,ny]==1) dfs(nx,ny);
			}
		}
	}
}