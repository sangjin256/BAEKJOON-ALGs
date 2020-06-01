//배열을 여러 개의 블록으로 나눔으로써 효율적인 자료 구조를 만들 수 있는 경우 있음
//블록의 크기를 √n으로 두고, 각 블록에 포함된 배열의 원솟값의 정보를 따로 관리함
//배열 원소값을 갱신하는 질의와 구간에 속한 원소들의 최솟값 구하는 질의

//구간트리나 이진 인덱스트리같은 O(logn)시간보다는 느리지만 쉽게 만들 수 있음
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class ih 
{
	public static void Main(string[] args) {
        int[] arr = new int[]{5,8,6,3,4,7,2,6,7,1,7,5,6,2,3,2};
        int rootn = (int)Math.Sqrt(arr.Length);
        int[] blocks = new int[rootn];
        //전처리. 블록마다 그 블록에 속한 원소들의 최솟값을 등록한다.
        int mn = 10000;
        for(int i = 0; i < arr.Length; i++){
            mn = Math.Min(mn,arr[i]);
            blocks[i/blocks.Length] = mn;
            //다음블럭으로 넘어가면 mn값을 초기화
            if(i/blocks.Length != (i-1)/blocks.Length) mn = 10000;
        }

        //원소들의 최솟값 구하는 질의
        //시작점 a = 3, 끝점 b = 13으로 가정
        int a = 3, b = 13;
        mn = 10000;
        for(int i = 0; i < rootn; i++){
            //구간 안에 블록이 포함되어 있으면 그 부분은 원소 개별값이 아니라 블록을 비교해준다.
            if(a <= rootn*i && b >= rootn*(i+1)) mn = Math.Min(mn,blocks[i]);
            //위에서 처리한 블록을 제외한 구간은 개별적으로 비교해준다.
            else if(a > rootn*i){
                for(int k = a; k < rootn*(i+1); k++){
                    mn = Math.Min(mn, arr[k]);
                }
            }
            else if(b >= rootn*i){
                for(int k = rootn*i; k <= b; k++){
                    mn = Math.Min(mn, arr[k]);
                }
            }
        }
        Console.WriteLine(mn);

        //원솟값 갱신하는 질의
        //index = 6의 원소값을 5로 바꾸는 질의
        int index = 6;
        arr[index] = 5;
        for(int i = 0; i < rootn; i++){
            if(index >= 4*i && index < 4*(i+1)){
                mn = 10000;
                for(int k = 4*i; k < 4*(i+1); k++){
                    mn = Math.Min(mn, arr[k]);
                }
                blocks[i] = mn;
            }
        }

        Console.WriteLine(blocks[1]);
    }
}