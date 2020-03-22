using System;
using System.Collections.Generic;

class Exercise_FW{
    static long[,] adj;
    static long[,] dist;
    static long INF = 400*(400-1)*10000 + 1;

    public static void Main(String[] args){
        int[] parts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        int v = parts[0];
        int e = parts[1];
        adj = new long[v+1,v+1];
        dist = new long[v+1,v+1];

        for(int i = 0; i < e; i++){
            parts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            adj[parts[0],parts[1]] = parts[2];
        }

        for(int i = 1; i <= v; i++){
            for(int j = 1; j <= v; j++){
                if(i == j) dist[i,j] = 0;
                else if(Convert.ToBoolean(adj[i,j])) dist[i,j] = adj[i,j];
                else dist[i,j] = INF;
            }
        }

        for(int k = 1; k <= v; k++){
            for(int i = 1; i <= v; i++){
                for(int j = 1; j <= v; j++){
                    dist[i,j] = Math.Min(dist[i,k] + dist[k,j], dist[i,j]);
                }
            }
        }

        long mn = INF;
        for(int i = 1; i <= v; i++){
            for(int j = 1; j <= v; j++){
                if(i == j) continue;
                if(dist[i,j] + dist[j,i] < mn){
                    mn = dist[i,j]+dist[j,i];
                }
            }
        }

        if(mn == INF) Console.WriteLine(-1);
        else Console.WriteLine(mn);
    }
}