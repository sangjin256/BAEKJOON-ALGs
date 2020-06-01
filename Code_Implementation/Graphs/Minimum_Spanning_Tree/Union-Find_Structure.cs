//유니온 파인드 자료구조
//집합마다 원소 하나가 대푯값이 되며 나머지 다른 원소에서 대표 원소로 가는 경로가 항상 존재
//두 원소가 같은 집합에 있는 경우와 두 원소의 대푯값이 같은 경우는 정확히 일치
//두 집합을 합치기 위해서는 한 집합의 대푯값을 다른 집합의 대푯값으로 이으면 됨
//원소가 더 적은 집합의 대푯값을 많은 집합의 대푯값으로 연결하는 것이 효율적(같을땐 상관없음)
using System;
using System.IO;
using System.Collections.Generic;

public class ek 
{
    //각 원소에 대해 경로상의 다음 원소 저장하는 배열(원소가 대푯값이면 자기자신 저장)
    static int[] link;
    // 각 대푯값에 대해 집합의 크기 저장
    static int[] size;
    public static void Main(String[] args){
        //원소(노드)가 6개로 가정
        link = new int[7];
        size = new int[7];

        //처음에는 각자 따로있으므로 각자가 대푯값 = 자기자신 저장
        for(int i = 1; i <= 7; i++) link[i] = i;
        for(int i = 1; i <= 7; i++) size[i] = 1;
    }
    //find함수는 x의 대푯값을 반환
    static int Find(int x){
        while(x != link[x]) x = link[x];
        return x;
    }
    //find함수를 구현하는 또다른 방법. 경로 압축(path compression)을 사용함
    //경로상의 모든 원소가 대푯값을 바로 가리키게 됨
    //이 방법을 사용하면 안되는 경우도 있으므로 확인후 사용
    static int FindWithCompression(int x){
        if(x == link[x]) return x;
        return link[x] = FindWithCompression(link[x]);
    }
    //same함수는 두 원소 a와 b가 같은 집합에 속하는지 확인
    static bool Same(int a, int b){
        return Find(a) == Find(b);
    }
    //unite함수는 원소 a와 b가 속한 집합을 합치는 함수
    //먼저 두 집합의 대푯값을 구하고, 작은 집합의 대푯값을 큰 집합의 대푯값으로 연결
    static void Unite(int a, int b){
        a = Find(a);
        b = Find(b);
        if(size[a] < size[b]) Swap(ref a, ref b);
        size[a] += size[b];
        link[b] = a;
    }

    //두 원소값 바꾸는 함수
    static void Swap(ref int a, ref int b){
        int temp = a;
        a = b;
        b = temp;
    }
}