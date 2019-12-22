using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        Console.WriteLine(Prime(135));

        foreach(var c in Factors(135)){
            Console.WriteLine(c);
        }
    }

    //소수 판별 함수
    //정수 n이 소수가 아니라면 두 정수의 곱 a*b로 나타낼 수 있고, 이때 a<=√n 또는 b<=√n
    //이 성립한다. 즉, 2 이상 |√n|이하의 인수가 반드시 존재한다.
    //따라서 정수 n을 2이상 |√n|이하의 모든 정수로 나누어볼때 나누어떨어지는
    //경우가 없으면 n은 소수이다.
    public static bool Prime(int n){
        if(n < 2) return false;
        for(int x = 2; x*x<=n; x++){
            if(n%x == 0) return false;
        }
        return true;
    }

    //n의 소인수 분해를 리스트로 만드는 함수
    //n을 소인수로 나눈 후, 소인수를 벡터에 넣는 과정을 반복
    //이 과정은 현재 남아있는 n에 대해 2이상 |√n|이하의 인수가 없을때까지 진행
    //알고리즘이 종료했는데 n>1인 경우, 이 값은 소수이고 마지막 인수가 됨
    public static List<int> Factors(int n){
        List<int> f = new List<int>();
        for(int x = 2; x*x <= n; x++){
            while(n%x == 0){
                f.Add(x);
                n/=x;
            }
        }
        if(n>1) f.Add(n);
        return f;
    }
}