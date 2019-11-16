using System;
using System.IO;
using System.Collections.Generic;
public class Lecture
{
    //수빈이의 위치와 동생의 위치를 static으로 선언해준다.
    //Dfs에서 둘이 만났을때의 위치를 알아야하기 때문이다.
    static int n;
    static int k;

    //방문했는지를 확인하는 배열
    static int[] visited = new int[100001];

    //Bfs에 사용할 큐
    static Queue<int> q = new Queue<int>();
    public static void Main(string[] args)
    {
        //수빈이가 있는 위치 n과 동생이 있는 위치 k가 첫째줄에 주어짐
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        n = arr[0];
        k = arr[1];

        q.Enqueue(n);

        //시간을 세는 문제기 때문에 방문 배열에 초를 넣어준다. 그리고 마지막에 -1을 해주어야 한다.
        visited[n] = 1;


        Console.WriteLine(Bfs());

    }

    public static int Bfs()
    {
        while(q.Count != 0)
        {
            int x = q.Dequeue();
            Console.WriteLine($"{x} : {visited[x]}");
            if (x == k) return visited[x] - 1;
            if (x - 1 >= 0 && visited[x - 1] == 0)
            {
                visited[x - 1] = visited[x] + 1;
                q.Enqueue(x - 1);
            }
            if(x+1 <= 100000 && visited[x+1] == 0)
            {
                visited[x + 1] = visited[x] + 1;
                q.Enqueue(x + 1);
            }
            if(2*x <= 100000 && visited[2*x] == 0)
            {
                visited[2 * x] = visited[x] + 1;
                q.Enqueue(2 * x);
            }
        }
        return 0;
    }
}
        