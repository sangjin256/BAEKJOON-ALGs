//동전들로 합 x를 만들 수 있는 경우의 수
//ex) coins = {1,3,4} x = 5이면 1+1+1+1+1,3+1+1,1+1+3,1+4,1+3+1,4+1로 6개 있음
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] coins;
	public static void Main(string[] args) {
        coins = new int[]{1,3,4};
        int[] count = new int[6];
        count[0] = 1;
        for(int x = 1; x <= 5; x++){
            foreach(var c in coins){
                if(x-c>=0){
                    count[x] += count[x-c];
                }
            }
        }

        Console.WriteLine(count[5]);
    }
}