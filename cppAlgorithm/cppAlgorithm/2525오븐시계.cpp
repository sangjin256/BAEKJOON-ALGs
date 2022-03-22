//
//  2525오븐시계.cpp
//  cppAlgorithm
//
//  Created by 이상진 on 2022/03/22.
//

#include <iostream>

int main(){
    int A, B, time;
    std::cin >> A >> B >> time;
    B += time;
    
    while(B >= 60){
        A = (A >= 23) ? 0 : A+1;
        B -= 60;
    }

    std::cout << A << " " << B << std::endl;
}
