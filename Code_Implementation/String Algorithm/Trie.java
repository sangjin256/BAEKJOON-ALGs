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