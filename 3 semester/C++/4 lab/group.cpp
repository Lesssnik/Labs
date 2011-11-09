#include "group.h"

void CGroup::AddStudent(CStudent student)
{
	_students.push_back(student);
}

void CGroup::AppointCurator(CCurator &curator)
{
	_curator = curator;
}

void CGroup::View()
{
	_curator.View();

	vector<CStudent>::iterator student;
	for(student = _students.begin(); student < _students.end(); student++)
		student->View();
}

void CGroup::ForeachStudent(Action &action)
{
	vector<CStudent>::iterator student;
	for(student = _students.begin(); student < _students.end(); student++)
		action(*student);
}