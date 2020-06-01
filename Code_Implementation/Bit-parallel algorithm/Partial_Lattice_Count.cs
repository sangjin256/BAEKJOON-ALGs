//부분 격자 세기
//n*n크기의 격자가 있는데, 각 지점에는 검은색(1) 또는 흰색(0)이 칠해져 있다.
//이때 네 귀퉁이에 모두 검은색이 칠해져 있는 부분 격자의 개수를 구하려 한다.
//c++의 비트셋이 없으므로 O(n3)이 나온다.
//그래도 무차별알고리즘으로 하는것보다는 비트를 쓰는게 좀더 빠르다는 결론이 나옴
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class qm 
{
    //bitarray로 만들어도 됨(더 빠른지는 아직 미확인)
    static int[] row = {Convert.ToByte("01001",2),
                        Convert.ToByte("01100",2),
                        Convert.ToByte("10000",2),
                        Convert.ToByte("01101",2),
                        Convert.ToByte("00000",2)};
	public static void Main(string[] args) {
        int sum = 0;
        for(int i = 0; i < row.Length; i++){
            for(int j = i+1; j < row.Length; j++){
                int temp = row[i]&row[j];
                int count = 0;
                for(int k = 0; temp!= 0; k++){
                    temp&=(temp-1);
                    count++;
                }
                //첫째 행이 i이고 마지막 행이 j인 부분 격자의 개수를 구하는 공식
                sum += count*(count-1)/2;
            }
        }
        Console.WriteLine(sum);
    }
}