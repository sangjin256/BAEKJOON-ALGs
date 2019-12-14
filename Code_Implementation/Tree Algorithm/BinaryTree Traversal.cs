//트리 순회 및 동적 계획법을 사용한 각 노드 s에 대한 서브트리의 노드 수 계산하는 함수
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static List<int>[] adj;
	public static void Main(string[] args) {
        adj = new List<int>[9];
        for(int i = 0; i < adj.Length; i++){
            adj[i] = new List<int>();
        }
        adj[1].Add(2);
        adj[1].Add(3);
        adj[1].Add(4);
        adj[2].Add(5);
        adj[6].Add(8);
        adj[2].Add(6);
        adj[4].Add(7);
    }
}