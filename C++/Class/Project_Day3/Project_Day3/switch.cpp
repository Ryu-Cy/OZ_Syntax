#include<iostream>

using namespace std;

/********************************************
[switch]
- 여러 조건을 처리할 때 사용하는 분기문(조건문) 중 하나
- 하나의 변수를 검사하고 그 변수의 값에 따라 여러 case 블록 중 하나를 실행
- 여러 선택지 중 하나를 선택하는 상황에서 사용하기 좋다
- 코드의 가독성을 높이고 효율성 개선이 가능하지만, 표현식의 제한이 존재
- 범위 기반 비교 불가
- if문은 범용적으로 다양한 조건을 다루는 데 유용하고 논리 연산자를 사용해 복잡한 조건을 만들 수 있음.
- break키워드를 통해 각 case의 실행을 종료

[break]
- 반복문이나 switch문을 제어할 때 사용함.
- break가 실행되면 해당 루프나 switch문을 종료하고 break다음으로 이동하여 실행
- 다중 switch나 중첩 반복문에서는 break가 있는 해당 스코프만 빠져나가게 된다.
********************************************/

int main()
{
	/*
	int choice;

	cout << "게임을 선택하세요." << endl;
	cout << "1. 리그 오브 레전드" << endl;
	cout << "2. 발로란트" << endl;
	cout << "3. 스타크래프트" << endl;
	cout << "숫자를 입력하세요: ";
	cin >> choice;

	switch (choice)
	{
	case 1:
		cout << "리그 오브 레전드를 선택했습니다." << endl;
		break;
	case 2:
		cout << "발로란트를 선택했습니다." << endl;
		break;
	case 3:
		cout << "스타크래프트를 선택했습니다." << endl;
		break;
	default:
		break;
	}
	*/

	
	int jopChoice;
	int skillChoice;

	cout << "직업을 선택하시오." << endl;
	cout << "1. 전사" << endl;
	cout << "2. 마법시" << endl;
	cout << "3. 도적" << endl;
	cin >> jopChoice;

	switch (jopChoice)
	{
	case 1:
		cout << "전사를 선택했습니다. 사용할 스킬을 선택하시오." << endl;
		cout << "1. 기본 공격" << endl;
		cout << "2. 강한 공격" << endl;
		cin >> skillChoice;

		switch (skillChoice)
		{
		case 1:
			cout << "기본 공격을 선택했습니다." << endl;
			break;
		case 2:
			cout << "강한 공격을 선택했습니다." << endl;
			break;
		}

	break;
	}

	cout << "모든 switch문을 빠져나옴" << endl;


	return 0;
}