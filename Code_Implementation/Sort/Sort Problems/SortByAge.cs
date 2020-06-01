// # 10814

// 온라인 저지에 가입한 사람들의 나이와 이름이 가입한 순서대로 주어진다. 이때, 회원들을 나이가 증가하는 순으로, 나이가 같으면 먼저 가입한 사람이 앞에 오는 순서로 정렬하는 프로그램을 작성하시오.
using System;
using System.Collections.Generic;

class SortByAge{
    static List<(int,string)> list = new List<(int, string)>();
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++){
            string[] parts = Console.ReadLine().Split(' ');
            list.Add((int.Parse(parts[0]), parts[1]));
        }

        list.Sort((a,b) => {
                            if(a.Item1 > b.Item1) return 1;
                            else if(a.Item1 < b.Item1) return -1;
                            else return 0;
        });

        foreach(var u in list){
            Console.WriteLine(u.Item1 + " " + u.Item2);
        }
    }
}