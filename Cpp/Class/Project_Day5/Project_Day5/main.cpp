#include<iostream>

using namespace std;

/**************************************************
[함수(Function)]
- 특정 작업을 수행하는 코드의 집합.
- 코드의 재사용성
- 볼륨이 커지는 프로그램일 수록 수정, 유지보수가 쉽지 않기 때문에 기능 별로 세분화

[함수의 형태]
- 매개변수의 유무에 따라 네 개의 형태를 가짐
	1. 매개변수o, 반환 값o
	2. 매개변수o, 반환 값x
	3. 매개변수x, 반환 값o
	4. 매개변수x, 반환 값x

클린 코드
- 함수는 한 가지를 해야한다.
- 함수는 단 하나의 역할만을 위해서만 존재해야 한다.
**************************************************/

void Print()
{
	cout << "Hi~" << endl;
}

void PrintNumber(int a)
{
	cout << a << endl;
}

int Add(int x, int y);
int Sub(int x, int y);
int Mul(int x, int y);
int Div(int x, int y);


int main()
{
	Print();
	PrintNumber(1);
	cout << Add(2, 1) << endl;
	cout << Sub(2, 1) << endl;
	cout << Mul(2, 1) << endl;
	cout << Div(2, 1) << endl;

	return 0;
}

int Add(int x, int y)
{
	return x + y;
}
int Sub(int x, int y)
{
	return x - y;
}
int Mul(int x, int y)
{
	return x * y;
}
int Div(int x, int y)
{
	return x / y;
}