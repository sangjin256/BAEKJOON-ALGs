//특정한 동적 계획법 문제를 풀 때 분할 정복 최적화 기법(divide and conquer optimization technique)를 사용할 수 있음
//원소 n개로 이루어진 수열 s1,s2,s3,...,sn이 주어질 때, 연속한 원소로 이루어진 부분 수열 k개로 원래의 수열을 나눠야 한다고 해보자.
//이때 비용함수 cost(a,b)도 주어지는데, 이는 부분 수열 s(a), s(a+1),...,s(b)를 생성하는 데 드는 비용을 의미
//수열을 나누는 데 드는 전체 비용은 각각의 부분 수열을 생성하는 데 드는 비용의 합. 이 비용이 최소가 되도록 수열을 나누는 문제
//여기서 cost(a,b) = (s(a) + s(a+1) + ... + s(b))^2로 가정
//solve[i,j]를 수열 앞부분의 원소 i개를 부분 수열 j개로 나누는 최소 비용이라고 정의할때 이 문제의 대한 답은 sovlve[n,k]
//solve[i,j]를 구하려면 solve[p-1,j-1] + cost(p,i)를 최소화하는 위치 1<=p<=i인 p를 찾아야함
//분할 정복 최적화 기법은 비용 함수에 대한 다음의 사각 부등식이 모든 a <= b <= c <= d에 대해 성립할 때 사용할 수 있다.
//cost(a,c) + cost(b,d) <= cost(a,d) + cost(b,c)
//이때 pos(i,j) <= pos(i+1,j)이 모든 i,j에 대해 성립한다는 것도 보장됨
using System;
class un{
    static int[] arr = new int[]{2,3,1,2,2,3,4,1};
    static int[,] solve;
    public static void Main(string[] args){
        int k = int.Parse(Console.ReadLine());
        //이 문제에서 index는 1부터 시작한다.
        solve = new int[arr.Length+1, k+1];
        //초기화
        Init();

        for(int j = 2; j <= k; j++){
            Calc(j, 1, arr.Length, 1, arr.Length);
        }

        Console.WriteLine(solve[arr.Length, k]);
    }

    public static void Calc(int j, int a, int b, int x, int y){
        int z = (a + b) / 2;
        int p = 1;
        //최대값으로 미리 초기화해준다.
        
        solve[z,j] = 100000000;
        for(int i = x; i <= y; i++){
            if(i > z) break;
            int temp = solve[i-1,j-1] + Cost(i,z);
            if(solve[z,j] > temp){
                solve[z,j] = temp;
                p = i;
            }
        }
        Console.WriteLine($"solve[{z},{j}] = {solve[z,j]}, p = {p}");
        //Console.WriteLine($"j = {j}, a = {a}, b = {b}, x = {x}, y = {y}, p = {p}");
        if(a <= z-1) Calc(j, a, z-1, x, p);
        if(b >= z+1) Calc(j, z+1, b, p, y);
    }

    public static void Init(){
        for(int i = 1; i < solve.GetLength(0); i++){
            solve[i,1] = Cost(1,i);
        }
    }
    //index가 1부터 시작하므로 i-1을 해준다.
    public static int Cost(int a, int b){
        int sum = 0;
        for(int i = a; i <= b; i++){
            sum+=arr[i-1];
        }
        return sum*sum;
    }
}