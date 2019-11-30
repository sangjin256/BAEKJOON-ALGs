//O(nlogn)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] a;
	public static void Main(string[] args) {
        a = new int[]{5,4,7,1,9,2};
        QuickSort(a,0,a.Length-1);
        for(int i = 0; i < a.Length; i++){
            Console.Write(a[i]);
        }
    }

    static void QuickSort(int[] a, int left, int right){
        int pl = left; int pr = right;
        int x = a[(pl+pr)/2];
        do{
            while(a[pl]<x) pl++;
            while(a[pr]>x) pr--;
            if(pl <= pr) Swap(a, pl++, pr--);
        } while(pl <= pr);
        if(left < pr) QuickSort(a, left, pr);
        if(pl < right) QuickSort(a, pl, right);
    }

    static void Swap(int[] a, int x, int y){
        int temp = a[x];
        a[x] = a[y];
        a[y] = temp;
    }
}