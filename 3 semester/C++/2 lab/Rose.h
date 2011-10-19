#include "Flower.h"
#pragma once

// класс представляющий розу
class Rose:public Flower
{
protected:
	bool _spines; // присутствуют/отсутствуют колючки
	int _petals_number; // количество лепестков
	char* _rose_name; // сорт розы

	void Set_spines(bool s); // устанавливает наличие/отсутствие колючек
	bool Get_spines(void); // возвращает наличие/отсутствие колючек
	void Set_petals_number(int pn); // устанавливает количество лепестков
	int Get_petals_number(void); // возвращает количество лепестков
	void Set_rose_name(char &rn); // устанавливает название сорта
	char* Get_rose_name(void); // возвращает название сорта
	
public:
	virtual void Show(void); // Выводит все данные об объекте
	Rose(void); // конструктор по умолчанию
	Rose(Rose* obj); // конструктор копирования
	Rose(double life_time, double stem_length, int leaves_number, bool smell, bool spines, int petals_number, char* rose_name); // конструктор с параметрами
	~Rose(void); // деструктор
};

