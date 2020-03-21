// # 10217

// 각고의 노력 끝에 찬민이는 2014 Google Code Jam World Finals에 진출하게 되었다. 구글에서 온 초대장을 받고 기뻐했던 것도 잠시, 찬찬히 읽어보던

// 찬민이는 중요한 사실을 알아차렸다. 최근의 대세에 힘입어 구글 역시 대기업답게 비용 감축에 열을 내고 있었던 것이다.

// 초대장 내용에 의하면 구글은 찬민에게 최대 M원까지의 비용만을 여행비로써 부담해주겠다고 한다. 인천에서 LA행 직항 한 번 끊어주는게

// 그렇게 힘드냐고 따지고도 싶었지만, 다가올 결승 대회를 생각하면 대회 외적인 곳에 마음을 쓰고 싶지 않은 것 또한 사실이었다.

// 그래서 찬민은 인천에서 LA까지 M원 이하로 사용하면서 도착할 수 있는 가장 빠른 길을 차선책으로 택하기로 하였다.

// 각 공항들간 티켓가격과 이동시간이 주어질 때, 찬민이 인천에서 LA로 갈 수 있는 가장 빠른 길을 찾아 찬민의 대회 참가를 도와주자.


// 동적 계획법과 다익스트라를 둘 다 사용해야 한다.
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
    static final int INF = 10000*1000+1;
    // 인접 리스트
    static ArrayList<ArrayList<Third>> adj;

    // 동적 계획법을 사용하기 위한 2차원 배열
    // dp[x,y]는 x공항에서 y원을 쓰고 갔을때의 최단거리가 들어간다.
    static int[][] dp;
    public static void init(int n, int m){
        dp = new int[n+1][m+1];
        adj = new ArrayList<ArrayList<Third>>();
        for(int i = 0; i <= n; i++){
            adj.add(new ArrayList<Third>());
        }
    }

    public static void Add(int a, int b, int m, int w){
        adj.get(a).add(new Third(b,w,m));
    }

    public static void Dijkstra(int s, int n, int m){
        for(int[] row : dp){
            Arrays.fill(row, INF);
        }

        dp[s][0] = 0;
        PriorityQueue<Third> q = new PriorityQueue<>();
        q.add(new Third(s, 0, 0));

        // 가장 빠른 경로가 실패하면 다시 돌아와서 다른 돈으로 계산해야 하므로
        // processed배열로 노드를 방문체크하면 안된다.
        while(!q.isEmpty()){
            Third tmp = q.poll();
            for(Third t : adj.get(tmp.b)){
                if(tmp.m + t.m > m) continue;
                if(dp[t.b][tmp.m + t.m] > dp[tmp.b][tmp.m] + t.w){
                    dp[t.b][tmp.m + t.m] = dp[tmp.b][tmp.m] + t.w;
                    q.add(new Third(t.b, dp[t.b][tmp.m + t.m], tmp.m + t.m));
                }
            }
        }
    }

    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int cases = sc.nextInt();
        for(int c = 0; c < cases; c++){
            int n = sc.nextInt(), m = sc.nextInt(), k = sc.nextInt();
            init(n, m);
            for(int i = 0; i < k; i++){
                Add(sc.nextInt(), sc.nextInt(), sc.nextInt(), sc.nextInt());
            }
            Dijkstra(1, n, m);
            int mn = INF;
            for(int i = 0; i <= m; i++){
                mn = Math.min(mn, dp[n][i]);
            }

            if(mn == INF) System.out.println("Poor KCM");
            else System.out.println(mn);
        }
        sc.close();
    }
}