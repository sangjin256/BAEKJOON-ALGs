// *
// **
// ***
// **
// *
import java.util.*;

class Starts13{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int count = 1;
        for(int i = 1; i < n*2; i++){
            for(int s = 0; s < count; s++){
                System.out.print("*");
            }
            System.out.println();
            if(i < n) count++;
            else count--;
        }
        sc.close();
    }
}