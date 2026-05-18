#include<iostream>

using namespace std;

// 과제 2. if문 구현 과제
//			2-1 숫자를 입력 받아 홀/짝 판별하기
//			2-2 HP를 입력받아 상태 판별하기
// 과제 3. switch/if문을 활용한 구현 과제
//			3-1 게임 선택 (3개)
//			3-2 캐릭터 선택 (2개)
//			3-3 기술 선택 (2개)

int main()
{
	// 과제 2-1.
	// 숫자를 입력 받아 홀/짝 판별하기
	int numCheck;
	
	cout << "== 과제 2-1. 홀/짝 판별기 ==" << endl << endl;
	cout << "숫자 입력: ";
	cin >> numCheck;

	if ((numCheck % 2) == 0)
	{
		cout << numCheck << "은(는) 짝수입니다." << endl;
	}
	else
	{
		cout << numCheck << "은(는) 홀수입니다." << endl;
	}
	cout << endl;

	// 과제 2-2. HP를 입력받아 상태 체크하기
	int inputHp;

	cout << "== 과제 2-2. 플레이어 상태 체크하기 ==" << endl << endl;
	for (int i = 0; i < 3; i++)
	{
		cout << "현재 HP 입력: ";
		cin >> inputHp;

		if (inputHp <= 0)
		{
			cout << "사망하였습니다." << endl;
		}
		else if (inputHp <= 50)
		{
			cout << "위험한 상태입니다." << endl;
		}
		else
		{
			cout << "정상입니다." << endl;
		}
		cout << endl;
	}
	

	//===============================================
	
	// 과제 3. switch/if문을 활용한 구현 과제
	int selectGame;
	int selectCharacter;
	int selectSkill;

	cout << "== 과제 3. 게임/캐릭터/스킬 선택하기 ==" << endl << endl;
	cout << "게임을 선택해주세요." << endl;
	cout << "1. 리그 오브 레전드" << endl;
	cout << "2. 스타크래프트" << endl;
	cout << "3. 붉은사막" << endl;
	cin >> selectGame;

	switch (selectGame)
	{
	case 1:
		cout << "리그 오브 레전드를 선택하셨습니다." << endl;
		cout << "플레이할 캐릭터를 선택해주세요." << endl;
		cout << "1. 가렌" << endl;
		cout << "2. 다리우스" << endl;
		cin >> selectCharacter;

		switch (selectCharacter)
		{
		case 1:
			cout << "가렌을 선택하셨습니다." << endl;
			cout << "사용할 스킬을 선택해주세요." << endl;
			cout << "1. 일반 공격" << endl;
			cout << "2. 강력한 공격" << endl;
			cin >> selectSkill;

			switch (selectSkill)
			{
			case 1:
				cout << "가렌의 일반 공격을 사용합니다." << endl;
				break;
			case 2:
				cout << "가렌의 강력한 공격을 사용합니다." << endl;
				break;
			default:
				cout << "잘못된 번호를 입력했습니다." << endl;
				break;
			}
			break;
		case 2:
			cout << "다리우스를 선택하셨습니다." << endl;
			cout << "사용할 스킬을 선택해주세요." << endl;
			cout << "1. 일반 공격" << endl;
			cout << "2. 강력한 공격" << endl;
			cin >> selectSkill;

			switch (selectSkill)
			{
			case 1:
				cout << "다리우스의 일반 공격을 사용합니다." << endl;
				break;
			case 2:
				cout << "다리우스의 강력한 공격을 사용합니다." << endl;
				break;
			default:
				cout << "잘못된 번호를 입력했습니다." << endl;
				break;
			}
			break;
		default:
			cout << "잘못된 번호를 입력했습니다." << endl;
			break;
		}
		break;
	case 2:
		cout << "스타크래프트를 선택하셨습니다." << endl;
		cout << "플레이할 캐릭터를 선택해주세요." << endl;
		cout << "1. SCV" << endl;
		cout << "2. 프로브" << endl;
		cin >> selectCharacter;

		switch (selectCharacter)
		{
		case 1:
			cout << "SCV를 선택하셨습니다." << endl;
			cout << "사용할 스킬을 선택해주세요." << endl;
			cout << "1. 기본 공격" << endl;
			cout << "2. 강력한 공격" << endl;
			cin >> selectSkill;

			switch (selectSkill)
			{
			case 1:
				cout << "SCV의 기본 공격을 사용했습니다." << endl;
				break;
			case 2:
				cout << "SCV의 강력한 공격을 사용했습니다." << endl;
				break;
			default:
				cout << "잘못된 번호를 입력했습니다." << endl;
				break;
			}
			break;
		case 2:
			cout << "프로브를 선택하셨습니다." << endl;
			cout << "사용할 스킬을 선택해주세요." << endl;
			cout << "1. 기본 공격" << endl;
			cout << "2. 강력한 공격" << endl;
			cin >> selectSkill;

			switch (selectSkill)
			{
			case 1:
				cout << "프로브의 일반 공격을 사용합니다." << endl;
				break;
			case 2:
				cout << "프로브의 강력한 공격을 사용합니다." << endl;
				break;
			default:
				cout << "잘못된 번호를 입력했습니다." << endl;
				break;
			}
			break;
		default:
			cout << "잘못된 번호를 입력했습니다." << endl;
			break;
		}
		break;
	case 3:
		cout << "붉은사막을 선택하셨습니다." << endl;
		cout << "플레이할 캐릭터를 선택해주세요." << endl;
		cout << "1. 클리프" << endl;
		cout << "2. 데미안" << endl;
		cin >> selectCharacter;

		switch (selectCharacter)
		{
		case 1:
			cout << "클리프를 선택하셨습니다." << endl;
			cout << "사용할 스킬을 선택해주세요." << endl;
			cout << "1. 기본 공격" << endl;
			cout << "2. 강력한 공격" << endl;
			cin >> selectSkill;

			switch (selectSkill)
			{
			case 1:
				cout << "클리프의 기본 공격을 사용합니다." << endl;
				break;
			case 2:
				cout << "클리프의 강력한 공격을 사용합니다." << endl;
				break;
			default:
				cout << "잘못된 번호를 입력했습니다." << endl;
				break;
			}
			break;
		case 2:
			cout << "데미안을 선택하셨습니다." << endl;
			cout << "사용할 스킬을 선택해주세요." << endl;
			cout << "1. 기본 공격" << endl;
			cout << "2. 강력한 공격" << endl;
			cin >> selectSkill;

			switch (selectSkill)
			{
			case 1:
				cout << "데미안의 기본 공격을 사용합니다." << endl;
				break;
			case 2:
				cout << "데미안의 강력한 공격을 사용합니다." << endl;
				break;
			default:
				cout << "잘못된 번호를 입력했습니다." << endl;
				break;
			}
			break;
		default:
			cout << "잘못된 번호를 입력했습니다." << endl;
			break;
		}
		break;
	default:
		cout << "잘못된 번호를 입력했습니다." << endl;
		break;
	}



	return 0;
}