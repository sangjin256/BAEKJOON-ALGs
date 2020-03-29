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
        else tree = new long[2*(int)Math.pow(2, (int)Math.sqrt(n)+1)];
        arrayN = n;
        n = tree.length - arrayN;
        for(int i = 1; i <= n; i++){
            Change(i, sc.nextInt());
        }
        
        //수의 변경이 m번 일어나고 구간곱이 k번 일어나므로 while문으로 제대로된 숫자가 들어올때만
        //count해준다.
        int count = 0;
        while(count < m+k){
            int a = sc.nextInt(), b = sc.nextInt(), c = sc.nextInt();
            if(a == 1){
                if(b > 0 && b <= arrayN){
                    Change(b, c);
                    count++;
                } 
            }
            if(a == 2){
                if(b > 0 && b <= arrayN && c > 0 && c <= arrayN){
                    System.out.println(Multiply(b, c));
                }
            }
        }
        sc.close();
    }

    public static void Change(int k, int x){
        k += n-1;
        tree[k] = x;
        for(k/=2; k >= 1; k/=2){
            tree[k] = tree[k*2]*tree[k*2+1] % 1000000007;
        }
    }

    public static int Multiply(int a, int b){
        a += n-1;
        b += n-1;
        int s = 1;
        while(a <= b){
            if(a % 2 == 1) s*=tree[a++] % 1000000007;
            if(b % 2 == 0) s*=tree[b--] % 1000000007;
            a/=2; b/=2;
        }

        return s;
    }
}