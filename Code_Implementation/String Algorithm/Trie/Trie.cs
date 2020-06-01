//트라이(Trie)는 문자열의 집합을 관리하는 루트 트리 O(n)에 동작
//집합의 각 문자열은 트리의 루트 노드에서 시작하는 글자 경로의 형태로 저장된다.
//int trie[n,a] 배열에 저장하며 n은 노드의 최대 수, 즉 집합에 속한 문자열 전체 길이의 최대 제한값
//a는 알파벳의 개수, 즉 가능한 글자의 종류 수이다.
//루트 노드의 번호는 0이고 trie[s,c]는 노드 s에서 글자 c를 따라가면 어느 노드로 이동하게 되는지를 나타낸다.
using System;
using System.Collections.Generic;
class TrieNode{
    private Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    private bool endOfWord;

    public Dictionary<char, TrieNode> GetChildren(){
        return children;
    }

    public bool IsEndOfWord(){
        return endOfWord;
    }

    public void SetEndOfWord(bool endOfWord){
        this.endOfWord = endOfWord;
    }
}

class Trie{
    private TrieNode root;

    public Trie(){
        root = new TrieNode();
    }

    public void Insert(string word){
        TrieNode current = root;
        
        for(int i = 0; i < word.Length; i++){
            TrieNode node = null;
            if(current.GetChildren().TryGetValue(word[i], out node)){
                current = node;
            }
            else{
                node = new TrieNode();
                current.GetChildren().Add(word[i], node);
                current = node;
            }
        }
        current.SetEndOfWord(true);
    } 

    public bool Delete(string word){
        return Delete(root, word, 0);
    }

    public bool ContainsNode(string word){
        TrieNode current = root;
        for(int i = 0; i < word.Length; i++){
            char ch = word[i];
            TrieNode node = null;
            if(!current.GetChildren().TryGetValue(ch, out node)){
                return false;
            }
            else current = node;
        }
        return current.IsEndOfWord();
    }

    public bool IsEmpty(){
        return root == null;
    }

    private bool Delete(TrieNode current, string word, int index){
        if(index == word.Length){
            if(!current.IsEndOfWord()){
                return false;
            }

            current.SetEndOfWord(false);
            return current.GetChildren().Count == 0;
        }

        char ch = word[index];
        TrieNode node = null;
        if(!current.GetChildren().TryGetValue(ch, out node)){
            return false;
        }

        bool shouldDeleteCurrentNode = Delete(node, word, index+1) && !node.IsEndOfWord();

        if(shouldDeleteCurrentNode){
            current.GetChildren().Remove(ch);
            return current.GetChildren().Count == 0;
        }

        return false;
    }
}

class yx{
    public static void Main(string[] args){
        Trie trie = new Trie();
        trie.Insert("CANAL");
        trie.Insert("CANDY");
        trie.Insert("THE");
        trie.Insert("THERE");
        Console.WriteLine(trie.ContainsNode("CANAL"));
        Console.WriteLine(trie.Delete("CANAL"));
        Console.WriteLine(trie.ContainsNode("CANAL"));
    }
}