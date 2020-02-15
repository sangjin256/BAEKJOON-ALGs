//사전 순 첫번째 회전
//문자열의 회전은 주어진 문자열의 첫 번째 글자를 마지막으로 옮기는 과정을
//반복함으로써 만들 수 있다.
//ex) ATLAS의 회전은 ATLAS, TLASA, LASAT, ASATL, SATLA이다.
//이들 중 사전순으로 첫번째 문자열인 ASATL을 찾는 문제이다.
//효율적으로 풀기 위해서 문자열 해싱과 이분 탐색을 결합하여 사용
//문자열의 공통 접두사의 길이를 이분탐색으로 찾기(공통 접두사의 상한선보다 작으면 무조건 같고 크면 무조건 다르기
//때문에 이분탐색 가능)
//그 다음 공통 접두사의 다음 글자를 비교하여 문자열의 순서 판단.
using System;

class Lecture{
    static int[] hash, p;
    static int A = 3, B = 97;

    public static void Main(string[] args){
        string str = Console.ReadLine();
        Console.WriteLine(DicFirstRot(str));
    }

    public static string DicFirstRot(string str){
        string twiceStr = str + str;
        int left = 0;
        //twiceStr로 해시값을 만든다.
        StringToHash(twiceStr);
        for(int i = 1; i < str.Length; i++){
            int a = i, b = i + str.Length - 1;
            while(a <= b){
                int mid = (a + b) / 2;
                if(SubstringHash(left, left - i + mid) == SubstringHash(i, mid)){
                    a = mid + 1;
                }
                else b = mid - 1;
            }
            //그 다음자리 문자의 알파벳 순서도 앞의 문자열이 먼저이면 continue한다.
            if(twiceStr[left - i + a] < twiceStr[a]) continue;
            else{
                left = i;
            }
        }

        return twiceStr.Substring(left, str.Length);
    }

    public static void StringToHash(string str){
        hash = new int[str.Length];
        p = new int[str.Length];
        hash[0] = str[0];
        p[0] = 1;
        for(int i = 1; i < str.Length; i++){
            hash[i] = (hash[i-1]*A + str[i]) % B;
            p[i] = (p[i-1]*A) % B;
        }
    }

    public static int SubstringHash(int a, int b){
        if(a == 0) return hash[b];
        int temp = (hash[b] - hash[a-1]*p[b-a+1]) % B;
        if(temp < 0) return temp + B;
        else return temp;
    }
}