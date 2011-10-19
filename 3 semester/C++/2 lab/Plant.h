#pragma once

// класс представляющий растение
class Plant
{
protected:
	double _life_time; //время жизни в годах 
	double _stem_length; // длина стебля
	
	void Set_life_time(double lt); // устанавливает время жизни
	double Get_life_time(void); // возвращает время жизни
	void Set_stem_length(double sl); // устанавливает длину стебля
	double Get_stem_length(void); // возвращает длину стебля

public:
    virtual	void Show(void); // Выводит все данные об объекте
	Plant(void); // конструктор по умолчанию
	Plant(Plant* obj); // конструктор копирования
	Plant(double life_time, double stem_length); // конструктор с параметрами
	~Plant(void); // деструктор
};

