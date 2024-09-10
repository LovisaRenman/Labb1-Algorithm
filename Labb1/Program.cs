static void Labb1()
{
    bool isSubstringExisting = true;
    string input;

    do
    {
        Console.WriteLine("Please write some text");

        input = Console.ReadLine();
        isSubstringExisting = true;
        if (input == String.Empty)
        {
            isSubstringExisting = false;
            Console.WriteLine("Please press enter to try again");
            Console.ReadLine();
            Console.Clear();
        }
    } while (!isSubstringExisting);
    Console.Clear();

    string substring = "";
    ulong sumOfSubString = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if (char.IsDigit(input[i]))
        {
            for (int j = 1; j < input.Length; j++)
            {
                if (i + j < input.Length && input[i] == input[i + j])
                {
                    isSubstringExisting = true;
                    j = input.Length + 1;
                }
                else if (i + j < input.Length && !char.IsDigit(input[i + j]))
                {
                    isSubstringExisting = false;
                    j = input.Length;
                }
                else isSubstringExisting = false;
            }
            while (isSubstringExisting)
            {
                substring += Convert.ToString(input[i]);
                for (int j = 1; j < input.Length; j++)
                {
                    if (input[i] != input[i + j] && char.IsDigit(input[i + j]))
                    {
                        substring += Convert.ToString(input[i + j]);
                    }
                    else if (input[i] == input[i + j])
                    {
                        substring += Convert.ToString(input[i + j]);
                        j = input.Length;
                        isSubstringExisting = false;
                    }
                }
                if (input.Contains(substring))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    int indexSubstringStart = input.IndexOf(substring);
                    Console.Write(input.Substring(0, indexSubstringStart));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(substring);
                    Console.ForegroundColor = ConsoleColor.White;

                    int indexSubstringEnd = 0;
                    foreach (char item in substring)
                    {
                        indexSubstringEnd++;
                    }
                    indexSubstringEnd += indexSubstringStart;

                    Console.Write(input.Substring(indexSubstringEnd));
                    Console.WriteLine();
                    sumOfSubString += ulong.Parse(substring);
                    substring = "";
                }
            }
        }
    }
    Console.WriteLine();
    Console.WriteLine($"The sum of all substring is: {sumOfSubString}");
}

Labb1();