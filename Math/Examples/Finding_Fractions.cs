/*
#1193

무한히 큰 배열에 다음과 같이 분수들이 적혀있다.

1/1	1/2	1/3	1/4	1/5	…
2/1	2/2	2/3	2/4	…	…
3/1	3/2	3/3	…	…	…
4/1	4/2	…	…	…	…
5/1	…	…	…	…	…
…	…	…	…	…	…

이와 같이 나열된 분수들을 1/1 -> 1/2 -> 2/1 -> 3/1 -> 2/2 -> … 과 같은 지그재그

순서로 차례대로 1번, 2번, 3번, 4번, 5번, … 분수라고 하자.

X가 주어졌을 때, X번째 분수를 구하는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
	public static void Main(string[] args) {
        //첫째 줄에 X(1 ≤ X ≤ 10,000,000)가 주어진다.
        int n = int.Parse(Console.ReadLine());
        //1 => 1개 2 =>2개 3 => 3개 이런식으로 전개된다.
        //따라서 n의 값이 count < n < count+1 사이에 있는 count를 찾고 그 사이에 있는 분수만 고르면 된다.
        int count = 0;
        int sum = 0;
        while(true){
        	count++;
        	sum+=count;
        	if(n<=sum) break;
        }
        sum-=count;
        //tmp의 수만큼 더 계산하면 값이 나온다.
        int tmp = n-sum;
        int i = count;
        string str = "";
        for(int j = 1; j <=tmp; j++){
        	if(count%2==0){
        		str = j+"/"+i;
        	}
        	else{
        		str = i+"/"+j;
        	}
        	i--;
        }
        Console.WriteLine(str);
    }
}