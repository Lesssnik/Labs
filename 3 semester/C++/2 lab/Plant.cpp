#include "Plant.h"
#include "main.h"

void Plant::Show(void) // ���������, ������� ������� ��� ���������� �� �������
{
	cout << "Life time: " << Get_life_time() << '\n'; // �������� ����� �����
	cout << "Stem length: " << Get_stem_length() << '\n'; // �������� ����� ������
}

// ��������, ����� ������� ���������� ��������� � ������ ������ �� �����
void Plant::Set_life_time(double lt){_life_time = lt;}
double Plant::Get_life_time(void){return _life_time;}
void Plant::Set_stem_length(double sl){_stem_length = sl;}
double Plant::Get_stem_length(void){return _stem_length;}

Plant::Plant() // ����������� �� ���������, ������� ������ ������
{
}

Plant::Plant(Plant* obj) // ����������� �����������
{
	Set_life_time(obj->_life_time); // ������������� ����� �����
	Set_stem_length(obj->_stem_length); // ������������� ����� ������
}

Plant::Plant(double life_time, double stem_length) // ����������� � �����������
{
	Set_life_time(life_time); // ������������� ����� �����
	Set_stem_length(stem_length); // ������������� ����� ������
}


Plant::~Plant(void) // ����������
{
}