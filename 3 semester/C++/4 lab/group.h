#pragma once

#include <vector>
#include "student.h"
#include "curator.h"

//Псевдоним типа, передаваемого в ForEachStudent. Принимает ссылку на студента,
//который будет подвержен обработке
typedef void(*Action)(CStudent &student);

class CGroup
{
protected:
	//Динамический массив студентов
	vector<CStudent> _students;
	//Куратор группы
	CCurator _curator;
public:
	//Добавление студента в динамический массив
	void AddStudent(CStudent student);
	//Назначить куратора группы
	void AppointCurator(CCurator &curator);
	//Отобразить состав группы в консоли
	void View();
	//Итератор, выполняемый для каждого студента.
	void ForeachStudent(Action &action);
	
};