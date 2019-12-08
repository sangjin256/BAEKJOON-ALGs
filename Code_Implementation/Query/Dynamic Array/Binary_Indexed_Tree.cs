//이진 인덱스 트리 혹은 펜윅 트리라고 불림
//누적 합 배열의 동적인 변종
//구간 합 질의를 처리하는 연산, 배열의 원소 갱신하는 연산 지원(둘 다 O(logn))
//이진 인덱스 트리는 모든 배열의 인덱스가 1부터 시작한다고 가정한다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] tree;
	public static void Main(string[] args) {
        int[] arr = new int[]{1,3,4,8,6,1,4,2};
        //인덱스가 1부터 시작하므로 +1을 해준다.
        tree = new int[arr.Length+1];
        for(int k = 1; k < tree.Length; k++){
            int ki = k - (k&(-k)) + 1;
            while(ki <= k){
                tree[k] += arr[ki-1];
                ki++;
            }
        }
        Console.WriteLine(Sum(1,7));
    }

    //sum(1,k)의 값을 구하는 함수
    public static int Sum(int a, int b){
        if(a != 1) return Sum_(b) - Sum_(a-1);
        else return Sum_(b);
    }
    public static int Sum_(int k){
        int s = 0;
        while(k >= 1){
            s += tree[k];
            k -= k&(-k);
        }
        return s;
    }

    //배열의 위치 k에 저장된 값을 x만큼 증가시키는 함수
    public static void Add(int k, int x){
        while(k <= tree.Length){
            tree[k] += x;
            k += k&(-k);
        }
    }
}