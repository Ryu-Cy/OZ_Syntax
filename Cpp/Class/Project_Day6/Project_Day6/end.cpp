#include<iostream>

using namespace std;

/**********************************************
[Call By Value]
- 함수에 인수를 전달할 때 인수의 값이 복사되어 함수의 매개변수로 전달
- 함수 내부에서 매개변수를 변경하더라도 호출한 함수의 실제 인수는 변하지 않는다.

[Call By Address]
- 함수 호출 시 인수로 변수의 주소를 전달
- 함수가 매개변수로 받은 포인터를 통해 실제 인수의 값을 직접 수정할 수 있다.
- 함수 내부에서 매개변수의 값을 변경하면 호출한 함수의 실제 인수도 변경된다.

[Call By Reference]
- 함수 호출 시 인수로 변수의 참조(별명)를 전달
- 함수가 해당 참조를 통해 실제 인수에 접근하여 값을 직접 수정할 수 있다.
**********************************************/

//	Ex)
void Value(int x);
void Address(int* p);
void Reference(int& n);

int main()
{
	/*int num = 30;
	Value(num);
	cout << "num의 값: " << num << endl;
	cout << "num의 주소값: " << &num << endl;
	cout << endl;

	int num1 = 30;
	Address(&num1);
	cout << "num1의 값: " << num1 << endl;
	cout << "num1의 주소값: " << &num1 << endl;
	cout << endl;
	
	int num2 = 30;
	Reference(num2);
	cout << "num2의 값: " << num2 << endl;
	cout << "num2의 주소값: " << &num2 << endl;
	cout << endl;*/

	cout << (char)-35 << endl;


	return 0;
}

void Value(int x)
{
	x = 10;
	cout << "x의 값: " << x << endl;
	cout << "x의 주소값: " << &x << endl;
}
void Address(int* p)
{
	*p = 10;
	cout << "p의 값: " << *p << endl;
	cout << "p의 주소값: " << &p << endl;
}
void Reference(int& n)
{
	n = 10;
	cout << "n의 값: " << n << endl;
	cout << "n의 주소값: " << &n << endl;
}
