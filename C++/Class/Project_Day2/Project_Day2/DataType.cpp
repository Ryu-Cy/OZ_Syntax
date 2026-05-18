#include<iostream>

using namespace std;

/******************************************
[자료형(DataType)]
- 자료의 형태를 지정
- 데이터가 메모리에 저장되는 형식을 명시
	- 정수형 -
		이름			형태								크기(Byte)			표현 범위
		int			부호가 있는 정수			4						-21억 ~ 21억
		short			부호가 있는 정수			2						-3.2만 ~ 3.2만
	일반적으로 int를 사용

	- 실수형 -
		이름			형태								크기(Byte)			표현 범위			정밀도
		float			부호가 있는 실수			4						굉장히				소수점 7
		double		부호가 있는 실수			8						넓다					소수점 15
	일반적으로 float을 사용

	unsigned: 음의 부호는 제외하며 배제한 음의 수만큼 양의 수에 더한다. ex) Level 등

	- 문자형 -
		이름			형태				크기(Byte)			표현 범위
		char			'a', 'b'...		1


	BytㄷPadding 
	남는 공간은 채워버리고 넘어감

******************************************/
int main()
{
	cout << "==정수형 데이터 타입 크기==" << endl;
	cout << "int형 크기: " << sizeof(int) << "Byte" << endl;
	cout << "short형 크기: " << sizeof(short) << "Byte" << endl << endl;

	cout << "==실수형 데이터 타입 크기==" << endl;
	cout << "float형 크기 : " << sizeof(float) << "Byte" << endl;
	cout << "double형 크기: " << sizeof(double) << "Byte" << endl << endl;

	cout << "==문자형 데이터 타입 크기==" << endl;
	cout << "char형 크기 : " << sizeof(char) << "Byte" << endl << endl;

	short number = 300;
	short number1 = 200;
	short result;

	cout << "변수 number 크기: " << sizeof(number) << "Byte" << endl;
	cout << "변수 number1 크기: " << sizeof(number1) << "Byte" << endl;

	result = number + number1;
	cout << "short 변수 number, number1의 크기: " << sizeof(number + number1) << "Byte" << endl;
	cout << "변수 result의 크기: " << sizeof(result) << "Byte" << endl << endl;

	char c;
	char d;

	cout << "변수 c의 크기: " << sizeof(c) << "Byte" << endl;
	cout << "변수 d의 크기: " << sizeof(d) << "Byte" << endl;
	cout << "변수 c, d의 크기: " << sizeof(c + d) << "Byte" << endl << endl;	// 계산할 때 int형의 형태가 가장 빠르고, 그렇기에 int형식으로 변환해서 계산하기에 4byte의 크기로 변경된다.

	int input;
	cout << "정수 입력: ";
	cin >> input;
	cout << "입력 값: " << input << endl;

	return 0;
}