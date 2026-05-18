#include<iostream>

using namespace std;

/*****************************************************
과제 1. 리마인드(자유주제)
	- 복습을 활용한 자유구현
	- 내가 할 수 있는 범위 내에서
과제 2. 함수(자유주제)
	- 게임에서의 특정 기능을 함수로 구현하기 (3개 이상)
과제 3. 배열
	- 배열에 저장된 최대값 찾기
*****************************************************/


int NormalAttack(int x, int y);
int UseMysticShot(int x, int y);
int UseHeal(int x, int y);
void StatusCheck(int x, bool y);


int main()
{
	// 과제 1. 리마인드
	// 자유주제 - 숫자를 5번 입력받아 배열에 저장한 후 배열 출력하기
	int arrInputNum[5];
	int inputNum;
	for (int i = 0; i < 5; i++)
	{
		cout << "저장할 숫자를 입력해주세요: ";
		cin >> inputNum;
		arrInputNum[i] = inputNum;
	}
	for (int i = 0; i < 5; i++)
	{
		cout << arrInputNum[i] << " ";
	}
	cout << endl << endl;

	// 과제 2. 함수
	// 도대체 뭘 만들어야하는 걸까...
	// 2-1. 1입력 시 기본 공격 발동
	// 2-2. 2입력 시 신비한 화살 발동
	// 2-3. 3입력 시 회복 발동
	// 2-4. 전투 대미지 판단 후 상태 출력
	int inputNumFunc;
	int playerHp = 70;
	int playerPower = 10;
	int enemyHp = 100;
	bool isPlayer = true;
	cout << "== 과제 2 ==" << endl;
	while (playerHp != 0 && enemyHp != 0)
	{
		cout << "행동을 선택해주세요." << endl;
		cout << "1. 기본 공격" << endl;
		cout << "2. 신비한 화살" << endl;
		cout << "3. 회복" << endl;
		cout << "0. 종료" << endl;
		cin >> inputNumFunc;

		if (inputNumFunc == 1)
		{
			enemyHp = NormalAttack(playerPower, enemyHp);
			StatusCheck(enemyHp, !isPlayer);
			cout << endl;
		}
		else if (inputNumFunc == 2)
		{
			enemyHp = UseMysticShot(playerPower, enemyHp);
			StatusCheck(enemyHp, !isPlayer);
			cout << endl;
		}
		else if (inputNumFunc == 3)
		{
			playerHp = UseHeal(playerPower, playerHp);
			StatusCheck(playerHp, isPlayer);
			cout << endl;
		}
		else if (inputNumFunc == 0)
		{
			cout << "종료합니다." << endl;
			break;
		}
	}
	cout << endl;

	// 과제 3. 배열에 저장된 최대값 찾기
	cout << "== 과제 3 ==" << endl;
	int arr[4] = { 10, 30, 17,265 };
	int tmp = 0;
	cout << "배열 안의 값: ";
	for (int i = 0; i < 4; i++)
	{
		cout << arr[i] << " ";
		if (tmp < arr[i])
		{
			tmp = arr[i];
		}
	}
	cout << endl;
	cout << "배열 안의 가장 큰 값: " << tmp << endl;


	return 0;
}


int NormalAttack(int x, int y)
{
	int currentEnemyHp;
	cout << "기본 공격을 사용했습니다. 대미지: " << x << endl;
	currentEnemyHp = y - x;
	if (currentEnemyHp <= 0)
	{
		currentEnemyHp = 0;
	}
	return currentEnemyHp;
}

int UseMysticShot(int x, int y)
{
	int currentEnemyHp;
	cout << "신비한 화살을 사용했습니다. 대미지: "<< x * 2 << endl;
	currentEnemyHp = y - (x * 2);
	if (currentEnemyHp <= 0)
	{
		currentEnemyHp = 0;
	}
	return currentEnemyHp;
}

int UseHeal(int x, int y)
{
	int currentPlayerHp;
	cout << "회복을 사용했습니다. 회복량: " << x << endl;
	currentPlayerHp = y + x;
	if (currentPlayerHp >= 100)
	{
		currentPlayerHp = 100;
	}
	return currentPlayerHp;
}

void StatusCheck(int x, bool y)
{
	if (y)
	{
		cout << "현재 플레이어의 체력은 " << x << "입니다." << endl;
		if (x >= 100)
		{
			cout << "플레이어의 체력이 가득 찼습니다." << endl;
		}
	}
	else
	{
		cout << "현재 적의 체력은 " << x << " 입니다." << endl;
		if (x <= 0)
		{
			cout << "적이 사망하였습니다." << endl;
		}
	}
	
}
