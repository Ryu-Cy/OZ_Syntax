#include<iostream>

using namespace std;

/**********************************
	과제
	5x5 사이즈의 빙고 게임 만들기
**********************************/

int main()
{
	int bingoArr[5][5] = {
		3,	15,	9,	8,	10,
		12,	6,	14,	1,	5,
		11,	4,	19,	2,	39,
		34,	27,	20,	33,	47,
		24, 18, 36, 42, 50
	};
	int inputNum = 0;
	int bingoCount = 0;
	bool checkAns = true;
	bool checkRow[5] = { false, false, false, false, false };
	bool checkCol[5] = { false, false, false, false, false };
	bool checkCro[2] = { false, false };

	
	while (1)
	{
		if (checkAns)
		{
			system("cls");	// 콘솔 내용 비우기

			int rowSum[5] = { 0, 0, 0, 0, 0 };
			int colSum[5] = { 0, 0, 0, 0, 0 };
			int croSum[2] = { 0, 0 };

			cout << "== 과제 ==" << endl;
			cout << "Bingo" << endl;
			cout << endl;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					// 숫자가 맞으면 '#'전환
					if (bingoArr[i][j] == inputNum)
					{
						bingoArr[i][j] = (char)35;
					}
					// 빙고판 출력
					if (bingoArr[i][j] == (char)35)
					{
						cout << (char)bingoArr[i][j] << "	";
					}
					else
					{
						cout << bingoArr[i][j] << "	";
					}

					// 행, 열, 대각선 더하기
					rowSum[i] += bingoArr[i][j];
					colSum[i] += bingoArr[j][i];
					if (i + j == 4)
					{
						croSum[0] += bingoArr[i][j];
					}
					if (i == j)
					{
						croSum[1] += bingoArr[i][j];
					}
				}
				// 빙고 체크
				// 행, 열 체크
				if (rowSum[i] == 35 * 5 && !checkRow[i])
				{
					bingoCount++;
					checkRow[i] = true;
				}
				if (colSum[i] == 35 * 5 && !checkCol[i])
				{
					bingoCount++;
					checkCol[i] = true;
				}
				// 대각선 체크
				if (croSum[0] == 35 * 5 && !checkCro[0])
				{
					bingoCount++;
					checkCro[0] = true;
				}
				if (croSum[1] == 35 * 5 && !checkCro[1])
				{
					bingoCount++;
					checkCro[1] = true;
				}

				cout << endl << endl;
			}

			cout << "Binog count: " << bingoCount << endl;
			if (bingoCount == 3)
			{
				break;
			}

			checkAns = false;
		}

		cout << "숫자 입력: ";
		cin >> inputNum;
		checkAns = true;

	}
	cout << endl;
	cout << "빙고가 3줄 완성되었습니다." << endl;


	return 0;
}