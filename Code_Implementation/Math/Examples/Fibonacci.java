import java.util.*;

class Fibonacci{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        System.out.println(Fibo(n));
        sc.close();
    }

    public static int Fibo(int n){
        Queue<Integer> q = new LinkedList<Integer>();
        q.offer(0);
        q.offer(1);
        int count = 0;
        while(count < n){
            int a = q.poll();
            int b = q.peek();
            q.offer(a+b);
            count++;
        }
        return q.peek();
    }
}