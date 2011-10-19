#include "Plant.h"
#pragma once

// класс представляющий цветок
class Flower:public Plant
{
protected:
	int _leaves_number; // количество листьев
	bool _smell; // наличие/отсутствие запаха

	void Set_leaves_number(int ln); // устанавливает количество листьев
	int Get_leaves_number(void); // возвращает количество листьев
	void Set_smell(bool s); // устанавливает наличие/отсутствие запаха
	bool Get_smell(void); // возвращает наличие/отсутствие запаха

public:
	virtual void Show(void); // Выводит все данные об объекте
	Flower(void); // конструктор по умолчанию
	Flower(Flower* obj); // конструктор копирования
	Flower(int leaves_number, bool smell, double life_time, double stem_length); // конструктор с параметрами
	~Flower(void); // деструктор
};

