#include "Rose.h"
#include "main.h"

void Rose::Show(void) // ���������, ������� ������� ��� ���������� �� �������
{
	cout << "Spines: " << Get_spines() << '\n'; // �������� �������/���������� �������
	cout << "Petals number: " << Get_petals_number() << '\n'; // �������� ���������� ���������
	Flower::Show();
}

// ��������, ����� ������� ���������� ��������� � ������ ������ �� �����
void Rose::Set_spines(bool s){_spines = s;}
bool Rose::Get_spines(void){return _spines;}
void Rose::Set_petals_number(int pn){_petals_number = pn;}
int Rose::Get_petals_number(void){return _petals_number;}
void Set_rose_name(char &rn){}//strcpy(_rose_name, &rn);}
char* Get_rose_name(void){return NULL;}//return _rose_name;}
Rose::Rose(void) // ����������� �� ���������, ������� ������ ������
{
}

Rose::Rose(Rose* obj) // ����������� �����������
{
	Set_spines(obj->_spines); // ������������� �������/���������� �������
	Set_petals_number(obj->_petals_number); // ������������� ���������� ���������
}

Rose::Rose(double life_time, double stem_length, int leaves_number, bool smell, bool spines, int petals_number, char* rose_name):Flower(leaves_number, smell, life_time, stem_length) // ����������� � �����������
{
	Set_spines(spines); // ������������� �������/���������� �������
	Set_petals_number(petals_number); // ������������� ���������� ���������
	_rose_name = rose_name;
}

Rose::~Rose(void) // ����������
{
}