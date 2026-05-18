#include<iostream>

using namespace std;

/******************************************
[산술 연산자]
+, -, *, /, %
+	: 더하기			a + b
-	: 빼기			a - b
*	: 곱하기			a * b
/	: 나누기			a / b
%	: 나머지 값	a % b

[대입 연산자]
=

[증감 연산자]
++, --	: 피 연산자의 값을 1씩 증가or감소 시키는 연산자
전위, 후위 방식이 존재하며 전위는 증감 후 연산, 후위는 연산 후 증감의 방식이다.
******************************************/



int main()
{
	int a = 10;
	int b = 3;

	cout << "==산술 연산자==" << endl;
	cout << "a+b= " << a + b << endl;
	cout << "a-b= " << a - b << endl;
	cout << "a*b= " << a * b << endl;
	cout << "a/b= " << a / b << endl;
	cout << "a%b= " << a % b << endl;
	
	int num = 10;
	
	cout << "num의 값: " << num << endl;
	num++;
	cout << "num++후 값: " << num << endl;
	--num;
	cout << "num++후 --num한 값: " << num << endl;

	int num1 = 10;
	int num2 = 20;
	int c;
	int d;

	c = ++num1;		// 전위, 대입 연산 전 증가 후 대입 연산 진행
	cout << "변수 c의 값: " << c << ", " << "변수 num1의 값: " << num1 << endl;
	d = num2++;	// 후위, 대입 연산 후 증가
	cout << "변수 d의 값: " << d << ", " << "변수 num2의 값: " << num2 << endl;


	return 0;
}