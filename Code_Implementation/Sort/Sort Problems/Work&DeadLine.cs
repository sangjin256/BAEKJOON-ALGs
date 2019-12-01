//작업의 소요시간과 데드라인이 주어질 때 작업의 데드라인이 d이고 그 작업의 수행완료시간이 x면
//d-x점을 얻는다. 얻을 수 있는 최대 점수는?
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] a;
	public static void Main(string[] args) {
        //소요시간이 짧은 순으로 스케쥴해야 최적해
        List<(int,int)> list = new List<(int,int)>();
        list.Add((4,2));
        list.Add((3,10));
        list.Add((2,8));
        list.Add((4,15));

        var query = from c in list
                    orderby c.Item1
                    select c;
        
        int time = 0;
        sum = 0;
        foreach(var k in query){
            time += k.Item1;
            sum += k.Item2 - time;
        }
        Console.WriteLine(sum);
    }
}