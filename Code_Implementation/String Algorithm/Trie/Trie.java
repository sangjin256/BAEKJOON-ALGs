//트라이(Trie)는 문자열의 집합을 관리하는 루트 트리 O(n)에 동작
//집합의 각 문자열은 트리의 루트 노드에서 시작하는 글자 경로의 형태로 저장된다.
//int trie[n,a] 배열에 저장하며 n은 노드의 최대 수, 즉 집합에 속한 문자열 전체 길이의 최대 제한값
//a는 알파벳의 개수, 즉 가능한 글자의 종류 수이다.
//루트 노드의 번호는 0이고 trie[s,c]는 노드 s에서 글자 c를 따라가면 어느 노드로 이동하게 되는지를 나타낸다.
package Trie;
class Trie {
    private TrieNode root;

    Trie() {
        root = new TrieNode();
    }

    void insert(String word) {
        TrieNode current = root;
        for(int i = 0; i < word.length(); i++){
            //word.charAt(i)가 있으면 그 값을 반환하고 없으면 새로 생성한다.
            current = current.getChildren().computeIfAbsent(word.charAt(i), c -> new TrieNode());
        }
        current.setEndOfWord(true);
    }

    boolean delete(String word) {
        return delete(root, word, 0);
    }

    boolean containsNode(String word) {
        TrieNode current = root;

        for(int i = 0; i < word.length(); i++){
            char ch = word.charAt(i);
            TrieNode node = current.getChildren().get(ch);
            if(node == null){
                return false;
            }
            current = node;
        }

        return current.isEndOfWord();
    }

    boolean isEmpty() {
        return root == null;
    }

    //노드에 자식이 1개 이상이면 다른 곳으로 연결될 수 있는 노드이므로
    //endOfWord의 값만 false로 바꾼다.
    private boolean delete(TrieNode current, String word, int index){
        if(index == word.length()){
            if(!current.isEndOfWord()){
                return false;
            }

            current.setEndOfWord(false);
            return current.getChildren().isEmpty();
        }

        char ch = word.charAt(index);
        TrieNode node = current.getChildren().get(ch);
        if(node == null) {
            return false;
        }
        boolean shouldDeleteCurrentNode = delete(node, word, index + 1) && !node.isEndOfWord();
        
        if(shouldDeleteCurrentNode) {
            current.getChildren().remove(ch);
            return current.getChildren().isEmpty();
        }

        return false;
    }
}