//구간 단위 갱신
//배열을 구간 단위로 갱신하고 개별 원소의 값을 질의하는 경우 사용
//여기서는 위치가 구간[a,b]에 속하는 모든 원소의 값을 x만큼 증가시키는 연산에 초점
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{	
    static int[] arr;
    static int[] diff;
    public static void Main(string[] args) {
        arr = new int[]{3,3,1,1,1,5,2,2};
        //차이 배열을 만들어준다.
        //원래 배열에서 연달아 있는 두 원소의 차이값을 저장하는 배열
        //그러면 원래 배열은 차이 배열의 누적 합 배열이 됨
        //이를 이용하면 원래 배열에 대해 구간 단위 갱신을 처리하기 위해 차이 배열의
        //원소를 두 개만 수정해도 된다는 장점이 있음.
        diff = new int[arr.Length];
        diff[0] = arr[0];
        for(int i = 1; i < arr.Length; i++){
            diff[i] = arr[i] - arr[i-1];
        }

        Add(1,4,3);
        for(int i = 0; i < arr.Length; i++){
            Console.WriteLine(arr[i]);
        }
    }

    //구간 a,b의 값을 전부 x만큼 증가시키는 함수
    //차이 배열의 위치 a의 원소를 x만큼 증가시키고 위치 b+1의 원소는 x만큼 감소시키면 됨
    public static void Add(int a, int b, int x){
        diff[a] += x;
        diff[b+1] -= x;
        for(int i = a; i <= b; i++){
            arr[i] = arr[i-1] + diff[i];
        }
    }
}