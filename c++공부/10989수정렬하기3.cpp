// 배열을 초기화해놓지 않아서 출력초과 에러 떴었음
// scanf랑 printf를 사용하지 않으면 시간초과남

#include <iostream>

int main(){
    int N, max = -1;
    std::cin >> N;
    int arr[10001]{};

    for(int i = 0; i < N; i++){
        int tmp;
        scanf("%d", &tmp);
        arr[tmp]++;
        if(tmp > max) max = tmp;
    }

    for(int i = 0; i <= max; i++){
        while(arr[i] != 0){
            printf("%d\n", i);
            arr[i]--;
        }
    }
}