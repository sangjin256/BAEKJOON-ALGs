//커누스의 최적화 기법 O(n^2) : 원소 n개로 이루어진 수열 s1,s2,s3,...,sn이 주어질 때 수열을 각각의 원소 단위로 쪼개야 한다.
//이때 비용 함수 cost(a,b)도 주어지는데, 이는 부분 수열 s(a), s(a+1),...,s(b)를 처리하는데 드는 비용이다.
//문제는 수열을 쪼개는 데 드는 비용의 총합을 최소화하는 것
//여기서 cost(a,b) = s(a) + s(a+1) + ... + s(b)라고 가정
//solve(i,j)를 수열 s(i), s(i+1), ..., s(j)를 원소 단위로 쪼개는 최소 비용으로 정의할때 이 문제에 대한 답은 solve(1,n)
//답을 구하기 위해서는 cost(i,j) + solve(i,p) + solve(p+1,j)를 최소화하는 위치 i <= p < j를 찾아야됨
using System;
class um{
    static int[] arr = new int[]{2,7,3,2,5};
    static int[,] solve, pos;
    public static void Main(string[] args){
        solve = new int[arr.Length+1, arr.Length+1];
        pos = new int[arr.Length+1, arr.Length+1];
        Knuth();
        Console.WriteLine(solve[1,arr.Length]);
    }

    public static void Knuth(){
        for(int i = 1; i <= arr.Length; i++){
            pos[i,i] = i;
        }
        for(int round = 2; round <= arr.Length; round++){
            for(int i = 1; i <= arr.Length; i++){
                int j = round + i - 1;
                if(j > arr.Length) continue;
                solve[i,j] = 10000;
                for(int p = pos[i,j-1]; p <= pos[i+1,j]; p++){
                    if(p < j){
                        int temp = Cost(i,j) + solve[i,p] + solve[p+1,j];
                        if(solve[i,j] > temp){
                            solve[i,j] = temp;
                            pos[i,j] = p;
                        }
                    }
                }
            }
        }
    }

    public static int Cost(int a, int b){
        int sum = 0;
        for(int i = a; i <= b; i++){
            sum += arr[i-1];
        }
        return sum;
    }
}