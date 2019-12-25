using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        Console.WriteLine(Modpow(2,10,100));
    }

    //거듭제곱에 대한 나머지 연산
    //거듭제곱 연산을 효율적으로 가능
    //아예 반환값을 long으로 해도 됨
    public static int Modpow(int x, int n, int m){
        if(n == 0) return 1%m;
        long u = Modpow(x,n/2,m);
        u = (u*u)%m;
        if(n%2==1) u = (u*x)%m;
        return (int)u;
    }
}