/*
# 11659

수 N개가 주어졌을 때, i번째 수부터 j번째 수까지 합을 구하는 프로그램을 작성하시오.

입력
첫째 줄에 수의 개수 N (1 ≤ N ≤ 100,000), 합을 구해야 하는 횟수 M (1 ≤ M ≤ 100,000)

이 주어진다. 둘째 줄에는 N개의 수가 주어진다. 수는 1,000보다 작거나 같은 자연수이다.

셋째 줄부터 M개의 줄에는 합을 구해야 하는 구간 i와 j가 주어진다.
*/

//통과 못함 but 정답

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    //누적 합 배열 사용
    static int[] sum = new int[100001];
    static int[] arr = new int[100001];
	public static void Main(string[] args) {
        int[] t = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        arr = Array.ConvertAll(Console.ReadLine().Split(' '), p => int.Parse(p));
        sum[0] = arr[0];
        for(int i = 1; i < arr.Length; i++){
            sum[i] = sum[i-1] + arr[i];
        }
        for(int i = 0; i < t[1]; i++){
            int[] temp = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            if(temp[0] != 1) Console.WriteLine(sum[temp[1]-1] - sum[temp[0]-1-1]);
            else Console.WriteLine(sum[temp[1]-1]);
        }
    }
}