// # 3009

// 세 점이 주어졌을 때, 축에 평행한 직사각형을 만들기 위해서 필요한 네 번째 점을 찾는 프로그램을 작성하시오.
import java.util.*;
class Fourth_Point{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int x[] = new int[1001];
        int y[] = new int[1001];
        for(int i = 0; i < 3; i++){
            x[sc.nextInt()]++;
            y[sc.nextInt()]++;
        }

        for(int i = 1; i < 1001; i++){
            if(x[i]%2 == 1){
                System.out.print(i + " ");
                break;
            }
        }
        for(int i = 1; i < 1001; i++){
            if(y[i]%2 == 1){
                System.out.print(i);
                break;
            }
        }
        sc.close();
    }
}