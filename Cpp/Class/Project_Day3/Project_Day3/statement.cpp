#include<iostream>

using namespace std;

/********************************************
[조건문] if, else, else if
- 프로그램의 실행 흐름을 제어하는 용도로 사용
- 주어진 조건의 참/거짓에 따라 코드블록의 실행을 결정
- 조건문 아래 중괄호는 내용이 한 줄일 경우 생략 가능
- 중첩 가능

if ()
{
	()안의 조건이 true라면 실행
}
else if ()
{
	위 if문의 조건이 false일 때, ()안의 조건이 true라면 실행
}
else
{
	위 if/else if의 조건이 모두 false일 때 실행
}

********************************************/

int main()
{
	/*
	if (true)
	{
		cout << "if문 ()안의 조건이 true라면 실행." << endl;
	}
	if (false)
	{
		cout << "두 번째 if문" << endl;
	}
	else if (true)
	{
		cout << "else if문" << endl;
	}
	else
	{
		cout << "else 실행" << endl;
	}
	*/


	/*
	int num;
	cout << "정수 입력: ";
	cin >> num;

	if (num > 0)
	{
		cout << num << "은 양수이다." << endl;
	}
	else if (num < 0)
	{
		cout << num << "은 음수이다." << endl;
	}
	else
	{
		cout << num << "은 0이다." << endl;
	}

	int input;
	cout << "숫자 입력: ";
	cin >> input;

	if ((input % 2) == 0)
	{
		cout << input << "은 짝수" << endl;
	}
	else
	{
		cout << input << "은 홀수" << endl;
	}
	*/


	/*
	int month;
	cout << "월을 입력하라(1~12): ";
	cin >> month;

	if (month >= 1 && month <= 12)
	{
		if (month >= 3 && month <= 5)
		{
			cout << "봄" << endl;
		}
		else if (month >= 6 && month <= 8)
		{
			cout << "여름" << endl;
		}
		else if (month >= 9 && month <= 11)
		{
			cout << "가을" << endl;
		}
		else
		{
			cout << "겨울" << endl;
		}
	}
	else
	{
		cout << month << "값의 범위를 벗어났습니다." << endl;
	}

	int marks;
	cout << "점수를 입력: ";
	cin >> marks;

	if (marks >= 0 && marks <= 100)
	{
		if (marks >= 60)
		{
			cout << "합격 ";
			if (marks >= 90)
			{
			cout << "A" << endl;
			}
			else if (marks >= 80)
			{
			cout << "B" << endl;
			}
			else if (marks >= 70)
			{
				cout << "C" << endl;
			}
		}
		else
		{
			cout << "불합격" << endl;
		}
	}
	else
	{
		cout << marks << "는 값의 범위를 벗어났습니다." << endl;
	}
	*/

	// 실습
	// 1. 적의 체력 존재
	// 2. 플레이어의 체력 존재
	// 3. 플레이어의 공격 존재
	//	3 - 1. 기본 공격
	// 3 - 2. 강한 공격
	// 3 - 3. 치유마법

	int playerHp;
	int playerAttackPower;
	int playerHealSkill;
	int enemyHp;
	
	int playerInput;

	playerHp = 50;
	playerAttackPower = 10;
	playerHealSkill = 10;
	enemyHp = 100;
	
	while (1)
	{
		if (playerHp <= 0 || enemyHp <= 0)
		{
			if (playerHp <= 0)
				cout << "플레이어가 쓰러졌습니다." << endl;
			else
				cout << "고블린이 쓰러졌습니다." << endl;
			break;
		}
		cout << "플레이어의 현재 체력: " << playerHp << endl;
		cout << "고블린의 현재 체력: " << enemyHp << endl << endl;

		cout << "행동을 선택하시오." << endl;
		cout << "1. 기본 공격" << endl;
		cout << "2. 강한 공격" << endl;
		cout << "3. 치유 마법" << endl << endl;

		cin >> playerInput;

		if (playerInput == 1)
		{
			enemyHp -= playerAttackPower;
			cout << "기본 공격: 고블린에게 " << playerAttackPower << "만큼의 대미지를 입혔다." << endl;
			cout << "고블린의 체력: " << enemyHp << endl << endl;
		}
		else if (playerInput == 2)
		{
			enemyHp -= playerAttackPower * 2;
			cout << "강한 공격: 고블린에게 " << playerAttackPower * 2 << "만큼의 대미지를 입혔다." << endl;
			cout << "고블린의 체력: " << enemyHp << endl << endl;
		}
		else if (playerInput == 3)
		{
			playerHp += playerHealSkill;
			cout << "치유 마법: 플레이어의 체력을 " << playerHealSkill << "만큼의 회복시켰다." << endl;
			cout << "플레이어의 체력: " << playerHp << endl << endl;
		}
		else
		{
			cout << "잘못 입력했습니다." << endl << endl;
		}
	}

	return 0;
}