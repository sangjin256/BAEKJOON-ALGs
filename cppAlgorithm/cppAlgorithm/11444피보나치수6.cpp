#include <iostream>
#include <vector>

typedef std::vector<std::vector<long long>> matrix;
const long long mod = 1000000007;

matrix operator* (matrix& a, matrix& b){
    matrix c(2, std::vector<long long>(2));
    
    for(int i = 0; i < 2; i++){
        for(int j = 0; j < 2; j++){
            for(int k = 0; k < 2; k++){
                c[i][j] += a[i][k] * b[k][j];
            }
            c[i][j] %= mod;
        }
    }
    
    return c;
}
matrix modpow(matrix& x, long long n){
    if(n == 0 || n == 1) return x;
    matrix u = modpow(x, n/2);
    u = u * u;
    if(n % 2 == 1) u = u * x;
    return u;
}

int main(){
    long long n;
    std::cin >> n;
    
    matrix a = {{1,1}, {1,0}};
    
    a = modpow(a, n);
    
    std::cout << a[0][1] << '\n';
}
