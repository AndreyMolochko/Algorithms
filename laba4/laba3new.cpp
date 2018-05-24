#include <assert.h>
#include <math.h>
#include <algorithm>
#include <vector>
#include <string>
#include <list>
#include <set>
#include <map>
#include <unordered_map>
#include <queue>
#include <sstream>
#include <iostream>
#include <fstream>
#include <iomanip>

#include <ctime>

#pragma GCC target("sse,sse2,sse3,ssse3,sse4,popcnt,abm,mmx")

using namespace std;

#define space ' '
#define enter "\n"
#define fi first
#define se second
#define mp make_pair
#define ALL(x) x.begin(), x.end()
#define bits(x) __builtin_popcount(x)
#define bitsll(x) __builtin_popcountll(x)
#define crr(a) cerr << #a << " = " << a << "\n"
#define precision(a) fixed << setprecision(a)

typedef long long ll;
typedef unsigned int uint;
typedef unsigned long long ull;
typedef pair <int, int> pii;
typedef set <int> si;
typedef map <int, int> mii;
typedef pair <ll, ll> pll;
typedef vector <int> vi;
typedef vector <pii> vii;

inline bool isDigit (char c) {
    return '0' <= c && c <= '9';
}

template<class T>
inline T sqr (T x) {
    return x * x;
}

template<class T>
inline bool isSquare (T x) {
    T y = sqrt(x + 0.5);
    return (y * y) == x;
}

template<class T1, class T2>
inline T1 gcd (T1 a, T2 b) {
    return b ? gcd(b, a % b) : a;
}

template<class T1, class T2>
inline T1 eqMin (T1 & x, const T2 & y) {
    if (T1(y) < x)
        return x = y;
    return x;
}

template<class T1, class T2>
inline T1 eqMax (T1 & x, const T2 & y) {
    if (T1(y) > x)
        return x = y;
    return x;
}

template<class T1, class T2>
inline T1 min (const T1 & x, const T2 & y) {
    return x < (T1) y ? x : (T1) y;
}

template<class T1, class T2>
inline T1 max (T1 & x, const T2 & y) {
    return x > (T1) y ? x : (T1) y;
}

template<typename T>
inline T getint () {
    T x = 0, p = 1;
    char ch;
    do {
        ch = getchar();
    } while (ch <= ' ');
    if (ch == '-')
        p = -1, ch = getchar();
    while (ch >= '0' && ch <= '9')
        x = x * 10 + ch - '0', ch = getchar();
    return x * p;
}

template<class T1, class T2>
ostream & operator << (ostream & os, const pair <T1, T2> & p) {
    return os << '(' << p.fi << ", " << p.se << ')';
}

template<class T>
ostream & operator << (ostream & os, const vector <T> & v) {
    os << '{';
    bool was = false;
    for (const T & x : v) {
        if (was)
            os << ", ";
        was = true;
        os << x;
    }
    os << '}';
    return os;
}

template<class T>
ostream & operator << (ostream & os, const set <T> & v) {
    os << '[';
    bool was = false;
    for (const T & x : v) {
        if (was)
            os << ", ";
        was = true;
        os << x;
    }
    os << ']';
    return os;
}

template<class T>
ostream & operator << (ostream & os, const multiset <T> & v) {
    os << '[';
    bool was = false;
    for (const T & x : v) {
        if (was)
            os << ", ";
        was = true;
        os << x;
    }
    os << ']';
    return os;
}

template<class T1, class T2>
ostream & operator << (ostream & os, const map <T1, T2> & m) {
    os << '<';
    bool was = false;
    for (const auto & x : m) {
        if (was)
            os << ", ";
        was = true;
        os << x;
    }
    os << '>';
    return os;
}

template<size_t sz>
ostream & operator << (ostream & os, const bitset <sz> & bit) {
    os << '/';
    for (int i = 0; i < sz; i++)
        os << bit[i];
    os << '\\';
    return os;
}

const double PI = acos(-1);
const double EPS = 1e-8;
const int INF = (int) 2e9;
const ll LINF = (ll) 2e18;
const int MOD = (int) 1e9 + 7;
const int MAXN = (int) 1;

vector <int> merge (const vector <int> & v1, const vector <int> & v2) {
    vector <int> result;
    int i1 = 0, i2 = 0;
    while (i1 < v1.size() && i2 < v2.size()) {
        if (v1[i1] < v2[i2]) {
            result.push_back(v1[i1++]);
        } else {
            result.push_back(v2[i2++]);
        }
    }
    while (i1 < v1.size()) {
        result.push_back(v1[i1++]);
    }
    while (i2 < v2.size()) {
        result.push_back(v2[i2++]);
    }
    return result;
}

vector <int> merge (const vector <vector <int> > & arrays) {
    vector <int> result = arrays[0];
    for (int i = 1; i < arrays.size(); i++) {
        result = merge(result, arrays[i]);
    }
    return result;
}

vector <vector <int> > input () {
    int n, k;
    cin >> n >> k;
    vector <vector <int> > arrays(n);
    for (auto & arr : arrays) {
        for (int i = 0; i < k; i++) {
            arr.push_back(rand());
        }
        sort(ALL(arr));
    }
    return arrays;
}

vector <int> recoursiveMerge (const vector <vector <int> > & arrays, int l = 0, int r = -1) {
    if (r == -1) r = arrays[0].size() - 1;
    vector <int> result;
    if (l == r) {
        for (int i = 0; i < arrays.size(); i++) {
            result.push_back(arrays[i][l]);
        }
        sort(ALL(result));
        return result;
    }
    int md = (l + r) / 2;
    return merge(recoursiveMerge(arrays, l, md), recoursiveMerge(arrays, md + 1, r));
}

int main () {
    ios_base::sync_with_stdio(false);
    auto arrays = input();
    auto sortedArray1 = merge(arrays);
    auto sortedArray2 = recoursiveMerge(arrays);
    cout << sortedArray1 << endl << sortedArray2;

}
