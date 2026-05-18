#include<iostream>

using namespace std;

/******************************
					승급 과제
	for문 이용
		1. 특정 단수 구구단 출력
		2. 1~100 사이 짝수의 합 계산
		3. 역순 카운트 다운
	while문 이용
		4. 1~입력 값 까지의 합 계산
******************************/

int main()
{
	// 1. 특정 단수 구구단 출력
	cout << "== 과제 1 ==" << endl;
	int inputNum;
	cout << "구구단을 출력할 단수를 입력해주세요: ";
	cin >> inputNum;
	for (int i = 1; i < 10; i++)
	{
		cout << inputNum << " * " << i << " = " << inputNum * i << endl;
	}
	cout << endl;

	// 2. 1~100 사이 짝수의 합 계산
	cout << "== 과제 2 ==" << endl;
	int sum = 0;
	for (int i = 1; i <= 100; i++)
	{
		if (i % 2 == 0)
		{
			sum += i;
		}
	}
	cout << "1부터 100사이의 모든 짝수의 합: " << sum << endl;
	cout << endl;

	// 3. 역순 카운트다운 프로그램
	cout << "== 과제 3 ==" << endl;
	for (int i = 10; i > 0; i--)
	{
		cout << i << endl;
	}
	cout << "발사!" << endl;
	cout << endl;

	// 4. 1부터 입력 값까지의 합
	cout << "== 과제 4 ==" << endl;
	int inputNum1;
	int num = 1;
	int total = 0;
	cout << "양의 정수를 입력해주세요: ";
	cin >> inputNum1;
	cout << num << "부터 " << inputNum1 << "까지의 합은 ";
	while (num  <= inputNum1)
	{
		total += num;
		num++;
	}
	cout << total << "입니다." << endl;


	return 0;
}