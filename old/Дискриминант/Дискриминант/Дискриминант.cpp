#include <iostream>
using namespace std;

int main() {
	setlocale(LC_ALL, "ru");
	float a, b, c, D, x1, x2;
	bool notcloseconsole;
	cout << "Введите числа a, b, c для решения квадратного уравнения" << endl;
	while (true) {
		try {
			cout << "Введите а - ";
			cin >> a;
			cout << "Введите b - ";
			cin >> b;
			cout << "Введите c - ";
			cin >> c;
			break;
		}
		catch (exception) {
			cout << "Введите переменные корректного формата" << endl;
		}
	}
	D = b * b - 4 * a * c;
	if (D > 0) {
		x1 = ((-1) * b - sqrt(D)) / (2 * a);
		x2 = ((-1) * b + sqrt(D)) / (2 * a);
		cout << "Дискриминант = " << D << endl;
		cout << "Первый корень = " << x1 << endl;
		cout << "Второй корень = " << x2 << endl;
	}
	else if (D == 0) {
		x1 = ((-1) * b) / (2 * a);
		cout << "Дискриминант = " << D << endl;
		cout << "Корень = " << x1 << endl;
	}
	else if (D < 0) {
		cout << "Дискриминант = " << D << endl;
		cout << "Парабола не имеет пересечений с осью, корней нет" << endl;
	}
	else {
		cout << "Ошибка, некорректная работа программы" << endl;
	}
	cin >> notcloseconsole;
	return 0;
}