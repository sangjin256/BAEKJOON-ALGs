/*
# 1541

세준이는 양수와 +, -, 그리고 괄호를 가지고 길이가 최대 50인 식을 만들었다.

그리고 나서 세준이는 괄호를 모두 지웠다.

그리고 나서 세준이는 괄호를 적절히 쳐서 이 식의 값을 최소로 만들려고 한다.

괄호를 적절히 쳐서 이 식의 값을 최소로 만드는 프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
public class h 
{
	public static void Main(string[] args) {
        string pattern = @"([-+*/])";
        //string을 이용해서 한번에 받아준다.
        string expressions = Console.ReadLine();
        //마이너스가 나오기 전을 체크
        bool minus = false;
        //마이너스가 나오기 전값을 더함
        int tmp = 0;
        //마이너스 이후 값 더함
        int b = 0;
        //정규식을 사용해 숫자와 연산자를 구분해준다.
        //이 문제의 핵심은 +-에 상관없이 괄호를 씌운다는 것
        //55-50+40-10
        // -> 55-(50+40)-10 첫 -부터 다음 -가 나올때까지를 더하면
        // -> 55-(50+40+10)으로 변경가능
        //따라서 - 전까지의 값들을 더해주고 - 이후의 값들을 따로 더해준담에 빼면된다.
        String[] elements = System.Text.RegularExpressions.Regex.Split(expressions, pattern);
		for(int i = 0; i < elements.Length; i++){
			if(elements[i]=="-"){
				minus = true;
			}
			
			if(elements[i]!="+"&&elements[i]!="-"){
				if(!minus){
					tmp+=int.Parse(elements[i]);
				}
				else{
					b+=int.Parse(elements[i]);
					
				}
			}
		}

        Console.WriteLine(tmp-b);
    }
}