// # 1181

// 알파벳 소문자로 이루어진 N개의 단어가 들어오면 아래와 같은 조건에 따라 정렬하는 프로그램을 작성하시오.

// 1. 길이가 짧은 것부터
// 2. 길이가 같으면 사전 순으로
using System;

class WordSort{
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        string[] strarr = new string[n];
        for(int i = 0; i < n; i++){
            strarr[i] = Console.ReadLine();
        }

        Array.Sort(strarr, (a, b) => {
                                      if(a.Length < b.Length) return -1;
                                      else if(a.Length > b.Length) return 1;
                                      else return StringComparison(a, b);
        });

        for(int i = 0; i < strarr.Length; i++){
            Console.WriteLine(strarr[i]);
        }
    }

    public static int StringComparison(string a, string b){
        int i;
        for(i = 0; i < a.Length; i++){
            if(a[i] != b[i]) break;
        }
        if(a[i] > b[i]) return 1;
        else if(a[i] < b[i]) return -1;
        else return 0;
    }
}

class 