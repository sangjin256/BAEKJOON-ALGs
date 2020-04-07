// # 11651

// 2차원 평면 위의 점 N개가 주어진다. 좌표를 y좌표가 증가하는 순으로, y좌표가 같으면 x좌표가 증가하는 순서로 정렬한 다음 출력하는 프로그램을 작성하시오.
using System;
using System.Collections.Generic;

class SortGrid2{
    static List<(int,int)> list = new List<(int,int)>();
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());

        for(int i = 0; i < n; i++){
            int[] parts = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            list.Add((parts[0], parts[1]));
        }

        list.Sort((a,b) => {
                            if(a.Item2 > b.Item2) return 1;
                            else if(a.Item2 < b.Item2) return -1;
                            else{
                                if(a.Item1 > b.Item1) return 1;
                                else if(a.Item1 < b.Item1) return -1;
                                else return 0;
                            }
        });

        foreach(var u in list){
            Console.WriteLine(u.Item1 + " " + u.Item2);
        }
    }
}