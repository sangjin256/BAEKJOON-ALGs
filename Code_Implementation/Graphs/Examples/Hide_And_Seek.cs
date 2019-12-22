/*
# 1697

수빈이는 동생과 숨바꼭질을 하고 있다. 수빈이는 현재 점 N(0 ≤ N ≤ 100,000)에

있고, 동생은 점 K(0 ≤ K ≤ 100,000)에 있다. 수빈이는 걷거나 순간이동을 할 수 있다. 만약,

수빈이의 위치가 X일 때 걷는다면 1초 후에 X-1 또는 X+1로 이동하게 된다. 순간이동을 하는 경우에는

1초 후에 2*X의 위치로 이동하게 된다. 수빈이와 동생의 위치가 주어졌을 때, 수빈이가 동생을 찾을

수 있는 가장 빠른 시간이 몇 초 후인지 구하는 프로그램을 작성하시오.
*/

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
            if (x == k) return visited[x] - 1;
            //x-1이 0보다 크고 방문한적 없으면 1초를 추가해준다.
            if (x - 1 >= 0 && visited[x - 1] == 0)
            {
                visited[x - 1] = visited[x] + 1;
                q.Enqueue(x - 1);
            }
            //x+1이 100000보다 작고 방문한적 없으면 1초를 추가해준다.
            if(x+1 <= 100000 && visited[x+1] == 0)
            {
                visited[x + 1] = visited[x] + 1;
                q.Enqueue(x + 1);
            }
            //2*x가 100000보다 작고 방문한적 없으면 1초를 추가해준다.
            if(2*x <= 100000 && visited[2*x] == 0)
            {
                visited[2 * x] = visited[x] + 1;
                q.Enqueue(2 * x);
            }
        }
        return 0;
    }
}
        