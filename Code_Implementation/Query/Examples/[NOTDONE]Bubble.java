import java.io.*;
public class Bubble{
    static int count = 0;
    static int[] buff;
    public static void main(String[] args){
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        try{
            int n = Integer.parseInt(br.readLine());
            String[] tmparr = br.readLine().split(" ");
            int[] arr = new int[n];
            for(int i = 0; i < n; i++){
                arr[i] = Integer.parseInt(tmparr[i]);
            }
            MergeSort(arr, n);
            System.out.println(count);
            br.close();
        }catch(Exception e){e.printStackTrace();}
    }

    static void MergeSort(int[] a, int n){
        buff = new int[n];
        MergeSort_(a, 0, n-1);
        buff = null;
    }
    static void MergeSort_(int[] a, int left, int right){
        if(left < right){
            int i;
            int center = (left + right) / 2;
            int j = 0, p = 0, k = left;
            MergeSort_(a, left, center);
            MergeSort_(a, center+1, right);
            for(i = left; i <= center; i++){
                buff[p++] = a[i];
            }
            while(i <= right && j < p){
                a[k++] = (buff[j] <= a[i]) ? buff[j++] : a[i++];
                count++;
            }
            while(j < p){
                a[k++] = buff[j++];
            }
        }
    }
}