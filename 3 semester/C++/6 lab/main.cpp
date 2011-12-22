#include "main.h"
#include "BotanicalGarden.h"
#include "BotanicalGarden.cpp"

void main(void)
{
	Flower f1 = Flower(12, true, 12.5, 2.1);
	Rose r1 = Rose(1, 6, 32, true, true, 99, "Good");
	Rose r2 = Rose(0.4, 3.2, 5, false, false, 10, "Death");
	Rose r3 = Rose(2, 2, 52, true, false, 43, "Black");
	CBotanicalGarden<Flower> garden;
	CBotanicalGarden<Flower> garden2;
	garden.Add(f1);
	garden.Add(r1);
	garden.Add(r2);
	garden.Add(r3);

	freopen("D:\\output.txt", "w", stdout);

	cout << "Information about garden_1:" << endl;
	garden[0].Show();
	cout << "\n" << endl;
	garden[1].Show();
	cout << "\n" << endl;
	garden[2].Show();
	cout << "\n" << endl;
	garden[3].Show();
	cout << "\n" << endl;
	
	if (garden > garden2)
		cout << "Garden_1 bigger then Garden_2" << endl;
	else if (garden < garden2)
		cout << "Garden_1 smaller then Garden_2" << endl;
	else cout << "Garden_1 and Garden_2 are equals" << endl;

	freopen("CON", "wt", stdout);
	cout << "Information was write" << endl;
	system("pause");
}