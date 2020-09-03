#include <bits/stdc++.h>
using namespace std;

#define mod 1000

typedef long long ll;
typedef vector<vector<long long>> vv;
//단위행렬
vv unit(5, vector<ll>(5));

void unitMatrix(int n) {
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			if (i == j) unit[i][j] = 1;
		}
	}
}

vv operator * (const vv& a, const vv& b) {
	int n = a.size();
	vv result(5, vector<ll>(5));
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			for (int k = 0; k < n; k++) {
				result[i][j] += a[i][k] * b[k][j];
			}
			result[i][j] %= mod;
		}
	}
	return result;
}

vv modpow(const vv& x, ll n, ll length) {
	if (n == 0) return unit;
	vv u = modpow(x, n / 2, length);
	u = u * u;
	if (n % 2 == 1) u = u * x;
	return u;
}

int main() {
	vv matrix(5, vector<ll>(5));
	// m값의 최대 범위가 int를 넘으므로 그냥 다 long long형으로 받아준다.
	ll n, m;
	scanf("%lld %lld", &n, &m);
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			scanf("%lld", &matrix[i][j]);
		}
	}

	unitMatrix(n);

	vv tmp = modpow(matrix, m, n);

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			printf("%lld ", tmp[i][j]);
		}
		printf("\n");
	}
}