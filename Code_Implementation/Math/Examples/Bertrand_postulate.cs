// # 4948

// 베르트랑 공준은 임의의 자연수 n에 대하여, n보다 크고, 2n보다 작거나 같은 소수는 적어도 하나 존재한다는

// 내용을 담고 있다. 이 명제는 조제프 베르트랑이 1845년에 추측했고, 파프누티 체비쇼프가 1850년에 증명했다.

// 예를 들어, 10보다 크고, 20보다 작거나 같은 소수는 4개가 있다. (11, 13, 17, 19) 또, 14보다 크고,

// 28보다 작거나 같은 소수는 3개가 있다. (17,19, 23)

// n이 주어졌을 때, n보다 크고, 2n보다 작거나 같은 소수의 개수를 구하는 프로그램을 작성하시오. 
using System;
class rur{
    static bool[] eratos = new bool[123456*2+1];
    public static void Main(string[] args){
        ErastosInit();
        while(true){
            int input = int.Parse(Console.ReadLine());
            if(input == 0) break;
            int result = 0;
            for(int i = input+1; i <= input*2; i++){
                if(!eratos[i]) result++;
            }
            Console.WriteLine(result);
        }

    }

    //eratos[u] == false이면 소수
    public static void ErastosInit(){
        for(int x = 2; x<= eratos.Length-1; x++){
            if(eratos[x]) continue;
            for(int u = 2*x; u <= eratos.Length-1; u+=x){
                eratos[u] = true;
            }
        }
    }
}