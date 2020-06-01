//O(n2)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class tx 
{
    static int[] a;
	public static void Main(string[] args) {
        a = new int[]{5,4,7,1,9,2};
        BubbleSort(a,a.Length);
        for(int i = 0; i < a.Length; i++){
            Console.Write(a[i]);
        }
    }

    static void BubbleSort(int[] a, int n){
        int k = 0;
        while(k < n-1){
            int last = n-1;
            for(int i = n-1; i > k; i--){
                if(a[i-1]>a[i]){
                    Swap(a,i-1,i);
                    last = i;
                }
            }
            k = last;
        }
    }

    static void Swap(int[] a, int x, int y){
        int temp = a[x];
        a[x] = a[y];
        a[y] = temp;
    }
}