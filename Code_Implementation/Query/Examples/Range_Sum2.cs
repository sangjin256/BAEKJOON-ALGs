/*
# 2042

어떤 N개의 수가 주어져 있다. 그런데 중간에 수의 변경이 빈번히 일어나고 그 중간에

어떤 부분의 합을 구하려 한다. 만약에 1,2,3,4,5 라는 수가 있고, 3번째 수를 6으로

바꾸고 2번째부터 5번째까지 합을 구하라고 한다면 17을 출력하면 되는 것이다. 그리고

그 상태에서 다섯 번째 수를 2로 바꾸고 3번째부터 5번째까지 합을 구하라고 한다면 12가

될 것이다.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class tf 
{
    //구간 트리
    static long[] tree;
	public static void Main(string[] args) {
        int[] tem = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        //구간 트리의 크기를 결정하기 전에 arr배열의 크기보다 크거나 같은 길이 n을 구함
        int n = 0;
        if((tem[0]&(tem[0]-1)) != 0){
            for(n = 1;; n<<=1){
                if(n>tem[0]){
                    break;
                }
            }
            tree = new long[n*2];
        }
        else{
            n = tem[0];
            tree = new long[n*2];
        }

        //원래 배열 값 받기
        for(int i = 0; i < tem[0]; i++){
            tree[i+tree.Length/2] = int.Parse(Console.ReadLine());
        }

        //구간 트리 전처리
        for(int i = tree.Length/2-1; i>= 1; i--){
            tree[i] = tree[i*2] + tree[i*2+1];
        }
		
        //a,b,c가 주어질 때 a가 1이면 b번째 수를 c로 바꾸고 a가 2이면 b~c합 구하기
        for(int i = 0; i < tem[1]+tem[2]; i++){
            int[] imsi = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            if(imsi[0] == 1){
                Change(imsi[1]-1,imsi[2],n);
            }
            else if(imsi[0] == 2){
                Console.WriteLine(Sum(imsi[1]-1,imsi[2]-1,n));
            }
        }
    }

    public static long Sum(int a, int b, int n){
        a += n;
        b += n;
        long s = 0;
        while(a <= b){
            if(a%2==1) s += tree[a++];
            if(b%2==0) s += tree[b--];
            a/=2; b/=2;
        }
        return s;
    }

    public static void Change(int k, int x, int n){
        k += n;
        tree[k] = x;
        for(k/=2; k>=1; k/=2){
            tree[k] = tree[k*2] + tree[k*2+1];
        }
    }
}