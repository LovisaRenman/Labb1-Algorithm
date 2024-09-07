
using System;

bool boolean = true;
string inmatat;

do
{
    Console.WriteLine("Mata in vilken text du vill");
    inmatat = Console.ReadLine();
    if (inmatat == null)
    {
        boolean = false;
        Console.WriteLine("Försök igen");
        Thread.Sleep(5000);
        Console.Clear();
    }
    else boolean = true;
} while (!boolean);

string[] delString = new string[10000];
char[] alltInmatatSomChar = new char[10000];
int antalTecken = 0;
int elementDelString = 0;

foreach (char tecken in inmatat)
{
    alltInmatatSomChar[antalTecken] = tecken;
    antalTecken++;
}

for (int i = 0; i <= inmatat.Length; i++)
{
    if (char.IsDigit(alltInmatatSomChar[i]))
    {
        for (int j = 1; j < inmatat.Length; j++)
        {
            if (alltInmatatSomChar[i] == alltInmatatSomChar[i+j] && i + j < inmatat.Length) 
            {
                boolean = true;
                j = inmatat.Length + 1;
            }
            else if (!char.IsDigit(alltInmatatSomChar[i + j]))
            {
                boolean = false;
                j = inmatat.Length;
            }
            else boolean = false;
        }

        while (boolean)
        {
            delString[elementDelString] += Convert.ToString(alltInmatatSomChar[i]);
            for (int j = 1; j < inmatat.Length; j++)
            {
                if (alltInmatatSomChar[i] != alltInmatatSomChar[i + j] && char.IsDigit(alltInmatatSomChar[i + j]))
                {
                    delString[elementDelString] += Convert.ToString(alltInmatatSomChar[i + j]);
                }
                else if (alltInmatatSomChar[i] == alltInmatatSomChar[i + j])
                {
                    delString[elementDelString] += Convert.ToString(alltInmatatSomChar[i + j]);
                    j = inmatat.Length;
                    boolean = false;
                }
            }
        Console.WriteLine(delString[elementDelString]);
        elementDelString++;
        }        
    }
}