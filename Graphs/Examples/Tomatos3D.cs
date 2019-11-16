using System;
using System.IO;
using System.Collections.Generic;
public class Lecture
{
    //3차원 창고이므로 3차원 배열을 만들어준다.
    static int[,,] adj;
    static int count = 0;
    //3차원 배열의 앞 뒤 위 아래 왼쪽 오른쪽이므로 6개씩 만들어준다.
    static int[] dx = { 0, 0, -1, 1, 0, 0 };
    static int[] dy = { 1, -1, 0, 0, 0, 0 };
    static int[] dz = { 0, 0, 0, 0, -1, 1 };
    static Queue<(int, int, int)> q = new Queue<(int, int, int)>();
    //dfs에서 사용할 배열의 상한
    static int height;
    static int width;
    static int depth;

    public static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        height = arr[1];
        width = arr[0];
        depth = arr[2];

        adj = new int[height, width, depth];
        //높이
        for(int i = 0; i < depth; i++)
        {
            //세로
            for(int j = 0; j < height; j++)
            {
                string[] str = Console.ReadLine().Split(' ');
                //가로
                for(int k = 0; k < width; k++)
                {
                    adj[j, k, i] = int.Parse(str[k].ToString());
                    if (adj[j, k, i] == 1) q.Enqueue((j,k,i));
                }
            }
        }

        while(q.Count != 0)
        {
            (int x, int y, int z) = q.Dequeue();
            Dfs(x, y, z);
        }

        for(int i = 0; i < depth; i++)
        {
            for(int j = 0; j < height; j++)
            {
                for(int k = 0; k < width; k++)
                {
                    if(adj[j,k,i] == 0)
                    {
                        Console.WriteLine("-1");
                        return;
                    }
                    count = Math.Max(count, adj[j, k, i]);
                }
            }
        }

        Console.WriteLine(count - 1);
    }

    public static void Dfs(int x, int y, int z)
    {
        for(int i = 0; i < 6; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            int nz = z + dz[i];
            if(nx >= 0 && ny >= 0 && nz >= 0 && nx < height && ny < width && nz < depth)
            {
                if(adj[nx,ny,nz] == 0)
                {
                    adj[nx, ny, nz] = adj[x, y, z] + 1;
                    q.Enqueue((nx, ny, nz));
                }
            }
        }
    }
}
        