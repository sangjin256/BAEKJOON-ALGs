#include <bits/stdc++.h>
using namespace std;

//중앙값과 최빈값은 counting sort를 이용해 구한다.
//절대값이 4000을 넘지 않는다는 말은 -4000도 허용이므로 4000을 더한 값을 구한다.

int main(){
    int n, tmp, sum = 0, mx = -4001, mn = 4001, count[8001] = {}, middle = 0, choibin = 0;
    scanf("%d", &n);

    for(int i = 0; i < n; i++){
        scanf("%d", &tmp);
        sum += tmp;
        count[tmp+4000]++;
        mx = max(mx, tmp);
        mn = min(mn, tmp);
    }
    int mxforchoibin = 0;
    int countformiddle = 0;
    bool same = false;
    for(int i = mn+4000; i <= mx+4000; i++){
        if(count[i] != 0 && mxforchoibin <= count[i]){
            if(mxforchoibin != count[i]){
                same = false;
                mxforchoibin = count[i];
                choibin = i-4000;
            }
            else if(!same){
                choibin = i-4000;
                same = true;
            }
        }
        while(count[i] != 0){
            //중앙에 도달하면 중앙값에 대입해준다.
            if(countformiddle == n/2){
                middle = i-4000;
            }
            countformiddle++;
            count[i]--;
        }
    }
    
    //산술평균 출력
    printf("%d\n", static_cast<int>(round(static_cast<double>(sum)/n)));
    //중앙값 출력
    printf("%d\n", middle);
    //최빈값 출력
    printf("%d\n", choibin);
    //범위 출력
    printf("%d\n", mx - mn);
}