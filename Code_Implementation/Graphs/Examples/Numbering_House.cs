/*
#2667

<그림 1>과 같이 정사각형 모양의 지도가 있다. 1은 집이 있는 곳을, 0은 집이 없는 곳을

나타낸다. 철수는 이 지도를 가지고 연결된 집들의 모임인 단지를 정의하고, 단지에 번호를

붙이려 한다. 여기서 연결되었다는 것은 어떤 집이 좌우, 혹은 아래위로 다른 집이 있는

경우를 말한다. 대각선상에 집이 있는 경우는 연결된 것이 아니다. <그림 2>는 <그림 1>을

단지별로 번호를 붙인 것이다. 지도를 입력하여 단지수를 출력하고, 각 단지에 속하는 집의

수를 오름차순으로 정렬하여 출력하는 프로그램을 작성하시오.

<그림 1>   <그림2>
0110100    0110200
0110101    0110202
1110101    1110202
0000111    0000222 
0100000    0300000
0111110    0333330
0111000    0333000
*/
using System;
using System.IO;
using System.Collections.Generic;

public class eu 
{
	//집의 존재유무를 표현하기 위한 2차원배열
	static int[,] adj;
    //단지수를 표시하기 위한 변수
	static int count = 0;
    //한 단지 안에 있는 집 수
	static int[] numbers;
    //그 집을 이미 계산했는지 확인하기 위한 배열
	static bool[,] visited;
    //위아래양옆을 체크하기 위한 배열
	static int[] dx = {0,0,-1,1};
	static int[] dy = {1,-1,0,0};

	public static void Main(string[] args) {
        //num값에 따라 모두 초기화해주고 입력값을 adj에 넣는다.
        //첫 번째 줄에는 지도의 크기 N(정사각형이므로 가로와 세로의 크기는 같으며
        //5≤N≤25)이 입력되고, 그 다음 N줄에는 각각 N개의 자료(0혹은 1)가 입력된다.
		int num = int.Parse(Console.ReadLine());
		adj = new int[num+2,num+2];
		numbers = new int[num*num+1];
		visited = new bool[num+2,num+2];
		for(int i = 1; i <= num; i++){
			string str = Console.ReadLine();
			for(int j = 1; j <= str.Length; j++){
				adj[i,j] = int.Parse(str[j-1].ToString());
			}
		}
		
        //현재 확인하는 곳에 집이 있고 방문하지 않았다면 dfs 함수를 수행한다.
        //함수 수행이 끝나면 그 단지는 전부 처리한 것이므로 count++를 하여 다음단지로 넘어간다.
		for(int i = 1; i <= num; i++){
			for(int j = 1; j <= num; j++){
				if(adj[i,j] == 1 && visited[i,j] == Convert.ToBoolean(false)){
					dfs(i,j);
					count++;
				}
			}
		}
		
        //첫 번째 줄에는 총 단지수를 출력하시오.
        //그리고 각 단지내 집의 수를 오름차순으로 정렬하여 한 줄에 하나씩 출력하시오.
		Array.Sort(numbers);
		Console.WriteLine(count);
		for(int i = 0; i < numbers.Length; i++){
			if(numbers[i] != 0){
				Console.WriteLine(numbers[i]);
			}
		}
		
	}
	
	public static void dfs(int x, int y){
        //현재 집을 방문처리하고 단지에 추가한다.
		visited[x,y] = true;
		numbers[count]++;
		for(int i = 0; i < 4; i++){
			int nx = x + dx[i];
			int ny = y + dy[i];
            //위아래양옆이 배열을 벗어났는지를 체크하고 그곳이 방문하지 않았으며 집이 존재한다면 재귀적으로 수행한다.
			if(nx>=0&&ny>=0&&nx<adj.GetLength(0)&&ny<adj.GetLength(0)){
				if(!visited[nx,ny]&&Convert.ToBoolean(adj[nx,ny])){
					dfs(nx,ny);
				}
			}
		}
	}
	
}