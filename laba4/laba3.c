#include <bits/stdc++.h>
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

template <class T>
inline T sqr (T x) {
	return x * x;
}

template <class T>
inline bool isSquare (T x) {
	T y = sqrt(x + 0.5);
	return (y * y) == x;
}

template <class T1, class T2>
inline T1 gcd (T1 a, T2 b) {
	return b ? gcd(b, a % b) : a;
}

template <class T1, class T2>
inline T1 eqMin (T1 & x, const T2 & y) {
	if (T1(y) < x)
		return x = y;
	return x;
}

template <class T1, class T2>
inline T1 eqMax (T1 & x, const T2 & y) {
	if (T1(y) > x)
		return x = y;
	return x;
}

template <class T1, class T2>
inline T1 min (const T1 & x, const T2 & y) {
	return x < (T1) y ? x : (T1) y;
}

template <class T1, class T2>
inline T1 max (T1 & x, const T2 & y) {
	return x > (T1) y ? x : (T1) y;
}

template <typename T>
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

template <class T1, class T2>
ostream & operator << (ostream & os, const pair <T1, T2> & p) {
	return os << '(' << p.fi << ", " << p.se << ')';
}

template <class T>
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

template <class T>
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

template <class T>
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

template <class T1, class T2>
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

template <size_t sz>
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
const int MAXN = (int) 100;

struct Edge {
	int from, to, cost;

	Edge (int f, int t, int c) : from(f), to(t), cost(c) {}
};

int n, m;
vector <Edge> d[MAXN], edges;
int g[MAXN][MAXN];
int dist[MAXN];

void init () {
	for (int i = 1; i <= n; i++) {
		dist[i] = INF;
	}
	dist[1] = 0;
}

void input () {
	cin >> n >> m;
	for (int i = 1; i <= m; i++) {
		int x, y, cost;
		cin >> x >> y >> cost;
		d[x].push_back(Edge(x, y, cost));
		edges.push_back(Edge(x, y, cost));
	}
}

void dijkstra () {
	init();
	set <pair <int, int> > q;
	for (int i = 1; i <= n; i++) {
		q.insert(mp(dist[i], i));
	}
	while (!q.empty()) {
		int v = q.begin()->second;
		q.erase(q.begin());

		for (auto edge : d[v]) {
			if (dist[v] + edge.cost < dist[edge.to]) {
				q.erase(q.find(mp(dist[edge.to], edge.to)));
				dist[edge.to] = dist[v] + edge.to;
				q.insert(mp(dist[edge.to], edge.to));
			}
		}
	}
	for (int i = 1; i <= n; i++) {
		cout << dist[i] << ' ';
	}
	cout << enter;
}

void fordBellman () {
	init();

	for (int i = 1; i <= n; i++) {
		for (auto edge : edges) {
			if (dist[edge.from] + edge.cost < dist[edge.to]) {
				dist[edge.to] = dist[edge.from] + edge.cost;
			}
		}
	}
	for (int i = 1; i <= n; i++) {
		cout << dist[i] << ' ';
	}
	cout << enter;
}

void floydWarshall () {
	for (int i = 1; i <= n; i++) {
		for (int j = 1; j <= n; j++) {
			g[i][j] = INF;
		}
		g[i][i] = 0;
	}

	for (int i = 1; i <= n; i++) {
		for (auto edge : d[i]) {
			g[edge.from][edge.to] = edge.cost;
		}
	}

	for (int k = 1; k <= n; k++) {
		for (int i = 1; i <= n; i++) {
			for (int j = 1; j <= n; j++) {
				if (g[i][k] + g[k][j] < g[i][j]) {
					g[i][j] = g[i][k] + g[k][j];
				}
			}
		}
	}

	for (int i = 1; i <= n; i++) {
		for (int j = 1; j <= n; j++) {
			cout << '\t' << g[i][j];
		}
		cout << endl;
	}
}

int main () {
	ios_base::sync_with_stdio(false);
	input();
	dijkstra();
	fordBellman();
	floydWarshall();
}
