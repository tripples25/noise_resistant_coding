using noise_resistant_coding;

var calculator = new CrcCalculator();

while (true)
{
    Console.WriteLine("1. Кодировать слово");
    Console.WriteLine("2. Декодировать слово");
    Console.WriteLine("3. Выйти");
    Console.WriteLine();
    
    var input = Console.ReadLine();
    Console.WriteLine();

    switch (int.TryParse(input, null, out var output))
    {
        case true when output == 1:
            Console.Write("Кодируемое слово: ");
            var dataword = Console.ReadLine();
            Console.Write("Генераторный полином: ");
            var generator = Console.ReadLine();
            var calc = calculator.CRC(dataword, generator);
            Console.WriteLine($"Закодированное слово: {calc.codeword.ToBin()}, CRC: {calc.crc.ToBin()}");
            Console.WriteLine();
            break;
        case true when output == 2:
            Console.Write("Закодированное слово: ");
            var codeword = Console.ReadLine();
            Console.Write("Генераторный полином: ");
            var generator1 = Console.ReadLine();
            var decode = calculator.Decode(codeword, generator1);
            if (decode.isCorrect)
            {
                Console.WriteLine("Данные корректны.");
            }
            else
            {
                Console.WriteLine("Данные повреждены.");
            }
            Console.WriteLine();
            break;
        case true when output == 3:
            return;
        default:
            Console.WriteLine("Введено неверное значение.");
            break;
    }
}
    
