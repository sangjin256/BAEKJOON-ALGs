//O(nlogn)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] a;
    static int[] buff;
	public static void Main(string[] args) {
        a = new int[]{5,4,7,1,9,2};
        buff = new int[a.Length];
        MergeSort(a,a.Length);
        for(int i = 0; i < a.Length; i++){
            Console.Write(a[i]);
        }
    }

    static void MergeSort(int[] a, int n){
        buff = new int[n];
        __MergeSort(a,0,n-1);
        buff = null;
    }

    static void __MergeSort(int[] a, int left, int right){
        if(left<right){
            int i;
            int center = (left + right)/2;
            int j = 0,p = 0, k = left;
            __MergeSort(a,left,center);
            __MergeSort(a,center+1,right);
            for(i = left; i <= center; i++){
                buff[p++] = a[i];
            }
            while(i <= right && j < p){
                a[k++] = (buff[j]<=a[i])?buff[j++]:a[i++];
            }
            while(j < p){
                a[k++] = buff[j++];
            }
        }
    }

    static void Swap(int[] a, int x, int y){
        int temp = a[x];
        a[x] = a[y];
        a[y] = temp;
    }
}