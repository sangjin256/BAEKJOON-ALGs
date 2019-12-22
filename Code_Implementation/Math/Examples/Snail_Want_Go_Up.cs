/*
# 2869

땅 위에 달팽이가 있다. 이 달팽이는 높이가 V미터인 나무 막대를 올라갈 것이다.

달팽이는 낮에 A미터 올라갈 수 있다. 하지만, 밤에 잠을 자는 동안 B미터 미끄러진다.

또, 정상에 올라간 후에는 미끄러지지 않는다. 달팽이가 나무 막대를 모두 올라가려면,

며칠이 걸리는지 구하는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture
{
	public static void Main(string[] args) {
        // A, B, V
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
        //하루에 A-B씩 올라가지만 성공한 날에는 A만 올라가고 떨어지지 않으므로 마지막 전날까지 총 V-B미터를 올라가게
        //되는 것과 같다. 만약 (V-B)/(A-B)가 나누어떨어지지 않으면 몫에 +1한 것이 정답이지만 애매하니까 (V-B)에 1을 미리
        //빼놓고 몫에 무조건 1을 더하는 것으로 처리한다. 
        day = (arr[2] - arr[1] - 1) / (arr[0] - arr[1]) + 1;

        Console.WriteLine(day);
    }
}