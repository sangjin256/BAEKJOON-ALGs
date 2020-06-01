using System;
using System.IO;
using System.Collections.Generic;
public class ez 
{
	static List<(int,int,int)> edges = new List<(int,int,int)>();
	//MaxValue에서 덧셈을 하면 오버플로우가 일어나므로 일정량을 빼준다.
	//간선의 가중치를 전부 알고시작하면 가중치를 더한 값으로 해도 될 듯하다.
	static int[] distance;
	public static void Main(string[] args) {
		InsertEdge(1,2,2);
		InsertEdge(1,3,3);
		InsertEdge(1,4,7);
		InsertEdge(2,4,3);
		InsertEdge(2,5,5);
		InsertEdge(3,4,1);
		InsertEdge(4,5,2);
		
		distance = new int[10];
        distance_m = new int[10];
		
		for(int i = 1; i <= 5; i++){
            //최단경로찾기 거리 초기화
			distance[i] = int.MaxValue-1000;
            //음수사이클찾기 거리 초기화
            distance_m[i] = int.MaxValue-1000;
		}
		
		//시작노드 1을 입력해주고 시작
		BellmanFord(1);
		BellmanFord_FindMinus(1);
		
		for(int i = 0; i < distance.Length; i++){
			if(distance[i] != 0){
				Console.WriteLine(i + " : " + distance[i]);
			}
		}
		Console.WriteLine(str);
	}
	
	//양방향 그래프일때 간선으로 연결된 노드 2개를 넣으면 양 방향으로 추가되게 하는 함수
	public static void InsertEdge(int a, int b, int w){
		edges.Add((a,b,w));
		edges.Add((b,a,w));
	}
	
	public static void BellmanFord(int x){
		distance[x] = 0;
		//마지막 노드는 수행해봤자 돌아가는것 뿐이므로 n-1개만 수행한다.
		for(int i = 1; i <= 4; i++){
			int count = 0;
			foreach(var e in edges){
				(int a,int b,int w) p = e;
				int temp = Math.Min(distance[p.b], distance[p.a]+p.w);
				if(distance[p.b] == temp){
					count++;
				}
				else distance[p.b] = temp;
			}
			if(count == edges.Count){
				break;
			}
		}
	}

    static string str = "음수 사이클 없음";
    static int[] distance_m;
    //음수사이클 찾는 함수
    public static void BellmanFord_FindMinus(int x){
		distance[x] = 0;
		//n번의 라운드로 진행하고 마지막 라운드에서도 거리가 줄어드면 음수 사이클 존재
		for(int i = 1; i <= 5; i++){
			foreach(var e in edges){
				(int a,int b,int w) p = e;
				int temp = Math.Min(distance_m[p.b], distance_m[p.a]+p.w);
				if(distance_m[p.b] > temp){
                    if(i == 5){
                        str = "음수 사이클 존재";                        
                    }
				}
                distance_m[p.b] = temp;
			}
		}
    }
}