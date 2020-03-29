// # 2357

// N(1 ≤ N ≤ 100,000)개의 정수들이 있을 때, a번째 정수부터 b번째 정수까지 중에서 제일 작은 정수, 또는 제일 큰 정수를 찾는 것은 어려운 일이 아니다.

// 하지만 이와 같은 a, b의 쌍이 M(1 ≤ M ≤ 100,000)개 주어졌을 때는 어려운 문제가 된다. 이 문제를 해결해 보자.

// 여기서 a번째라는 것은 입력되는 순서로 a번째라는 이야기이다. 예를 들어 a=1, b=3이라면 입력된 순서대로 1번, 2번,

// 3번 정수 중에서 최소, 최댓값을 찾아야 한다. 각각의 정수들은 1이상 1,000,000,000이하의 값을 갖는다.
import java.util.*;
public class MinMax{
    static int[] minTree;
    static int[] maxTree;
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt(), m = sc.nextInt();
        minTree = new int[1<<((int)Math.ceil(Math.log10(n) / Math.log10(2))+1)];
        maxTree = new int[1<<((int)Math.ceil(Math.log10(n) / Math.log10(2))+1)];
        for(int i = 0; i < n; i++){
            Add(i, sc.nextInt());
        }
        for(int i = 0; i < m; i++){
            int a = sc.nextInt(), b = sc.nextInt();
            System.out.println(Min(a,b) + " " + Max(a, b));
        }
        sc.close();
    }

    public static void Add(int k, int x){
        k += minTree.length/2;
        minTree[k] = x;
        maxTree[k] = x;
        for(k /= 2; k >= 1; k /= 2){
            minTree[k] = Math.min(minTree[k*2], minTree[k*2+1]);
            maxTree[k] = Math.max(maxTree[k*2], maxTree[k*2+1]);
        }
    }

    public static long Min(int a, int b){
        a += minTree.length/2 - 1;
        b += minTree.length/2 - 1;
        long r = 1000000001;
        while(a <= b){
            if(a % 2 == 1 && minTree[a] != 0) r = Math.min(r, minTree[a++]);
            if(b % 2 == 0 && minTree[a] != 0) r = Math.min(r, minTree[b--]);
            a /= 2; b /= 2;
        }
        return r;
    }

    public static int Max(int a, int b){
        a += maxTree.length/2 - 1;
        b += maxTree.length/2 - 1;
        int r = 0;
        while(a <= b){
            if(a % 2 == 1) r = Math.max(r, maxTree[a++]);
            if(b % 2 == 0) r = Math.max(r, maxTree[b--]);
            a /= 2; b /= 2;
        }
        return r;
    }
}