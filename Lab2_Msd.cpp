// Вариант 15
// Струна Виктор Русланович 525б
// Исследование улучшенных алгоритмов сортировки
#include <stdio.h>
#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <locale.h>
#include <list>

#define N 100 // Объявляем константу
int cmp(const void* a, const void* b) {
	return *(int*)a - *(int*)b;
}
//сортировка методом подсчета
void methodOfCalculation(int n, float mass[], float sortedMass[])
{
	int k, srv = 0, obm = 0, sum = 0;
	for (int i = 0; i < n; i++)
	{
		k = 0;
		for (int j = 0; j < n; j++)
		{
			if (mass[i] > mass[j]) {
				obm++;
				k++;
			}
		}
		sortedMass[k] = mass[i];
		srv++;
		sum = obm + srv;
	}
	printf("\nКоличество сравнений: %d\nКоличество обменов: %d\n Всего операций: %d\n", srv, obm, sum);//вывод
}
void radixSort(int* arr, int n, int max) {
	int i, j, m, p = 1, index, temp, count = 0;
	std::list<int> pocket[10];      //radix of decimal number is 10
	for (i = 0; i < max; i++) {
		m = pow(10, i + 1);
		p = pow(10, i);
		for (j = 0; j < n; j++) {
			temp = arr[j] % m;
			index = temp / p;      //find index for pocket array
			pocket[index].push_back(arr[j]);
		}
		count = 0;
		for (j = 0; j < 10; j++) {
			//delete from linked lists and store to array
			while (!pocket[j].empty()) {
				arr[count] = *(pocket[j].begin());
				pocket[j].erase(pocket[j].begin());
				count++;
			}
		}
	}
}
	int main() {
		for (;;) {
			float a[N], b[N], max = 0;
			int r, m, i, s, c[N];
			int buff = 0, srv = 0, obm = 0, sum = 0;
			setlocale(LC_ALL, "rus");
			printf("\nЧто вы хотите выполнить:\n");
			printf("1. Ввод вручную.\n");
			printf("2. Ввод по возрастанию.\n");
			printf("3. Обратный ввод.\n");
			printf("4. Случайный ввод.\n");
			printf("0. Выход.\n");
			scanf_s("%i", &m); // Пользователь выбирает какой функцией он хочет воспользоваться
			if (m == 0)
				goto swit;
			printf("\nВведите размерность массива: ");
			scanf_s("%i", &r);
			printf("\n");
		swit:
			switch (m)
			{
			case 1: //Ввод вручную
			scan:
				printf("Введите числа в диапозоне от 0,009 до 0,1:\n");
				for (i = 0; i < r; i++) {
					printf("a[%d]: ", i);
					scanf_s("%f", &a[i]);
					c[i] = a[i] * 1000;
					if (a[i] > max)
						max = a[i];
					if (a[i] <= 0.009 || (a[i] >= 0.1)) { //Проверка на ввод чисел вне диапозона
						printf("Вы ввели число выходящее из диапозона.\n");
						printf("\n");
						goto scan; //Переход к вводу
					}
				}
				break;
			case 2: //Ввод по возрастанию
				srand(time(0));
				for (i = 0; i < r; i++) {
					a[i] = 9 + rand() % 91;
					a[i] = a[i] / 1000;
					c[i] = a[i] * 1000;
					if (a[i] > max)
						max = a[i];
				}
				qsort(a, r, sizeof(int), cmp); // Вызов функции быстрой сортировки
				for (i = 0; i < r; i++) { //Вывод массива
					printf("%.3f ", a[i]);
				}
				printf("\n");
				break;
			case 3: //Ввод по убыванию
				for (i = 0; i < r; i++) {
					a[i] = 9 + rand() % 91;
					c[i] = a[i] * 1000;
					if (a[i] > max)
						max = a[i];
				}
				qsort(a, r, sizeof(int), cmp); //Вызов функции быстрой сортировки
				for (int i = r - 1; i >= 0; i--) { //Вывод массива
					a[i] = a[i] / 1000;
					printf("%.3f ", a[i]);
				}
				printf("\n");
				break;
			case 4: //Случайный ввод
				for (i = 0; i < r; i++) {
					a[i] = 9 + rand() % 91;
					a[i] = a[i] / 1000;
					c[i] = a[i] * 1000;
					if (a[i] > max)
						max = a[i];
				}
				for (i = 0; i < r; i++) //Вывод массива
					printf("%.3f ", a[i]);
				printf("\n");
				break;
			case 0: //Выход
				exit(0);
				break;
			}
			printf("\nКаким методом сортировки хотите воспользоваться:\n");
			printf("1. Сортировка подсчетом.\n");
			printf("2. Порязрядная сортировка(LSD).\n");
			scanf_s("%d", &s);
			switch (s)
			{
			case 1: methodOfCalculation(r, a, b);
				printf("Сортированый массив:\n");
				for (int i = 0; i < r; i++)
					printf("%.3f ", b[i]);
				printf("\n");
				break;

			case 2:
				int n, odin = 0, dva = 0, tri = 0;
				for (int i = 0; i < N; i++) {
					n = 0;
					int dd = c[i];
					while ((dd /= 10) > 0) n++;
					if (n == 0)
						odin++;
					else if (n == 1)
						dva++;
					else if (n == 2)
						tri++;
				}
				radixSort(c, r, max);
				printf("Отсортированный массив: ");
				methodOfCalculation(r, a, b);
				for (int i = 0; i < r; i++)
					printf("%.3f ", b[i]);
				printf("\n");
				if (dva == 0 && tri == 0)
					printf("\nПрисваиваний = %d\n", odin);
				else if (tri == 0)
					printf("\nПрисваиваний = %d\n", odin + dva + 10 + 10 + dva);
				else
					printf("\nПрисваиваний = %d\n", odin + dva + tri + dva + tri + tri + 30);
				break;
			}
		}
		}