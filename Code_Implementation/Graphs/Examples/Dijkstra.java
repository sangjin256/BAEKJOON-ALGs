/*
#1753

 ����׷����� �־����� �־��� ���������� �ٸ� ��� ���������� �ִ� ��θ� ���ϴ� ���α׷��� �ۼ��Ͻÿ�.
 
 ��, ��� ������ ����ġ�� 10 ������ �ڿ����̴�.
 */
import java.io.*;
import java.util.*;
public class Dijkstra {
	//���ؿ� �����ϱ� ���� ����Ŭ������ �ۼ�. �ڹٴ� �� ���Ͽ� 2���� Ŭ������ �� �� ����.
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
	//���ͽ�Ʈ�󿡼� ����� �켱���� ť
	static PriorityQueue<Pair> q = new PriorityQueue<Pair>();
	
	//���� ����Ʈ
	static ArrayList<ArrayList<Pair>> adj;
	
	//�Ÿ� ��� �迭
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
			//INF(���Ѵ�)�� ���� �����Ƿ� ������ ū ���� �ִ´�.
			for(int i = 1; i <= arr[0]; i++) {
				distance[i] = 2000000;
			}
			
			Dijkstra(start);
			
			for(int i = 1; i <= arr[0]; i++) {
				if(distance[i] == 2000000) System.out.println("INF");
				else System.out.println(distance[i]);
			}
			
		} catch(Exception e) {e.printStackTrace();}
	}
	
	public static void Dijkstra(int start) {
		//���۰������� ���� ������ ���̰� 0�̶�� �ǹ�
		distance[start] = 0;
		q.add(new Dijkstra().new Pair(start,0));
		
		while(!q.isEmpty()) {
			int a = q.poll().index;
			//�� ���� ���̿� �������� ������ ������ �� �����Ƿ� �湮ó�� x!!
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