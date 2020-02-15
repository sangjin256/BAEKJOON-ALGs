class TrieTest{
    public static void main(String[] args){
        Trie trie = new Trie();
        trie.insert("CANAL");
        trie.insert("CANDY");
        trie.insert("THE");
        trie.insert("THERE");
        trie.insert("FORGIVE");

        //System.out.println(trie.delete("CANAL"));
        System.out.println(trie.containsNode("CANAL"));

        //System.out.println(trie.delete("FORGIVE"));
        System.out.println(trie.containsNode("FORGIVE"));
    }
}