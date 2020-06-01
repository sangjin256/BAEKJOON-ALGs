//동적 구간 트리(Dynamic Segment Tree) : 알고리즘 수행 과정에서 실제로 접근하게 되는 노드에만 메모리를 할당하는
//자료 구조 -> 메모리 양 크게 절약 가능
//희소 구간 트리(Sparse Segment Tree) : 처음에는 값이 0인 노드 [0,n-1]한 개로 이루어져 있으며 이는 배열의 모든 값이
//0임을 의미. 원소를 갱신할 때 트리에 동적으로 노드를 추가한다. k개의 연산을 처리하고 나면 트리의 노드 수가 O(klogn)개가 됨
using System;
class Node{
    public int value; //현재 노드의 값
    public int x, y; //현재 노드의 범위
    public Node left, right; //자식노드
    public Node(int v, int x, int y){
        this.value = v;
        this.x = x;
        this.y = y;
    }
}

class Tree{
    Node root;
    public Tree(int n){
        root = new Node(0, 0, n-1);
    }

    //위치 k의 값을 value 만큼 더하는 함수
    public void Add(int k, int value){
        int x = root.x;
        int y = root.y;
        root.value += value;
        Node node = root;
        while(x!=k || y!= k){
            int d = (x+y) / 2;
            if(k <= d){
                if(node.left == null) node.left = new Node(value, x, d);
                else node.left.value += value;
                node = node.left;
                y = d;
            }
            else if(k > d){
                if(node.right == null) node.right = new Node(value, d+1, y);
                else node.right.value += value;
                node = node.right;
                x = d+1;
            }
        }
    }

    public int Sum(int a, int b){
        return Sum(root,a,b);
    }

    public int Sum(Node node, int a, int b){
        if(node == null) return 0;
        if(b < node.x || a > node.y) return 0;
        if(a <= node.x && node.y <= b) return node.value;
        return Sum(node.left, a, b) + Sum(node.right, a, b);
    }
}

class if{
    public static void Main(string[] args){
        Tree tree = new Tree(16);
        tree.Add(3, 2);
        tree.Add(10, 4);
        Console.WriteLine(tree.Sum(8,15));
    }
}