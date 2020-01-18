//그래프의 인접 행렬의 거듭제곱은 여러 가지 흥미로운 성질을 가지고 있는데,
//M이 가중치가 없는 인접 행렬이라 할때 M^n행렬은 각 노드 쌍(a,b)에 대해,
//노드 a에서 시작하고 노드 b에서 끝나며 간선의 개수가 n인 경로의 개수를 나타내는 행렬이 됨
//가중 그래프에서는 각 노드 쌍(a,b)에 대해 a에서 시작하고 b에서 끝나며
//간선의 개수가 n인 최단 경로의 길이를 계산 가능
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[,] adj;
    static int[,] adj_w;
	public static void Main(string[] args) {
        adj = new int[,]{{0,0,0,1,0,0},
                         {1,0,0,0,1,1},
                         {0,1,0,0,0,0},
                         {0,1,0,0,0,0},
                         {0,0,0,0,0,0},
                         {0,0,1,0,1,0}};
        adj_w = new int[,]{{1000,1000,1000,4,1000,1000},
                           {2,1000,1000,1000,1,2},
                           {1000,4,1000,1000,1000,1000},
                           {1000,1,1000,1000,1000,1000},
                           {1000,1000,1000,1000,1000,1000},
                           {1000,1000,3,1000,2,1000}};
        //n을 4라고 가정해보자
        adj = Modpow(adj, 4);
        //2번 노드에서 시작하고 5번 노드에서 끝나는 간선의 개수 = 2개
        //0부터 시작하므로 -1 해주어야한다.
        Console.WriteLine(adj[1,4]);

        //가중치 있는 버전
        //간선이 n개인 '최단 거리'를 나타낸다.
        //n=1일때 이미 간선이 2개일때의 최단거리가 나오므로 n-2한 값을 넣어줘야한다.
        //밑에는 간선이 4인 경우
        adj_w = MakeWithWeight(adj_w, 2);
        Console.WriteLine(adj_w[1,4]);
    }

    //가중치 없을때 사용
    //n제곱은 거듭제곱의 대한 나머지 연산을 사용한다.
    public static int[,] Modpow(int[,] x, int n){
        if(n == 1 || n == 0) return x;
        int[,] u = Modpow(x, n/2);
        u = Square(u, u);
        if(n%2==1) u = Square(u, x);
        return u;
    }
    //가중치 없을때 사용
    public static int[,] Square(int[,] x, int[,] y){
        int[,] c = new int[x.GetLength(0), x.GetLength(1)];
        for(int i = 0; i < x.GetLength(0); i++){
            for(int j = 0; j < x.GetLength(0); j++){
                for(int k = 0; k < x.GetLength(0); k++){
                    c[i,j] += x[i,k] * y[k,j];
                }
            }
        }
        return c;
    }

    //가중치가 있을때는 행렬곱이 아니라 AB[i,j] = Min(k=1부터 n까지)(A[i,k] + B[k,j])를
    //n번 해주면 된다.
    public static int[,] MakeWithWeight(int[,] x, int n){
        int[,] c = new int[x.GetLength(0), x.GetLength(0)];
        for(int count = 0; count < n; count++){
            for(int i = 0; i < x.GetLength(0); i++){
                for(int j = 0; j <x.GetLength(0); j++){
                    int temp = 1000;
                    for(int k = 0; k < x.GetLength(0); k++){
                        if(x[i,k] != 1000 && x[k,j] != 1000){
                            temp = Math.Min(temp, x[i,k]+x[k,j]);
                        }
                    }
                    c[i,j] = temp;                    
                }
            }
            x = (int[,])c.Clone();
        }        
        return c;
    }
}