public class ArrayUtils
{
    public delegate bool FilterDelegate(int number);

    public static int[] GetEvenNumbers(int[] array)
    {
        return FilterArray(array, IsEven);
    }

    public static int[] GetOddNumbers(int[] array)
    {
        return FilterArray(array, IsOdd);
    }

    public static int[] GetPrimeNumbers(int[] array)
    {
        return FilterArray(array, IsPrime);
    }

    public static int[] GetFibonacciNumbers(int[] array)
    {
        return FilterArray(array, IsFibonacci);
    }

    private static int[] FilterArray(int[] array, FilterDelegate filter)
    {
        List<int> result = new List<int>();
        foreach (int number in array)
        {
            if (filter(number))
            {
                result.Add(number);
            }
        }
        return result.ToArray();
    }

    private static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    private static bool IsOdd(int number)
    {
        return number % 2 != 0;
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    private static bool IsFibonacci(int number)
    {
        int a = 0;
        int b = 1;
        if (number == a || number == b) return true;
        int c = a + b;
        while (c <= number)
        {
            if (c == number) return true;
            a = b;
            b = c;
            c = a + b;
        }
        return false;
    }

    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 13, 21 };

        int[] evenNumbers = GetEvenNumbers(numbers);
        Console.WriteLine("Even Numbers: " + string.Join(", ", evenNumbers));

        int[] oddNumbers = GetOddNumbers(numbers);
        Console.WriteLine("Odd Numbers: " + string.Join(", ", oddNumbers));

        int[] primeNumbers = GetPrimeNumbers(numbers);
        Console.WriteLine("Prime Numbers: " + string.Join(", ", primeNumbers));

        int[] fibonacciNumbers = GetFibonacciNumbers(numbers);
        Console.WriteLine("Fibonacci Numbers: " + string.Join(", ", fibonacciNumbers));
    }
}
