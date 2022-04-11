#include <iostream>
#include <map>
#include <string>

using namespace std;

int main(){
    int T, n;
    string temp;
    cin >> T;
    
    for(int tcase = 0; tcase < T; tcase++){
        map<string, int> clothes;
        int result = 1;
        
        scanf("%d", &n);
        for(int i = 0; i < n; i++){
            cin >> temp >> temp;
            if(clothes.find(temp) == clothes.end()){
                clothes.insert({temp, 1});
            }
            else clothes[temp]++;
        }
        
        for(auto iter : clothes){
            result *= (iter.second + 1);
        }
        
        cout << result - 1 << endl;
    }
}
