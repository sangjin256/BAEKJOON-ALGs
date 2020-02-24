// # 1085

// 한수는 지금 (x, y)에 있다. 직사각형의 왼쪽 아래 꼭짓점은 (0, 0)에 있고, 오른쪽 위 꼭짓점은 (w, h)에 있다.

// 직사각형의 경계선까지 가는 거리의 최솟값을 구하는 프로그램을 작성하시오.

import java.util.*;
class EscapeFromRect{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int x = sc.nextInt();
        int y = sc.nextInt();
        int w = sc.nextInt();
        int h = sc.nextInt();
        
        System.out.println(Math.min(Math.min(w-x, x), Math.min(h-y,y)));
    }
}