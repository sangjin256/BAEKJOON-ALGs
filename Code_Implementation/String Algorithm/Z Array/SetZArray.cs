//길이가 n인 문자열 s의 Z배열 z는 k = 0,1,...,n-1에 대해 위치 k에서 시작하는 부분 문자열
//이면서 s의 접두사이기도 한 가장 긴 문자열의 길이를 저장하는 배열이다.
//즉 z[k] = p라면 s[0...p-1]과 s[k...k+p-1]이 같으며, s[p]와 s[k+p]는 다르다는(혹은 문자열 s의 길이가
//k+p라는) 것이다.
//z배열을 구하는 방법 O(n)
//z배열의 값을 효율적으로 계산하기 위해 구간 [x,y]를 관리하며 이때 s[x...y] 는 s의
//접두사이고 z[x]의 값은 계산되어있으며, y의 값은 가능한 값중 최대여야 함
using System;
class Lecture{
    static int[] z;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        SetZArray(str);
        for(int i = 0; i < z.Length; i++){
            Console.WriteLine(i + " " + z[i]);
        }
    }

    public static void SetZArray(string str){
        z = new int[str.Length];
        int x = 0, y = 0;
        for(int k = 1; k < str.Length; k++){
            int count = 0;
            if(y < k){
                while(str[count] == str[k+count]){
                    count++;
                    if(count + k >= str.Length) break;
                }
                z[k] = count;
                if(count != 0){
                    x = k;
                    y = k + count - 1;
                }
            }

            else if(y >= k && k + z[k-x] <= y){
                z[k] = z[k-x];
            }

            else if(y >= k && k + z[k-x] > y){
                z[k] = y - k + 1;
                if(y == str.Length-1) continue;
                while(str[(y-k+1) + count] == str[(y+1) + count]){
                    count++;
                    if(y+1+count >= str.Length) break;
                }
                z[k] += count;
            }
        }
    }
}