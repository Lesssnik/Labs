#include "Weed.h"
#include "main.h"

void Weed::Show(void) // процедура, которая выводит всю информацию об объекте
{
	cout << "Growth rate: " << Get_growth_rate() << '\n'; // печатает скорость роста
	cout << "Expansion area: " << Get_expansion_area() << '\n'; // печатает площадь разрастания
	Plant::Show();
}

// свойства, через которые происходит установка и чтение данных из полей
void Weed::Set_growth_rate(double gr){_growth_rate = gr;}
double Weed::Get_growth_rate(void){return _growth_rate;}
void Weed::Set_expansion_area(double ea){_expansion_area = ea;}
double Weed::Get_expansion_area(void){return _expansion_area;}

Weed::Weed(void) // конструктор по умолчанию, создает пустой объект
{
}

Weed::Weed(Weed* obj)  // конструктор копирования
{
	Set_growth_rate(obj->_growth_rate); //устанавливаем скорость роста
	Set_expansion_area(obj->_expansion_area); // устанавливаем площадь разростания
}

Weed::Weed(double life_time, double stem_length, double growth_rate, double expansion_area):Plant(life_time, stem_length)  // конструктор с параметрами
{
	Set_growth_rate(growth_rate); //устанавливаем скорость роста
	Set_expansion_area(expansion_area); // устанавливаем площадь разростания
}

Weed::~Weed(void) // деструктор
{
}