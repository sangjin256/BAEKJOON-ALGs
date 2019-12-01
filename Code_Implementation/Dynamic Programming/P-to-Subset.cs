//순열(O(n!))을 부분집합(O(2^n))으로 바꾸기
//최대하중이 x인 엘리베이터가 있고 1층에서 꼭대기 층까지 가려고 하는 사람 n명이 있다.
//i번째 사람 무게를 weights[i]라고 하자. 모든 사람이 꼭대기 층까지 가려면 최소 몇번 운행해야 하는가?


//valueTuple만으로 배열 생성이 불가능한 것 같다.
//다음번에는 List<(int,int)>로 해보자
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    public static void Main(string[] args) {
        int n = 5;
        int x = 12;
        int[] weight = new int[]{2,3,4,5,9};

        (int,int)[] best = new (int,int)[1<<n];
        best[0] = (1,0);
        for(int s = 1; s < (1<<n); s++){
            //초깃값 : n+1번 운행해야 하는 경우로 설정
            best[s] = (n+1,0);
            for(int p = 0; p < n; p++){
                //p번째 사람이 현재 포함 안되어있을때
                if(s&(1<<p)){
                    //p위치의 사람을 포함해서 option에 담음
                    var option = best[s^(1<<p)];
                    if(option.Item2 + weight[p] <= x){
                        option.Item2 += weight[p];
                    }
                    else {
                        option.Item1++;
                        option.Item2 = weight[p];
                    }
                    //요소로 따로 비교해야될수도있음(한번에 되는지 실험필요)
                    best[s] = Math.Min(best[s],option);
                }
            }
        }
        Console.WriteLine(best[1<<n-1].Item1);
    }
}