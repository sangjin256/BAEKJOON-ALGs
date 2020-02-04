import java.io.*;
import java.util.*;
public class ACM_Hotel{
    public static void main(String[] args){
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();
        try{
            int n = Integer.parseInt(br.readLine());
            for(int i = 0; i < n; i++){
                int[] arr = Arrays.stream(br.readLine().split(" ")).mapToInt(Integer::parseInt).toArray();
                //층수와 그 층의 방번호를 따로 만들고 나중에 합친다.
                int floor = arr[2];
                int num = 1;
                
                if(floor%arr[0] == 0){
                    sb.append(arr[0]);
                    num = floor/arr[0];
                    if(num < 10){
                        sb.append("0" + num);
                    }
                    else sb.append(num);                    
                }
                else{
                    floor = floor % arr[0];
                    sb.append(floor);
                    num += arr[2]/arr[0];
                    //이 10보다 작으면 앞에 0을 붙여준다.
                    if(num < 10){
                        sb.append("0" + num);
                    }
                    else sb.append(num);
                }
                
                System.out.println(sb);
                
                sb.setLength(0);
            }

        }catch(Exception e){e.printStackTrace();};
    }
}