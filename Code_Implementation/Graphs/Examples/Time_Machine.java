/*
# 11657

N개의 도시가 있다. 그리고 한 도시에서 출발하여 다른 도시에 도착하는 버스가 M개 있다.

각 버스는 A, B, C로 나타낼 수 있는데, A는 시작도시, B는 도착도시, C는 버스를 타고

이동하는데 걸리는 시간이다. 시간 C가 양수가 아닌 경우가 있다. C = 0인 경우는 순간 이동을

하는 경우, C < 0인 경우는 타임머신으로 시간을 되돌아가는 경우이다.

1번 도시에서 출발해서 나머지 도시로 가는 가장 빠른 시간을 구하는 프로그램을 작성하시오.

만약 1번 도시에서 출발해 어떤 도시로 가는 과정에서 시간을 무한히 오래 전으로 되돌릴 수

있다면 첫째 줄에 -1을 출력한다. 그렇지 않다면 N-1개 줄에 걸쳐 각 줄에 1번 도시에서

출발해 2번 도시, 3번 도시, ..., N번 도시로 가는 가장 빠른 시간을 순서대로 출력한다.

만약 해당 도시로 가는 경로가 없다면 대신 -1을 출력한다.
*/

//distance의 최대값을 잘못 설정해서 계속 틀렸다. distance의 최대값은 (가중치의 최대값*모든 간선의 개수)보다 커야됨을 인지하자
import java.util.*;
class Triple{
    int a, b, w;
    Triple(int a, int b, int w){
        this.a = a;
        this.b = b;
        this.w = w;
    }
}

class Time_Machine{
    static int[] distance;
    static boolean[] canVisit;
    static boolean[] processed;
    static ArrayList<Triple> edges = new ArrayList<Triple>();
    static ArrayList<ArrayList<Integer>> adj = new ArrayList<ArrayList<Integer>>();
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int m = sc.nextInt();
        Initialize(n);
        for(int i = 0; i < m; i++){
            Add(sc.nextInt(),sc.nextInt(),sc.nextInt());
        }
        boolean noMCycle = BellmanFord(1, n);
        if(!noMCycle){
            System.out.println(-1);
            sc.close();
            return;
        }
        for(int i = 2; i < distance.length; i++){
            if(canVisit[i]) System.out.println(distance[i]);
            else System.out.println(-1);
        }
        sc.close();
    }

    public static void Add(int a, int b, int w){
        edges.add(new Triple(a, b, w));
        adj.get(a).add(b);
    }
    
    public static void Dfs(int a){
        if(processed[a]) return;
        processed[a] = true;
        canVisit[a] = true;
        for(Integer p : adj.get(a)){
            Dfs(p);
        }
    }
    
    public static boolean BellmanFord(int s, int n){
        for(int i = 1; i <= n; i++){
            distance[i] = 6000*10000+1;
        }
        Dfs(1);
        distance[s] = 0;
        for(int i = 1; i <= n; i++){
            int count = 0;
            for(Triple e : edges){
                int a = e.a; int b = e.b; int w = e.w;
                if(distance[b] > distance[a]+w){
                    distance[b] = distance[a]+w;
                    count++;
                    if(i == n){
                        if(canVisit[a] && canVisit[b]) return false;
                    }
                }
            }
            //한 라운드동안 거리가 안줄어들면 끝냄
            if(count == 0) return true;
        }
        return true;
    }
    
    public static void Initialize(int n){
        processed = new boolean[n+1];
        distance = new int[n+1];
        canVisit = new boolean[n+1];
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Integer>());
        }
    }
}
