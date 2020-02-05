//트라이(Trie)는 문자열의 집합을 관리하는 루트 트리 O(n)에 동작
//집합의 각 문자열은 트리의 루트 노드에서 시작하는 글자 경로의 형태로 저장된다.
//int trie[n,a] 배열에 저장하며 n은 노드의 최대 수, 즉 집합에 속한 문자열 전체 길이의 최대 제한값
//a는 알파벳의 개수, 즉 가능한 글자의 종류 수이다.
//루트 노드의 번호는 0이고 trie[s,c]는 노드 s에서 글자 c를 따라가면 어느 노드로 이동하게 되는지를 나타낸다.

using System;
using System.IO;
using System.Collections.Generic;

public class Lecture{
   static char trie = new char[5,26];
    public static void Main(string[] args){

    }

    void TrieInsert(string str){
        
    }
}
