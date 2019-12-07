//배열의 각 원소에 대해 그 원소보다 작으면서 가장 가까운 원소를 구해야됨
//스택을 이용하여 효율적인 풀이 가능
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{
    static Stack<int> stack = new Stack<int>();
	public static void Main(string[] args) {
        int[] arr = new int[]{1,3,4,2,5,3,4,2};
        stack.Push(arr[0]);
        for(int i = 1; i < arr.Length;i++){
            while(arr[i] < stack.Peek()) stack.Pop();
            if(stack.Peek() != arr[i]) stack.Push(arr[i]);
        }

        foreach(var c in stack){
            Console.WriteLine(c);
        }
    }
}