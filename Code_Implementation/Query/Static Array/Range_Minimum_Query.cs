using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    //min[a,b]는 구간 a~b의 최솟값을 나타냄
    static int[,] min;
	public static void Main(string[] args) {
        int[] arr = new int[]{1,3,4,8,6,1,4,2};
        //더 효율적으로 배열 길이 설정하는 방법이 필요
        //구간별로 따로 하는게 나은가?
        min = new int[arr.Length,arr.Length];
        for(int i = 0; i < arr.Length; i++){
        	//min[i,i]는 i에서 i 자기 자신까지의 최솟값이므로 자기 자신을 등록
        	min[i,i] = arr[i];
        }
        //전처리 과정
        for(int i = 2; i <= arr.Length; i<<=1){
            int a = 0;
            //0~2면 구간의 길이가 3이므로 -1해준다.
            for(int b = i-1; b < arr.Length; b++){
                Min(a++,b);
            }
        }
        Console.WriteLine(Min_Calcul(3,4));
    }
    //x는 그 구간의 길이가 몇인지 전달
    public static void Min(int a, int b){
        int w = (b - a + 1)/2;
        min[a,b] = Math.Min(min[a, a+w-1], min[a+w,b]);
    }
    
    //실제 계산할때 쓸 함수
    public static int Min_Calcul(int a, int b){
    	int temp = b-a+1;
    	//k는 b-a+1을 초과하지 않는 가장 큰 2의 거듭제곱수
    	//temp가 이미 가장 큰 2의 거듭제곱수일 경우 바로 for문이 끝나므로 k=temp로 초기화
    	int k = temp;
    	for(int i = 1; i <= b-a+1; i<<=1){
    		if((temp&(temp-1)) == 0) break;
    		k = temp&(temp-1);
    		temp = temp - 1;
    	}
    	return Math.Min(min[a,a+k-1], min[b-k+1,b]);
    }
}