//서로 다른 부분 문자열. 해싱을 이용 O(nlogn)
//어떤 문자열에 대해 길이가 k인 서로 다른 부분 문자열의 수를 세는 문제
//ex)문자열 ABABAB의 길이가 3인 서로 다른 부분 문자열은 ABA와 BAB
using System;

class yf{
    static int[] hash, p;
    static int A = 3, B = 97;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(DifferentSubstirng(str, k));
    }

    public static int DifferentSubstirng(string str, int k){
        StringToHash(str);
        //길이가 k인 부분 문자열은 총 (문자열의 길이) - k + 1개 있다.
        int[] subHash = new int[str.Length - k + 1];
        for(int i = 0; i < str.Length - k + 1; i++){
            subHash[i] = SubstringHash(i, i+k-1);
        }
        //subHash배열을 정렬해주고 숫자가 달라지면 전과는 다른 부분 문자열이라는 뜻이다.
        Array.Sort(subHash);
        //기본적으로 자기 자신 하나는 있어야 하므로 1로 시작
        int count = 1;
        for(int i = 1; i < subHash.Length; i++){
            if(subHash[i-1] != subHash[i]) count++;
        }

        return count;
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