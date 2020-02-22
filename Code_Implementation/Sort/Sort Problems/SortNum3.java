import java.io.*;
class SortNum3{
    public static void main(String[] args){
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        try{
            int n = Integer.parseInt(br.readLine());
            int[] arr = new int[n];
            for(int i = 0; i < n; i++){
                arr[i] = Integer.parseInt(br.readLine());
            }
            countSort(arr);
        } catch(Exception e){e.printStackTrace();}
    }

    public static void countSort(int[] a){
        BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
        int[] count = new int[10001];
        for(int i = 0; i < a.length; i++){
            count[a[i]]++;
        }
        try{
            for(int i = 0; i < count.length; i++){
                if(count[i] == 0) continue;
                int num = 0;
                while(count[i] != num){
                    bw.write(i + "\n");
                    num++;
                }
            }
            bw.close();
        }catch(Exception e){e.printStackTrace();}
    }

    public static void swap(int[] a, int x, int y){
        int temp = a[x];
        a[x] = a[y];
        a[y] = temp;
    }
}