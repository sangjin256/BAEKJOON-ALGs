// 병합정렬을 사용하니 사용하지 않을때보다 시간은 6ms 늘었지만 메모리가 2000kb가량 줄어들었다.

#include <bits/stdc++.h>
using namespace std;

pair<int, string> buff[100001];

void mergesort(pair<int, string> a[], int left, int right){
    if(left < right){
        int i;
        int center = (left + right) / 2;
        int p = 0, j = 0, k = left;

        mergesort(a, left, center);
        mergesort(a, center+1, right);

        for(i = left; i <= center; i++){
            buff[p++] = a[i];
        }

        while(i <= right && j < p){
            a[k++] = (buff[j].first <= a[i].first) ? buff[j++] : a[i++];
        }

        while(j < p){
            a[k++] = buff[j++];
        }
    }
}

int main(){
    int n;
    cin >> n;
    pair<int, string> p[n];
    for(int i = 0; i < n; i++){
        int age; string name;
        cin >> age >> name;
        p[i] = {age, name};
    }

    mergesort(p, 0, n-1);

    for(int i = 0; i < n; i++){
        cout << p[i].first << " " << p[i].second << "\n";
    }
}