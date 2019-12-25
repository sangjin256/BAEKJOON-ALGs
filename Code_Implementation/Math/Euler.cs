using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        Console.WriteLine(EulerTotientFunction(10));
    }

    //오일러 피 함수
    //오일러 피 함수 q(n)은 1 이상 n 이하의 정수 중 n과 서로소인 정수의 개수를
    //나타내는 함수이다.
    //n을 소인수 분해한 뒤 공식을 이용해서 계산하므로 소인수분해를 사용한다.
    public static int EulerTotientFunction(int n){
        //기본적으로 가지고있는 인수인 1은 n과 서로소이므로 추가해놓는다.
        int sum = 1;
        foreach(var c in Factors(n)){
            sum *= (int)Math.Pow(c, a[c]-1)*(c-1);
        }
        return sum;
    }

    //소인수분해의 지수도 알아야 하므로 배열로 구분한다.
    static int[] a; // 지수
    public static List<int> Factors(int n){
        List<int> f = new List<int>();
        // a[2]의 값은 소인수분해 시 2의 지수값
        // n이 소수이면 a[n]자리에 값이 들어가므로 n+1칸을 만들어준다.
        a  = new int[n+1]; 
        for(int i = 2; i*i <= n; i++){
            while(n%i==0){
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