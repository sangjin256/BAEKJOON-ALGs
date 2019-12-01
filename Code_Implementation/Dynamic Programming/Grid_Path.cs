//격자상의 경로.
//왼쪽 위 지점에서 오른쪽 아래 지점으로 가는 경로를 구하는 문제
//움직이는 방향은 오른쪽과 아래만 가능 지나가는 지점의 합을 가장 크게 만들어야 함.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    public static void Main(string[] args) {
        int[,] grid = new int[,]{{3,7,9,2,7},
                                 {9,8,3,5,5},
                                 {1,7,9,8,5},
                                 {3,8,6,4,10},
                                 {6,3,9,7,8}};
        int[,] sum = new int[grid.GetLength(0), grid.GetLength(1)];

        // y == 0 이거나 x == 0일때는 한쪽으로밖에 못가므로 먼저 처리해준다.
        sum[0,0] = grid[0,0];
        for(int i = 1; i < grid.GetLength(0); i++){
            sum[0,i] = grid[0,i] + sum[0,i-1];
            sum[i,0] = grid[i,0] + sum[i-1,0];
        }

        for(int i = 1; i < grid.GetLength(0); i++){
            for(int j = 1; j < grid.GetLength(1); j++){
                sum[i,j] = Math.Max(sum[i-1,j], sum[i,j-1]) + grid[i,j];
            }
        }

        Console.WriteLine(sum[4,4]);
    }
}