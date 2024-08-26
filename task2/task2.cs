if (args.Length == 2)
{
    int x0 = 0;
    int y0 = 0;
    int radius = 1;

    string circlePath = args[0];

    int FindOutPosition(int x0, int y0, int radius, int x, int y)
    {
        double d = Math.Sqrt(Math.Pow(x0 - x, 2) + Math.Pow(y0 - y, 2));

        if (d < radius)
            return 1;
        else if (d > radius) return 2;
        else return 0;
    }

    using (StreamReader reader = new StreamReader(circlePath))
    {
        string centerText = reader.ReadLine();
        string[] center = centerText.Split(' ');
        string radiusText = reader.ReadLine();
        if (!(int.TryParse(center[0], out x0) && int.TryParse(center[1], out y0) && int.TryParse(radiusText, out radius)))
        {
            Console.WriteLine("Incorrect first argument");
            return;
        }
    }

    string pointsPath = args[1];

    using (StreamReader reader = new StreamReader(pointsPath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] points = line.Split(' ');
            if (int.TryParse(points[0], out int x) && int.TryParse(points[1], out int y))
            {
                Console.WriteLine(FindOutPosition(x0, y0, radius, x, y));
            }
        }

    }
}


