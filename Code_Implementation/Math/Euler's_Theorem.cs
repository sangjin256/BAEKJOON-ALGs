using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class rs 
{
	public static void Main(string[] args) {
        Console.WriteLine(EulerTheorem(10));
    }

    //오일러 정리란,
    //모든 서로소인 정수 x와 m에 대해 다음 식이 성립한다는 정리
    //(x^q(m)) mod m = 1 (q(n)은 오일러 피 함수(Euler.cs 참고))
    //정수 m이 소수일 경우 q(m) = m-1이 됨(<= 이를 페르마 소정리(Fermat's little theorem) 라고 함)
    //증명. 정수 n을 받고 그 정수가 소수인지 아닌지를 매개변수로 보낸다.(기본 false)
    public static bool EulerTheorem(int n, bool prime = false){
        bool result = true;
        int qm = EulerTotientFunction(n);
        if(prime == false){
            foreach(var c in Coprime(n)){
                if(Math.Pow(c, qm) % n != 1) result = false;
            }
            return result;
        }
        //m이 소수이면 페르마 소정리 적용
        //페르마 소정리를 적용해서
        //x^n mod m = x^(n mod (m-1)) mod m으로 변형 가능
        //그러면 n이 매우 큰 경우 x^n의 값을 구할 때 사용 가능
        else{
            foreach(var c in Coprime(n)){
                if(Math.Pow(c, n-1) % n != 1) result = false;
            }
            return result;
        }
    }
    //서로소인 정수들 찾기
    public static List<int> Coprime(int n){
        List<int> cp = new List<int>();
        for(int i = 1; i < n; i++){
            if(Gcd(n,i) == 1) cp.Add(i);
        }
        return cp;
    }

    // Euclid.cs 참고
    public static int Gcd(int a, int b){
        if(b == 0) return a;
        return Gcd(b, a%b);
    }

    //Euler.cs 참고
    public static int EulerTotientFunction(int n){
        //기본적으로 가지고있는 인수인 1은 n과 서로소이므로 추가해놓는다.
        int sum = 1;
        //Factors(n)은 소인수의 리스트가 들어있는 함수라 n=20일 때,
        //2,2,5가 들어가서 2가 중복된다. 중복을 방지하기 위해 temp 변수를 만든다.
        int temp = 0;
        foreach(var c in Factors(n)){
        	if(temp != c) sum *= (int)Math.Pow(c, a[c]-1)*(c-1);
        	temp = c;
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