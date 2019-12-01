using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        int[] a = new int[]{0,1,1,3,3,3,5,6,7,8};
        Console.WriteLine(BinarySearch(a, 5));
        
    }

    public static int BinarySearch(int[] arr, int x){
        int k = 0;
        int n = arr.Length;
        for(int b = n/2; b >= 1; b/=2){
            while(k+b < n && arr[k+b] <= x) k += b;
        }
        if(arr[k] == x){
            return k;
        }
        else return -1;
    }
}