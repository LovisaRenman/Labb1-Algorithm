


bool boolean = true;
string inmatat;

do
{
    inmatat = String.Empty;
    Console.WriteLine("Mata in vilken text du vill");
    try
    {
        inmatat = Console.ReadLine();
        boolean = true;
    }
    catch
    {
        if (inmatat == String.Empty)
        {
            boolean = false;
            Console.WriteLine("Försök igen");
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
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
        elementDelString++;
        }        
    }
}

for (int i = 0; i <300; i++)
{
    try
    {
        if (inmatat.Contains(delString[i]))
        {
            Console.ForegroundColor = ConsoleColor.White;
            int indexDelstringStart = inmatat.IndexOf(delString[i]);
            Console.Write(inmatat.Substring(0, indexDelstringStart));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(delString[i]);
            Console.ForegroundColor = ConsoleColor.White;

            string raknaChar = delString[i];
            int indexDelStringSlut = 0;
            foreach (char item in raknaChar)
            {
                indexDelStringSlut++;
            }
            indexDelStringSlut += indexDelstringStart;

            Console.Write(inmatat.Substring(indexDelStringSlut));
            Console.WriteLine();
        }
    }
    catch
    {

    }
}

ulong summanAvAllaDelString = 1;
foreach (var item in delString)
{
    summanAvAllaDelString += Convert.ToUInt64(item);
}
Console.WriteLine($"Summan av alla delsträngar är: {summanAvAllaDelString}");