//간선 리스트

using System;
using System.IO;
using System.Collections.Generic;

public class eh 
{
	//가중치가 없는 간선리스트
	//(int,int)방식은 c# 7.0부터 가능 그 전 버전은 Tuple<int,int,int>로 해줘야함
	static List<(int,int)> edges = new List<(int,int)>();
	//가중치가 있는 간선리스트
	static List<(int,int,int)> edges = new List<(int,int,int)>();
	
	public static void Main(string[] args) {
		edges.Add((1,2));
		edges.Add((2,3));
		edges.Add((2,4));
		edges.Add((3,4));
		edges.Add((4,1));
		
		//(a,b,w)는 a에서 b로 가는 가중치가 w인 간선을 의미
		edges_w.Add((1,2,5));
		edges_w.Add((2,3,7));
		edges_w.Add((2,4,6));
		edges_w.Add((3,4,5));
		edges_w.Add((4,1,2));
	}
}