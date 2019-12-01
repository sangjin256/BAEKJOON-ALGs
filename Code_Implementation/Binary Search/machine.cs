//기계 n대를 이용하여 k개의 작업을 처리하는 문제
//i번 기계에는 p(i)라는 값이 할당되어있는데 이는 이 기계로 한 개의 작업을 처리하는 데
//드는 시간. 모든 작업을 처리하는데 드는 시간의 최솟값은?
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    static int[] arr;
	public static void Main(string[] args) {
        //3개의 기계가 있고 P(1)=2,p(2)=3,p(3)=7이라는 뜻
        arr = new int[]{2,3,7};
        //작업의 개수
        int k = 8;
        int x = -1;
        //valid가 false인 x의 최댓값에 +1을 하면 올바른 해가 나옴
        //처음 상한값은 확실한 상한값을 해야됨 ex)k*p(i)
        for(int b = 8*arr[0]; b >= 1; b/=2){
            while(!(valid(x+b,k))) x += b;
        }
        int result = x+1;
        Console.WriteLine(result);
    }

    //i번 기계로 x만큼의 시간 안에 처리할 수 있는 작업의 최대 개수가 x/p(i)이므로
    //모든 x/p(i)를 합한 값이 k 이상이면 x는 올바른 해
    public static bool valid(int x, int k){
        if((x/arr[0] + x/arr[1] + x/arr[2]) >= k) return true;
        else return false;
    }
}