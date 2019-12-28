//디오판토스 방정식은 ax+by = c 형태의 방정식을 말함. 여기서 a,b,c는 상수이고
//x,y가 구하려는 값 (방정식의 모든 값은 정수여야 함!!)
//디오판토스 방정식은 확장 유클리드 알고리즘으로 효율적으로 풀 수 있음
//디오판토스 방정식의 해가 존재하는 경우와 c가 gcd(a,b)로 나누어떨어지는 경우는 동치
//따라서 ax+by=gcd(a,b)로 풀고 나누어떨어지므로 c/gcd(a,b)값만큼 값들에 곱해주면 답
//디오판토스 방정식의 해는 유한하지 않음(무한)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        //39x+15y = 12로 가정
        (int x, int y, int g) = Gcd(39, 15);
        //12나누기 gcd(a,b)값만큼 곱해야한다.
        int t = 12/g;
        Console.WriteLine($"x = {x*t}, y = {y*t}");
        //해는 무한하다.(다음 형태의 모든 조합이 해가 된다.)
        //(x+(kb/gcd(a,b), y-(ka/gcd(a,b))
        //이때 k는 임의의 정수
    }

    //확장 유클리드 알고리즘
    public static (int,int,int) Gcd(int a, int b){
        if(b == 0) return (1,0,a);
        else{
            int x, y, g;
            (x,y,g) = Gcd(b, a%b);
            return (y, x-(a/b)*y, g);
        }
    }
}