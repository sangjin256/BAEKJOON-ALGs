using System;
using System.IO;
using System.Collections.Generic;
//이거 없으면 사용 불가
using System.Numerics;

public class Lecture 
{
    public static void Main(String[] args){
        //벡터 a = (x1,y1) 과 벡터 b = (x2,y2)의 외적(x1y2-x2y1)의 값을 이용하면
        //벡터 a의 바로 다음에 벡터 b를 놓았을때 어느 방향을 가르키는지를 알 수 있다.
        Complex a = new Complex(4,2);
        Complex b = new Complex(1,2);

        //x1y2 - x2y1의 값을 구하려면 a의 켤레복소수(Conjugate)와 b를 곱한다음
        //그 값의 허수(y값)값을 구하면 된다. (x1,y1)의 켤레복소수 = (x1,-y1)
        Complex c = Complex.Multiply(Complex.Conjugate(a), b);
        //(a기준)
        //외적값이 0보다 크면 b는 왼쪽으로 회전
        //외적값이 0이면 어느방향으로도 회전 x(또는 180도 회전)
        //외적값이 0보다 작으면 b는 오른쪽으로 회전
        Console.WriteLine(c.Imaginary);
        if(c.Imaginary > 0) Console.WriteLine("왼쪽으로 회전");
        else if(c.Imaginary < 0) Console.WriteLine("오른쪽으로 회전");
        else Console.WriteLine("회전 x(또는 180도 회전)");
    }
}