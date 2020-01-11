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
            Parent = null;
        }

        public bool isLeaf(){
            return this.children.Count == 0;
        }

        public bool isRoot(){
            return this.Parent == null;
        }
    }

    public class Tree{
        public Node root;

        public void Add(int data, params int[] children){
            if(root == null){
                root = new Node(data);
                for(int i = 0; i < children.Length; i++){
                    root.children.Add(new Node(children[i]));
                    root.children[i].Parent = root;
                }
            }
            else{
                Search(root, data, children);
            }
        }

        public void Search(Node root, int data, int[] children){
            if(root == null) return;
            else if(root.data == data){
                for(int i = 0; i < children.Length; i++){
                    root.children.Add(new Node(children[i]));
                    root.children[i].Parent = root;
                }
            }
            else{
                foreach(var c in root.children){
                    Search(c, data, children);
                }
            }
        }

        public Node Find(Node root, int data){
            if(root == null) return null;
            else if(root.data == data) return root;
            else{
                if(root.children.Count != 0){
                    foreach(var c in root.children){
                        Find(c, data);
                    }
                    return null;
                }
                else return null;
            }
        }  

        public void GetParent(int data){
            Console.WriteLine(Find(this.root, data).Parent.data);
        }

        public void GetChild(int data){
            foreach(var c in Find(this.root, data).children){
                Console.WriteLine(c.data);
            }
        }
    }
	public static void Main(string[] args) {
        Tree tree = new Tree();
        tree.Add(1, new int{4,5,2});
        tree.Add(4, new int{3,7});
        tree.Add(7, new int{8});
        tree.Add(2, new int{6});

        tree.GetChild(4);
        tree.GetParent(8);
    }
}