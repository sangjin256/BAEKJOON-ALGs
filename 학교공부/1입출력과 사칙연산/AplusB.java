
// import java.util.*;
import java.io.*;
public class AplusB {
    public static void main(String[] args){
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        try{
            String[] str = br.readLine().split(" ");
            int a = Integer.parseInt(str[0]);
            int b = Integer.parseInt(str[1]);
            System.out.println(a+b);
            br.close();
        }
        catch(IOException e){e.printStackTrace();}
        
        // try{
        //     // map은 연산의 결과로 Stream타입의 스트림을 반환(컬랙션 Map이 아님!)
        //     int[] arr = Arrays.stream(br.readLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        //     System.out.println(arr[0]+arr[1]);
        //     br.close();
            
        // }
        // catch(IOException e){e.printStackTrace();}





        // Scanner sc = new Scanner(System.in);
        // int a = sc.nextInt(), b = sc.nextInt();
        // System.out.println(a+b);
        // sc.close();
    }
}