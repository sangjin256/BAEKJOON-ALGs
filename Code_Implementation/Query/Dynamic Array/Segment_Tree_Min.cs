//최솟값 질의를 위한 구간 트리
//
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    static int[] tree;
    static int[] arr;
    public static void Main(string[] args) {
        arr = new int[]{5,8,6,3,1,7,2,6};
        tree = new int[arr.Length*2];
        Array.Copy(arr,0,tree,arr.Length,arr.Length);
        for(int i = arr.Length-1; i >= 1; i--){
            tree[i] = Math.Min(tree[i*2], tree[i*2+1]);
        }
        Console.WriteLine(Min(2,7));
    }

    //sum(a,b)의 값을 구하는 함수
    public static int Min(int a, int b){
        a += arr.Length;
        b += arr.Length;
        int s = 100;
        while(a <= b){
            if(a%2 == 1){
                s = Math.Min(s, tree[a++]);
            } 
            if(b%2 == 0){
                s = Math.Min(s, tree[b--]);
            }
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
    //이진 탐색과 유사한 방식으로 배열 원소의 위치 찾기 가능
    //루트에서 시작하여 아래 방향으로 경로 탐색
    //배열의 최소 원소가 어느 위치에 있는지를 찾는 함수
    public static int FindElement(){
        int s = 1;
        int index = 0;
        while(s*2+1 <= tree.Length){
            if(tree[s*2] < tree[s*2+1]){
                s = s*2;
            }
            else s = s*2+1;
        }
        return s-arr.Length;
    }
}