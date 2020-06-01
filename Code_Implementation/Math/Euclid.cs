using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class rz 
{
	public static void Main(string[] args) {
        int a = 30, b = 12;
        //최대공약수
        Console.WriteLine(Gcd(a, b));
        //최소공배수
        Console.WriteLine(Lcm(a, b));
        //확장 유클리드 알고리즘 사용
        //x,y값과 최대공약수 값이 나옴
        (int x, int y, int g) = ExtendedGcd(a, b);
        Console.WriteLine($"{x} | {y} | {g}");
    }

    //유클리드 알고리즘을 사용해 최대공약수(Gcd(a,b))를 구하는 함수
    public static int Gcd(int a, int b){
        if(b == 0) return a;
        return Gcd(b, a%b);
    }

    //최소공배수는 (a*b)/Gcd(a,b) 이다.
    public static int Lcm(int a, int b){
        return (a*b)/Gcd(a,b);
    }

    //유클리드 알고리즘을 확장한 '확장 유클리드 알고리즘'에서는
    //a*x + b*y = gcd(a,b)를 만족하는 x,y를 구할 수 있다.
    //ex) a = 30, b = 12일때 30*(1) + b*(-2) = 6. x = 1, y = -2
    //gcd(a,b) = gdc(b,a mod b)사용
    public static (int,int,int) ExtendedGcd(int a, int b){
        if(b == 0) return (1,0,a);
        else{
            int x, y, g;
            (x,y,g) = ExtendedGcd(b, a%b);
            return (y, x-(a/b)*y, g);
        }
    }
}