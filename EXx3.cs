using System;
using System.IO;

class ImageProcessing
{
    static void Main()
    {
        
        Console.Write("filelocation: ");
        string inputImagePath = Console.ReadLine();

        
        Console.Write("filelocation: ");
        string kernelPath = Console.ReadLine();

        
        Console.Write("filelocationinfo: ");
        string outputImagePath = Console.ReadLine();

        
        double[,] imageData = ReadImageDataFromFile(inputImagePath);

        
        double[,] kernel = ReadImageDataFromFile(kernelPath);

       
        double[,] result = Convolve(imageData, kernel);

        
        WriteImageDataToFile(outputImagePath, result);

        
    }

    static double[,] ReadImageDataFromFile(string imagePath)
    {
       
        int width = 0, height = 0;
        double[,] imageData;

        using (StreamReader reader = new StreamReader(imagePath))
        {
            
            string[] size = reader.ReadLine().Split(',');
            width = int.Parse(size[0]);
            height = int.Parse(size[1]);

            
            imageData = new double[height, width];

            
            for (int i = 0; i < height; i++)
            {
                string[] values = reader.ReadLine().Split(',');

                for (int j = 0; j < width; j++)
                {
                    imageData[i, j] = double.Parse(values[j]);
                }
            }
        }

       

        