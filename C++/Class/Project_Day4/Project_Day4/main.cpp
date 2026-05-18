#include<iostream>

using namespace std;

/*****************************************************
[반복문]
	for
- 반복 작업을 수행할 때 사용되는 반복문 중 하나.
- 반복 횟수가 명확하거나 정밀한 제어가 필요할 때 유용
- while문 보다 상대적으로 많은 코드로 이루어져 있지만, 임의의 횟수만큼 반복을 수행하기에는 for문이 편리하다.

- 반복 횟수가 정해져있을 때
- 범위가 명확할 때
- 배열의 모든 요소를 순서대로 볼 때
- 몇 번 반복할지 감이 잡히는 경우
*****************************************************/



int main()
{
	/*
	for (int i = 0; i < 5; i++)
	{
		cout << "Hi~" << endl;
	}
	*/
	// 1. 초기식 실행 (int i = 0)
	// 2. 조건식 검사 (i < lenth)
	// 3. 조건이 참이면 코드 실행
	// 4. 증감식 실행 (i++)
	// 5. 다시 조건식 검사
	// 조건이 거짓이 될 떄까지 반복

	/*
	for (int i = 0; i < 10; i++)
	{
		cout << i << endl;
	}	// 증가
	for (int i = 10; i < 0; i++)
	{
		cout << i << endl;
	}	// 감소

	int sum = 0;
	for (int i = 0; i < 6; i++)
	{
		sum += i;
	}
	cout << sum << endl;

	for (int i = 2; i <= 10; i += 2)
	{
		cout << i << endl;
	}
	*/

	/*
	for (int i = 1; i < 10; i++)
	{
		if (i > 5)
		{
			break;
		}
		cout << i << endl;
	}
	

	for (int i = 0; i <= 10; i++)
	{
		if (i % 2 == 0)
		{
			cout << i << "짝수" << endl;
		}
		else
		{
			cout << i << "홀수" << endl;
		}
	}
	*/

	/*
	int sum = 0;
	int score;

	for (int i = 0; i <= 5; i++)
	{
		cout << i << " 번쨰 점수 입력: ";
		cin >> score;

		sum += score;
	}
	cout << sum << endl;

	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			cout << "i의 값: " << i << ", j의 값: " << j << endl;
		}
	}
	*/

	for (int i = 2; i < 10; i++)
	{
		for (int j = 1; j < 10; j++)
		{
			cout << i << " * " << j << " = " << i * j << endl;
		}
	}


	return 0;
}