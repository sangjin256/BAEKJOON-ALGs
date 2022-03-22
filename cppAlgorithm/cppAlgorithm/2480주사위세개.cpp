//
//  2480주사위세개.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2022/03/22.
//

#include <iostream>
#include <algorithm>

int main(){
    int dice[3], sameNumCount = 0, sameNum = 0;
    std::cin >> dice[0] >> dice[1] >> dice[2];
    std::sort(dice, dice+3);
    for(int i = 1; i < std::size(dice); i++){
        if(dice[i] == dice[i-1]){
            sameNumCount++;
            sameNum = dice[i];
        }
    }
    
    if(sameNumCount){
        if(sameNumCount == 1) std::cout << 1000+sameNum*100 << std::endl;
        else std::cout << 10000+sameNum*1000 << std::endl;
    }
    else{
        std::cout << dice[2]*100 << std::endl;
    }
}
