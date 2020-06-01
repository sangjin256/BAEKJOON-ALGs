//트리 순회 배열(Tree traversal array)은 루트 트리의 노드를 루트 노드에서부터 
//깊이 우선 탐색으로 방문하는 순서대로 담은 배열.

//여기서는 노드의 값을 갱신하는 질의와 서브트리에 대해 값의 합을 계산하는 질의 처리
//문제를 풀기 위해 트리 순회 배열을 만들고, 각 노드에 대해 노드의 번호, 서브트리의 크기,
//노드의 값의을 배열에 저장
//이 배열을 사용하면 서브트리의 크기를 먼저 판단한 뒤, 대응되는 노드의 값을 모두
//더하는 방식으로 값의 합을 계산 가능
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class uk 
{
    static List<int>[] adj;
    
    static int[] valtemp;
    public static void Main(string[] args) {
        //노드의 기본값들. index 0이 노드번호 1
        valtemp = new int[]{2,3,5,3,1,4,4,3,1};
        AdjacentInit(9);
        Add(1,2);
        Add(1,3);
        Add(1,4);
        Add(1,5);
        Add(2,6);
        Add(4,7);
        Add(4,8);
        Add(4,9);

        visited = new bool[10];
        num = new int[10];
        sizetemp = new int[10];
        size = new int[10];
        value = new int[10];

        Dfs(1);
        
        for(int i = 0; i < num.Length; i++){
        	size[i] = sizetemp[num[i]];
        }
        
        setTree();
        //전처리 완료
        
        //4번 노드의 서브트리에 있는 노드 값의 합 계산
        Console.WriteLine(Result(4));

    }   

    //노드번호, 서브트리의 크기, 노드의 값
    static int[] num;
    static int[] size;
    static int[] value;
    //size배열에 담기 전 임시배열
    static int[] sizetemp;

    static bool[] visited;

    static int count = 1;
    //노드 번호 배열(트리순회배열)과 노드의 값 배열을 만드는 깊이우선탐색
    static void Dfs(int s){
        visited[s] = true;
        num[count] = s;
        value[count] = valtemp[s-1];
        sizetemp[s] = 1;
        count++;
        foreach(var u in adj[s]){
            if(visited[u]){
            	continue;
            }
            Dfs(u);
            sizetemp[s]+=sizetemp[u];
        }
    }

    //배열의 마지막 행인 노드의 값을 이진 인덱스 트리로 만들어서 O(logn)시간에
    //합을 구할 수 있게 한다.
    static int[] tree;

    static void setTree(){
        tree = new int[value.Length];
        for(int k = 1; k < tree.Length; k++){
            int ki = k - (k&(-k)) + 1;
            while(ki <= k){
                tree[k] += value[ki];
                ki++;
            }
        }
    }

    //이진 인덱스 트리를 이용해서 1~k까지의 합을 구함. a~k는 1~k - 1~a-1 하면 됨
    static int treeSum(int k){
        int s = 0;
        while(k >= 1){
            s += tree[k];
            k -= k&(-k);
        }
        return s;
    }

    //노드의 값 갱신 질의. 위치 k의 값을 x만큼 '증가'시키는 함수
    static void treeAdd(int k, int x){
        value[k] += x;
        while(k <= tree.Length){
            tree[k] += x;
            k += k&(-k);
        }
    }

    static int Result(int k){
        int pos = Array.IndexOf(num, 4);
        int sz = size[pos];
        return treeSum(pos+sz-1) - treeSum(pos-1);
    }



    static void AdjacentInit(int n){
        adj = new List<int>[n+1];
        for(int i = 1; i <= n; i++){
            adj[i] = new List<int>();
        }
    }
    static void Add(int a, int b){
        adj[a].Add(b);
        adj[b].Add(a);
    }
}