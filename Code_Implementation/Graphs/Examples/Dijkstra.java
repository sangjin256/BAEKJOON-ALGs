/*
#1753

 방향그래프가 주어지면 주어진 시작점에서 다른 모든 정점으로의 최단 경로를 구하는 프로그램을 작성하시오.
 
 단, 모든 간선의 가중치는 10 이하의 자연수이다.
*/
import java.io.*;
import java.util.*;
public class Dijkstra {
	class Pair implements Comparable<Pair> {
		public int index;
		public int distance;
		
		Pair(int index, int distance){
			this.index = index;
			this.distance = distance;
		}
		
		public int compareTo(Pair p) {
			if(distance > p.distance) return 1;
			else if(distance < p.distance) return -1;
			else return 0;
		}
	}
	//다익스트라에서 사용할 우선순위 큐
	static PriorityQueue<Pair> q = new PriorityQueue<Pair>();
	
	//인접 리스트
	static ArrayList<ArrayList<Pair>> adj;
	
	//거리 담는 배열
	static int[] distance;
	
	public static void main(String[] args) {
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
		try {
			int[] arr = Arrays.stream(br.readLine().split(" ")).mapToInt(Integer::parseInt).toArray();
			int start = Integer.parseInt(br.readLine());
			AdjInit(arr[0]);
			for(int i = 0; i < arr[1]; i++) {
				int[] a = Arrays.stream(br.readLine().split(" ")).mapToInt(Integer::parseInt).toArray();
				Add(a[0],a[1],a[2]);
			}
			//INF(무한대)가 따로 없으므로 적당한 큰 수를 넣는다.
			for(int i = 1; i <= arr[0]; i++) {
				distance[i] = 2000000;
			}
			
			Dijkstra_(start);
			
			for(int i = 1; i <= arr[0]; i++) {
				if(distance[i] == 2000000) System.out.println("INF");
				else System.out.println(distance[i]);
			}
			
		} catch(Exception e) {e.printStackTrace();}
	}
	
	public static void Dijkstra_(int start) {
		//시작간선까지 가는 간선의 길이가 0이라는 의미
		distance[start] = 0;
		q.add(new Dijkstra().new Pair(start,0));
		
		while(!q.isEmpty()) {
			int a = q.poll().index;
			//두 정점 사이에 여러개의 간선이 존재할 수 있으므로 방문처리 x!!
			//if(processed[a]) continue;
			//processed[a] = true;
			for(Pair p : adj.get(a)) {
				int b = p.index; int w = p.distance;
				if(distance[a] + w < distance[b]) {
					distance[b] = distance[a] + w;
					q.offer(new Dijkstra().new Pair(b, distance[b]));
				}
			}
		}
	}
	
	public static void Add(int a, int b, int w) {
		adj.get(a).add(new Dijkstra().new Pair(b, w));
	}
	
	public static void AdjInit(int n) {
		adj = new ArrayList<ArrayList<Pair>>();
		distance = new int[n+1];
		for(int i = 0; i < n+1; i++) {
			adj.add(new ArrayList<Pair>());
		}
	}
}