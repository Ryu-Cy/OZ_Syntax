#include<iostream>

using namespace std;

/*****************************************************
[반복문]
	while
- 조건이 참인 동안 특정 코드를 반복 실행
- 조건이 거짓이 될 떄까지 반복
- 일반적으로 반복 횟수가 미리 정해지지 않았거나 특정 조건을 만족할 때까지 반복할 때 사용

	do while
- 조건이 참인지 여부와 관계 없이 코드블록을 최소 한 번은 실행해야할 때 사용

*****************************************************/


int main()
{
	/*
	int num = 0;
	while (num < 10)
	{
		cout << num << endl;
		num++;
	}
	*/

	/*
	int sum = 0;
	int num = 0;

	while (true)
	{
		sum += num;
		if (sum > 5000)
		{
			break;
		}
		num++;
	}
		cout << "sum: " << sum << ", num: " << num << endl;
		*/

	/*
	cout << "숫자를 입력하시오." << endl;
	while (true)
	{
		int inputNum;
		cin >> inputNum;
		cout << "내가 입력한 숫자: " << inputNum << endl;

		if (inputNum < 1 || inputNum > 10)
		{
			break;
		}
	}
	*/

	/*
	int inputNum = 1;
	int total = 0;
	while (inputNum != 0)
	{
		cout << "0보다 큰 수를 입력하시오. (종료하려면 0): ";
		cin >> inputNum;

		total += inputNum;
	}
	cout << "Total: " << total << endl;
	*/

	int inputNum;
	int total;
	do
	{
		cout << "0보다 큰 숫자를 입력하시오. : " << endl;
		cin >> inputNum;
		total += inputNum;
	} while (inputNum != 0);
	cout << "Total: " << total << endl;


	return 0;
}