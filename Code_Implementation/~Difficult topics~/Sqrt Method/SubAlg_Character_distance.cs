//서브알고리즘
//각 서브알고리즘은 전체 알고리즘의 수행 과정에서 발생하는 특정 상황에 특화된 형태
//두 서브알고리즘 중 한 가지만을 이용해도 문제를 풀 순 있지만 둘을 조합하면
//더 효율적으로 풀 수 있음

//문자 거리 문제
//각 칸에 문자가 들어있는 n*n크기의 격자가 주어진다. 서로 같은 문자가 들어있는 두 칸
//사이의 최소 맨헤튼 거리는 얼마인가?
//Dictionary를 통해 좌표값을 미리 넣고 시작하자.
using System;
using System.Collections.Generic;

class Pair{
    public int x, y;
    public Pair(int x, int y){
        this.x = x;
        this.y = y;
    }

    public override string ToString(){
        return string.Format(x + " , " + y);
    }
}

public class Lecture 
{
    static char[,] arr= new char[,]{{'A','C','E','A'},
                                    {'B','D','F','D'},
                                    {'E','A','B','C'},
                                    {'C','F','E','A'}};
                                    
    static Dictionary<char,List<Pair>> dic = new Dictionary<char,List<Pair>>();
	public static void Main(string[] args) {
        DicInit();

        Console.WriteLine(SubAlgorithm());
    }

    //서브알고리즘으로 종합
    //c가 들어있는 칸의 개수를 k라 할때 첫번째 알고리즘은 k가 작을때 효과적이고
    //두번째 알고리즘은 k가 클때 효과적이다. 따라서 x = sqrt(n^2) = n으로 두고
    //k가 x이하일때 첫번째 알고리즘, 그렇지 않을때는 두번째 알고리즘을 사용하자.
    public static int SubAlgorithm(){
        int x = (int)Math.Sqrt(arr.GetLength(0)*arr.GetLength(0));
        int min = 10000;
        foreach(var u in dic.Keys){
            int temp = -1;
            if(dic[u].Count <= x) temp = FirstAlgorithm(u);
            else temp = SecondAlgorithm(u);

            if(temp != -1){
                min = Math.Min(min, temp);
            }
        }

        if(min == 10000) return -1;
        else return min;
    }

    //첫번째 알고리즘
    //각 문자 c에 대해 c가 들어있는 모든 칸의 조합을 하나씩 살펴보고, 두 칸 사이에
    //거리를 계산하여 최솟값을 구함(맨헤튼거리)
    public static int FirstAlgorithm(char ch){
        int min = 100000;
        //그 문자가 하나밖에 없다면 -1을 반환한다.
        if(dic[ch].Count <= 1) return -1;
        for(int i = 0; i < dic[ch].Count; i++){
            for(int j = i+1; j < dic[ch].Count; j++){
                int X = Math.Abs(dic[ch][i].x - dic[ch][j].x);
                int Y = Math.Abs(dic[ch][i].y - dic[ch][j].y);
                min = Math.Min(min, X + Y);
            }
        }
        return min;
    }

    //두번째 알고리즘
    //c가 들어있는 모든 칸에서 출발하는 너비 우선 탐색을 동시에 수행
    static int[] dx = new int[]{0, 0, 1, -1};
    static int[] dy = new int[]{1, -1, 0, 0};
    public static int SecondAlgorithm(char ch){
        int min = 10000;
        Queue<Pair> q = new Queue<Pair>();
        foreach(var u in dic[ch]){
            q.Enqueue(u);
        }
        //먼저 ch에 속한 좌표를 q에 다 넣어둔다음
        //다시 큐를 하나 만들어거 q의 각 요소마다 BFS를 돌린다.
        //그와중에 다른 q의 요소를 만나면 그 최솟값을 저장한다.
        while(q.Count != 0){
            Pair p = q.Dequeue();
            Queue<(int,int)> temp = new Queue<(int,int)>();
            temp.Enqueue((p.x, p.y));
            while(temp.Count != 0){
                (int a,int b) t = temp.Dequeue();
                for(int i = 0; i < dx.Length; i++){
                    int nx = dx[i] + t.a;
                    int ny = dy[i] + t.b;
                    if(nx>=0&&ny>=0&&nx<arr.GetLength(0)&&ny<arr.GetLength(1)){
                        if(ch == arr[nx,ny]){
                            int X = Math.Abs(nx - p.x);
                            int Y = Math.Abs(ny - p.y);
                            min = Math.Min(min, X + Y);
                        }
                        else temp.Enqueue((nx, ny));
                    }
                }
            }
        }
        if(min == 1000) return -1;
        else return min;
    }

    public static void DicInit(){
        for(int i = 65; i <= 70; i++){
            dic.Add((char)i, new List<Pair>());
        }
        for(int i = 0; i < arr.GetLength(0); i++){
            for(int j = 0; j < arr.GetLength(1); j++){
                dic[arr[i,j]].Add(new Pair(i,j));
            }
        }
    }
}