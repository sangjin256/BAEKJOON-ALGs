#include <bits/stdc++.h>

using namespace std;

vector<pair<int, int>> adj[7];
vector<tuple<int, int, int>> minspan;

void AddEdges(int a, int b, int w) {
    adj[a].push_back({ b,w });
    adj[b].push_back({ a,w });
}
void makeMinSpanningTree(int n);


int main() {
    int n;
    cout << "몇 개의 간선이 존재합니까?" << endl;
    cin >> n;
    cout << "노드 노드 간선의 길이를 입력하시오 (a b w) : " << endl;
    for (int i = 0; i < n; i++) {
        int a, b, w;
        cin >> a >> b >> w;
        AddEdges(a, b, w);
    }
    makeMinSpanningTree(1);

    cout << endl;

    for (auto u : minspan) {
        cout << get<0>(u) << " " << get<1>(u) << " " << get<2>(u)  << endl;
    }
}

void makeMinSpanningTree(int start) {
    // a값이 바로전값이 아닐수도 있으므로 간선 길이, 시작 끝을 다 넣어준다.
    priority_queue<tuple<int, int, int>> p;
    queue<int> q;

    int dist[7];
    bool processed[7] = {};
    for (int i = 1; i < 7; i++) {
        dist[i] = 1000000000;
    }
    dist[start] = 0;
    q.push(1);

    while (!q.empty()) {
        int a = q.front(); q.pop();
        processed[a] = true;

        for (auto u : adj[a]) {
            if (!processed[u.first]) {
                p.push({ -u.second, u.first, a });
            }
        }

        while (!p.empty()) {
            int b = get<1>(p.top()), a = get<2>(p.top()), w = get<0>(p.top()); p.pop();
            if (!processed[b]) {
                processed[b] = true;
                q.push(b);
                minspan.push_back({ a,b,-w });
                break;
            }
        }
    }
}