// # 9020

// 1보다 큰 자연수 중에서  1과 자기 자신을 제외한 약수가 없는 자연수를 소수라고 한다. 예를 들어, 5는 1과

// 5를 제외한 약수가 없기 때문에 소수이다. 하지만, 6은 6 = 2 × 3 이기 때문에 소수가 아니다.

// 골드바흐의 추측은 유명한 정수론의 미해결 문제로, 2보다 큰 모든 짝수는 두 소수의 합으로 나타낼 수 있다는

// 것이다. 이러한 수를 골드바흐 수라고 한다. 또, 짝수를 두 소수의 합으로 나타내는 표현을 그 수의 골드바흐

// 파티션이라고 한다. 예를 들면, 4 = 2 + 2, 6 = 3 + 3, 8 = 3 + 5, 10 = 5 + 5, 12 = 5 + 7, 14 = 3 + 11,

// 14 = 7 + 7이다. 10000보다 작거나 같은 모든 짝수 n에 대한 골드바흐 파티션은 존재한다.

// 2보다 큰 짝수 n이 주어졌을 때, n의 골드바흐 파티션을 출력하는 프로그램을 작성하시오. 만약 가능한 n의

// 골드바흐 파티션이 여러 가지인 경우에는 두 소수의 차이가 가장 작은 것을 출력한다.

import java.io.*;
class Goldbach_conjecture{
    public static boolean[] eratos = new boolean[10001];
    public static void main(String[] args){
        eratosInit();
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        try{
            int n = Integer.parseInt(br.readLine());
            for(int k = 0; k < n; k++){
                int num = Integer.parseInt(br.readLine());
                //주어진 값을 반으로 나눠서 그 값으로부터 점점 작아지게 계산
                //소수의 차지가 가장 작은 것을 출력해야함으로 위의 방식대로 한다.
                for(int i = num/2; i >= 2; i--){
                    if(eratos[i] == false){
                        if(eratos[num-i] == false){
                            System.out.println(i + " " + (num-i));
                            break;
                        }
                    }
                }
            }
        }catch(Exception e){e.printStackTrace();}
    }

    public static void eratosInit(){
        for(int i = 2; i <= eratos.length-1; i++){
            if(eratos[i]) continue;
            for(int j = i*2; j <= eratos.length-1; j+=i){
                eratos[j] = true;
            }
        }
    }
}