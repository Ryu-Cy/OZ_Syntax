#include<iostream>

using namespace std;

/******************************
					도전 과제
	for문 이용
		1. 별 찍기 (직각삼각형)
		2. 369게임 (1~30)
		3. 정수 뒤집기
	while문 이용
		4. 입력받은 숫자의 자릿수 합계 구하기
******************************/

int main()
{
	// 과제 1. 별 찍기 (직각삼각형)
	cout << "== 과제 1 ==" << endl;
	int inputHeight;
	cout << "삼각형의 높이를 입력해주세요: ";
	cin >> inputHeight;
	for (int i = 0; i < inputHeight; i++)
	{
		for (int j = 0; j < i+1; j++)
		{
			cout << "*";
		}
		cout << endl;
	}
	cout << endl;
	
	// 과제 2. 369게임 (1~30)
	// 30대 짝 해결해야함
	cout << "== 과제 2 ==" << endl;
	for (int i = 1; i <= 30; i++)
	{
		if (i % 10 == 3 || i % 10 == 6 || i % 10 == 9)
		{
			cout << "짝 ";
		}
		else if (i / 10 == 3 || i / 10 == 6 || i / 10 == 9)
		{
			cout << "짝 ";
		}
		else
		{
			cout << i << " ";
		}
	}
	cout << endl << endl;
	
	
	// 과제 3. 정수 뒤집기
	cout << "== 과제 3 ==" << endl;
	int inputNum;
	int reverse = 0;
	cout << "뒤집을 정수를 입력해주세요: ";
	cin >> inputNum;
	while (inputNum != 0)
	{
		reverse *= 10;
		reverse += inputNum % 10;	
		inputNum /= 10;
	}
	cout << "뒤집은 결과: " << reverse << endl;
	cout << endl;
	
	
	// 과제 4. 입력받은 숫자의 자릿수 합계 구하기
	cout << "== 과제 4 ==" << endl;
	int inputNum1;
	int result = 0;
	cout << "정수를 입력해주세요: ";
	cin >> inputNum1;
	while (inputNum1 != 0)
	{
		result += inputNum1 % 10;
		inputNum1 /= 10;
	}
	cout << "각 자릿수의 합: " << result << endl;
	cout << endl;



	return 0;
}