using System.Collections.Concurrent;
using System.Diagnostics;
using BusinessLogicLayer.Unadesk.Model.Shapes;

Console.WriteLine(@"Enter:");
Console.WriteLine(@"1 - To calculate triangular type.");
Console.WriteLine(@"2 - To run speed test.");

var modeToString = Console.ReadLine();

if (!int.TryParse(modeToString, out var mode) ||
    mode is not (1 or 2)
) {
    throw new ArgumentException();
}

if (mode == 1)
{
    Console.WriteLine(@"Enter triangular sides :");
    Console.WriteLine(@"First side - ");

    var firstSideToString = Console.ReadLine();

    Console.WriteLine(@"Second side - ");

    var secondSideToString = Console.ReadLine();

    Console.WriteLine(@"Third side - ");

    var thirdSideToString = Console.ReadLine();

    if(!int.TryParse(firstSideToString, out var firstSide) ||
       !int.TryParse(secondSideToString, out var secondSide) ||
       !int.TryParse(thirdSideToString, out var thirdSide)
    ) {
        throw new ArgumentException();
    }

    var triangular = new Triangular(
        firstSide,
        secondSide,
        thirdSide
    );

    var triangularType = triangular.GetShapeType();

    Console.WriteLine($@"Triangular has { triangularType } type.");
}
else
{
    var resultMassages = new ConcurrentQueue<string>();

    var getTriangularType = new Action<int>(_ =>
    {
        var random = new Random();

        Triangular triangular = null;

        while (triangular is null)
        {
            var firstSide = random.Next(1, 100);
            var secondSide = random.Next(1, 100);
            var thirdSide = random.Next(1, 100);

            if (firstSide + secondSide > thirdSide &&
                firstSide + thirdSide > secondSide &&
                secondSide + thirdSide > firstSide
            ) {
                triangular = new Triangular(
                    firstSide,
                    secondSide,
                    thirdSide
                );
            }
        }

        var triangularType = triangular.GetShapeType();

        resultMassages.Enqueue($"Triangular with sides: { triangular.FirstSide }, { triangular.SecondSide }, { triangular.ThirdSide } has type { triangularType }");
    });

    Console.WriteLine(@"Speed test starting.....");

    Console.WriteLine(@"Call a method 10 000 000 times.");

    var timer = Stopwatch.StartNew();

    Parallel.For(0, 10_000_000, getTriangularType);

    timer.Stop();

    Console.WriteLine($@"speed test ended. Execution time { timer.ElapsedMilliseconds }.");

    Console.WriteLine(@"Display the result?");
    Console.WriteLine(@"1 - Yes.");
    Console.WriteLine(@"2 - No.");

    var displayResultToString = Console.ReadLine();

    if (!int.TryParse(displayResultToString, out var displayResult) ||
        mode is not (1 or 2)
    ) {
        throw new ArgumentException();
    }

    if (displayResult == 1)
    {
        foreach (var massage in resultMassages)
        {
            Console.WriteLine(massage);
        }
    }
    else
    {
        resultMassages.Clear();
    }
}