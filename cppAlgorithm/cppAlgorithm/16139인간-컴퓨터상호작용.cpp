#include <iostream>
#include <string>

int main(){
    std::ios_base::sync_with_stdio(false); std::cin.tie(NULL); std::cout.tie(NULL);
    
    std::string str;
    int q, l, r, alphabet[1000000][26];
    char ch;
    std::cin >> str >> q;
    
    alphabet[0][str[0]-'a']++;
    for(int i = 1; i < str.size(); i++){
        alphabet[i][str[i] - 'a']++;
        for(int j = 0; j < 26; j++){
            alphabet[i][j] += alphabet[i-1][j];
            //std::cout << i << " " << j << " " << alphabet[i][j] << std::endl;
        }
    }
    for(int t = 0; t < q; t++){
        std::cin >> ch >> l >> r;
        if(l-1 >= 0) std::cout << alphabet[r][ch-'a']-alphabet[l-1][ch-'a'] << "\n";
        else std::cout << alphabet[r][ch-'a'] << "\n";
    }
}
