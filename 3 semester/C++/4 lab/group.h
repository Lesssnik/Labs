#pragma once

#include <vector>
#include "student.h"
#include "curator.h"

//��������� ����, ������������� � ForEachStudent. ��������� ������ �� ��������,
//������� ����� ��������� ���������
typedef void(*Action)(CStudent &student);

class CGroup
{
protected:
	//������������ ������ ���������
	vector<CStudent> _students;
	//������� ������
	CCurator _curator;
public:
	//���������� �������� � ������������ ������
	void AddStudent(CStudent student);
	//��������� �������� ������
	void AppointCurator(CCurator &curator);
	//���������� ������ ������ � �������
	void View();
	//��������, ����������� ��� ������� ��������.
	void ForeachStudent(Action &action);
	
};