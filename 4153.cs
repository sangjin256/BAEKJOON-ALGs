// # 4153

// 과거 이집트인들은 각 변들의 길이가 3, 4, 5인 삼각형이 직각 삼각형인것을 알아냈다. 주어진 세변의 길이로 삼각형이 직각인지 아닌지 구분하시오.
using System;
class Lecture{
    public static void Main(string[] args){
        while(true){
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            if(a[0] == 0 && a[1] == 0 && a[2] == 0) break;
            int mx = 0;
            for(int i = 0; i < a.Length; i++){
                mx = Math.Max(mx, a[i]);
            }
            int mxIndex = Array.IndexOf(a, mx);
            
            int otherPow = 0;
            for(int i = 0; i < a.Length; i++){
                if(i == mxIndex) continue;
                otherPow += a[i]*a[i];
            }

            if(otherPow == mx*mx) Console.WriteLine("right");
            else Console.WriteLine("wrong");
        }
    }
}