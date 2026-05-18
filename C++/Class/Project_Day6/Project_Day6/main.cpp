#include<iostream>

using namespace std;

/**********************************************
[2차원 배열]
- 표기 방식: 
	arr[2(row)][3(col)]	->	arr[0][0] arr[0][1] arr[0][2]
							arr[1][0] arr[1][1] arr[1][2]
- 

**********************************************/

int main()
{
	/*
	// 아래 표가 있다고 가정하고 가로의 합, 세로의 합, 모든 수의 합을 구하려면 어떻게 해야하는가
	int arr[15] =
	{
		90, 78, 77, 98, 98,
		80, 45, 67, 88, 57,
		88, 99, 65, 55, 74
	};
	// 가로(row)의 합 구하기
	// 규칙: 행(row) x 열(col) + 열
	int row = 3;
	int col = 5;

	for (int i = 0; i < row; i++)
	{
		int rowSum = 0;	// 각 행의 합을 저장할 변수
		
		for (int j = 0; j < col; j++)
		{
			int index = i * col + j;
			rowSum += arr[index];
		}
		cout << i << "행의 합: " << rowSum << endl;
	}
	// 세로(col)의 합 구하기
	// 위 방식에서 행(row)와 행(col)의 위치만 바꿔주면 됨.
	// 전체 합 구하기
	int total = 0;
	for (int i = 0; i < 15; i++)
	{
		total += arr[i];
	}
	*/

	/*
	int array1[4][3] = { 1,2,3,4,5,6,7,8,9,10,11,12 };

	for (int i = 0; i < 4; i++)
	{
		cout << endl;
		for (int j = 0; j < 3; j++)
		{
			cout << array1[i][j] << " ";
		}
	}
	cout << endl;

	int array2[4][3] = { {1,2,3}, {4,5,6}, {7,8,9}, {10} };

	for (int i = 0; i < 4; i++)
	{
		cout << endl;
		for (int j = 0; j < 3; j++)
		{
			cout << array2[i][j] << " ";
		}
	}
	*/

	// 위의 1차원 배열로 행의 합을 구했던 방식을 2차원 배열로 구현
	int arr[3][5] = {
		{90, 78, 77, 98, 98},
		{80, 45, 67, 88, 57},
		{88, 99, 65, 55, 74}
	};
	int total = 0;

	for (int i = 0; i < 3; i++)
	{
		int rowSum = 0;
		for (int j = 0; j < 5; j++)
		{
			rowSum += arr[i][j];
		}
		cout << "행의 합: " << rowSum << endl;
	}
	




	return 0;
}