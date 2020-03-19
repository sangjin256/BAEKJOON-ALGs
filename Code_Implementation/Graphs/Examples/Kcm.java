import java.util.*;
class Third implements Comparable<Third>{
    int b, w, m;
    Third(int b, int w, int m){
        this.b = b;
        this.w = w;
        this.m = m;
    }
    public int compareTo(Third t){
        if(w > t.w) return 1;
        else if(w < t.w) return -1;
        else return 0;
    }
}

class Kcm{
    static ArrayList<ArrayList<Third>> adj;
    static int[] distance;
    static int[] money;
    public static void Initialize(int n){
        adj = new ArrayList<ArrayList<Third>>();
        distance = new int[n+1];
        money = new int[n+1];
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Third>());
        }
    }

    public static void Dijkstra(int s, int n, int maxM){
        boolean[] processed = new boolean[n+1];
        PriorityQueue<Third> q = new PriorityQueue<>();
        for(int i = 1; i <= n; i++){
            distance[i] = 10000*1000+1;
        }
        distance[s] = 0;
        q.add(new Third(s,0,0));
        while(!q.isEmpty()){
            int a = q.poll().b;
            if(processed[a]) continue;
            processed[a] = true;
            for(Third t : adj.get(a)){
                if(distance[a]+t.w < distance[t.b]){
                    if(money[a]+t.m < maxM){
                        distance[t.b] = distance[a]+t.w;
                        money[t.b] = money[a]+t.m;
                        q.add(new Third(t.b, distance[t.b], money[t.b]));
                    }
                }
            }
        }
    }

    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int cases = sc.nextInt();
        for(int c = 0; c < cases; c++){
            int n = sc.nextInt(), m = sc.nextInt(), k = sc.nextInt();
            Initialize(n);
            for(int i = 0; i < k; i++){
                adj.get(sc.nextInt()).add(new Third(sc.nextInt(), sc.nextInt(), sc.nextInt()));
            }
            Dijkstra(1, n, m);
            if(distance[n] == 10000*1000+1) System.out.println("Poor KCM");
            else System.out.println(distance[n]);
        }
        sc.close();
    }
}