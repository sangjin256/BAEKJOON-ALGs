//라스베가스 알고리즘은 항상 정답을 내는 알고리즘이지만 답을 구하는 데 걸리는
//시간이 실행할 때마다 달라짐
//배열의 k번째 순서 통계랑(Order Statistic)은 배열을 오름차순으로 정렬했을 때
//위치 k에 있는 원소.
//과연 이를 구하기 위해 꼭 배열을 정렬할 필요가 있을까? ->라스베가스 알고리즘 사용
//O(nlogn)에서 최소 O(n)까지 줄일 수 있음(최대 O(n^2)가 됨)
//배열에서 임의의 원소 x를 선택한 뒤 x보다 작은 원소는 배열의 왼쪽으로, 나머지
//원소는 배열의 오른쪽으로 옮긴다. 이때 왼쪽 부분의 원소 개수를 a로, 오른쪽 개수를 b로
//나타낼 때 a = k이면 x가 k번째 순서 통계량이 됨. 그렇지 않은 경우 a > k이면
//왼쪽 부분에서 재귀적으로 k번째 순서 통계량을 찾고 a < k이면 오른쪽 부분에서 r번째(r = k-a-1) 순서
//통계량을 찾는다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] arr;
    static int result = 0;
	public static void Main(string[] args) {
        arr = new int[]{3,5,2,7,4,8,9,1,6};
        OrderStatistic(0, arr.Length-1, 6);
        Console.WriteLine(result);
    }

    //퀵소트와 비슷한 방식으로 풀면 된다.
    public static void OrderStatistic(int left, int right, int k){
        int pl = left;
        int pr = right;
        int x = arr[(left + right)/2];
        do{
            while(arr[pl] < x) pl++;
            while(arr[pr] > x) pr--;
            if(pl <= pr) Swap(pl++, pr--);
        } while(pl <= pr);
        int pos = Array.IndexOf(arr, x);
        if(pos == k){
        	result = x;
        	return;
        }
        else if(pos > k) OrderStatistic(left, pr, k);
        else if(pos < k) OrderStatistic(pl, right, k);
    }

    public static void Swap(int x, int y){
        int temp = arr[x];
        arr[x] = arr[y];
        arr[y] = temp;
    }
}