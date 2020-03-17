import java.util.*;
class UncertainDestination{
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

    static PriorityQueue<Pair> p = new PriorityQueue<Pair>();
    static ArrayList<ArrayList<Pair>> adj;
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int T = sc.nextInt();
        for(int cases = 0; cases < T; cases++){
            int n = sc.nextInt(), m = sc.nextInt(), t = sc.nextInt();
            int start = sc.nextInt(), g = sc.nextInt(), h = sc.nextInt();
            int[] dests = new int[t];
            Initialize(n);
            for(int i = 0; i < m; i++){
                Add(sc.nextInt(), sc.nextInt(), sc.nextInt());
            }
            for(int i = 0; i < t; i++){
                dests[i] = sc.nextInt();
            }



            
        }
    }

    public static void Add(int a, int b, int w){
        adj.get(a).add(new UncertainDestination().new Pair(b, w));
        adj.get(b).add(new UncertainDestination().new Pair(a, w));
    }

    public static void Initialize(int n){
        adj = new ArrayList<ArrayList<Pair>>();
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Pair>());
        }
    }
}