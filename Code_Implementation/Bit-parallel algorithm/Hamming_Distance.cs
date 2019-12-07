//길이가 같은 두 문자열 a와 b사이의 해밍 거리는 두 문자열이 일치하지 않는 위치의 개수이다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        string a = "01101";
        string b = "11001";
        int a_ = Convert.ToByte(a,2);
        int b_ = Convert.ToByte(b,2);
        //일반적인 방법
        Console.WriteLine(Hamming_Normal(a,b));
        //비트 병렬 알고리즘을 사용한 최적화 방법
        Console.WriteLine(Hamming_Bit(a_,b_));
    }

    //일반적인 방법
    public static int Hamming_Normal(string a, string b){
        int d = 0;
        for(int i = 0; i < a.Length; i++){
            if(a[i] != b[i]) d++;
        }
        return d;
    }

    //비트 병렬 알고리즘을 사용한 방법
    public static int Hamming_Bit(int a, int b){
        int d = 0;
        int temp = a^b;
        for(int i = 0; temp!= 0; i++){
            //x&(x-1)은 가장 오른쪽의 비트 1을 0으로 바꾸는 공식
            //위의 공식을 사용해서 temp가 0이 될때까지 count하면 1의 개수를 알 수 있다.
            temp&=(temp-1);
            d++;
        }
        return d;
    }
}