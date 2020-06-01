/*
#1931

한 개의 회의실이 있는데 이를 사용하고자 하는 N개의 회의들에 대하여 회의실 사용표를

만들려고 한다. 각 회의 I에 대해 시작시간과 끝나는 시간이 주어져 있고, 각 회의가 겹치지

않게 하면서 회의실을 사용할 수 있는 최대수의 회의를 찾아라. 단, 회의는 한번 시작하면

중간에 중단될 수 없으며 한 회의가 끝나는 것과 동시에 다음 회의가 시작될 수 있다. 회의의

시작시간과 끝나는 시간이 같을 수도 있다. 이 경우에는 시작하자마자 끝나는 것으로 생각하면 된다.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class j 
{
	public static void Main(string[] args) {
        //시작시간과 끝나는시간을 넣을 리스트
        List<(int,int)> mt = new List<(int,int)>();
        int n = int.Parse(Console.ReadLine());
        for(int i = 0 ; i < n; i++){
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '),s => int.Parse(s));
            mt.Add((arr[0],arr[1]));
        }

        //linq쿼리식을 사용해서 끝나는시간순으로 정렬해준다.
        //끝나는시간이 같은경우 시작시간으로 정렬해준다.
        var query = from num in mt
                    orderby num.Item2, num.Item1
                    select num;
        int count = 0;
        int tmp = 0;
        foreach(var u in query){
            if(tmp<=u.Item1){
                count++;
                tmp = u.Item2;
            }
        }
        Console.WriteLine(count);
    }
}