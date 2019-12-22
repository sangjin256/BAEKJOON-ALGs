/*
# 2606

신종 바이러스인 웜 바이러스는 네트워크를 통해 전파된다. 한 컴퓨터가 웜 바이러스에 걸리면

그 컴퓨터와 네트워크 상에서 연결되어 있는 모든 컴퓨터는 웜 바이러스에 걸리게 된다.

예를 들어 7대의 컴퓨터가 <그림 1>과 같이 네트워크 상에서 연결되어 있다고 하자.

1번 컴퓨터가 웜 바이러스에 걸리면 웜 바이러스는 2번과 5번 컴퓨터를 거쳐 3번과 6번

컴퓨터까지 전파되어 2, 3, 5, 6 네 대의 컴퓨터는 웜 바이러스에 걸리게 된다. 하지만

4번과 7번 컴퓨터는 1번 컴퓨터와 네트워크상에서 연결되어 있지 않기 때문에 영향을 받지

않는다. 어느 날 1번 컴퓨터가 웜 바이러스에 걸렸다. 컴퓨터의 수와 네트워크 상에서 서로

연결되어 있는 정보가 주어질 때, 1번 컴퓨터를 통해 웜 바이러스에 걸리게 되는 컴퓨터의

수를 출력하는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//그래프를 표현하기 위해 인접리스트 사용
	static List<int>[] adj;
	public static void Main(string[] args) {
		int num = int.Parse(Console.ReadLine());
		AdjacencyList(num+1, false);
		int pairs = int.Parse(Console.ReadLine());
		
		//다음 M개의 줄에는 간선이 연결하는 두 정점의 번호
		//입력으로 주어지는 간선은 양방향이다.
		//따라서 반대방향으로도 넣어주자.
		for(int i = 0; i < pairs; i++){
			int[] tmp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
			adj[tmp[0]].Add(tmp[1]);
			adj[tmp[1]].Add(tmp[0]);
		}
		
		visited_dfs = new bool[num+1];
		
		dfs(1);
		
		//count가 시작점인 1도 포함하고 있으므로 빼준다.
		Console.WriteLine(count-1);
	}
	
	static bool[] visited_dfs;
	static int count = 0;
	public static void dfs(int s){
		if(visited_dfs[s]) return;
		visited_dfs[s] = true;
		count++;
		foreach(var u in adj[s]){
			dfs(u);
		}
	}
	
	public static void AdjacencyList(int length, bool isWeight){
		if(isWeight == false){
			adj = new List<int>[length];
			
			for(int i = 0; i < length; i++){
				adj[i] = new List<int>();
			}
		}
	}
}