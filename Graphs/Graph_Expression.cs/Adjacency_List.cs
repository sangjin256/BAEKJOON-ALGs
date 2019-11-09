//인접 리스트

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture 
{
	//인접 리스트(Adjacency list)로 표현 (가중치 x)
	static List<int>[] adj_l;

	//인접 리스트로 표현 (가중치 o)
	static List<Tuple<int, int>>[] adj_lw;
	
	public static void Main(string[] args) {
		AdjacencyList(10, false);
		adj_l[1].Add(2);
		adj_l[2].Add(3);
		adj_l[2].Add(4);
		adj_l[3].Add(4);
		adj_l[4].Add(1);
		
		AdjacencyList(10, true);
        //(b,w)는 b로 가는 가중치가 w인 간선을 의미
		adj_lw[1].Add(new Tuple<int,int>(2,5));
		adj_lw[2].Add(new Tuple<int,int>(3,7));
		adj_lw[2].Add(new Tuple<int,int>(4,6));
		adj_lw[3].Add(new Tuple<int,int>(4,5));
		adj_lw[4].Add(new Tuple<int,int>(1,2));
	}
	
	//인접 리스트를 초기화해주는 함수. 가중치가 있는 그래프와 없는 그래프를 bool로 받아서 초기화한다.
	public static void AdjacencyList(int length, bool isWeight){
		if(isWeight == false){
			adj_l = new List<int>[length];
			
			for(int i = 0; i < length; i++){
				adj_l[i] = new List<int>();
			}
		}
		else {
			adj_lw = new List<Tuple<int, int>>[length];
			
			for(int i = 0; i < length; i++){
				adj_lw[i] = new List<Tuple<int, int>>();
			}
		}
	}
}