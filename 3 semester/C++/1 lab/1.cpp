#include <iostream>
#include <malloc.h>
using namespace std;

class Phone
{
private:
	char surname[100];
	unsigned long number;
	long money;
	void set_surname(char &s){strcpy(surname, &s);}
	void set_number(unsigned long n){number = n;}
    void set_money(long m){money = m;}

public:
	char* get_surname(){return surname;}
	unsigned long get_number(){return number;}
	long get_money(){return money;}

	Phone(char &surname, unsigned long number, long money)
	{
		set_surname(surname);
		set_number(number);
		set_money(money);
		cout << "Constructor create an object";
	}

	Phone(Phone* object)
	{
		set_surname(*object->surname);
		set_number(object->number);
		set_money(object->money);
		cout << "Constructor copy an object";
	}

	~Phone()
	{
		cout << "Destructor destroy an object\n";
	}
};

void main(void)
{
	unsigned long number;
	long money;
	char surname[100];

	cout << "Input surname: ";
	cin >> surname;
	cout << "Input number: ";
	cin >> number;
	cout << "Input money: ";
	cin >> money;

	Phone* obj = new Phone(*surname, number, money);
	
	cout << "\n" << obj->get_surname();
	cout << "\n" << obj->get_number();
	cout << "\n" << obj->get_money();
	cout << "\n\n";

	Phone* obj2 = new Phone(obj);
	cout << "\n" << obj2->get_surname();
	cout << "\n" << obj2->get_number();
	cout << "\n" << obj2->get_money();
	cout << "\n\n";

	delete(obj);
	delete(obj2);

	system("pause");
}