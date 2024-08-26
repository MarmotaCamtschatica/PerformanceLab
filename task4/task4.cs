if (args.Length > 0)
{
    string path = args[0];   

    using (StreamReader reader = new StreamReader(path))
    {
        string line;
        List<int> list = new List<int>();
        while ((line = reader.ReadLine()) != null)
        {            
            if (int.TryParse(line, out int x))
            {
                list.Add(x);
            }
        }

        int[] nums = list.ToArray();

        int mean = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            mean += nums[i];
        }
        mean = mean / nums.Length;

        int count = 0;

        foreach (int num in nums)
        {
            count += Math.Abs(mean - num);
        }

        Console.WriteLine(count);
    }
}

