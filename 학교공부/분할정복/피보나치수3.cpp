#include <bits/stdc++.h>
using namespace std;
#define mod 1000000;

typedef long long ll;
typedef vector<vector<long long>> vv;

vv unit{ {1,0},{0,1} };
vv matrix{ {0,1},{1,1} };

vv operator * (const vv& a, const vv& b) {
	int n = a.size();
	int m = b[0].size();
	vv result(n, vector<ll>(m));
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			for (int k = 0; k < n; k++) {
				result[i][j] += a[i][k] * b[k][j];
			}
			result[i][j] %= mod;
		}
	}
	return result;
}

vv modpow(const vv& x, ll n) {
	if (n == 0) return unit;
	vv u = modpow(x, n / 2);
	u = u * u;
	if (n % 2 == 1) u = u * x;
	return u;
}

int main() {
	//피보나치 수 0번째인 0과 1번째인 1을 2*1 행렬로 만듦
	vv start{ {0},{1} };
	ll num;
	scanf("%lld", &num);

	vv result = modpow(matrix, num) * start;
	printf("%lld", result[0][0]);
}
