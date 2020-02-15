//LCP(Longest common prefix) 배열 : 접미사 배열에서 현재 접미사와 다음 접미사의 최장 공통 접두사를 저장하는 배열
//(경우에 따라 현재 접미사와 이전 접미사의 최장 공통 접두사를 구할수도 있음)
//LCP값이 x인 접미사를 생각해볼때 이 접미사에서 첫 번째 글자를 제거한 접미사의 LCP값은
//최소한 x-1이 되어야 함을 알 수 있다.
//이 관찰을 기반으로 접미사 길이의 내림차순으로 계산함으로써 효율적으로 LCP배열 구하기 가능
using System;
using System.Collections.Generic;
class Lecture{
    static int[] suffix, LCP;
    static List<(int,int,int)> list = new List<(int, int, int)>();
    public static void Main(string[] args){
        string str = Console.ReadLine();
        SetLCP(str);
        for(int i = 0; i < str.Length; i++){
            Console.WriteLine(LCP[i]);
        }
    }

    public static void SetLCP(string str){
        SetSuffixArray(str);
        LCP = new int[str.Length];
        //접미사 길이의 내림차순으로 계산해야 하므로 접미사 배열의 위치와 값을 바꾸기 위한 배열을 생성
        int[] pos = new int[str.Length];
        int index = 0;
        for(int i = 0; i < str.Length; i++){
            pos[suffix[i]] = i;
        }

        for(int i = 0; i < str.Length; i++){
            int k = pos[i];
            if(k+1 <= str.Length-1){
                int j = suffix[k+1];
                if(i + index >= str.Length || j + index >= str.Length){
                    index--;
                    continue;
                }
                while(str[i+index] == str[j+index]){
                    index++;
                    if(i + index >= str.Length || j + index >= str.Length) break;
                }
            }
            LCP[k] = index;
            if(index > 0) index--;
        }
    }

    public static void SetSuffixArray(string str){
        int[] arr = new int[str.Length];
        suffix = new int[str.Length];
        for(int i = 1; i <= str.Length; i<<= 1){
            if(i == 1){
                for(int j = 0; j < str.Length; j++){
                    arr[j] = str[j] - 'A' + 1;
                }
            }
            else{
                for(int j = 0; j < str.Length; j++){
                    int b;
                    if(j + i/2 > str.Length-1) b = 0;
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
                arr[list[0].Item3-1] = 1;
                int count = 1;
                for(int j = 1; j < list.Count; j++){
                    if(list[j-1].Item1 != list[j].Item1 || list[j-1].Item2 != list[j].Item2) count++;
                    arr[list[j].Item3-1] = count;
                }
                list.Clear();
            }
        }

        for(int i = 0; i < str.Length; i++){
            suffix[arr[i]-1] = i;
        }
    }
}