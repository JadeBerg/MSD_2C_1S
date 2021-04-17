#include <iostream>
#include <locale.h>
using namespace std;
#define N 10	
typedef int Item;
Item STACK_AR[N];
typedef int Item;	// тип информационного элемента очереди 
const int MAX_QUEUE=10;			// максимальный размер очереди 
Item QUEUE_AR[MAX_QUEUE];		// массив под очередь
int front = 0;	// индекс начала очереди 
int back=MAX_QUEUE-1;	// индекс конца очереди
int count = 0;	// количество элементов очереди

int push_stack(Item* a, int& t)
{
	int n;
	t++;	// увеличение значения вершины стека
	if(t<N) // проверка не заполнен ли стек
	{	cout << "Введите элемент" << endl; 
	scanf_s("%d", &n);
	a[t] = n; 
	return 0;
	}
    else	// если стек заполнен
    {
    t--;	// если начали работать с уже полным стеком 
	cout<<"Стек полный!"<<endl;
    return -1;
    }
}
int pop_stack(Item* a, int& t)	// удаление элемента из вершины стека
{
	if (t == -1)	// проверка не заполнен ли стек
	{
		cout << "Стек пуст!" << endl; 
		return -1;
	}
	else	// если стек заполнен //
		if (t<=N && t>=0)
	{
		cout << "Появляется a[top]= " << a[t] << endl;
		t--;	
		cout<<"Вершина= "<<t<<endl;
		return 0;
	}
}
int print_top_stack(Item* a, int& t)	//печать элемента из вершины стека
{
	if (t == -1)	//проверка не заполнен ли стек
	{
		cout << "Стек пуст!" << endl; 
		return -1;
	}
	else	//если стек заполнен
	{
		cout << "a[вершина]=" << a[t] << endl; 
		return 0;
	}
}
int empty_stack(int& t)	//определение - пуст ли стек
{
	if (t == -1)	//проверка не заполнен ли стек
	{
		cout << "Стек пуст!" << endl;
		return -1;
	}
	else	//если стек заполнен
	{
		cout << "Стек не пуст!" << endl; 
		return 0;
	}
}
int delete_stack(Item* a, int& t)	//уничтожение стека
{
	for (int i = 0; i <= t; i++) 
		a[i] = -1;
	t = -1; // только этого достаточно для уничтожения стека 
	return t;
}
int count_stack(int& t)//определение числа элементов в стеке
{
	if (t == -1)	//проверка не заполнен ли стек
	{
		cout << "Стек пуст!" << endl; 
		return -1;
	}
	else	//если стек заполнен
	{
		cout << "Количество элементов стека = " << (t + 1) << endl; 
		return 0;
	}
}
int print_stack(Item* a, int& t)
{
	if (t == -1)	//проверка не заполнен ли стек
	{
		cout << "Стек пуст!" << endl; 
		return -1;
	}
	else	//если стек заполнен, то вывод элементов стека начиная с вершины
	{
		for (int i = t; i >= 0; i--) 
			cout << "a[" << i << "]= " << a[i] << endl; 
		return 0;
	}
}
bool isempty_Queue(const int& count)
{
	if (count == 0)	// очередь пуста
	{
		cout << "Очередь пуста!" << endl; 
		return true;
	}
	else	// очередь не пуста
	{
		cout << "Очередь не пуста!" << endl;
		return false;
	}
	//	return bool(count = = 0); - вариант функции
}
int delete_Queue(int& count, int& front, int& back)
{
	count = 0;	// уничтожение очереди 
	front = 0;	// инициализация очереди 
	back=MAX_QUEUE-1;
	return count;
}
int insert_Queue(Item* a, int& count, int& back)
{
	Item n;
	if (count == MAX_QUEUE)	// очередь уже заполнена
	{
		cout << "Очередь полная!" << endl;
		return -1;
	}
	else	// очередь не полностью заполнена
	{
		Item n;
		cout << "Введите элемент" << endl; 
		scanf_s("%d", &n);
		back = (back + 1) % MAX_QUEUE; 
		a[back] = n;
		++count; return 0;
	}
}
int remove_Queue(Item* a, int& count, int& front)
{
	if (count == 0)
	{
		cout << "Очередь пуста!" << endl;
		return 0;	// возврат числа элементов в очереди, равного 0
	}
	else	// очередь не пуста, удалить элемент
	{
		front = (front + 1) % MAX_QUEUE;
		--count;
		return 1; // возврат (1)
	}
}
int print_front_Queue(Item* a, int& count, int& front)
// &front - адрес индекса начала очереди
{
	if (count == 0)
	{
		cout << "Очередь пуста!" << endl;
		return 0;	// возврат числа элементов в очереди, равного 0
	}
	else	// очередь не пуста, удалить элемент
	{
		cout << "b[" << front << "]= " << a[front] << endl; 
		front = (front + 1) % MAX_QUEUE;
		--count;
		return 1; // возврат (1)
		// return a[front-1]; // возврат удаляемого из очереди элемента
	}
}
int count_Queue(const int& count)
{
	cout << "Количество элементов очереди = " << count << " ." << endl; 
	return count;
}
int print_Queue(Item* a, int& count, int& front)
{
	if (count == 0)
	{
		cout << "Очередь пуста!" << endl; return 0;
	}
	else
	{
		int i, c; i = front; c = count; while (c != 0)
		{		// вывод элементов очереди 
			cout<<"b["<<i<<"]= "<<a[i]<<endl;
		// вычисление индексов массива начиная с i=front;
			i=(i+1)%MAX_QUEUE;
			--c;
		}
		return 1; // индикатор успешности вывода
	}
}
int main() {
	int c, op, t=-1, a[N], b[N];
	int count = 0;
	setlocale(LC_ALL, "Rus");
	scan:
	printf("Выберите списковую структуру:\n");
	printf("1. Стек\n");
	printf("2. Очередь\n");
	scanf_s("%d", &c);
	if (c < 1 || c>2) {
		printf("Ошибка ввода, попробуйте еще раз.\n");
		goto scan;
	}
	for (;;) {
		if (c == 1) {
			printf("//=============================================//\n");
			printf("Выберите операцию на стеком\n");
			printf("1. Вставка элемента в вершину стека\n");
			printf("2. Уничтожение стека\n");
			printf("3. Возвращение элемента из вершины стека\n");
			printf("4. Удаление элемента из вершины стека\n");
			printf("5. Определение количества элементов в стеке\n");
			printf("6. Определение пуст ли стек\n");
			printf("7. Вывод элементов стека\n");
			printf("8. Вернуться к выбору структуры данных\n");
			printf("//=============================================//\n");
			scanf_s("%d", &op);
			switch (op) {
			case 1:
				push_stack(a, t);
				break;
			case 2:
				delete_stack(a, t);
				break;
			case 3:
				print_top_stack(a, t);
				break;
			case 4:
				pop_stack(a, t);
			case 5:
				count_stack(t);
				break;
			case 6:
				empty_stack(t);
				break;
			case 7:
				print_stack(a, t);
				break;
			case 8:
				goto scan;
				break;
			}
		}
		if (c == 2) {
			printf("//=============================================//\n");
			printf("Выберите операцию над очередью \n");
			printf("1. Вставка элемента в конец очереди\n");
			printf("2. Уничтожение очереди\n");
			printf("3. Удаление элемента из начала очереди\n");
			printf("4. Выборка элемента из очереди\n");
			printf("5. Определение количества элементов в очереди\n");
			printf("6. Определение пуста ли очередь\n");
			printf("7. Вывод элементов очереди\n");
			printf("8. Вернуться к выбору структуры данных\n");
			printf("//=============================================//\n");
			scanf_s("%d", &op);
			switch (op) {
			case 1:
				insert_Queue(b, count, back);
				break;
			case 2:
				delete_Queue(count, front, back);
				break;
			case 3:
				remove_Queue(b, count, front);
				break;
			case 4:
				print_front_Queue(b, count, front);
			case 5:
				count_Queue(count);
				break;
			case 6:
				isempty_Queue(count);
				break;
			case 7:
				print_Queue(b, count, front);
				break;
			case 8:
				goto scan;
				break;
			}
		}
	}
	return 0;
	}