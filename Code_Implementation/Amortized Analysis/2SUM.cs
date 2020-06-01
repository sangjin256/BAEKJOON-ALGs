//분할 상환 분석 2SUM 문제
//수 n개로 이루어진 배열과 목표 함 x가 있을 때 합이 x가 되는 배열 원소 '두' 개를 구하거나,
//그러한 원소 조합이 존재하지 않는다는 것을 알아내야함
//목표합 x = 12로 가정
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class qd 
{
	public static void Main(string[] args) {
        int[] arr = new int[]{4,5,7,9,6,1,10,9};
        //시작하기 전에 정렬이 필요하다.
        Array.Sort(arr);
        //p1은 첫번째 원소에서 시작, p2는 마지막 원소에서 시작
        int p1 = 0;
        int p2 = arr.Length-1;
        for(p1 = 0; p1 < arr.Length; p1++){
            while(arr[p1] + arr[p2] >= 12 && p1 < p2){
                if(arr[p1] + arr[p2] == 12){
                    Console.WriteLine(p1 + " " + p2);
                    break;
                }
                p2--;
            }
            if(arr[p1] + arr[p2] == 12){
                break;
            }
        }
    }
}