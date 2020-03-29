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
    static int[] tree;
    static int n;
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        n = sc.nextInt();
        int m = sc.nextInt(), k = sc.nextInt();
        if((n&(n-1)) == 0) tree = new int[2*n];
        else tree = new int[Math.]
        for(int i = 0; i < n; i++){

        }
    }
}