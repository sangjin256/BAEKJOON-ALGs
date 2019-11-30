using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int count;
    static int n;
    //세로줄
    static bool[] col;
    //대각선"/"
    static bool[] diag1;
    //대각선"\"
    static bool[] diag2;
    public static void Main(string[] args) {
        n = 8;
        col = new bool[2*n];
        diag1 = new bool[2*n];
        diag2 = new bool[2*n];
        Search(0);
        Console.WriteLine(count);
    }
    public static void Search(int y){
        if(y == n){
            count++;
            return;
        }
        for(int x = 0; x < n; x++){
            if(col[x]||diag1[x+y]||diag2[x-y+(n-1)]) continue;
            col[x] = diag1[x+y] = diag2[x-y+(n-1)] = true;
            Search(y+1);
            col[x] = diag1[x+y] = diag2[x-y+(n-1)] = false;
        }
    }
}