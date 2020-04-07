// # 2108

// 수를 처리하는 것은 통계학에서 상당히 중요한 일이다. 통계학에서 N개의 수를 대표하는 기본 통계값에는 다음과 같은 것들이 있다. 단, N은 홀수라고 가정하자.

// 산술평균 : N개의 수들의 합을 N으로 나눈 값
// 중앙값 : N개의 수들을 증가하는 순서로 나열했을 경우 그 중앙에 위치하는 값
// 최빈값 : N개의 수들 중 가장 많이 나타나는 값
// 범위 : N개의 수들 중 최댓값과 최솟값의 차이
// N개의 수가 주어졌을 때, 네 가지 기본 통계값을 구하는 프로그램을 작성하시오.
using System;

class Statistic{
    static int[] arr;
    static int[] arrMode;
    static int sum = 0;
    public static void Main(string[] args){
        int n = int.Parse(Console.ReadLine());
        arr = new int[n];
        //최빈값을 구하기위한 배열
        arrMode = new int[8001];
        for(int i = 0; i < n; i++){
            arr[i] = int.Parse(Console.ReadLine());
            arrMode[arr[i]+4000]++;
            sum += arr[i];
        }
        Array.Sort(arr);
        Console.WriteLine(Arith());
        Console.WriteLine(Mid());
        Console.WriteLine(Mode());
        Console.WriteLine(Range());
    }

    public static int Arith(){
        return (int)Math.Round(sum/(double)arr.Length, MidpointRounding.AwayFromZero);
    }

    public static int Mid(){
        return arr[arr.Length/2];
    }

    //최빈값이 영어로 mode
    public static int Mode(){
        int modeIndex = 0;
        for(int i = 1; i < 8001; i++){
            if(arrMode[i] > arrMode[modeIndex]) modeIndex = i;
        }
        for(int i = modeIndex + 1; i < 8001; i++){
            if(arrMode[i] == arrMode[modeIndex]){
                modeIndex = i;
                break;
            }
        }
        return modeIndex - 4000;
    }

    public static int Range(){
        if(arr.Length == 1) return 0;
        return arr[arr.Length-1] - arr[0];
    }
}