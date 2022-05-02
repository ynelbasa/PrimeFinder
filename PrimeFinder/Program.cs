using System.Diagnostics;
using PrimeFinder;

var timer = new Stopwatch();

timer.Start();

var primeNumbers = PrimeFinderUtil.GetPrimesWithinRange(1, 1000);

PrimeFinderUtil.Solve(primeNumbers);

timer.Stop();

Console.WriteLine($"Total time elapsed: {timer.Elapsed.TotalSeconds}s");
