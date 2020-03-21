// # 9370

// (취익)B100 요원, 요란한 옷차림을 한 서커스 예술가 한 쌍이 한 도시의 거리들을 이동하고 있다. 너의 임무는 그들이 어디로 가고 있는지 알아내는 것이다.

// 우리가 알아낸 것은 그들이 s지점에서 출발했다는 것, 그리고 목적지 후보들 중 하나가 그들의 목적지라는 것이다. 그들이 급한 상황이기 때문에 목적지까지

// 우회하지 않고 최단거리로 갈 것이라 확신한다. 이상이다. (취익)

// 어휴! (요란한 옷차림을 했을지도 모를) 듀오가 어디에도 보이지 않는다. 다행히도 당신은 후각이 개만큼 뛰어나다. 이 후각으로 그들이 g와 h 교차로

// 사이에 있는 도로를 지나갔다는 것을 알아냈다. 이 듀오는 대체 어디로 가고 있는 것일까?


// h<->g도로의 가중치를 홀수로 하고 나머지 가중치를 짝수로 만들면 1번의 다익스트라로 풀 수 있다. 덧셈에서 홀수가 한번있으면 무조건 홀수가 되므로 최단거리가
// 홀수가 나오면 h<->g도로를 지난 것이다.
import java.util.*;
class Pair implements Comparable<Pair>{
    int b, w;
    Pair(int b, int w){
        this.b = b;
        this.w = w;
    }

    public int compareTo(Pair p){
        if(w > p.w) return 1;
        else if(w < p.w) return -1;
        else return 0;
    }
}
public class UncertainDestination{
    static ArrayList<ArrayList<Pair>> adj;
    static final int INF = 1000*50000+2;
    public static void Initialize(int n){
        adj = new ArrayList<ArrayList<Pair>>();
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Pair>());
        }
    }

    public static void Add(int a, int b, int w, int g, int h){
        if((a==g&&b==h) || (a==h&&b==g)){
            adj.get(a).add(new Pair(b, w*2-1));
            adj.get(b).add(new Pair(a, w*2-1));
        }
        else {
            adj.get(a).add(new Pair(b, w*2));
            adj.get(b).add(new Pair(a, w*2));
        }
    }

    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int cases = sc.nextInt();
        for(int c = 0; c < cases; c++){
            int n = sc.nextInt(), m = sc.nextInt(), t = sc.nextInt();
            int s = sc.nextInt(), g = sc.nextInt(), h = sc.nextInt();
            Initialize(n);
            for(int i = 0; i < m; i++){
                Add(sc.nextInt(), sc.nextInt(), sc.nextInt(),g ,h);
            }
            int[] distance = Dijkstra(s, n);
            ArrayList<Integer> results = new ArrayList<Integer>();
            for(int i = 0; i < t; i++){
                Integer d = sc.nextInt();
                if(distance[d]%2 == 1) results.add(d);
            }

            Collections.sort(results);
            for(Integer i : results){
                System.out.print(i + " ");
            }
            System.out.println();
        }
        sc.close();
    }

    public static int[] Dijkstra(int s, int n){
        int[] distance = new int[n+1];
        boolean[] processed = new boolean[n+1];
        PriorityQueue<Pair> q = new PriorityQueue<>();
        for(int i = 0; i <= n; i++){
            //h<->g도로를 지나지 않으면 전부 짝수가 되어야 하므로 시작점과 연결되는 말든
            //짝수로 남게 한다.
            distance[i] = INF;
        }
        distance[s] = 0;
        q.add(new Pair(s,0));
        while(!q.isEmpty()){
            int a = q.poll().b;
            if(processed[a]) continue;
            processed[a] = true;
            for(Pair p : adj.get(a)){
                if(distance[p.b] > distance[a]+p.w){
                    distance[p.b] = distance[a]+p.w;
                    q.add(new Pair(p.b, distance[p.b]));
                }
            }
        }
        return distance;
    }
}