using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class tz 
{
    //부분집합을 넣을 list
    static Stack<int> subset = new Stack<int>();
    //집합의 원소 수
    static int n;
    static int count = 0;
	public static void Main(string[] args) {
        n = 3;//{1,2,3}
        Search(1);
    }
    
    static void Search(int k){
        if(k == n+1){
            foreach(var c in subset){
                Console.Write(c+" ");
            }
            Console.WriteLine();
        } else {
            subset.Push(k);
            Search(k+1);
            subset.Pop();
            Search(k+1);
        }
    }
}