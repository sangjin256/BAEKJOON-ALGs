//트립(Treap)은 어떤 배열의 내용을 저장하고 있는 이진 트리로, 배열을 분할하여 두 개의 배열로 만들거나, 두 배열을 하나로
//병합하는 연산을 효율적으로 처리하기 위한 자료 구조
//트립의 각 노드에는 가중치와 값이 저장되어 있음 이때 각 노드의 가중치는 자식 노드의 가중치보다 작거나 같아야 한다.
//또한 각 배열상 위치는 그 노드의 왼쪽 서브트리에 속한 노드들보다 뒤에 있어야 하고, 오른쪽 서브트리에 속한 노드들보다는 앞에 있어야 함

//트립의 분할 O(logn)
//배열을 두개로 나누는 연산. 원래 배열 왼쪽의 원소 k개가 하나의 배열을 이루고, 오른쪽의 나머지 원소가 다른 배열을 이룸
//이 연산 처리를 위해 두 개의 비어있는 트립을 만들고, 원래 트립의 루트부터 탐색 수행 각 단계에서 현재 살펴보고 있는 노드가
//왼쪽 트립에 속하는 노드라면, 그 노드 및 왼쪽 서브트리를 왼쪽 트립에 추가하고 오른쪽 서브트리는 재귀적으로 처리
//오른쪽 서브트립에 속하는 노드라면, 그 노드 및 오른쪽 서브트리를 오른쪽 트립에 추가하고 왼쪽 서브트리는 재귀적으로 처리

//트립의 병합 O(logn)
//두 배열을 이어 붙여서 하나의 배열로 만드는 연산. 두 트립을 동시에 처리하며 진행하는데, 단계마다 두 트립 중 루트의 가중치가 더 작은
//쪽을 선택함. 만약 루트의 가중치가 더 작은 쪽이 왼쪽 트립이라면, 루트와 그 왼쪽 서브트리를 새 트립으로 옮기고, 오른쪽 서브트리가
//왼쪽 트립을 대체하도록 한 후 계속 진행
//이와 비슷하게 루트의 가중치가 더 작은 쪽이 오른쪽 트립이라면, 루트와 그 오른쪽 서브트리를 새 트립으로 옮기고, 왼쪽 서브트리가 오른쪽
//트립을 대체하도록 한 후 계속 진행
using System;

class Node{
    public Random rand = new Random();
    public Node left, right;
    public int weight, size, value;
    public Node(int v){
        left = right = null;
        weight = rand.Next();
        size = 1;
        value = v;
    }
}

class Treap{
    public Node root;

    public Treap(){
        root = null;
    }

    public int Size(Node treap){
        if(treap == null) return 0;
        return treap.size;
    }

    public void Split(Node treap, ref Node left, ref Node right, int k){
        if(treap == null){
            left = right = null;
        }
        else{
            if(Size(treap.left) < k){
                Split(treap.right, ref treap.right, ref right, k-Size(treap.left)-1);
                left = treap;
            }
            else{
                Split(treap.left, ref left, ref treap.left, k);
                right = treap;
            }
            treap.size = Size(treap.left) + Size(treap.right) + 1;
        }
    }

    public void Merge(ref Node treap, Node left, Node right){
        if(left == null) treap = right;
        else if(right == null) treap = left;
        else{
            if(left.weight < right.weight){
                Merge(ref left.right, left.right, right);
                treap = left;
            }
            else{
                Merge(ref right.left, left, right.left);
                treap = right;
            }
            treap.size = Size(treap.left) + Size(treap.right) + 1;
        }
    }

    public void Read(Node treap){
        if(treap.left != null) Read(treap.left);
        Console.WriteLine(treap.value);
        if(treap.right != null) Read(treap.right);
    }
}

class Lecture{
    public static void Main(string[] args){
        Treap treap = new Treap();
        treap.Merge(ref treap.root, treap.root, new Node(1));
        treap.Merge(ref treap.root, treap.root, new Node(2));
        treap.Merge(ref treap.root, treap.root, new Node(3));
        treap.Merge(ref treap.root, treap.root, new Node(4));
        Treap left = new Treap();
        Treap right = new Treap();
        treap.Split(treap.root, ref left.root, ref right.root, 2);
        treap.Merge(ref treap.root, right.root, left.root);
        treap.Read(treap.root);
    }
}