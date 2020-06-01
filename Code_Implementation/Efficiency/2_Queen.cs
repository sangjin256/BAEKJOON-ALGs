using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class wa 
{
	public static void Main(string[] args) {
        int n = 4;
        int[] dp = new int[n+1];
        dp[1] = 0;
        dp[2] = 0;
        //점화식을 사용
        //n*n의 마지막 행과 열에 퀸 배치 안한다면 dp[n-1]이 되고, 마지막 행과 열에 퀸을 배치할 수 있는
        //칸의 개수는 2n-1, 그 퀸이 공격할 수 있는 칸의 개수는 3(n-1). 따라서 두번째 퀸을 배치할 수 있는
        //칸의 개수는 n*n-3(n-1)-1 마지막으로, 마지막 행과 열에 퀸 2개를 모두 배치하는 방법의 수가 (n-1)(n-2)
        //이러한 경우를 2번 계산했으므로 이만큼 더 빼줘야함
        //따라서 dp[n] = dp[n-1] + (2n-1)(n*n-3(n-1)-1)-(n-1)(n-2)
        for(int i = 3; i < n+1; i++){
            dp[i] = dp[i-1] + 2*(i-1)*(i-1)*(i-2);
        }
        Console.WriteLine(dp[n]);

    }
}