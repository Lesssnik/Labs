#include "Rose.h"
#include "main.h"

void Rose::Show(void) // процедура, которая выводит всю информацию об объекте
{
	cout << "Spines: " << Get_spines() << '\n'; // печатает наличие/отсутствие колючек
	cout << "Petals number: " << Get_petals_number() << '\n'; // печатает количество лепестков
	Flower::Show();
}

// свойства, через которые происходит установка и чтение данных из полей
void Rose::Set_spines(bool s){_spines = s;}
bool Rose::Get_spines(void){return _spines;}
void Rose::Set_petals_number(int pn){_petals_number = pn;}
int Rose::Get_petals_number(void){return _petals_number;}
void Set_rose_name(char &rn){}//strcpy(_rose_name, &rn);}
char* Get_rose_name(void){return NULL;}//return _rose_name;}
Rose::Rose(void) // конструктор по умолчанию, создает пустой объект
{
}

Rose::Rose(Rose* obj) // конструктор копирования
{
	Set_spines(obj->_spines); // устанавливаем наличие/отсутствие колючек
	Set_petals_number(obj->_petals_number); // устанавливаем количество лепестков
}

Rose::Rose(double life_time, double stem_length, int leaves_number, bool smell, bool spines, int petals_number, char* rose_name):Flower(leaves_number, smell, life_time, stem_length) // конструктор с параметрами
{
	Set_spines(spines); // устанавливаем наличие/отсутствие колючек
	Set_petals_number(petals_number); // устанавливаем количество лепестков
	_rose_name = rose_name;
}

Rose::~Rose(void) // деструктор
{
}