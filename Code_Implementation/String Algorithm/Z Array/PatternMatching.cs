//Z알고리즘을 사용한 패턴 매칭 패턴p와 문자열s가 있을 때 p#s의 형태로 만듬
//z배열의 위치에 대응되는 원소의 값이 p의 길이와 같으면 그곳에 패턴이 있다는 의미
using System;
class Lecture{
    static int[] z;
    public static void Main(string[] args){
        string str = Console.ReadLine();
        string pat = Console.ReadLine();
        Console.WriteLine(PatternMatching(str, pat));
    }

    public static int PatternMatching(string str, string pat){
        string patStr = pat + "#" + str;
        SetZArray(patStr);
        int count = 0;
        for(int i = 0; i < patStr.Length; i++){
            if(z[i] == pat.Length) count++;
        }

        return count;
    }

    public static void SetZArray(string str){
        z = new int[str.Length];
        int x = 0, y = 0;
        for(int k = 1; k < str.Length; k++){
            int count = 0;
            if(y < k){
                while(str[count] == str[k+count]){
                    count++;
                    if(k + count >= str.Length) break;
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
                z[k] = y-k+1;
                while(str[(y-k+1) + count] == str[(y+1) + count]){
                    count++;
                    if((y+1) + count >= str.Length) break;
                }
                z[k] += count;
            }
        }
    }
}