//구간 트리 갱신을 뒤로 미루는 방법을 사용해서 구간 단위 갱신과 구간 질의를 모두 O(logn)에 처리하는 구간트리 생성가능
//느긋한 구간 트리(Lazy Segment Tree)에서는 노드마다 두 가지 정보(s/z)를 관리
//일반적인 구간 트리의 값 저장할 정보와 각 노드마다 뒤로 미뤄둔, 즉 트리의 자식 노드로 아직 전파하지 않은 갱신 정보 저장
//느긋한 구간 트리는 구간에 속한 원소의 값을 특정 값만큼 증가시키는 것과 구간에 속한 원소를 모두 특정 원소로 바꾸는 것 처리 가능
using System;
class Lecture{
    static int[] tree;
    //뒤로 미뤄둔 갱신정보 저장할 배열
    static int[] z;
    static int[] arr = new int[]{5,8,6,3,2,7,2,6,7,1,7,5,6,2,3,2};
    public static void Main(string[] args){
        SegTreeInit();
        Add(5, 13, 2);
        Console.WriteLine(Sum(10, 13));
    }

    public static int Sum(int a, int b){
        return Sum(a, b, 1, 0, arr.Length-1);
    }

    private static int Sum(int a, int b, int k, int x, int y){
        if(k < arr.Length && z[k] > 0){
            tree[k] += z[k]*(y-x+1);
            //자식이 z배열 범위의 안쪽이면
            if((k*2+1) < arr.Length){
                z[k*2] += z[k];
                z[k*2+1] += z[k];
            }
            else{
                tree[k*2] += z[k];
                tree[k*2+1] += z[k];
            }
            z[k] = 0;
        }
        if(b < x || a > y) return 0;
        if(a <= x && y <= b){
            if(k < arr.Length){
                return tree[k]+z[k]*(y-x+1);
            }
            else return tree[k];
        }
        int d = (x + y) / 2;
        return Sum(a, b, k*2, x, d) + Sum(a, b, k*2+1, d+1, y);
    }

    //구간에 속한 원소 값을 특정 값만큼 증가시킴
    public static void Add(int a, int b, int value){
        Add(a,b,1,0,arr.Length-1,value);
    }

    private static void Add(int a, int b, int k, int x, int y, int value){
        if(k < arr.Length && z[k] > 0){
            tree[k] += z[k]*(y-x+1);
            //자식이 z배열 범위의 안쪽이면
            if((k*2+1) < arr.Length){
                z[k*2] += z[k];
                z[k*2+1] += z[k];
            }
            else{
                tree[k*2] += z[k]*(y-x+1);
                tree[k*2+1] += z[k]*(y-x+1);
            }
            z[k] = 0;
        }
        if((b < x || a > y)) return;
        if(a <= x && y <= b){
            if(k < arr.Length) z[k] += value;
            else tree[k] += value;
            return;
        }
        int d = (x+y) / 2;
        Add(a, b, k*2, x, d, value);
        Add(a, b, k*2+1, d+1, y, value);
        
        return;
    }

    public static void SegTreeInit(){
        tree = new int[arr.Length*2];
        //뒤쪽은 원래 배열이 담겨서 뒤로 미뤄둘 값이 없으므로 앞쪽만 만들어준다.
        z = new int[arr.Length];
        Array.Copy(arr, 0, tree, arr.Length, arr.Length);
        for(int i = arr.Length-1; i >= 1; i--){
            tree[i] = tree[i*2] + tree[i*2+1];
        }
    }
}