//구간 트리
//원래 배열의 크기가 2의 거듭제곱이고 인덱스가 0부터 시작한다고 가정
//원래 배열의 크기가 2의 거듭제곱이 아니면 원소를 추가해 그렇게 되도록 만든다.
//tree배열의 시작 원소(루트)는 tree[1] (tree[0]는 사용x!!)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    static int[] tree;
    static int[] arr;
    public static void Main(string[] args) {
        arr = new int[]{5,8,6,3,2,7,2,6};
        tree = new int[arr.Length*2];
        Array.Copy(arr,0,tree,arr.Length,arr.Length);
        for(int i = arr.Length-1; i >= 1; i--){
            tree[i] = tree[i*2] + tree[i*2+1];
        }
        Console.WriteLine(Sum(2,7));
    }

    //sum(a,b)의 값을 구하는 함수
    public static int Sum(int a, int b){
        a += arr.Length;
        b += arr.Length;
        int s = 0;
        while(a <= b){
            if(a%2 == 1) s += tree[a++];
            if(b%2 == 0) s += tree[b--];
            a /= 2;
            b /= 2;
        }
        return s;
    }

    public static void Add(int k, int x){
        k += arr.Length;
        tree[k] += x;
        for(k /= 2; k >= 1; k /= 2){
            tree[k] = tree[2*k] + tree[2*k+1];
        }
    }
}