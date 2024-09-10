static void Labb1()
{
    bool substringExist = true;
    string inmatat;

    do
    {
        Console.WriteLine("Mata in vilken text du vill");

        inmatat = Console.ReadLine();
        substringExist = true;
        if (inmatat == String.Empty)
        {
            substringExist = false;
            Console.WriteLine("Tryck på en tagent för att försöka igen");
            Console.ReadLine();
            Console.Clear();
        }
    } while (!substringExist);
    Console.Clear();

    string delstring = "";
    ulong summaAvDelstring = 0;

    for (int i = 0; i < inmatat.Length; i++)
    {
        if (char.IsDigit(inmatat[i]))
        {
            for (int j = 1; j < inmatat.Length; j++)
            {
                if (i + j < inmatat.Length && inmatat[i] == inmatat[i + j])
                {
                    substringExist = true;
                    j = inmatat.Length + 1;
                }
                else if (i + j < inmatat.Length && !char.IsDigit(inmatat[i + j]))
                {
                    substringExist = false;
                    j = inmatat.Length;
                }
                else substringExist = false;
            }
            while (substringExist)
            {
                delstring += Convert.ToString(inmatat[i]);
                for (int j = 1; j < inmatat.Length; j++)
                {
                    if (inmatat[i] != inmatat[i + j] && char.IsDigit(inmatat[i + j]))
                    {
                        delstring += Convert.ToString(inmatat[i + j]);
                    }
                    else if (inmatat[i] == inmatat[i + j])
                    {
                        delstring += Convert.ToString(inmatat[i + j]);
                        j = inmatat.Length;
                        substringExist = false;
                    }
                }
                if (inmatat.Contains(delstring))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    int indexDelstringStart = inmatat.IndexOf(delstring);
                    Console.Write(inmatat.Substring(0, indexDelstringStart));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(delstring);
                    Console.ForegroundColor = ConsoleColor.White;

                    int indexDelStringSlut = 0;
                    foreach (char item in delstring)
                    {
                        indexDelStringSlut++;
                    }
                    indexDelStringSlut += indexDelstringStart;

                    Console.Write(inmatat.Substring(indexDelStringSlut));
                    Console.WriteLine();
                    summaAvDelstring += ulong.Parse(delstring);
                    delstring = "";
                }
            }
        }
    }
    Console.WriteLine();
    Console.WriteLine($"Summan av alla delsträngar är: {summaAvDelstring}");
}

Labb1();