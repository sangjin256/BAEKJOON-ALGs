/*
# 11659

수 N개가 주어졌을 때, i번째 수부터 j번째 수까지 합을 구하는 프로그램을 작성하시오.

입력
첫째 줄에 수의 개수 N (1 ≤ N ≤ 100,000), 합을 구해야 하는 횟수 M (1 ≤ M ≤ 100,000)

이 주어진다. 둘째 줄에는 N개의 수가 주어진다. 수는 1,000보다 작거나 같은 자연수이다.

셋째 줄부터 M개의 줄에는 합을 구해야 하는 구간 i와 j가 주어진다.
*/
import java.util.*;
class Range_Sum1{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int m = sc.nextInt();
        int[] sum = new int[n];
        int[] a = new int[n];
        for(int i = 0; i <n; i++){
            a[i] = sc.nextInt();
        }
        sum[0] = a[0];
        for(int i = 1; i < n; i++){
            sum[i] = sum[i-1] + a[i];
        }

        for(int i = 0; i < m; i++){
            int a = sc.nextInt(), b = sc.nextInt();
            if(a == 1) System.out.println(sum[b-1]);
            else System.out.println(sum[b-1] - sum[a-2]);
        }
    }
}