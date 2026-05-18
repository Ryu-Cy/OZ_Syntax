#include<iostream>

using namespace std;


// 과제2. 자료형 종류별로 출력해보기
// 과제3. 국어, 영어, 수학 세 과목의 점수를 입력받고 평균값 출력하기

int main()
{
	// 과제2

	cout << "== 과제2. 자료형 출력 해보기 ==" << endl;
	// 문자
	char charTest = 'a';

	cout << "char형 출력 테스트: " << charTest << endl << endl;
	// 정수
	int intTest = 7;
	short shortTest = -10;
	long longTest = 17;
	long long longlongTest = -27;
	bool boolTestTrue = true;
	bool boolTestFalse = false;

	cout << "int형 출력 테스트: " << intTest << endl;
	cout << "short형 출력 테스트: " << shortTest << endl;
	cout << "long형 출력 테스트: " << longTest << endl;
	cout << "long long형 출력 테스트: " << longlongTest << endl;
	cout << "bool형 True 출력 테스트: " << boolTestTrue << endl;		// true값을 넣었기에 1로 출력
	cout << "bool형 False 출력 테스트: " << boolTestFalse << endl << endl;		// false값을 넣었기에 0로 출력
	// 실수
	float floatTest = 7.777777f;
	double doubleTest = -17.17177;
	long double longdoubleTest = 77.11111l;

	cout << "float형 출력 테스트: " << floatTest << endl;	// 소수점 5자리까지 표기되기에 6번째 자리에서 반올림
	cout << "double형 출력 테스트: " << doubleTest << endl;	// 소수점 4번째 자리까지 표기되기에 5번째 자리에서 반올림
	cout << "long double형 출력 테스트: " << longdoubleTest << endl << endl;	// 소수점 4번째 자리까지 표기되기에 5번째 자리에서 반올림

	//=====================================

	// 과제3


	cout << "== 과제3. 국어, 영어, 수학 세 과목 점수를 입력 받아 평균 내기 ==" << endl;

	int korean;
	int english;
	int math;
	int result;

	cout << "국어 점수를 입력해주세요: ";
	cin >> korean;
	cout << "영어 점수를 입력해주세요: ";
	cin >> english;
	cout << "수학 점수를 입력해주세요: ";
	cin >> math;

	result = (korean + english + math) / 3;

	cout << "세 과목 점수의 평균은: " << result << " 점 입니다." << endl;

	return 0;
}