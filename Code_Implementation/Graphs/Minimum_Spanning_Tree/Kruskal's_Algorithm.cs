//최소 신장 트리를 구하는 크루스칼 알고리즘
//탐욕법 기반
//유니온 파인드 자료구조 사용
//최소나 최대신장트리는 유일하지 않으며 여러 개 존재 가능
//최대 신장 트리는 내림차순으로 정렬 수 풀면 된다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class ej 
{
    //각 원소에 대해 경로상의 다음 원소 저장하는 배열(원소가 대푯값이면 자기자신 저장)
    static int[] link;
    // 각 대푯값에 대해 집합의 크기 저장
    static int[] size;
    //간선 리스트를 사용한다.
    static List<(int,int,int)> edges = new List<(int,int,int)>();
    //최소 신장 트리의 간선을 넣어줄 리스트를 만든다.
    static List<(int,int,int)> MinSpanTree = new List<(int,int,int)>();
    public static void Main(String[] args){
        //원소(노드)가 6개로 가정
        link = new int[7];
        size = new int[7];

        //처음에는 각자 따로있으므로 각자가 대푯값 = 자기자신 저장
        for(int i = 1; i < 7; i++) link[i] = i;
        for(int i = 1; i < 7; i++) size[i] = 1;

        edges.Add((1,2,3));
        edges.Add((1,5,5));
        edges.Add((2,5,6));
        edges.Add((2,3,5));
        edges.Add((5,6,2));
        edges.Add((6,3,3));
        edges.Add((3,4,9));
        edges.Add((6,4,7));

        //탐욕법 기반으로 풀기 위해 가중치 순으로 정렬해준다.(오름차순)
        var query = from w in edges
                    orderby w.Item3
                    select w;

        foreach(var e in query){
            int a = e.Item1; int b = e.Item2;
            if(!Same(a,b)){
                Unite(a,b);
                MinSpanTree.Add((a,b,e.Item3));
            }
        }

        foreach(var c in MinSpanTree){
            Console.WriteLine(c.Item1 + " " + c.Item2 + " " + c.Item3);
        }
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