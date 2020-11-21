#include <bits/stdc++.h>

using namespace std;

vector<tuple<int,int,int>> edges;
vector<tuple<int,int,int>> minspan;
int link[10000];
int size[10000];

void AddEdges(int a, int b, int w){
    edges.push_back({a,b,w});
}

bool compare(tuple<int,int,int> a, tuple<int,int,int> b){
    return get<2>(a) < get<2>(b);
}

void makeMinSpanningTree();
void unionFindInit(int n);
int find(int x);
bool same(int a, int b);
void unite(int a, int b);


int main(){
    int n;
    cout << "몇 개의 간선이 존재합니까?" << endl;
    cin >> n;
    cout << "노드 노드 간선의 길이를 입력하시오 (a b w) : " << endl;
    for(int i = 0; i < n; i++){
        int a, b, w;
        cin >> a >> b >> w;
        AddEdges(a, b, w);
    }
    makeMinSpanningTree();
}

void makeMinSpanningTree(){
    sort(edges.begin(), edges.end(), compare);
    unionFindInit(6);
    
    for(const auto& e : edges){
        int a = get<0>(e), b = get<1>(e);
        if(!same(a, b)){
            unite(a, b);
            cout << a << " " << b << " " << get<2>(e) << endl;
        }
    }
}

void unionFindInit(int n){
    for(int i = 1; i <= n; i++) link[i] = i;
    for(int i = 1; i <= n; i++) size[i] = 1;
}

int find(int x){
    if(x == link[x]) return x;
    return link[x] = find(link[x]);
}

bool same(int a, int b){
    return find(a) == find(b);
}

void unite(int a, int b){
    a = find(a);
    b = find(b);
    if(size[a] < size[b]){
        int tmp = a;
        a = b;
        b = tmp;
    }
    size[a] += size[b];
    link[b] = a;
}