/*
# 2263

n개의 정점을 갖는 이진 트리의 정점에 1부터 n까지의 번호가 중복 없이 매겨져 있다.

이와 같은 이진 트리의 중위 순회와 후위 순회가 주어졌을 때, 전위 순회를 구하는

프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class uv 
{
    static int[] inorder;
    static int[] postorder;
    static int[] position;
    public static void Main(string[] args) {
        int n = int.Parse(Console.ReadLine());
        inorder = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        postorder = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        position = new int[n+1];
        for(int i = 0; i < n; i++) position[inorder[i]] = i;
        Solve(0, n-1, 0, n-1);
    }

    public static void Solve(int in_start, int in_end, int post_start, int post_end){
        if(in_start > in_end || post_start > post_end) return;

        int root = postorder[post_end];
        Console.Write(root + " ");

        int p = position[root];

        int left = p - in_start;

        Solve(in_start, p-1, post_start, post_start+left-1);
        Solve(p+1, in_end, post_start+left, post_end-1);
    }
}