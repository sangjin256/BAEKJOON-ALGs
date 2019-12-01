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
        int a = 0;
        int b = arr.Length-1;
        while(a <= b){
            int k = (a+b)/2;
            if(arr[k] == x) return k;
            if(arr[k] < x) a = k+1;
            else b = k-1;
        }
        return -1;
    }       
}