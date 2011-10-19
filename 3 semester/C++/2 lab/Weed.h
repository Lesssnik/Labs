#include "Plant.h"
#pragma once

// класс представляющий сорняк
class Weed:public Plant
{
protected:
	double _growth_rate; // скорость роста
	double _expansion_area; // площадь разрастания

	void Set_growth_rate(double gr); // устанавливает скорость роста
	double Get_growth_rate(void); // возвращает скорость роста
	void Set_expansion_area(double ea); // устанавливает площадь разростания
	double Get_expansion_area(void); // возвращает площадь разростания
	
public:
	virtual void Show(void); // Выводит все данные об объекте
	Weed(void); // конструктор по умолчанию
	Weed(Weed* obj); // конструктор копирования
	Weed(double growth_rate, double expansion_area, double life_time, double stem_length); // конструктор с параметрами
	~Weed(void); // деструктор
};

