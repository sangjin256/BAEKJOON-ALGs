//그래프의 지름은 두 노드 간 경로의 길이 중 최댓값을 나타냄
//두 가지 방법을 알아볼텐데 동적계획법을 쓰는 알고리즘과 깊이 우선 탐색을 2번 진행하는
//알고리즘이 있다.
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class Lecture 
{
    public class Node{
        public int data;
        public List<Node> children = new List<Node>();
        public Node Parent;

        public Node(int data){
            this.data = data;
        }
    }

    public class Tree{
        public Node root;
        public Node child;

        public void Add(int data, int children){
            if(root == null){
                root = new Node(data);
                if(!root.children.Contains(new Node(children))){
                    child = new Node(children);
                    root.children.Add(child);
                    child.Parent = root;
                }
            }
            else{
                Search(root, child, data, children);
            }
        }

        public void Search(Node root, Node child, int data, int children){
            if(root == null) return;
            else if(root.data == data){
                if(!root.children.Contains(new Node(children))){
                    child = new Node(children);
                    root.children.Add(child);
                    child.Parent = root;
                }
            }
            else{
                foreach(var c in root.children){
                    Search(c, child, data, children);
                }
            }
        }

        public Node Find(Node root, int data){
            if(root == null) return new Node(0);
            else if(root.data == data) return root;
            else{
                if(root.children.Count != 0){
                    foreach(var c in root.children){
                        Find(c, data);
                    }
                    return new Node(0);
                }
                else return new Node(0);
            }
        }  

        public void GetParent(int data){
            Console.WriteLine(Find(this.root, data).Parent.data);
        }

        public void GetChildren(int data){
            foreach(var c in Find(this.root, data).children){
                Console.WriteLine(c.data);
            }
        }
    }
	public static void Main(string[] args) {
        Tree tree = new Tree();
        tree.Add(1,4);
        tree.Add(1,5);
        tree.Add(1,2);
        tree.Add(4,3);
        tree.Add(4,7);
        tree.Add(7,8);
        tree.Add(2,6);

        tree.GetChildren(4);
        tree.GetParent(8);
    }
}