#include<iostream>		// 전처리기, <>안의 내용을 사용하기 위함

using namespace std;	// std안의 내용을 쓴다는 의미이나, 간단하게는 이후 코드 작성할 때 std::를 생략하기 위함 ex)std::cout, std::endl 등

// 함수를 선택한 뒤 F12를 클릭하면 선언되어있는 곳으로 점프
// C++의 main함수는 int형식이 표준이며, void 등도 가능하지만 표준은 아니다. 

int main()		// 진입점, 반드시 하나만 존재해야 함.
{
	cout << "Hello World" << endl;
	cout << "Welcome to hell";	// 줄 바꿈 X
	cout << "오즈 코딩 스쿨 게임개발부트캠프 7기 화이팅!" << endl;

	// 처음 접하는 학생들이 가장 많이 하는 실수
	// 1. 스펠링 오타
	// 2. 세미콜론(;) 미기입
	// 3. 변수명 중복

	return 0;	// 최신 환경에서는 없어도 무방하다. 사용하는 이유는 과거 코드와의 호환을 위함.
}