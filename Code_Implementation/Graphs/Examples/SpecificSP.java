// # 1504

// 방향성이 없는 그래프가 주어진다. 세준이는 1번 정점에서 N번 정점으로 최단 거리로 이동하려고 한다.

// 또한 세준이는 두 가지 조건을 만족하면서 이동하는 특정한 최단 경로를 구하고 싶은데, 그것은 바로

// 임의로 주어진 두 정점은 반드시 통과해야 한다는 것이다. 세준이는 한번 이동했던 정점은 물론, 한번

// 이동했던 간선도 다시 이동할 수 있다. 하지만 반드시 최단 경로로 이동해야 한다는 사실에 주의하라. 1번 정점에서 N번 정점으로 이동할 때, 주어진 두 정점을 반드시 거치면서 최단 경로로 이동하는 프로그램을 작성하시오.
import java.util.*;
class SpecificSP{
    class Pair implements Comparable<Pair>{
        public int b, w;
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

    static PriorityQueue<Pair> q = new PriorityQueue<Pair>();
    static ArrayList<ArrayList<Pair>> adj;
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int e = sc.nextInt();
        Initialize(n);
        for(int i = 0; i < e; i++){
            Add(sc.nextInt(), sc.nextInt(), sc.nextInt());
        }

        int start = sc.nextInt();
        int end = sc.nextInt();
        // 1, start에서 시작, end에서 시작하는 다익스트라 알고리즘을 모두 수행한수 가장 짧은 거리 구해야됨
        List<Integer> result = Dijkstra(1, n);
        List<Integer> temp1 = Dijkstra(start, n);
        List<Integer> temp2 = Dijkstra(end, n);

        // 1 -> start -> end -> n
        // 1 -> end -> start -> n 중에 가장 작은숫자
        int answer = Math.min(result.get(start) + temp1.get(end) + temp2.get(n), result.get(end) + temp2.get(start) + temp1.get(n));
        if(answer >= 1001 || answer <= 0){
            System.out.println(-1);
        }
        else System.out.println(answer);
        
        sc.close();
    }

    public static List<Integer> Dijkstra(int s, int n){
        boolean[] processed = new boolean[n+1];
        Integer[] distance = new Integer[n+1];
        List<Integer> v = new ArrayList<Integer>();

        for(int i = 1; i <= n; i++){
            distance[i] = 1001;
        }

        distance[s] = 0;
        q.add(new SpecificSP().new Pair(s, 0));
        while(!q.isEmpty()){
            int a = q.poll().b;
            if(processed[a]) continue;
            processed[a] = true;
            for(Pair p : adj.get(a)){
                if(distance[a] + p.w < distance[p.b]){
                    distance[p.b] = distance[a] + p.w;
                    q.add(new SpecificSP().new Pair(p.b, distance[p.b]));
                }
            }
        }
        v = Arrays.asList(distance);
        return v;
    }

    public static void Initialize(int n){
        adj = new ArrayList<ArrayList<Pair>>();
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Pair>());
        }
    }

    public static void Add(int a, int b, int w){
        adj.get(a).add(new SpecificSP().new Pair(b,w));
        adj.get(b).add(new SpecificSP().new Pair(a,w));
    }
}