#include "Flower.h"
#pragma once

// ����� �������������� ����
class Rose:public Flower
{
protected:
	bool _spines; // ������������/����������� �������
	int _petals_number; // ���������� ���������
	char* _rose_name; // ���� ����

	void Set_spines(bool s); // ������������� �������/���������� �������
	bool Get_spines(void); // ���������� �������/���������� �������
	void Set_petals_number(int pn); // ������������� ���������� ���������
	int Get_petals_number(void); // ���������� ���������� ���������
	void Set_rose_name(char &rn); // ������������� �������� �����
	char* Get_rose_name(void); // ���������� �������� �����
	
public:
	virtual void Show(void); // ������� ��� ������ �� �������
	Rose(void); // ����������� �� ���������
	Rose(Rose* obj); // ����������� �����������
	Rose(double life_time, double stem_length, int leaves_number, bool smell, bool spines, int petals_number, char* rose_name); // ����������� � �����������
	~Rose(void); // ����������
};

