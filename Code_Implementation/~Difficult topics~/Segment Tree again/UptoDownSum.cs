//구간트리에서 고급구간트리를 사용할 때에는 연산을 위에서 아래의 순서로 구현해야 하는
//경우가 많이 생김
//tree[0]은 사용 X!!!!

using System;

class ig{
    public static int[] tree;
    public static int[] arr;
    public static void Main(string[] args){
        arr = new int[]{5,8,6,3,2,7,2,6,7,1,7,5,6,2,3,2};
        SegTreeInit();
        Console.WriteLine(Sum(5, 13));
    }

    //위에서 아래로 연산하는 sum 함수
    //a,b,x,y값은 tree배열의 index값이 아닌 원래 배열 arr의 index값이다.
    public static int Sum(int a, int b, int k, int x, int y){
        if(b < x || a > y) return 0;
        if(a <= x && y <= b){
            Console.WriteLine(k + " " + tree[k]);
            return tree[k];
        }
        int d = (x+y) / 2;
        return Sum(a, b, k*2, x, d) + Sum(a, b, k*2+1, d+1, y);
    }
    public static int Sum(int a, int b){
        return Sum(a, b, 1, 0, arr.Length-1);
    }
    
    public static void Add(int x, int k){
        k += arr.Length;
        tree[k] += x;
        for(k /= 2; k >= 1; k /= 2){
            tree[k] = tree[k*2] + tree[k*2+1];
        }
    }

    public static void SegTreeInit(){
        tree = new int[arr.Length*2];
        Array.Copy(arr, 0, tree, arr.Length, arr.Length);
        for(int i = arr.Length-1; i >= 0; i--){
            tree[i] = tree[i*2] + tree[i*2+1];
        }
    }
}