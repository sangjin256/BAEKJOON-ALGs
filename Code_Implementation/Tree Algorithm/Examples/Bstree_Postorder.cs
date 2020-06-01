/* # 5639

전위 순회 (루트-왼쪽-오른쪽)은 루트를 방문하고, 왼쪽 서브트리, 오른쪽 서브 트리를 순서대로

방문하면서 노드의 키를 출력한다. 후위 순회 (왼쪽-오른쪽-루트)는 왼쪽 서브트리,

오른쪽 서브트리, 루트 노드 순서대로 키를 출력한다. 예를 들어, 위의 이진 검색 트리의 전위 순회

결과는 50 30 24 5 28 45 98 52 60 이고, 후위 순회 결과는 5 28 24 45 30 60 52 98 50 이다.

이진 검색 트리를 전위 순회한 결과가 주어졌을 때, 이 트리를 후위 순회한 결과를 구하는

프로그램을 작성하시오.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class uz 
{
    static List<int> list = new List<int>();
    public static void Main(string[] args) {
        while(true){
            //입력제한이 없으므로 try~catch로 해결한다.
        	try{
            int temp = int.Parse(Console.ReadLine());
            list.Add(temp);
        	} catch(Exception e){break;}
        }
        MakeBFS(0, list.Count-1);
    }

    public static void MakeBFS(int left, int right){
        if(left > right) return;
        int root = list[left];
        int last = right;
        while(list[last] > root) last--;
        MakeBFS(left + 1, last);
        MakeBFS(last + 1, right);
        Console.WriteLine(root);
    }
}