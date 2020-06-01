//두 문자열의 편집 거리(Edit distance) 혹은 레벤슈타인 거리(Levenshtein distance)는 첫 번째 문자열을
//두 번째 문자열로 변환하기 위해 필요한 편집 연산의 최소 횟수를 나타냄.
//허용되는 편집 연산은 글자 삽입, 글자 삭제, 글자 수정이다.
using System;
using System.IO;

class ya{
    public static void Main(string[] args){
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();

        int[,] dp = new int[str1.Length+1, str2.Length+1];
        //str1가 첫글자만 있을때와 str2가 첫글자만 있을때는 무조건 삽입해야만 하므로 미리 채워준다.
        for(int i = 0; i <= str1.Length; i++){
            dp[i,0] = i;
        }
        for(int i = 0; i <= str2.Length; i++){
            dp[0,i] = i;
        }
        for(int i = 1; i <= str1.Length; i++){
            for(int j = 1; j <= str2.Length; j++){
                //각각 글자 삽입, 글자 삭제, 글자 수정(또는 유지)을 의미한다. 이중 가장 작은 값이 dp[i,j]에 들어간다.
                dp[i,j] = Min(dp[i,j-1] + 1, dp[i-1,j] + 1, dp[i-1,j-1] + Cost(str1[i-1], str2[j-1]));
            }
        }
        Console.WriteLine(dp[str1.Length, str2.Length]);
    }

    //두 값이 일치하면 0을 반환하고(유지) 일치하지 않으면 1을 반환한다.(수정)
    public static int Cost(char a, char b){
        if(a == b) return 0;
        return 1;
    }
    
    public static int Min(int a, int b, int c){
        return (a <= b && a <= c) ? a : (b <= c) ? b : c;
    }
}