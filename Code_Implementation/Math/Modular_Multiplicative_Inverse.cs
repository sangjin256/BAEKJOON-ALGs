//나머지 연산의 곱셈 역원 inv(m)(x)
//x와 m이 서로소인 경우에만 나머지 연산의 곱셈 역원이 존재
//x*inv(m)(x) mod m = 1 을 만족
//예를 들어 6*3mod17 = 1 이므로 inv(17)(6) = 3
//나머지 연산의 곱셈 역원을 이용하면 나눗셈의 결과를 m으로 나눈 나머지를 구할 수 있음
// 이유 : x로 나누는 것은 inv(m)(x)를 곱하는 것에 대응되기 때문
//따라서 inv(17)(6) = 3이기 때문에 36/6 mod 17을 구하기 위해 36*3 mod 17을 계산해도 됨
//공식을 이용하는 방법과 확장 유클리드 알고리즘을 이용하는 2가지 방법이 있음
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class rg 
{
	public static void Main(string[] args) {
        //마지막 bool 매개변수는 m이 소수일 경우 true로 해줌
        Console.WriteLine(Inv_Formula(6, 17, true));
        Console.WriteLine(Inv_ExEuclid(6, 17));
    }

    //공식 사용(오일러 정리 기반) : m이 소수일 경우 페르마의 소정리 사용
    //거듭제곱에 대한 나머지 정리인 Modpow도 함께 사용한다.
    //inv(m)(x) = x^(q(m)-1)
    //페르마의 소정리 사용시 inv(m)(x) = x^(m-2)
    public static int Inv_Formula(int x, int m, bool prime){
        if(prime == false){    
            return Modpow(x, EulerTotientFunction(m)-1, m);
        }
        else{
            //m이 소수일 경우 q(m)이 m-1이므로 m-2가 들어간다.
            return Modpow(x, m-2, m);
        }
    }

    //확장 유클리드 알고리즘 사용
    //만약 역원이 음수라면 m으로 더해줘서 양수로 바꿀 수 있다.
    public static int Inv_ExEuclid(int x, int m){
        int result = ExtendedEuclid(x,m).Item1;
        if(result < 0) return result + m;
        else return result;
    }

    //Modpow.cs 참고
    public static int Modpow(int x, int n, int m){ 
        if(n == 0) return 1%m;
        int u = Modpow(x, n/2, m);
        u = (u*u)%m;
        if(n%2==1) u = (u*x)%m;
        return u;
    }

    public static int Gcd(int a, int b){
        if(b == 0) return a;
        return Gcd(b, a%b);
    }

    public static (int,int,int) ExtendedEuclid(int a, int b){
        if(b == 0) return (1,0,a);
        else{
            int x, y, g;
            (x, y, g) = ExtendedEuclid(b, a%b);
            return (y, x-(a/b)*y, g);
        }
    }
    //Euler.cs 참고
    public static int EulerTotientFunction(int n){
        //기본적으로 가지고있는 인수인 1은 n과 서로소이므로 추가해놓는다.
        int sum = 1;
        int temp = 0;
        foreach(var c in Factors(n)){
            if(temp != c) sum *= (int)Math.Pow(c, a[c]-1)*(c-1);
            temp = c;
        }
        return sum;
    }

    static int[] a; // 지수
    public static List<int> Factors(int n){
        List<int> f = new List<int>();
        a = new int[n+1];
        for(int i = 2; i*i <= n; i++){
            while(n%i == 0){
                f.Add(i);
                a[i]++;
                n/=i;
            }
        }
        if(n>1){
            f.Add(n);
            a[n]++;
        }
        return f;
    }
}