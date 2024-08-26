
if (args.Length == 2 && int.TryParse(args[0], out int n) && int.TryParse(args[1], out int m))
{
    var path = new List<int>();
    path.Add(1); // start value

    int y = 1;

    for (int i = 1; ; i++)
    {
        int x = y - n * ((y - 1) / n);

        if (i % m == 0)
        {
            if (x == 1) // 1 - start value
            {
                break;
            }
            path.Add(x);
        }
        else
        {
            y++;
        }

    }

    foreach (int x in path)
    {
        Console.Write(x);
    }
}
else
{
    Console.WriteLine("Incorrect arguments");
}