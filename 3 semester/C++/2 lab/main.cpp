#include "main.h"

// основное приложение
void main(void)
{
	//char* str;
	//str = "Test";
	//int l = strlen(str) + 1;
	Plant p(1, 2);
	Weed w(1, 2, 3, 4);
	Flower f(1, 2, 3, 4);
	Rose r(1, 2, 3, 4, 5, 6, "7");
	
	Plant* arr[4] = {&p, &w, &f, &r};
	for (int i = 0; i < 4; i++)
	{
		arr[i]->Show();
		cout << '\n';
	}
	system("pause");
}