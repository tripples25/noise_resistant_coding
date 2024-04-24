namespace noise_resistant_coding;

public class CrcCalculator
{
    public (int codeword, int crc) CRC(string dataword, string generator)
    {
        var generatorLength = generator.Length;
        var gen = generator.ToDec();
        var dword = dataword.ToDec();

        var crc = CalculateCRC(dword, gen);
        
        var codeword = (dword << (generatorLength - 1)) | crc;
        
        return (codeword, crc);
    }
    
    public (bool isCorrect, int dataword, int crc) Decode(string receivedCodeword, string generator)
    {
        var generatorLength = generator.Length;
        var datawordLength = receivedCodeword.Length - generatorLength + 1;
        
        var receivedDataword = receivedCodeword[..datawordLength];
        var receivedCRC = receivedCodeword[datawordLength..];
        
        var crc = CalculateCRC(receivedDataword.ToDec(), generator.ToDec());
        
        return (crc.ToBin() == receivedCRC, receivedCodeword.ToDec(), receivedCRC.ToDec());
    }

    private int CalculateCRC(int dataword, int generator)
    {
        var generatorLength = generator.ToBin().Length;
        var dividend = dataword << (generatorLength - 1);
        var shift = (int)Math.Ceiling(Math.Log(dividend + 1) / Math.Log(2)) - generatorLength;

        while (dividend >= generator || shift >= 0) {
            
            var rem = (dividend >> shift) ^ generator;
            dividend = (dividend & ((1 << shift) - 1)) | (rem << shift);
            
            shift = (int)Math.Ceiling(Math.Log(dividend + 1)
                                     / Math.Log(2))
                   - generatorLength;
        }

        return dividend;
    }
}
