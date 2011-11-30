#include "BotanicalGarden.h"
#include "main.h"

template <class T> void CBotanicalGarden<T>::Add(T data)
{
	Element *pv = new Element(data);
	if (pbegin == 0)
		pbegin = pend = pv;
	else
	{
		pv->prev = pend;
		pend->next = pv;
		pend = pv;
	}
	Count++;
}

template <class T> void CBotanicalGarden<T>::Show(void)
{
	Element *pv = pbegin;
	cout << endl << "Elements:\n~~~~~~~~~~~~~~~~\n";
	while(pv)
	{
		pv->data.Show();
		cout << "\n~~~~~~~~~~~~~~~~\n";
		pv = pv->next;
	}
	cout << endl;
}

template <class T> int CBotanicalGarden<T>::GetCount(void)
{
	return Count;
}

template <class T> CBotanicalGarden<T>::~CBotanicalGarden(void)
{
	if (pbegin != 0)
	{
		Element *pv = pbegin;
		while (pv)
		{
			pv = pv->next;
			delete pbegin;
			pbegin = pv;
		}
	}
}

template <class T> T& CBotanicalGarden<T>::operator [] (int i)
{
	if (i < 0 || i >= Count)
	{
		cout << "Wrong index" << endl;
		exit(0);
	}
	Element *pv = pbegin;
	int j = 0;
	while (true)
	{
		if (i == j)
		{
			return pv->data;
		}
		pv = pv->next;
		j++;
	}
}

template <class T> bool CBotanicalGarden<T>::operator > (CBotanicalGarden garden_1)
{
	if (this->Count > garden_1.Count)
		return true;
	else return false;
}

template <class T> bool CBotanicalGarden<T>::operator < (CBotanicalGarden garden_1)
{
	if (this->Count < garden_1.Count)
		return true;
	else return false;
}

template <class T> bool CBotanicalGarden<T>::operator == (CBotanicalGarden garden_1)
{
	if (this->Count == garden_1.Count)
		return true;
	else return false;
}

template <class T> bool CBotanicalGarden<T>::operator != (CBotanicalGarden garden_1)
{
	if (this->Count != garden_1.Count)
		return true;
	else return false;
}