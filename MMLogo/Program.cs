using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    static int thickness = 0;
    static List<string> canvas;

    public static void Main()
    {
        canvas = new List<string>();
        
        do
        {
            Console.Write("Input thickness:");

            String input = Console.ReadLine();
            bool numberIsProvided = Int32.TryParse(input, out thickness);

            if (numberIsProvided && thickness > 2 && thickness < 10000 && thickness % 2 != 0)
            {
                for (int row = 0; row <= thickness; row++)
                {
                    string halfRow = "";

                    for (int column = 0; column < (thickness * 5); column++)
                    {
                        halfRow = String.Concat(halfRow, DetermineSign(row, column));
                    }
                    string rowContent = String.Concat(halfRow, halfRow);
                    canvas.Add(rowContent);
                }
                break;
            }
            else
            {
                Console.WriteLine("You should provide odd number between 2 and 10 000 for thickness!");
                continue;
            }
        } while (true);

        DrawLogo();

        Console.ReadLine();
    }

    private static bool FirstStroke(int row, int column)
    {
        int position = thickness - 1 - row;
        return (column > position && column <= (position + thickness));
    }

    private static bool SecondStroke(int row, int column)
    {
        int position = thickness - 1 + row;
        return (column > position && column <= (position + thickness));
    }

    private static bool ThirdStroke(int row, int column)
    {
        int position = (3 * thickness) - 1 - row;
        return (column > position && column <= (position + thickness));
    }

    private static bool FourthStroke(int row, int column)
    {
        int position = (3 * thickness) - 1 + row;
        return (column > position && column <= (position + thickness));
    }

    private static string DetermineSign(int row, int column)
    {
        String dash = "-";
        String star = "*";
        if (FirstStroke(row, column) || SecondStroke(row, column) || ThirdStroke(row, column) || FourthStroke(row, column))
        {
            return star;
        }
        else
        {
            return dash;
        }
    }

    private static void DrawLogo()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string row in canvas)
        {
            sb.AppendLine(row);
        }
        Console.Write(sb.ToString());
    }

}