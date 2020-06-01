//문자열 해싱(String Hashing)을 이용하면 두 문자열이 같은지를 효율적으로 판단할 수 있다.
//해시값은 문자열의 글자를 이용하여 계산한 정숫값이다. 두 문자열이 같으면 해시값도 같고, 따라서
//해시값을 이용하여 문자열이 같은지를 판단하는 것이 가능하다.
//일반적으로 많이 쓰는 문자열 해싱 구현 방법은 다항식 해싱(Polynomial Hashing)
//(s[0]*A^(n-1) + s[1]*A^(n-2) + ... + s[n-1]*A^0) mod B
//s[0], s[1], ..., s[n-1]은 문자의 아스키 코드값. A와 B는 미리 정한 상수
//문자열 s의 모든 부분 문자열의 해시값을 O(1)시간에 계산할수 있는데 전처리 과정에 O(n)시간이 걸림
using System;

class yh{
    static int[] hash, p;
    static int A = 3, B = 97;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        StringToHash(str);
        Console.WriteLine(SubstringHash(0,1) == SubstringHash(2,3));
    }

    public static void StringToHash(string str){
        hash = new int[str.Length];
        p = new int[str.Length];
        hash[0] = str[0];
        p[0] = 1;
        for(int i = 1; i < str.Length; i++){
            hash[i] = (hash[i-1]*A + str[i]) % B;
            p[i] = (p[i-1]*A) % B; 
        }
    }

    public static int SubstringHash(int a, int b){
        if(a == 0) return hash[b];
        int temp = (hash[b] - hash[a-1]*p[b-a+1]) % B;
        if(temp < 0) return temp + B;
        else return temp;
    }
}