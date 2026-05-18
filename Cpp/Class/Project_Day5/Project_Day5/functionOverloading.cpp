#include<iostream>

using namespace std;

/**************************************************
[함수 오버로딩]
- 동일한 함수 이름을 사용해서 매개변수의 타입, 개수, 순서를 다르게 정의하는 것.
- 가독성 및 편의성 향상 
	-> 비슷한 작업을 수행하는 여러 함수가 있을 때 각 함수에 다른 이름을 부여하는 대신 함수 오버로딩을 사용하면 코드의 가독성이 향상되며 
	사용자는 하나의 함수 이름으로 다양한 형태의 함수 호출 가능
- 일관성 유지
	-> 비슷한 작업을 하는 함수들이 많은 경우 함수 오버로딩을 사용하면 각 함수들이 동일한 이름을 가지고 있어 코드의 일관성 유지

[조건]
- 함수의 이름 동일.
- 매개 변수의 데이터 타입이 다르거나 개수가 달라야 한다.
- 리턴 타입만 다른 것은 허용x
**************************************************/

void Print(int num);
void Print(double num);
void Print(float num);

int Add(int x, int y);
int Add(int x, int y, int z);

int main()
{
	Print(10);
	Print(3.14);
	Print(0.7f);

	cout << Add(1, 2) << endl;
	cout << Add(1, 2, 3) << endl;

	return 0;
}

void Print(int num)
{
	cout << num << endl;
}
void Print(double num)
{
	cout << num << endl;
}
void Print(float num)
{
	cout << num << endl;
}

int Add(int x, int y)
{
	return x + y;
}
int Add(int x, int y, int z)
{
	return x + y + z;
}