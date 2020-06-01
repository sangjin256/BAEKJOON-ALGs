//해시를 사용한 패턴 매칭 O(n)
//문자열 s와 패턴 p가 있을 때 s 내에서 p가 등장하는 위치의 개수를 반환
//ex) ABCABABCA내에서 패턴 ABC가 등장하는 위치는 0,5로 2개이다.
using System;

class yg{
    static int[] hash, p;
    static int A = 3, B = 97;

    public static void Main(string[] args){
        string str = Console.ReadLine();
        string pat = Console.ReadLine();
    
        Console.WriteLine(PatMatch(str, pat));
    }

    public static int PatMatch(string str, string pat){
        int patHash = 0;
        int count = 0;
        //문자열의 해시값을 구할 때 패턴의 해시값도 함께 구한다.
        StringToHash(str, pat, out patHash);
        for(int i = 0; i < str.Length - pat.Length + 1; i++){
            if(SubstringHash(i, i+2) == patHash) count++; 
        }
        return count;
    }

    public static void StringToHash(string str, string pat, out int patHash){
        hash = new int[str.Length];
        p = new int[str.Length];
        hash[0] = str[0];
        p[0] = 1;
        patHash = pat[0];
        for(int i = 1; i < str.Length; i++){
            hash[i] = (hash[i-1]*A + str[i]) % B;
            p[i] = (p[i-1]*A) % B;
            if(i < pat.Length){
                patHash = (patHash*A + pat[i]) % B;
            }
        }
    }

    public static int SubstringHash(int a, int b){
        if(a == 0) return hash[b];
        int temp = (hash[b] - hash[a-1]*p[b-a+1]) % B;
        if(temp < 0) return temp + B;
        else return temp;
    }
}