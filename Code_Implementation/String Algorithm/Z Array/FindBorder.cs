//z 배열을 사용하여 경계 찾기
//문자열의 경게는 문자열의 접두사인 동시에 접미사이고, 원래의 문자열 자신과는 다른 문자열을 말함
//예를 들어, ABACABACABA의 경계는 A, ABA, ABACABA이다.
//위치 k의 접미사가 경계일 조건은 k + z[k] = (문자열의 길이)인 경우와 동치
using System;
class yc{
    static int[] z;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        FindBorder(str);
    }

    public static void FindBorder(string str){
        SetZArray(str);
        for(int i = 0; i < z.Length; i++){
            if(i + z[i] == z.Length) Console.WriteLine(str.Substring(i, z[i]));
        }
    }

    public static void SetZArray(string str){
        z = new int[str.Length];
        int x = 0, y = 0;
        for(int k = 1; k < str.Length; k++){
            int count = 0;
            if(y < k){
                while(str[count] == str[k + count]){
                    count++;
                    if(k+count >= str.Length) break;
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