#include "Plant.h"
#pragma once

// ����� �������������� ������
class Flower:public Plant
{
protected:
	int _leaves_number; // ���������� �������
	bool _smell; // �������/���������� ������

	void Set_leaves_number(int ln); // ������������� ���������� �������
	int Get_leaves_number(void); // ���������� ���������� �������
	void Set_smell(bool s); // ������������� �������/���������� ������
	bool Get_smell(void); // ���������� �������/���������� ������

public:
	virtual void Show(void); // ������� ��� ������ �� �������
	Flower(void); // ����������� �� ���������
	Flower(Flower* obj); // ����������� �����������
	Flower(int leaves_number, bool smell, double life_time, double stem_length); // ����������� � �����������
	~Flower(void); // ����������
};

