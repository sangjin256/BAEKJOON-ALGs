/*
# 11505

어떤 N개의 수가 주어져 있다. 그런데 중간에 수의 변경이 빈번히 일어나고 그 중간에

어떤 부분의 곱을 구하려 한다. 만약에 1, 2, 3, 4, 5 라는 수가 있고, 3번째 수를

6으로 바꾸고 2번째부터 5번째까지 곱을 구하라고 한다면 240을 출력하면 되는 것이다.

그리고 그 상태에서 다섯 번째 수를 2로 바꾸고 3번째부터 5번째까지 곱을 구하라고

한다면 48이 될 것이다.
*/
import java.util.*;
public class Range_Multiply{
    static long[] tree;
    static int n;
    static int arrayN;
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        n = sc.nextInt();
        int m = sc.nextInt(), k = sc.nextInt();
        if((n&(n-1)) == 0) tree = new long[2*n];
        else tree = new long[1<<((int)Math.ceil(Math.log10(n)/Math.log10(2))+1)];
        arrayN = n;
        n = tree.length/2;
        Arrays.fill(tree, 1);
        for(int i = 0; i < arrayN; i++){
            Change(i, 1, sc.nextInt(), 0, n-1);
        }

        for(int i = 0; i < m+k; i++){
            int a = sc.nextInt(), b = sc.nextInt(), c = sc.nextInt();
            if(a == 1){
                Change(b-1,1,c,0,n-1);
            }
            if(a == 2){
                System.out.println(Multiply(b-1, c-1, 1, 0,n-1) % 1000000007);
            }
        }
        sc.close();
    }

    public static long Change(int pos, int k, int v, int x, int y){
        if(y < pos || pos < x) return tree[k] % 1000000007;
        if(x == y) return tree[k] = v;
        int d = (x+y) / 2;
        return tree[k] = ((Change(pos,k*2,v,x,d) % 1000000007) * (Change(pos,k*2+1,v,d+1,y) % 1000000007)) % 1000000007;
    }

    public static long Multiply(int a, int b, int k, int x, int y){
        if(b < x || a > y) return 1;
        if(a <= x && y <= b) return tree[k];
        int d = (x + y) / 2;
        return ((Multiply(a, b, k*2, x, d) % 1000000007) * (Multiply(a, b, k*2+1, d+1, y) % 1000000007)) % 1000000007; 
    }
}