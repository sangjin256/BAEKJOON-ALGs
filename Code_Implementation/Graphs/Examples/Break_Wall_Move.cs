using System;
using System.IO;
using System.Collections.Generic;

public class wb
{
    static int[,] map;
    //마지막 차원에는 벽을 부쉈는지, 안부쉈는지가 나온다.
    static int[,,] visited;
    static int[] dx = { 0, 0, -1, 1 };
    static int[] dy = { -1, 1, 0, 0 };
    static Queue<(int, int, int)> q = new Queue<(int, int, int)>();
    public static void Main(string[] args)
    {
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));

        map = new int[arr[0] + 1, arr[1] + 1];
        visited = new int[arr[0] + 1, arr[1] + 1,2];

        for(int i = 1; i <= arr[0]; i++)
        {
            string str = Console.ReadLine();
            for(int j = 1; j <= arr[1]; j++)
            {
                map[i, j] = int.Parse(str[j - 1].ToString());
            }
        }

        //1이 벽이 아직 있는거 0이 벽을 뚫은거
        visited[1, 1, 1] = 1;
        q.Enqueue((1, 1, 1));

        Console.WriteLine(Bfs());
    }

    public static int Bfs()
    {
        while(q.Count != 0)
        {
            (int x, int y, int z) = q.Dequeue();
            if(x == map.GetLength(0)-1 && y == map.GetLength(1) - 1)
            {
                return visited[x, y, z];
            }
            for(int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if(nx >= 1 && ny >= 1 && nx < map.GetLength(0) && ny < map.GetLength(1))
                {
                    //가려는 곳에 벽이 있고 벽을 아직 안뚫은경우
                    if(map[nx,ny] == 1 && Convert.ToBoolean(z))
                    {
                        visited[nx, ny, z - 1] = visited[x,y,z] + 1;
                        q.Enqueue((nx, ny, z - 1));
                    }
                    //가려는곳에 벽이 없고 아직 안간곳인 경우
                    else if(map[nx,ny] == 0 && visited[nx,ny,z] == 0)
                    {
                        visited[nx, ny, z] = visited[x, y, z] + 1;
                        q.Enqueue((nx, ny, z));
                    }
                }
            }
        }
        return -1;
    }
}