using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class tl 
{
    static Stack<int> permutation = new Stack<int>();
    static int n;
    static bool[] chosen; 
    public static void Main(string[] args) {
        n = 3;
        chosen = new bool[n+1];
        Search();
    }

    public static void Search(){
        if(permutation.Count == n){
            foreach(var c in permutation){
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
        else{
            for(int i = 1; i <= n; i++){
                if(chosen[i]) continue;
                chosen[i] = true;
                permutation.Push(i);
                Search();
                chosen[i] = false;
                permutation.Pop();
            }
        }
    }
}