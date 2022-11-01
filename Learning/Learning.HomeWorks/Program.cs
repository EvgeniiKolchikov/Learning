using System.Text;
using Learning.HomeWorks;
var asyncWriter = new AsyncWriter();
await asyncWriter.WriteNumber();
 
public class AsyncWriter
{
    object _numberRuningThread = 0;
    object _laseWriteNumber = 3;
    public static bool JobIsDone = false;
    public readonly int[] NumberArr;
 
    public AsyncWriter()
    {
        NumberArr = new int[30];
        var rnd = new Random();
        for (int i = 0; i < NumberArr.Length; i++)
        {
            NumberArr[i] = rnd.Next(1, 4);
        }
    }
 
    public async Task WriteNumber()
    {
        for (int i = 1; i <= 3; i++)
        {
            Thread myThread = new(RunWriter);
            myThread.Start();
        }
        await CheckIsEnd();
    }
 
    private void RunWriter()
    {
        _numberRuningThread = (int)_numberRuningThread + 1;
        var writeNumber = (int)_numberRuningThread;
        var index = 0;
        while (index < NumberArr.Length)
        {
            if (writeNumber == 1 && (int)_laseWriteNumber == 3)
            {
                if (NumberArr[index] == writeNumber)
                {
                    Console.Write(NumberArr[index]);
                    _laseWriteNumber = 1;
                    index++;
                }
                else
                {
                    index++;
                }
            }else if (writeNumber == 2 && (int)_laseWriteNumber == 1)
            {
                if (NumberArr[index] == writeNumber)
                {
                    Console.Write(NumberArr[index]);
                    _laseWriteNumber = 2;
                }
                else
                {
                    index++;
                }
            }else if (writeNumber == 3 && (int)_laseWriteNumber == 2)
            {
                if (NumberArr[index] == writeNumber)
                {
                    Console.Write(NumberArr[index]);
                    _laseWriteNumber = 3;
                }
                else
                {
                    index++;
                }
            }
            else
            {
                Thread.Sleep(100);
            }
        }

        while (index < NumberArr.Length)
        {
            if (writeNumber == 2 && (int)_laseWriteNumber == 3)
            {
                if (NumberArr[index] == writeNumber)
                {
                    Console.Write(NumberArr[index]);
                    _laseWriteNumber = 2;
                    index++;
                }
                else
                {
                    index++;
                }
            }
        }
        
        return;
    }
 
    private async Task CheckIsEnd()
    {
        while (!JobIsDone)
        {
            Thread.Sleep(100);
        }
        return;
    }
}


