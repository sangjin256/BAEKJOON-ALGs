/*
# 1991

이진 트리를 입력받아 전위 순회(preorder traversal), 중위 순회(inorder traversal),

후위 순회(postorder traversal)한 결과를 출력하는 프로그램을 작성하시오.

예를 들어 위와 같은 이진 트리가 입력되면,

전위 순회한 결과 : ABDCEFG // (루트) (왼쪽 자식) (오른쪽 자식)
중위 순회한 결과 : DBAECFG // (왼쪽 자식) (루트) (오른쪽 자식)
후위 순회한 결과 : DBEGFCA // (왼쪽 자식) (오른쪽 자식) (루트)
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Node{
    public char data;
    public Node left, right;
    public Node(char data){
        this.data = data;
    }
}

public class Tree{
    //루트 노드. 처음엔 null상태이다.
    public Node root;
    public void Add(char data, char leftData, char rightData){
        if(root == null){
            if(data != '.') root = new Node(data);
            if(leftData != '.') root.left = new Node(leftData);
            if(rightData != '.') root.right = new Node(rightData);
        }
        //최초 상태가 아니면 어디에 들어가야하는지 찾는다.
        else Search(root, data, leftData, rightData);
    }
    //재귀를 사용해서 찾는다.
    private void Search(Node root, char data, char leftData, char rightData){
        //도착 노드가 null이면 종료하고 돌아간다.
        if(root == null) return;
        //위치를 찾으면
        else if(root.data == data){
            //'.'이 아닌 경우에 한해서 좌, 우 노드 생성 후 데이터 삽입
            if(leftData != '.') root.left = new Node(leftData);
            if(rightData != '.') root.right = new Node(rightData);
        }
        //아직 못찾았고, 탐색할 노드들이 남아있으면
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
        int n = int.Parse(Console.ReadLine());
        Tree tree = new Tree();
        for(int i = 0; i < n; i++){
        	char[] ch = Array.ConvertAll(Console.ReadLine().Split(' '), s => char.Parse(s));
            tree.Add(ch[0], ch[1], ch[2]);
        }

        tree.Preorder(tree.root);
        Console.WriteLine();
        tree.Inorder(tree.root);
        Console.WriteLine();
        tree.Postorder(tree.root);
    }
}