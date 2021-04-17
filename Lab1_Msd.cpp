// Вариант 15
// Струна Виктор Русланович 525б
// Исследование простых алгоритмов сортировки
#include <stdio.h>
#include <locale.h>
#include <time.h>
#include <stdlib.h>
#define N 100 // Объявляем константу

void selectionSort(int* num, int size) // Сортировка выбором
{
	int min, temp, srv=0, sum=0, obm=0;
	for (int i = 0; i < size - 1; i++)
	{
		min = i; // запоминаем индекс текущего элемента
		// ищем минимальный элемент чтобы поместить на место i - ого
		for (int j = i + 1; j < size; j++) // для остальных элементов после i-ого
		{
			srv = srv + 1; // считаем количество сравнений
			if (num[j] < num[min]) // если элемент меньше минимального,
				min = j; // запоминаем его индекс в min
		}
		if(num[min]!= num[i])
			obm = obm + 1; // считаем количество обменов
		temp = num[i]; // меняем местами i-ый и минимальный элементы
		num[i] = num[min];
		num[min] = temp;
	}
	sum = srv + obm; //считаем сумму
	printf("\nКоличество сравнений: %d\nКоличество обменов: %d\nВсего операций: %d\n", srv, obm, sum); //Выводим результат
}
int cmp(const void* a, const void* b) {
	return *(int*)a - *(int*)b;
}

int main() {
	for (;;) {
		int m, r, a[N], i, s, j;
		int buff = 0, srv = 0, obm = 0, sum=0;
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
			printf("Введите числа в диапозоне от 100 до 900:\n");
			for (i = 0; i < r; i++) {
				printf("a[%d]: ", i);
				scanf_s("%d", &a[i]);
				if (a[i] > 900 || (a[i] < 100)) { //Проверка на ввод чисел вне диапозона
					printf("Вы ввели число выходящее из диапозона.\n");
					printf("\n");
					goto scan; //Переход к вводу
				}
			}
			break;
		case 2: //Ввод по возрастанию
			srand(time(0));
			for (i = 0; i < r; i++) {
				a[i] = 100 + rand() % 801;
			}
			qsort(a, r, sizeof(int), cmp); // Вызов функции быстрой сортировки
			for (i = 0; i < r; i++) { //Вывод массива
				printf("%d ", a[i]);
			}
			printf("\n");
			break;
		case 3: //Ввод по убыванию
			for (i = 0; i < r; i++) {
				a[i] = rand() % 801 - 901;
			}
		qsort(a, r, sizeof(int), cmp); //Вызов функции быстрой сортировки
		    for (int i = 0; i < r; i++) { //Вывод массива
			a[i] = -1 * a[i];
			printf("%d ", a[i]);
		}
		    printf("\n");
			break;
		case 4: //Случайный ввод
			for (i = 0; i < r; i++)
				a[i] = 100 + rand() % 800;
			for (i = 0; i < r; i++) //Вывод массива
				printf("%d ", a[i]);
			printf("\n");
			break;
		case 0: //Выход
			exit(0);
			break;
		}
		printf("\nКаким методом сортировки хотите воспользоваться:\n");
		printf("1. Сортировка простыми включениями (вставками).\n");
		printf("2. Сортировка прямым выбором.\n");
		scanf_s("%d", &s); // Пользователь делает выбор как сортировать
		printf("\n");
		switch (s) {
		case 1:
			for (int i = 1; i < r; i++)
			{
				buff = a[i];//берем 2-й элемент массива
				int poz = i;
				srv++;//cчетчик сравнений*/
				while (poz > 0 && a[poz - 1] > buff)
				{
					a[poz] = a[poz - 1];
					poz--;
					srv++;//cчетчик сравнений*/
					obm++;//обмен элементов
				}
				if (poz == 0)
				{
					srv--;//cчетчик сравнений*/
				}
				a[poz] = buff;
			}
			for (int i = 0; i < r; i++) {
				printf("%d ", a[i]);
			}
			printf("\n");
			sum = srv + obm;
			printf("\nКоличество сравнений: %d\nКоличество обменов: %d\n Всего операций: %d\n", srv, obm, sum);//вывод

			break;
		case 2:
			selectionSort(a, r); // Вызов фукции сортировки выбором
			for (i = 0; i < r; i++) { //Вывод отсортированного массива
				printf("%d ", a[i]);
			}
			printf("\n");
			break;
		}
	}
	return 0;
}