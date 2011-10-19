#include "Flower.h"
#include "main.h"

void Flower::Show(void) // ���������, ������� ������� ��� ���������� �� �������
{
	cout << "Leaves number: " << Get_leaves_number() << '\n'; // �������� ���������� �������
	cout << "Smell: " << Get_smell() << '\n'; // �������� �������/���������� ������
	Plant::Show();
}

// ��������, ����� ������� ���������� ��������� � ������ ������ �� �����
void Flower::Set_leaves_number(int ln){_leaves_number = ln;}
int Flower::Get_leaves_number(void){return _leaves_number;}
void Flower::Set_smell(bool s){_smell = s;}
bool Flower::Get_smell(void){return _smell;}

Flower::Flower(void) // ����������� �� ���������, ������� ������ ������
{
}

Flower::Flower(Flower* obj) // ����������� �����������
{
	Set_leaves_number(obj->_leaves_number); // ������������� ���������� �������
	Set_smell(obj->_smell); // ������������� �������/���������� ������
}

Flower::Flower(int leaves_number, bool smell, double life_time, double stem_length):Plant(life_time, stem_length) // ����������� � �����������
{
	Set_leaves_number(leaves_number); // ������������� ���������� �������
	Set_smell(smell); // ������������� �������/���������� ������
}

Flower::~Flower(void) // ����������
{
}