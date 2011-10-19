#include "Flower.h"
#include "main.h"

void Flower::Show(void) // процедура, которая выводит всю информацию об объекте
{
	cout << "Leaves number: " << Get_leaves_number() << '\n'; // печатает количество листьев
	cout << "Smell: " << Get_smell() << '\n'; // печатает наличие/отсутствие запаха
	Plant::Show();
}

// свойства, через которые происходит установка и чтение данных из полей
void Flower::Set_leaves_number(int ln){_leaves_number = ln;}
int Flower::Get_leaves_number(void){return _leaves_number;}
void Flower::Set_smell(bool s){_smell = s;}
bool Flower::Get_smell(void){return _smell;}

Flower::Flower(void) // конструктор по умолчанию, создает пустой объект
{
}

Flower::Flower(Flower* obj) // конструктор копирования
{
	Set_leaves_number(obj->_leaves_number); // устанавливаем количество листьев
	Set_smell(obj->_smell); // устанавливаем наличие/отсутствие запаха
}

Flower::Flower(int leaves_number, bool smell, double life_time, double stem_length):Plant(life_time, stem_length) // конструктор с параметрами
{
	Set_leaves_number(leaves_number); // устанавливаем количество листьев
	Set_smell(smell); // устанавливаем наличие/отсутствие запаха
}

Flower::~Flower(void) // деструктор
{
}