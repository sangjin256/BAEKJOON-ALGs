#include <bits/stdc++.h>
using namespace std;
//세그먼트 트리의 각 노드에는 최소값의 '인덱스'가 들어감
int setSegtree(int left, int right, int node, const vector<long long>& v, vector<long long>& seg) {
    if (left == right) {
        return seg[node] = left;
    }

    int mid = (left + right) / 2;
    int leftMinIndex = setSegtree(left, mid, node * 2, v, seg);
    int rightMinIndex = setSegtree(mid + 1, right, node * 2 + 1, v, seg);

    return seg[node] = v[leftMinIndex] <= v[rightMinIndex] ? leftMinIndex : rightMinIndex;
}

long long query(const int& left, const int& right, int node, int nodeLeft, int nodeRight, const vector<long long>& v, const vector<long long>& seg) {
    if (nodeRight < left || right < nodeLeft) return -1;
    if (left <= nodeLeft && nodeRight <= right) return seg[node];

    int mid = (nodeLeft + nodeRight) / 2;
    long long leftMinIndex = query(left, right, node * 2, nodeLeft, mid, v, seg);
    long long rightMinIndex = query(left, right, node * 2 + 1, mid + 1, right, v, seg);

    //잘못된 범위로 진입시 index에러 방지
    if (leftMinIndex == -1) return rightMinIndex;
    else if (rightMinIndex == -1) return leftMinIndex;
    else return v[leftMinIndex] <= v[rightMinIndex] ? leftMinIndex : rightMinIndex;
}

long long getMaxArea(int left, int right, const vector<long long>& v, const vector<long long>& seg) {
    long long maxWidth, tmpWidth;
    long long minIndex = query(left, right, 1, 0, v.size() - 1, v, seg);
    maxWidth = static_cast<long long>(right - left + 1) * v[minIndex];

    // 왼쪽이 존재할경우
    if (left <= minIndex - 1) {
        tmpWidth = getMaxArea(left, minIndex - 1, v, seg);
        maxWidth = max(maxWidth, tmpWidth);
    }

    //오른쪽이 존재할경우
    if (minIndex + 1 <= right) {
        tmpWidth = getMaxArea(minIndex + 1, right, v, seg);
        maxWidth = max(maxWidth, tmpWidth);
    }
    return maxWidth;
}

int main() {
    while (1) {
        int n;
        scanf("%d", &n);
        if (n == 0) break;
        vector<long long> v, segtree(n * 2);

        for (int i = 0; i < n; i++) {
            long long tmp;
            scanf("%lld", &tmp);
            v.push_back(tmp);
        }
        setSegtree(0, n - 1, 1, v, segtree);
        printf("%lld\n", getMaxArea(0, n - 1, v, segtree));
    }
}