#include "Weed.h"
#include "main.h"

void Weed::Show(void) // ���������, ������� ������� ��� ���������� �� �������
{
	cout << "Growth rate: " << Get_growth_rate() << '\n'; // �������� �������� �����
	cout << "Expansion area: " << Get_expansion_area() << '\n'; // �������� ������� �����������
	Plant::Show();
}

// ��������, ����� ������� ���������� ��������� � ������ ������ �� �����
void Weed::Set_growth_rate(double gr){_growth_rate = gr;}
double Weed::Get_growth_rate(void){return _growth_rate;}
void Weed::Set_expansion_area(double ea){_expansion_area = ea;}
double Weed::Get_expansion_area(void){return _expansion_area;}

Weed::Weed(void) // ����������� �� ���������, ������� ������ ������
{
}

Weed::Weed(Weed* obj)  // ����������� �����������
{
	Set_growth_rate(obj->_growth_rate); //������������� �������� �����
	Set_expansion_area(obj->_expansion_area); // ������������� ������� �����������
}

Weed::Weed(double life_time, double stem_length, double growth_rate, double expansion_area):Plant(life_time, stem_length)  // ����������� � �����������
{
	Set_growth_rate(growth_rate); //������������� �������� �����
	Set_expansion_area(expansion_area); // ������������� ������� �����������
}

Weed::~Weed(void) // ����������
{
}