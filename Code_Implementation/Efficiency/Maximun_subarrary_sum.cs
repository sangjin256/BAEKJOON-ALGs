using System;
using System.IO;
using System.Collections.Generic;

public class ws 
{
	public static void Main(string[] args) {
        int[] arr = {-1,2,4,-3,5,2,-5,2};
        int best = 0;
        int sum = 0;
        for(int i = 0; i < arr.Length; i++){
            sum = Math.Max(arr[i], sum+arr[i]);
            best = Math.Max(sum,best);
        }
        Console.WriteLine(best);
    }
}