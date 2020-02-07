//문자열 해싱(String Hashing)을 이용하면 두 문자열이 같은지를 효율적으로 판단할 수 있다.
//해시값은 문자열의 글자를 이용하여 계산한 정숫값이다. 두 문자열이 같으면 해시값도 같고, 따라서
//해시값을 이용하여 문자열이 같은지를 판단하는 것이 가능하다.
//일반적으로 많이 쓰는 문자열 해싱 구현 방법은 다항식 해싱(Polynomial Hashing)
//(s[0]*A^(n-1) + s[1]*A^(n-2) + ... + s[n-1]*A^0) mod B
//s[0], s[1], ..., s[n-1]은 문자의 아스키 코드값. A와 B는 미리 정한 상수
//문자열 s의 모든 부분 문자열의 해시값을 O(1)시간에 계산할수 있는데 전처리 과정에 O(n)시간이 걸림
using System;
using System.IO;

class Lecture{
    //다항식 해시에 사용될 A와 B는 미리 정한 상수이다. 보통 B = 10^9이상의 수를 사용한다.
    const int A = 3;
    const int B = 97;

    static int[] hash;
    static int[] p;
    public static void Main(string[] args){
        string str = ABABAAC;
        hash = new int[str.Length];
        p = new int[str.Length];

        StringToHash(str);

        Console.WriteLine(IsEqual(SubstringHash(0,1), SubstringHash(2,3)));
    }

    //부분 문자열의 해시값 계산하기 전처리. 문자열 str을 해시배열로 만듬
    public static void StringToHash(string str){
        hash[0] = str[0];
        for(int i = 1; i < str.Length; i++){
            hash[i] = (hash[i-1]*A + str[i]) % B;
        }
        p[0] = 1;
        for(int i = 1; i < str.Length; i++){
            p[i] = (p[i-1]*A) % B;
        }
    }

    //부분 문자열 s[a...b]의 해시값을 구하는 함수
    //a가 0이면 s[0...b]이므로 그냥 hash[b]를 반환하면 된다.
    public static int SubstringHash(int a, int b){
        if(a == 0) return hash[b];
        return (hash[b] - hash[a-1]*p[b-a+1]) % B;
    }

    //두 부분 문자열이 같은지를 확인하는 함수
    //인자로 SubstringHash함수의 값인 int를 넣어준다.
    public static bool IsEqual(int a, int b){
        if(a == b) return true;
        return false;
    }
}