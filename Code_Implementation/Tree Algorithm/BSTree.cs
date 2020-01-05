using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Lecture 
{
    class Node{
        public int data;
        public Node left, right;
        public Node(int data){
            this.data = data;
            left = right = null;
        }
    }

    class BSTree{
        public Node root;
        public void Add(int data){
            if(root == null) root = new Node(data);
            else{
                Node temp = GetNode(data);
                if(temp == null) Console.WriteLine("이미 값이 있습니다.");
            }
        }
        //Add함수를 위해 알맞는 위치의 노드를 가져오는 함수
        public Node GetNode(int data){
            Node temp = root;
            while(true){
                if(data > temp.data){
                    if(temp.right != null) temp = temp.right;
                    else{
                        return temp.right = new Node(data);
                    }
                }
                else if(data < temp.data){
                    if(temp.left != null) temp = temp.left;
                    else{
                        return temp.left = new Node(data);
                    }
                }
                else break;
            }
            return null;
        }

        public void Delete(int data){
            Node temp = Search(data);
            if(temp != null){
                if(temp.data == root.data){
                    root = this.DeleteNode(root);
                }
                else{
                    Node parent = this.FindParent(data);
                    if(parent == null) return;
                    if(parent.left == temp){
                        parent.left = this.DeleteNode(temp);
                    }
                    else{
                        parent.right = this.DeleteNode(temp);
                    }
                }
            }
        }
        //delete 함수에 쓰기 위한 함수
        public Node DeleteNode(Node node){
            //case 1 리프노드인 경우
            if(node.left == null && node.right == null){
                return null;
            }
            //case 2 - 1 자식이 하나인 경우
            else if(node.left == null && node.right != null){
                return node.right;
            }
            //case 2 - 2
            else if(node.left != null && node.right == null){
                return node.left;
            }
            //case 3 자식이 둘인 경우
            //이진검색트리에서 자식이 둘인 경우의 노드를 없애면 자식노드들의 크기를
            //보고 결정해야한다.
            else{
                Node temp = node.right;
                //가장 왼쪽 노드의 부모노드를 저장할 변수
                Node parent = null;
                //삭제하고자 하는 노드의 오른쪽 자식의 가장 왼쪽 자식까지 찾아감
                while(temp.left != null){
                    parent = temp;
                    temp = temp.left;
                }
                //삭제한 노드에 가장 왼쪽 자식을 집어넣는다.
                node.data = temp.data;
                //오른쪽 자식에 왼쪽 자식이 없다면
                if(temp == node.right){
                    //오른쪽 자식을 삭제한 노드에 집어넣는다.
                    node.right = temp.right;
                }
                else{
                    //이동한 노드의 오른쪽 자식이 부모노드의 왼쪽 자식이 된다.
                    parent.left = temp.right;
                }
                return node;
            }
        }

        public Node Search(int data){
            Node temp = root;
            while(true){
                if(data > temp.data){
                    if(temp.right != null) temp = temp.right;
                    else break;
                }
                else if(data < temp.data){
                    if(temp.left != null) temp = temp.left;
                    else break;
                }
                //break된것은 밖으로 빠져나오므로 일치해야함 return temp가 됨
                else return temp;
            }
            return null;
        }

        public Node FindParent(int data){
            //root가 비었으면 부모가 없다.
            if(root == null) return null;
            //root와 키값이 같으면 root는 부모가 없다.
            if(data == root.data) return null;
            Node temp = root;
            while(true){
                if(data > temp.data){
                    if(temp.right == null) return null;
                    if(temp.right.data == data) return temp;
                    temp = temp.right;
                }
                else if(data < temp.data){
                    if(temp.left == null) return null;
                    if(temp.left.data == data) return temp;
                    temp = temp.left;
                }
            }
        }

        public void Preorder(Node root){
            Console.WriteLine(root.data);
            if(root.left != null) Preorder(root.left);
            if(root.right != null) Preorder(root.right);
        }
        public void Inorder(Node root){
            if(root.left != null) Inorder(root.left);
            Console.WriteLine(root.data);
            if(root.right != null) Inorder(root.right);
        }
        public void Postorder(Node root){
            if(root.left != null) Postorder(root.left);
            if(root.right != null) Postorder(root.right);
            Console.WriteLine(root.data);
        }
    }
    public static void Main(string[] args) {
        BSTree tree = new BSTree();
        tree.Add(4);
        tree.Add(7);
        tree.Add(3);
        tree.Add(6);
        tree.Add(8);
        tree.Add(5);
        tree.Preorder(tree.root);
    }
}