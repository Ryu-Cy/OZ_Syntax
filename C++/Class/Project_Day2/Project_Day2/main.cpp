#include<iostream>

using namespace std;

/******************************************
[변수]
- 값을 저장할 수 있는 메모리 공간에 붙혀진 이름
- 변수 선언 시 메모리 공간에 할당되고 이름이 붙는다.

[변수의 이름]
- 할당된 메모리 공간에 접근 가능
- 값을 저장 또는 참조 가능

[변수의 필요성]
- 프로그램은 데이터를 다뤄야함 ex)Name, Hp, Mp, Exp, Gold etc...

[변수 선언 시 주의사항]
- 변수 이름은 알파벳, 숫자, 언더스코어로 구분
- 대소문자 구분 ex) Num, num
- 변수의 이름은 숫자로 시작할 수 없고 키워드도 변수의 이름으로 사용 불가
- 공백 및 특수문자 사용 불가
- 한글은 가급적 사용하지 않는다.
- 변수 이름을 지을 떄는 반드시 의미룰 파악할 수 있게 지어라. (어떠한 내용을 가지고 있는지 명확히게)
- 변수의 선언과 초기화는 다른 것. (변수를 만드는 것이 선언이고, 값을 넣는 것이 초기화.)
- 표기법 잘 지키기
- 동일한 변수명 사용 불가
******************************************/


int main()
{
	cout << "오늘은 2일차" << endl;
	cout << 1 + 2 << endl;
	cout << "변수에 대해서 알아보기" << endl;

	int playerHp;	// 정수형(int)타입의  playerHp라는 변수를 선언
	int enemyHp = 10;	// 변수를 선언과 동시에 초기화

	playerHp = 100;	// 변수를 선언 후 초기화

	cout << "플레이어의 체력: " << playerHp << endl;
	cout << "적이 플레이어를 공격" << endl;
	cout << "남은 체력: " << playerHp - 10 << endl;

	// 변수명 선언의 안 좋은 예
	int a;

	int skillDamage1;
	int skillDamage2;
	int skillDamage3;

	int num;
	int Num;
	int nuM;

	// 변수 및 함수 표기법
	int monsterHp;		// 카멜			변수
	int player_hp;		// 스네이크	변수
	int MaxSpeed;		// 파스칼		함수, 클래스 등

	int gold = 100;

	cout << "변수 gold에 저장된 값: " << gold << endl;
	gold = 200;
	cout << "변수 gold에 저장된 값: " << gold << endl;
	

	return 0;
}