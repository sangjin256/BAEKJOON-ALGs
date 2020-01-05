//O(n)까지 가능
//도수정렬
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] a;
	public static void Main(string[] args) {
        a = new int[]{5,4,7,1,9,2};
        int mx = 0;
        for(int i = 0; i < a.Length; i++){
            if(mx < a[i]){
                mx = a[i];
            }
        }
        Fsort(a,a.Length,mx);
        for(int i = 0; i < a.Length; i++){
            Console.Write(a[i]+ " ");
        }
    }
    public static void Fsort(int[] a, int n, int max){
        int[] b = new int[n];
        int[] f = new int[max+1];
        for(int i = 0; i < n; i++) f[a[i]]++;
        for(int i = 1; i <= max; i++) f[i] += f[i-1];
        for(int i = n-1; i >= 0; i--) b[--f[a[i]]] = a[i];
        for(int i = 0; i < n; i++) a[i] = b[i];
    }
}