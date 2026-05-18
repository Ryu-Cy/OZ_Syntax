#include<iostream>

using namespace std;

/**************************************************
[배열]
- 동일한 타입의 여러 값을 연속적으로 저장할 수 있는 데이터 구조.
- 메모리에 연속적인 공간을 가지고 각 요소는 인덱스를 통해 접근 가능.

C# 리스트와 C++ 리스트는 완전히 다름.

**************************************************/

int main()
{
	int numbers[5];

	numbers[0] = 1;
	cout << numbers[0] << endl;

	int arr[] = {1, 2, 3};

	cout << arr[2] << endl;
	int score[5] = { 10, 20, 30, 40, 50 };
	for (int i = 0; i < 5; i++)
	{
		cout << score[i] << endl;
	}

	int sum = 0;
	for (int i = 0; i < 5; i++)
	{
		sum += score[i];
	}
	cout << sum << endl;



	return 0;
}