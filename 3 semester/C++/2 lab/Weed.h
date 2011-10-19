#include "Plant.h"
#pragma once

// ����� �������������� ������
class Weed:public Plant
{
protected:
	double _growth_rate; // �������� �����
	double _expansion_area; // ������� �����������

	void Set_growth_rate(double gr); // ������������� �������� �����
	double Get_growth_rate(void); // ���������� �������� �����
	void Set_expansion_area(double ea); // ������������� ������� �����������
	double Get_expansion_area(void); // ���������� ������� �����������
	
public:
	virtual void Show(void); // ������� ��� ������ �� �������
	Weed(void); // ����������� �� ���������
	Weed(Weed* obj); // ����������� �����������
	Weed(double growth_rate, double expansion_area, double life_time, double stem_length); // ����������� � �����������
	~Weed(void); // ����������
};

