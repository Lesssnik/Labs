#include "Plant.h"
#include "main.h"

void Plant::Show(void) // процедура, которая выводит всю информацию об объекте
{
	cout << "Life time: " << Get_life_time() << '\n'; // печатает длину жизни
	cout << "Stem length: " << Get_stem_length() << '\n'; // печатает длину стебля
}

// свойства, через которые происходит установка и чтение данных из полей
void Plant::Set_life_time(double lt){_life_time = lt;}
double Plant::Get_life_time(void){return _life_time;}
void Plant::Set_stem_length(double sl){_stem_length = sl;}
double Plant::Get_stem_length(void){return _stem_length;}

Plant::Plant() // конструктор по умолчанию, создает пустой объект
{
}

Plant::Plant(Plant* obj) // конструктор копирования
{
	Set_life_time(obj->_life_time); // устанавливает длину жизни
	Set_stem_length(obj->_stem_length); // устанавливает длину стебля
}

Plant::Plant(double life_time, double stem_length) // конструктор с параметрами
{
	Set_life_time(life_time); // устанавливает длину жизни
	Set_stem_length(stem_length); // устанавливает длину стебля
}


Plant::~Plant(void) // деструктор
{
}