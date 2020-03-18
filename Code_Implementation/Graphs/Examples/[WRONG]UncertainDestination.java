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
    static int gToh = 0;
    static int g, h;
    static ArrayList<ArrayList<Pair>> adj;
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int T = sc.nextInt();
        for(int cases = 0; cases < T; cases++){
            int n = sc.nextInt(), m = sc.nextInt(), t = sc.nextInt();
            int s = sc.nextInt();
            g = sc.nextInt(); h = sc.nextInt();
            Initialize(n);
            for(int i = 0; i < m; i++){
                Add(sc.nextInt(), sc.nextInt(), sc.nextInt());
            }
            List<Integer> sDistance = Dijkstra(s, n);
            List<Integer> hDistance = Dijkstra(h, n);
            List<Integer> gDistance = Dijkstra(g, n);
            PriorityQueue<Integer> results = new PriorityQueue<Integer>();
            for(int i = 0; i < t; i++){
                int d = sc.nextInt();
                if(sDistance.get(d) == 1001) continue;
                //h->g와 g->h 사이의 간선이 h->g와 g->h의 최단거리라는 보장이 없으므로 간선의 길이를 따로 나타낸다.
                if(sDistance.get(d) == sDistance.get(h)+ gToh + gDistance.get(d) || sDistance.get(d) == sDistance.get(g) + gToh+ hDistance.get(d)) results.add(d);
            }

            for(Integer i : results){
                System.out.print(i + " ");
            }
            System.out.println();
        }
        sc.close();
    }

    public static List<Integer> Dijkstra(int s, int n){
        Integer[] distance = new Integer[n+1];
        boolean[] processed = new boolean[n+1];
        PriorityQueue<Pair> q = new PriorityQueue<Pair>();
        for(int i = 1; i < distance.length; i++){
            distance[i] = 1001;
        }
        distance[s] = 0;
        q.add(new Pair(s,0));
        while(!q.isEmpty()){
            int a = q.poll().b;
            if(processed[a]) continue;
            processed[a] = true;
            for(Pair p : adj.get(a)){
                if(distance[a] + p.w < distance[p.b]){
                    distance[p.b] = distance[a]+p.w;
                    q.add(new Pair(p.b, distance[p.b]));
                }
            }
        }
        return Arrays.asList(distance);
    }

    public static void Add(int a, int b, int w){
        if(a == g && b == h || a == h && b == g) gToh = w;
        adj.get(a).add(new Pair(b, w));
        adj.get(b).add(new Pair(a, w));
    }

    public static void Initialize(int n){
        adj = new ArrayList<ArrayList<Pair>>();
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Pair>());
        }
    }
}