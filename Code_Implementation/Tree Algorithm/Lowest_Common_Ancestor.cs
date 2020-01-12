///루트 트리에 속한 두 노드의 최소 공통 조상(Lowest Common Ancestor)은 두 노드를 모두
//서브트리에 포함하고 있는 가장 낮은 노드이다.
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

        public static int count = 1;

        public int depth = 1;

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

        public void Add(int data, int[] children){
            if(root == null){
                root = new Node(data);
                for(int i = 0; i < children.Length; i++){
                    root.children.Add(new Node(children[i]));
                    root.children[i].Parent = root;
                    root.children[i].depth += root.depth;
                    Node.count++;
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
                    root.children[i].depth += root.depth;
                    Node.count++;
                }
            }
            else{
                foreach(var c in root.children){
                    Search(c, data, children);
                }
            }
        }
        
        //Find 재귀함수에서 빠져나올 노드
        Node FindNode = null;

        public Node Find(Node root, int data){
        	if(root == null){
        		return null;
        	}
        	if(data == root.data){
        		return root;
        	}
        	else{
        		if(!root.isLeaf()){
        			foreach(var c in root.children){
        				if(c.data == data){
        					FindNode = c;
        				}
        				else Find(c, data);
        			}
        		}
        	}
        	return FindNode;
        	
        }

        //포인터 2개를 사용해서 각각이 최소 공통 조상을 찾아야 하는 두 노드를
        //가리키도록 한다. 그 다음 우선 포인터가 가리키는 노드가 트리에서 같은 높이
        //에 있도록 하고 두 포인터가 같은 노드를 가리키게 하려면 포인터를 위로
        //몇 번 이동해야 하는지를 구한다.
        public Node LCA_Pointer(int a, int b){
            Node p1 = Find(root, a);
            Node p2 = Find(root, b);
            while(p1.depth > p2.depth){
                p1 = p1.Parent;
            }
            while(p1.depth < p2.depth){
                p2 = p2.Parent;
            }
            while(p1.data != p2.data){
                p1 = p1.Parent;
                p2 = p2.Parent;
            }

            return p1;
        }

        //오일러 투어 트리(Euler Tour Tree) 사용
        // = 확장된 트리 순회 배열. 노드를 지나는 모든 순간마다 노드를 배열에 추가(중복허용)
        //NumDep배열에는 노드 번호와 깊이가 들어간다.
        int[] Num;
        int[] Dep;

        public int LCA_Euler(int a, int b){
            //왔던길로 돌아와서 반복하기 때문에 총 노드갯수는 2n-1개가 들어간다.
            Num = new int[Node.count*2-1];
            Dep = new int[Node.count*2-1];
            Dfs(this.root);
            MakeMinArray();
            //a와 b는 노드 번호이기 때문에 깊이로 바꾼 후 구간 위치로 바꿔준다.
            a = Array.IndexOf(Num, a);
            b = Array.IndexOf(Num, b);
            int temp = b - a + 1;
            int k = temp;
            for(int i = 1; i <= b-a+1; i <<=1){
                if((temp&(temp-1)) == 0) break;
                k = temp&(temp-1);
                temp = temp-1;
            }
            return Math.Min(min[a, a+k-1], min[b-k+1, b]);
        }
        
        int count = 0;
        public void Dfs(Node s){
            Num[count] = s.data;
            Dep[count] = s.depth;
            count++;
            foreach(var c in s.children){
                Dfs(c);
                Num[count] = s.data;
                Dep[count] = s.depth;
            	count++;
            }
        }

        //NumDep 배열의 깊이 부분은 정적 배열이므로 최소 질의 배열로 만들어준다.
        int[,] min;
        public void MakeMinArray(){
            min = new int[Node.count*2-1, Node.count*2-1];
            for(int i = 0; i < min.GetLength(0); i++){
                min[i,i] = Dep[i];
            }
            for(int i = 2; i <= min.GetLength(0); i<<=1){
                int a = 0;
                for(int b = i-1; b < min.GetLength(0); b++){
                    Min(a++, b);
                }
            }
        }
        public void Min(int a, int b){
            int w = (b - a + 1) / 2;
            min[a, b] = Math.Min(min[a, a+w-1], min[a+w, b]);
        }

        //노드 a와 b 사이의 거리 계산하기.
        //공식은 depth(a) + depth(b) - 2 *depth(c)이다. (c는 a와 b의 최소 공통 조상)
        public int Distance(int a, int b){
        	//이미 한번 배열을 만들면 에러가 난다. 나중에 수정하거나 밖으로 빼자
            int c = (LCA_Euler(a, b));
            a = Find(this.root, a).depth;
            b = Find(this.root, b).depth;
            
            return a + b;
        }
    }
	public static void Main(string[] args) {
        Tree tree = new Tree();
        tree.Add(1, new int[]{2,3,4});
        tree.Add(2, new int[]{5,6});
        tree.Add(6, new int[]{8});
        tree.Add(4, new int[]{7});

        Console.WriteLine(tree.LCA_Pointer(5,8).data);
        Console.WriteLine(tree.LCA_Euler(5, 8));
        Console.WriteLine(tree.Distance(5, 8));
    }
}