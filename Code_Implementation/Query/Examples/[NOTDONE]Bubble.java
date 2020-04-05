import java.io.*;
class Bubble{
    static int count = 0;
    public static void main(String[] args){
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        try{
            int n = Integer.parseInt(br.readLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++){
                arr[i] = Integer.parseInt(br.readLine());
            }
            BubbleSort(arr, n);
            System.out.println(count);
            br.close();
        }catch(Exception e){e.printStackTrace();}
    }

    public static void BubbleSort(int[] a, int n){
        int k = 0;
        while(k < n-1){
            int last = n-1;
            for(int i = n-1; i > k; i--){
                if(a[i-1] > a[i]){
                    Swap(a,i-1,i);
                    last = i;
                    count++;
                }
            }
            k = last;
        }
    }

    public static void Swap(int[] a, int x, int y){
        int tmp = a[x];
        a[x] = a[y];
        a[y] = tmp;
    }
}