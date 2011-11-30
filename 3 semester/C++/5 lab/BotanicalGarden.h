#include "main.h"

#pragma once

template <class T> class CBotanicalGarden
{
    class Element
	{
	public:
		T data;
		Element *next, *prev;
		Element(T d = 0)
		{
			data = d;
			next = 0;
			prev = 0;
		}
	};
Element *pbegin, *pend;
private:
	int Count;

public:
	void Add(T data);
	void Show(void);
	int GetCount(void);
	CBotanicalGarden(void){pbegin = 0; pend = 0; Count = 0;};
	~CBotanicalGarden(void);
	T& operator [] (int i);
	bool operator > (CBotanicalGarden garden_1);
	bool operator < (CBotanicalGarden garden_1);
	bool operator == (CBotanicalGarden garden_1);
	bool operator != (CBotanicalGarden garden_1);
};

