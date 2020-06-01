//분할 상환 분석의 두 포인터 기법
//양의 정수 n개로 이루어진 배열과 목표 합 x가 있을 때, 합이 x인 부분 배열을
//구하거나 그러한 부분 배열이 존재x라는 것을 알아내야됨
//목표 합 x = 8로 가정하자
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class qh 
{
	public static void Main(string[] args) {
        //양의 정수 n개로 이루어진 배열
        int[] arr = new int[]{1,3,2,5,1,1,2,3};
        //포인터를 2개 만든다.
        int p1; //index 0에서 시작
        int p2 = 1; //index 1에서 시작
        int sum = arr[0];
        for(p1 = 0; p1 < arr.Length; p1++){
            //한 라운드가 끝났으면 p2가 더 못간다는 의미이므로 p1을 한칸 옮겨준다.
            if(p1 != 0){
                sum -= arr[p1-1];
            }
            while(sum+arr[p2] <= 8){
                sum += arr[p2];
                if(sum == 8){
                    Console.WriteLine(p1 + " " + p2);
                    break;
                }
                p2++;
            }
            if(sum == 8){
            	break;
            }
            if(p1 == arr.Length-1 && sum!=8){
                Console.WriteLine("그런거 존재 x");
            }
        }
    }
}