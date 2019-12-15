//이진트리의 생성과 순회
//클래스를 사용해 생성한다.
//순회의 종류는 3가지가 있다.
//전위 순회(Preorder) : 루트노드 - 왼쪽 - 오른쪽
//중위 순회(Inorder) : 왼쪽 - 루트노드 - 오른쪽
//후위 순회(Postorder) : 왼쪽 - 오른쪽 루트
//전위순회랑 중위순회 또는 후위 순회와 중위 순회가 주어지면 트리의 정확한 구조를
//알아낼 수 있음 (전위순회랑 후위순회만 있을때는 불가)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//개별 노드를 나타내는 클래스
public class Node{
    public int data;
    public Node left, right;
    public Node(int data){
        this.data = data;
    }
}
//노드들을 묶은 트리를 나타내는 클래스
public class Tree{
    //루트노드
    public Node root;
    //트리에 노드를 추가하는 함수
    public void Add(int data, int leftData, int rightData){
        //루트가 비어있으면 그곳을 기준으로 채워준다.
        if(root == null){
            if(data != 0) root = new Node(data);
            if(leftData != 0) root.left = new Node(leftData);
            if(rightData != 0) root.right = new Node(rightData);
        }

        else Search(root, data, leftData, rightData);
    }
    //루트가 null이 아닐 경우 노드가 들어갈 알맞는 빈자리를 찾는 함수
    //재귀로 이루어진다.
    public void Search(Node root, int data, int leftData, int rightData){
        //root가 null일 경우 돌아간다.
        if(root == null) return;
        //맞는 자리를 찾았을 경우 값을 넣어준다.
        else if(root.data == data){
            if(leftData != 0) root.left = new Node(leftData);
            if(rightData != 0) root.right = new Node(rightData);
        }
        //둘 다 아닐경우 다시 재귀를 한다.
        else{
            Search(root.left, data, leftData, rightData);
            Search(root.right, data, leftData, rightData);
        }
    }
    public void Preorder(Node root){
        Console.Write(root.data);
        if(root.left != null) Preorder(root.left);
        if(root.right != null) Preorder(root.right);
    }
    public void Inorder(Node root){
        if(root.left != null) Inorder(root.left);
        Console.Write(root.data);
        if(root.right != null) Inorder(root.right);
    }
    public void Postorder(Node root){
        if(root.left != null) Postorder(root.left);
        if(root.right != null) Postorder(root.right);
        Console.Write(root.data);
    }
}
public class Lecture 
{
    public static void Main(string[] args) {
        Tree tree = new Tree();
        tree.Add(1,2,3);
        tree.Add(2,4,5);
        tree.Add(5,6,0);
        tree.Add(4,0,0);
        tree.Add(6,0,0);
        tree.Add(3,0,7);
        tree.Add(7,0,0);

        tree.Preorder(tree.root);
        Console.WriteLine();
        tree.Inorder(tree.root);
        Console.WriteLine();
        tree.Postorder(tree.root);
    }
}