//중국인의 나머지 정리
//다음 형식의 방정식을 풀 때 사용 가능
//x = a1 mod m1
//x = a2 mod m2
//... x = an mod mn
//여기에서 m1,m2,...,mn의 모든 조합은 서로소이다.
//이 방정식의 해 x는 다음과 같음이 알려져 있다.
//x = a1*X1*inv(m1)(X1) + a2*X2*inv(m2)(X2) + ... + an*Xn*inv(mn)(Xn)
//이때 Xk = (m1*m2*...*mn)/mk
//중국인의 나머지 정리의 해도 무한하다.

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        //x = 3 mod 5
        //x = 4 mod 7
        //x = 2 mod 3 으로 가정
        int[] a = new int[]{3,4,2};
        int[] m = new int[]{5,7,3};
        //Xk를 담을 배열
        int[] X = new int[3];
        //Xk를 구하기 위한 모든 m값의 곱
        int M = 1;
        for(int i = 0; i < m.Length; i++){
            M *= m[i];
        }
        //답 구하기
        int result = 0;
        for(int i = 0; i < m.Length; i++){
            result += a[i]*(M/m[i])*Inv(M/m[i], m[i]);
        }
        
        Console.WriteLine(result);
        //해는 무한하다.(다음 형태의 모든 조합이 해가 된다.)
        //x+K*m1*m2*...*mn
        //이때 k는 임의의 정수
    }

    //여기서는 그냥 확장 유클리드 알고리즘으로 풀자
    public static int Inv(int x, int m){
        int result = Gcd(x,m).Item1;
        if(result < 0) return result + m;
        else return result;
    }

    public static (int,int,int) Gcd(int a, int b){
        if(b == 0) return (1,0,a);
        else{
            int x, y, g;
            (x,y,g) = Gcd(b, a%b);
            return (y, x-(a/b)*y, g);
        }
    }
}