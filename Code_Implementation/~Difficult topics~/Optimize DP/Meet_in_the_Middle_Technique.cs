//중간 만남 기법(Meet in the middle technique)는 탐색해야 할 공간을 거의 같은 크기의 두 부분으로 나누고,
//각 부분에 대해 독립적으로 탐색을 수행한 후, 최종적으로 각 탐색의 결과를 조합하여 답을 내는 기법을 말함
//정수 n개로 구성된 집합이 주어지고, 그 집합의 부분집합 중에서 그 합이 x인 경우가 존재하는지 판별하는 문제
//여기서는 집합 {2,4,5,9}와 x = 15로 가정
//먼저 집합 A = {2,4}와 B = {5,9}로 나누고 두 개의 목록 SA = {0,2,4,6} SB = {0,5,9,14}를 만듬
//그리고 두 포인터 알고리즘을 이용하여 합이 x가 되는 경우를 SA와 SB에서 만들어낼 수 있는지 검사함
using System;
class Lecture{
    //배열이 오름차순으로 고정되어있다고 가정. 그렇지 않을 경우 CalcSubarray함수에서 sort해주어야 함
    static int[] arr = new int[]{2,4,5,9};
    const  int X = 15;
    public static void Main(string[] args){
        int[] sumA = new int[1<<(arr.Length/2)];
        int[] sumB = new int[1<<(arr.Length - arr.Length/2)];
        CalcSubarray(sumA, arr.Length/2, 0);
        CalcSubarray(sumB, arr.Length - arr.Length/2, arr.Length/2);

        Console.WriteLine(MeetInTheMiddle(sumA, sumB));
    }

    //두 포인터 알고리즘 사용
    public static bool MeetInTheMiddle(int[] subA, int[] subB){
        int y = subB.Length-1;
        for(int i = 0; i < (1<<(arr.Length/2)); i++){
            while(subA[i] + subB[y] > X) y--;
            if(subA[i] + subB[y] == X) return true;
        }

        return false;
    }

    public static void CalcSubarray(int[] sub, int n, int s){
        for(int i = 0; i <(1<<n); i++){
            int sum = 0;
            for(int k = 0; k < n; k++){
                if(Convert.ToBoolean(i & (1<<k))){
                    sum += arr[k+s];
                }
            }
            sub[i] = sum;
        }
    }
}