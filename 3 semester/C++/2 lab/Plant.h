#pragma once

// ����� �������������� ��������
class Plant
{
protected:
	double _life_time; //����� ����� � ����� 
	double _stem_length; // ����� ������
	
	void Set_life_time(double lt); // ������������� ����� �����
	double Get_life_time(void); // ���������� ����� �����
	void Set_stem_length(double sl); // ������������� ����� ������
	double Get_stem_length(void); // ���������� ����� ������

public:
    virtual	void Show(void); // ������� ��� ������ �� �������
	Plant(void); // ����������� �� ���������
	Plant(Plant* obj); // ����������� �����������
	Plant(double life_time, double stem_length); // ����������� � �����������
	~Plant(void); // ����������
};

