//간선 리스트

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//가중치가 없는 간선리스트
	static List<Tuple<int,int>> edges = new List<Tuple<int,int>>();
	//가중치가 있는 간선리스트
	static List<Tuple<int,int,int>> edges_w = new List<Tuple<int,int,int>>();
	
	public static void Main(string[] args) {
		edges.Add(new Tuple<int,int>(1,2));
		edges.Add(new Tuple<int,int>(2,3));
		edges.Add(new Tuple<int,int>(2,4));
		edges.Add(new Tuple<int,int>(3,4));
		edges.Add(new Tuple<int,int>(4,1));
		
		//(a,b,w)는 a에서 b로 가는 가중치가 w인 간선을 의미
		edges_w.Add(new Tuple<int,int,int>(1,2,5));
		edges_w.Add(new Tuple<int,int,int>(2,3,7));
		edges_w.Add(new Tuple<int,int,int>(2,4,6));
		edges_w.Add(new Tuple<int,int,int>(3,4,5));
		edges_w.Add(new Tuple<int,int,int>(4,1,2));
	}
}