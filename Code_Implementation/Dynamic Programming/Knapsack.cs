//짐 싸기 문제
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    public static void Main(string[] args) {
        int[] weights = new int[]{1,3,3,5};
        int n = weights.Length;
        int m = 0;
        for(int i = 0; i < n; i++){
            m += weights[i];
        }
        bool[,] possible = new bool[m+1,n+1];
        possible[0,0] = true;
        for(int k = 1; k <= n; k++){
            for(int x = 0; x <= m; x++){
                if(x - weights[k-1] >= 0){
                    possible[x,k] |= possible[x-weights[k-1],k-1];
                }
                possible[x,k] |= possible[x,k-1];
            }
        }

        for(int i = 0; i <= 12; i++){
            if(possible[i,4] == true){
                Console.WriteLine(i);
            }
        }

        //1차원 배열만을 이용해서 효율적으로 구현도 가능
        //오른쪽에서 왼쪽순으로 계산해야 올바르게 작동함
        bool[] possible1 = new bool[m+1];
        possible1[0] = true;
        for(int k = 1; k <= n; k++){
            for(int x = m-weights[k-1]; x >= 0; x--){
                possible1[x+weights[k-1]] |= possible1[x];
            }
        }

        for(int i = 0; i < possible1.Length; i++){
            if(possible1[i] == true) Console.Write(i);
        }
    }
}