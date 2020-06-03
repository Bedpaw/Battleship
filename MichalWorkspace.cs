using System;
using System.IO;

namespace MichalWorspace
{
    class BattleShipGame
    {
        string shoot;
        bool checkValv = true;
        // Poniżej zakładam nazwy pól/ilość pól, żeby potem można było łatwo zmienić rozmiar pola gry (np dla testów)
        string[] positionNumber = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "01", "02", "03", "04", "05", "06", "07", "08", "09"}
        string[] positionLetter = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j"}
        

        while (checkValv) //pętla działa dopuki warunek jest prawdziwy, a zmieniam na false jak toś trafi
        {
            

            Console.Write("Where do You want to shoot? ");
            shoot = Console.ReadLine(); // wprowadzenie celu
            if (shoot.Length == 2 or shoot.Length == 3) //sprawdzam czy wprowadzony ciąg ma 2 znaki
            {
                // wkleje
                String shootLong = shoot.Insert(1, " ") // wstawiam spacje, żebym mógł potem podzielić
                string[] shootTable = shootLong.Split(" ") //dzielę wprowadzony string na 2 częśći - literę i numer
                for (int i = 0; i < positionLetter.Length; i++) //dla każdej litery
                {
                    if i == shootTable[0] // jeżeli litera w tabelce jest taka jak wprowadzona
                    {
                        for (int j = 0; j < positionNumber.Length; j++) // dla każdej cyfry w tabelce
                        {
                            if j == checkValv[1] //jeżeli cyfra w tabelce pokrywa się z cyfrą wprowadzoną - jeżeli wprowadzone pole istnieje
                            {
                                // wprowadzam co zrobię jak ktoś traf
                                checkValv = false //zmieniam warunek na false, żeby zakończyć petlę
                            }
                            else // jeżeli litera jest poza skalą
                            {
                                Console.WriteLine("You are out of order, please input value between 1 and 10")
                            }
                        }
                    }
                    else //jeżeli litera nie jest w tabelce
                    {
                        Console.WriteLine("You are out of order, please input value between a and j")
                    }

            }
            else //jak człowiek wprowadzi niepprawny strzał
            {
                Console.Write("You give a wrong shoot, try again");
            }
            
            }
            
        }




    }
}
