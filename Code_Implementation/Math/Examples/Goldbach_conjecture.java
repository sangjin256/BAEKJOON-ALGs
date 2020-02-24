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