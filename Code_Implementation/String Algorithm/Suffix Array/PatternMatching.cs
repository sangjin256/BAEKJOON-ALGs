//접미사 배열로 패턴 찾기
//배열의 범위를 관리하고 이분탐색을 사용
using System;
using System.Collections.Generic;
class yk{
    static List<(int,int,int)> list = new List<(int,int,int)>();
    static int[] suffix;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        string pat = Console.ReadLine();
        Console.WriteLine((PatternMatching(str, pat)));
    }

    public static int PatternMatching(string str, string pat){
        SetSuffixArray(str);
        //i의 최솟값을 1로 가정했으므로 문자열 범위 밖에서 시작한다.
        int x = -1, y = str.Length;
        for(int k = 0; k < pat.Length; k++){
            for(int i = str.Length; i >= 1; i /= 2){
                if(x+i <= y && x+i < suffix.Length){
                    if(suffix[x+i] + k > str.Length - 1) x++;
                    while(str[suffix[x+i] + k] < pat[k]){
                        x+=i;
                        if(x+i >= suffix.Length) break;
                    }
                }
                if(y-i > x && y- i >= 0){
                    if(suffix[y-i] + k > str.Length - 1) y--;
                    while(str[suffix[y-i]+k] > pat[k]){
                        y -= i;
                        if(y-i >= 0) break;
                    }
                }
            }
        }
        Console.WriteLine(x + " " + y);
        if(y <= x) return -1;
        return y-x-1;
    }

    public static void SetSuffixArray(string str){
        int[] arr = new int[str.Length];
        suffix = new int[str.Length];
        for(int i = 1; i <= str.Length; i<<=1){
            if(i == 1){
                for(int j = 0; j < str.Length; j++){
                    arr[j] = str[j] - 'A' + 1;
                }
            }
            else{
                for(int j = 0; j < str.Length; j++){
                    int b;
                    if(j + i/2 > str.Length - 1) b = 0;
                    else b = arr[j+i/2];
                    list.Add((arr[j], b, j+1));
                }
                list.Sort((a, b) => {if(a.Item1 > b.Item1) return 1;
                                     else if(a.Item1 < b.Item1) return -1;
                                     else{
                                        if(a.Item2 > b.Item2) return 1;
                                        else if(a.Item2 < b.Item2) return -1;
                                        else return 0;
                                     }
                                    });
                arr[list[0].Item3 - 1] = 1;
                int count = 1;
                for(int j = 1; j < list.Count; j++){
                    if((list[j-1].Item1 != list[j].Item1) || (list[j-1].Item2 != list[j].Item2)) count++;
                    arr[list[j].Item3 - 1] = count;
                }
                list.Clear();
            }
        }

        for(int i = 0; i < str.Length; i++){
            suffix[arr[i]-1] = i;
        }
    }
}