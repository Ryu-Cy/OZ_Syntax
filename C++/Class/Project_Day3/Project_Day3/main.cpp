#include<iostream>

using namespace std;

/********************************************
[관계 연산자]
- 두 피연산자의 값을 비교해서 그 관계가 참(true)인지 거짓(false)인지 판단하는 연산자.
- 연산자의 결과는 항상 bool 타입인 참(true)/거짓(false)으로 반환한다.
- 주로 조건문, 반복문 등에서 흐름을 제어하는 역할 수행
- 참(true)는 1로, 거짓(false)은 0으로 반환

a = 10, b = 20
	연산자			의미										예시			결과
	==				두 값이 같은가						a == b		거짓(false)
	!=					두 값이 다른가						a != b		참(true)
	>					왼쪽이 더 큰가						a > b			거짓(false)
	<					오른쪽이 더 큰가					a < b			참(true)
	>=				왼쪽이 더 크거나 같은가			a >= b		거짓(false)
	<=				오른쪽이 더 크거나 같은가		a <= b		참(true)

* 주의점
	=(대입), ==(비교) 혼동하지 말 것.
	a = b : a에 b의 값을 대입
	a == b : a와 b가 같은가?


[논리 연산자]
- 주어진 여러 개의 조건(관계식)을 결합하여 하나의 참(true)/거짓(false)을 판단할 때 사용
- 조건문(if), 반복문(for, while), 게임로직, 범위체크 등...

A = ture, B = false
	연산자			의미												예시			결과
	AND(&&)		두 조건이 모두 참(true)인가			A && B		거짓(false)
	OR(||)			두 조건 중 하나라도 참(true)인가	A || B		참(true)
	NOT(!)			조건이 거짓인가								!A				거짓(false)


[복합 대입 연산자]

	연산자			의미
	+=			a = a + b
	-=				a = a - b
	*=			a = a * b
	/=				a = a / b
	%=			a = a % b
	&=, |=, ^=, <<=, >>= 등...
********************************************/

int main()
{
	/*		== 관계 연산자 ==
	int a = 10;
	int b = 20;

	bool return1 = (a == b);
	bool return2 = (a != b);
	bool return3 = (a > b);
	bool return4 = (a < b);
	bool return5 = (a >= 10);
	bool return6 = (a <= 20);

	cout << return1 << endl;
	cout << return2 << endl;
	cout << return3 << endl;
	cout << return4 << endl;
	cout << return5 << endl;
	cout << return6 << endl;
	*/

	
	/*		== 논리 연산자 ==
	bool a = true;
	bool b = true;

	cout << "== AND ==" << endl;

	cout << (a && b) << endl;
	cout << (true && true) << endl;
	cout << (true && false) << endl;
	cout << (false && false) << endl;
	cout << (false && true) << endl;

	cout << "== OR ==" << endl;

	cout << (true || true) << endl;
	cout << (true || false) << endl;
	cout << (false || false) << endl;
	cout << (false || true) << endl;

	int x = 10;
	int y = 20;

	cout << "== 예시 ==" << endl;

	cout << (x > y || y == 20) << endl;

	int num1 = 10;
	int num2 = 0;
	bool result = (num1 > 5) && (num2 || 1);
	cout << result << endl;


	cout << "== NOT ==" << endl;

	cout << (!true) << endl;
	cout << (!false) << endl;
	*/


	int number1 = 5;
	int number2 = 3;
	number1 += number2;
	number1 -= 3;
	cout << number1 << endl;

	int bitNum1 = 20;
	int bitNum2 = 16;

	int bitres = bitNum1 & bitNum2;
	cout << "bit &연산: " << bitres << endl;
	bitres = bitNum1 | bitNum2;
	cout << "bit |연산: " << bitres << endl;

	int shiftBitNum = 10;
	int shiftRes = shiftBitNum << 2;
	cout <<  "bit <<연산: " << shiftRes << endl;
	shiftRes = shiftBitNum >> 1;
	cout <<  "bit >>연산: " << shiftRes << endl;
	// 한 칸당 *2 , /2



	return 0;
}