//음식점에 동시에 존재했던 손님 수의 최댓값 구하기
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] a;
	public static void Main(string[] args) {
        List<(int,int)> list = new List<(int,int)>();
        list.Add((2,6));
        list.Add((1,3));
        list.Add((5,7));
        list.Add((0,4));
        int[] a = new int[list.Count*2]; // 방문시간(1)과 떠나는시간(0)을 정렬해서 넣을 배열 
        int count = 0;
        int mx = 0;
        foreach(var c in list){
            a[c.Item1] = 1;
            a[c.Item2] = 0;
        }
        for(int i = 0; i < a.Length; i++){
            if(a[i] == 1) count++;
            else if(a[i] == 0) count--;
            mx = Math.Max(mx,count);
        }
        Console.WriteLine(mx);
    }
}