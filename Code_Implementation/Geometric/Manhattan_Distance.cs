//유클리드 거리 : 두 점 (x1,y1) (x2,y2)에서 우리가 흔히 알고있는 거리공식을 사용하면 된다.
//맨해튼 거리 : 두 점 (x1,y1) (x2,y2) 사이의 거리를 |x1-x2| + |y1-y2|로 정의한다.
//문제 - 2차원 공간상에 점들이 있을 때, 두 점 사이의 맨해튼 거리가 최대가 되는 경우를 찾는 문제
//이 문제를 풀때 좌표(x,y)를 (x+y,y-x)로 변환하면 유용한데 그렇게 하면 x좌표와 y좌표를 독립적으로
//처리할 수 있기 때문이다.
using System;
using System.IO;
using System.Collections.Generic;
//이거 없으면 사용 불가
using System.Numerics;

public class Lecture 
{
    public static void Main(String[] args){
        Complex a = new Complex(1,3);
        Complex b = new Complex(2,1);
        Complex c = new Complex(4,4);
        Complex d = new Complex(4,2);

        Complex[] arr = new Complex[]{a,b,c,d};
        for(int i = 0; i < arr.Length; i++){
            //(x,y)를 (x+y,y-x)로 변환
            arr[i] = new Complex(arr[i].Real + arr[i].Imaginary, arr[i].Imaginary - arr[i].Real);
        }

        string str;
        int result = 0;
        //둘씩 계산한다.
        for(int i = 1; i < arr.Length; i++){
            for(int j = 0; j <= i; j++){
                int temp = Math.Max(Math.Abs(arr[i].Real - arr[j].Real), Math.Abs(arr[i].Imaginary - arr[i].Imaginary));
                if(temp > result){
                    result = temp;
                    //변환후의 좌표가 출력됨. 변경필요
                    str = string.Format($"{arr[i]}에서 {arr[j]}까지의 거리");
                }
            }
        }

        Console.WriteLine(result + "\n" + str);
    }
}