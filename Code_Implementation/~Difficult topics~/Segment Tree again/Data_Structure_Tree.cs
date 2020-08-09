//구간트리의 노드에 값 하나 저장하는 대신 그 구간에 대한 정보를 관리하는 자료구조 저장 가능
//구간 [a,b]에 속한 원소 중 그 값이 x인 원소가 몇 개인지를 효율적으로 세야하는 자료구조
using System;
using System.Collections.Generic;
class Lsss{
    static Dictionary<int,int>[] dic;
    static int[] arr = new int[]{3,1,2,3,1,1,1,2};
    public static void Main(string[] args){
        TreeInit();
        foreach(var u in dic[1]){
            Console.WriteLine($"key = {u.Key}, value = {u.Value}");
        }
    }

    public static void TreeInit(){
        dic = new Dictionary<int, int>[arr.Length*2];
        for(int i = 1; i < dic.Length; i++){
            dic[i] = new Dictionary<int, int>();
            if(i >= arr.Length){
                dic[i].Add(arr[i-arr.Length], 1);
            }
        }

        for(int i = arr.Length-1; i >= 1; i--){
            foreach(var u in dic[i*2].Keys){
                if(dic[i].ContainsKey(u)){
                    dic[i][u] += dic[i*2][u];
                }
                else{
                    dic[i].Add(u, dic[i*2][u]);
                }
            }

            foreach(var u in dic[i*2+1].Keys){
                if(dic[i].ContainsKey(u)){
                    dic[i][u] += dic[i*2+1][u];
                }
                else{
                    dic[i].Add(u, dic[i*2+1][u]);
                }
            }
        }
    }
}