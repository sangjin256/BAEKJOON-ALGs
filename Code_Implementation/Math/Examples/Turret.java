// # 1002

// 조규현과 백승환은 터렛에 근무하는 직원이다. 하지만 워낙 존재감이 없어서 인구수는 차지하지 않는다. 다음은 조규현과 백승환의 사진이다.

// 이석원은 조규현과 백승환에게 상대편 마린(류재명)의 위치를 계산하라는 명령을 내렸다.

// 조규현과 백승환은 각각 자신의 터렛 위치에서 현재 적까지의 거리를 계산했다.

// 조규현의 좌표 (x1, y1)와 백승환의 좌표 (x2, y2)가 주어지고, 조규현이 계산한 류재명과의

// 거리 r1과 백승환이 계산한 류재명과의 거리 r2가 주어졌을 때, 류재명이 있을 수 있는

// 좌표의 수를 출력하는 프로그램을 작성하시오.
import java.util.*;
class Turret{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        for(int i = 0; i < n; i++){
            int x1 = sc.nextInt();
            int y1 = sc.nextInt();
            int r1 = sc.nextInt();
            int x2 = sc.nextInt();
            int y2 = sc.nextInt();
            int r2 = sc.nextInt();
            double distance = Math.sqrt(Math.pow(x1-x2, 2) + Math.pow(y1-y2, 2));
            if(x1 == x2 && y1 == y2 && r1 == r2){
                System.out.println(-1);
                continue;
            }
            if(x1 == x2 && y1 == y2 && r1 != r2 || (distance > r1+r2) || distance < Math.abs(r1-r2)){
                System.out.println(0);
            }
            else if(distance == r1 + r2 || Math.abs(r1-r2) == distance){
                System.out.println(1);
            }
            else{
                System.out.println(2);
            }
        }
        sc.close();
    }
}