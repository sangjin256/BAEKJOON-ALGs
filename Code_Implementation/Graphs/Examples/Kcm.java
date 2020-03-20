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
    static ArrayList<PriorityQueue<Third>> point;
    static ArrayList<ArrayList<Third>> reverse;
    static int[] maxMoney;
    static int[] distance;
    static boolean[] processed;
    public static void Initialize(int n){
        processed = new boolean[n+1];
        adj = new ArrayList<ArrayList<Third>>();
        point = new ArrayList<PriorityQueue<Third>>();
        reverse = new ArrayList<ArrayList<Third>>();
        distance = new int[n+1];
        maxMoney = new int[n+1];
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Third>());
            point.add(new PriorityQueue<Third>());
            reverse.add(new ArrayList<Third>());
        }
    }

    public static void Add(int a, int b, int m, int w){
        adj.get(a).add(new Third(b,w,m));
        reverse.get(b).add(new Third(a,w,m));
    }

    public static void LimitCal(){
        for(int i = 1; i <adj.size(); i++){
            for(Third t : adj.get(i)){
                if(maxMoney[i] + t.m <= maxMoney[t.b]){
                    point.get(i).add(t);
                }
            }
        }
    }

    public static void SetMaxMoney(int maxM){
        boolean[] visited = new boolean[reverse.size()];
        maxMoney[reverse.size()-1] = maxM;
        SMM(reverse.size()-1,visited);
    }

    public static void SMM(int a, boolean[] visited){
        if(visited[a]) return;
        visited[a] = true;
        for(Third t : reverse.get(a)){
            maxMoney[t.b] = Math.max(maxMoney[t.b], maxMoney[a] - t.m);
            SMM(t.b,visited);
        }
    }

    public static void Dfs(int a){
        if(processed[a]) return;
        processed[a] = true;
        for(Third t : point.get(a)){
            Dfs(t.b);
        }
    }

    public static void Dijkstra(int s, int n){
        for(int i = 1; i <= n; i++){
            distance[i] = 10000*1000+3;
        }
        distance[s] = 0;
        PriorityQueue<Third> q = new PriorityQueue<>();
        q.add(new Third(s,0,0));
        while(!q.isEmpty()){
            int a = q.poll().b;
            for(Third t : point.get(a)){
                if(maxMoney[t.b] >= t.m + maxMoney[a]){
                    distance[t.b] = distance[a]+t.w;
                    if(t.b == n) break;
                    q.add(new Third(t.b, t.m + maxMoney[a], distance[t.b]));
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
                Add(sc.nextInt(), sc.nextInt(), sc.nextInt(), sc.nextInt());
            }
            SetMaxMoney(m);
            LimitCal();
            Dfs(1);
            if(processed[n] == false){
                System.out.println("Poor KCM");
                return;
            }
            Dijkstra(1, n);
            // for(int i : maxMoney){
            //     System.out.println(i);
            // }
            // System.out.println();
            // for(int i = 1; i <= n; i++){
            //     for(Third t : point.get(i)){
            //         System.out.println(i + " : " + t.b + " " + t.m + " " + t.w);
            //     }
            // }
            System.out.println(distance[n]);
        }
        sc.close();
    }
}