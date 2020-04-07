using System;

class SortInside{
    public static void Main(string[] args){
        string str = Console.ReadLine();
        long[] arr = new long[str.Length];
        for(int i = 0; i < str.Length; i++){
            arr[i] = long.Parse(str[i].ToString());
        }
        QuickSort(arr, 0, arr.Length-1);
        for(int i = 0; i < arr.Length; i++){
            Console.Write(arr[i]);
        }
    }

    public static void QuickSort(long[] arr, long left, long right){
        long pl = left;
        long pr = right;
        long x = arr[(pl+pr) / 2];

        do{
            while(arr[pl] > x) pl++;
            while(arr[pr] < x) pr--;
            if(pl <= pr) Swap(arr, pl++, pr--);
        } while(pl <= pr);

        if(pl <= right) QuickSort(arr, pl, right);
        if(left <= pr) QuickSort(arr, left, pr);
    }

    public static void Swap(long[] arr, long a, long b){
        long tmp = arr[a];
        arr[a] = arr[b];
        arr[b] = tmp;
    }
}