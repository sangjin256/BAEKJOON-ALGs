//모스 알고리즘(모 알고리즘)
//정적 배열에 대한 구간 질의의 집합을 처리하는 알고리즘
//처리해야 할 질의는 구간 [a,b]에 속하는 배열 원소들을 이용하여 어떤 값을 계산하라는 형태
//여러가지 쿼리 구간이 미리 제시되고 그 구간들을 처리해야 한다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{
    static int[] cnt;
    static int[] arr;
    //서로 다른 것 카운팅하기 위한 변수
    static int distinctNumbers;

    //오른쪽 끝점을 오른쪽 칸으로 이동할 때 cnt[오른쪽 값]이 한개가 되면 distinctNubers도 +1한다.
    //서로 다른 숫자를 카운팅하는 것이므로 cnt[x]가 2 이상이 되면 의미가 없다.
    public static void Add(int x){
        if(++cnt[x] == 1){
            ++distinctNumbers;
        }
    }

    //왼쪽 칸이 오른쪽으로 이동할 때 cnt[원래 왼쪽 칸]이 0이 되면 distinctNumbers에서 제거
    public static void Erase(int x){
        if(--cnt[x] == 0){
            --distinctNumbers;
        }
    }

    //쿼리의 시작지점과 끝지점, 그리고 쿼리를 정렬하면 순서가 틀려지기 때문에
    //원래 순서를 포함할 3개의 int형 변수를 넣어준다.
    static List<(int,int,int)> list = new List<(int,int,int)>();
	public static void Main(string[] args) {
        arr = new int[]{4,2,5,4,2,4,3,3,4};
        //cnt[x]는 그 구간에서 원소 x가 들어있는 갯수를 의미하므로 arr배열에서
        //원소의 최댓값을 구해야 한다.(여기서는 그냥 보이는대로 정하겠다.)
        cnt = new int[6];
        //쿼리를 미리 설정해둠
        list.Add((1,4,0));
        list.Add((2,6,1));
        list.Add((3,5,2));
        list.Add((2,4,3));
        //쿼리를 정렬하는데 정렬기준 아래와 같다.
        //주어진 배열을 원소가 k=O(√n)인 블록으로 나눈다.
        //쿼리 [a1,b1]이 다음 조건을 만족한다면 이를 구간 [a2,b2]보다 먼저 처리
        //|a1/k| < |a2/k|이거나
        //|a1/k| = |a2/k|이고 b1<b2
        int k = (int)Math.Sqrt(arr.Length);
        list.Sort((a,b) => { int xk = a.Item1/k;
                         int yk = b.Item1/k;
                         return xk == yk ? a.Item2 == b.Item2 ? 0 : a.Item2 < b.Item2 ? -1 : 1 : xk < yk ? -1 : 1;
                         /*
                         if(xk == yk){
                         	if(a.Item2 < b.Item2) return -1;
                         	else if(a.Item2 == b.Item2) return 0;
                         	else return 1;
                         }
                         else{
                         	if(xk < yk) return -1;
                         	else return 1;}
                        */
                         });
        
        //초기 쿼리의 시작과 끝은 0
        int start = 0, end = 0;
        Add(arr[0]);
        //원래 순서대로 답을 저장할 배열
        int[] ans = new int[list.Count];
        foreach(var c in list){
            int nextStart = c.Item1, nextEnd = c.Item2;
            //start를 nextStart로 움직이는 부분
            //1. start가 nextStart보다 왼쪽에 있는 경우 수를 제거
            for(int i = start; i <nextStart; i++){
                Erase(arr[i]);
            }
            //2. start가 nextStart보다 오른쪽에 있는 경우 수를 더함
            for(int i = start-1; i >= nextStart; i--){
                Add(arr[i]);
            }
            //end를 nextEnd로 움직이는 부분
            //1. end가 nextEnd보다 왼쪽에 있는 경우 수를 더함
            for(int i = end+1; i <= nextEnd; i++){
                Add(arr[i]);
            }
            //2. end가 nextEnd보다 오른쪽에 있는 경우 수를 제거
            for(int i = end; i > nextEnd; i--){
                Erase(arr[i]);
            }
            //다음 쿼리를 현재쿼리로 바꿈
            start = nextStart;
            end = nextEnd;

            ans[c.Item3] = distinctNumbers;
        }

        for(int i = 0; i < ans.Length; i++){
            Console.WriteLine(ans[i]);
        }
    }
}