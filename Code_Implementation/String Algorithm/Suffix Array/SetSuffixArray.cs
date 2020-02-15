//접미사 배열은 접미사의 사전순 순서를 나타내는 배열
//접미사 배열의 값은 접미사가 시작하는 위치를 나타냄
//접미사 배열을 만드는 효율적인 방법은 접두사를 두 배씩 늘려가며 만드는 방법
//일반 sort함수를 사용하면 O(nlog^2(n))이고 선형시간 정렬 알고리즘 사용히 O(nlogn)
//그러나 일반 sort함수 사용도 충분히 빠름
using System;
using System.Collections.Generic;
class Lecture{
    //정렬시 원래 인덱스값이 유지되지 않으므로 원래 인덱스값을 Item3에 넣어준다.
    static List<(int,int,int)> list = new List<(int, int, int)>();
    static int[] suffix;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        SetSuffixArray(str);
        for(int i = 0; i < suffix.Length; i++){
            Console.WriteLine(suffix[i]);
        }        
    }

    public static void SetSuffixArray(string str){
        int[] arr = new int[str.Length];
        suffix = new int[str.Length];
        for(int i = 1; i <= str.Length; i <<= 1){
            if(i == 1){
                for(int j = 0; j < str.Length; j++){
                    arr[j] = str[j]-64;
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
                    //정렬을 했는데 Item1값이나 Item2값들이 다르면 순서가 바뀐다.
                    if((list[j-1].Item1 != list[j].Item1) || (list[j-1].Item2 != list[j].Item2)) count++;
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