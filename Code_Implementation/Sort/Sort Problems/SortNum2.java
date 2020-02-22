import java.util.*;
import java.io.*;
class SortNum2{
    public static void main(String[] args){
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        try{
            int n = Integer.parseInt(br.readLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++){
                arr[i] = Integer.parseInt(br.readLine());
            }
            quickSort(arr, 0, arr.length-1);
            for(int i = 0; i < n; i++){
                System.out.println(arr[i]);
            }
        } catch(Exception e){e.printStackTrace();}
    }

    public static void quickSort(int[] a, int left, int right){
        int pl = left; int pr = right;
        int x = a[(pl+pr)/2];
        do{
            while(a[pl] < x) pl++;
            while(a[pr] > x) pr--;
            if(pl <= pr) swap(a, pl++, pr--);
        } while(pl <= pr);
        if(left < pr) quickSort(a, left, pr);
        if(pl < right) quickSort(a, pl, right);
    }

    public static void swap(int[] a, int x, int y){
        int temp = a[x];
        a[x] = a[y];
        a[y] = temp;
    }
}