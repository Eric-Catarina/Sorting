using Sorting.enemy;
using Sorting.manager;
using Sorting.print;
using Sorting.reader;
using Sorting.utils;
using Sorting.enums;
using Sorting.sorting.simple;
using Sorting.sorting.efficient;
using Sorting.sorting.specials;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enemy Sorting System");
        Console.WriteLine("--------------------");
        
        // Read enemies from file
        ReaderFile reader = new ReaderFile("./inputs/enemys.txt");
        string[] lines = reader.LerLinhaALinha();
        Enemy[] enemies = new Enemy[lines.Length];
        
for (int i = 0; i < lines.Length; i++)
{
    string[] parts = lines[i].Split(',');
    if (parts.Length >= 4 && 
        int.TryParse(parts[1], out int health) && 
        int.TryParse(parts[2], out int damage) && 
        int.TryParse(parts[3], out int level))
    {
        enemies[i] = new Enemy(parts[0], health, damage, level);
    }
    else
    {
        Console.WriteLine($"Formato inválido na linha {i + 1}");
        return;
    }
}
        
        // Display menu
        Console.WriteLine("Choose sorting algorithm:");
        Console.WriteLine("1. BubbleSort");
        Console.WriteLine("2. SelectionSort");
        Console.WriteLine("3. InsertionSort");
        Console.WriteLine("4. ShellSort");
        Console.WriteLine("5. QuickSort");
        Console.WriteLine("6. MergeSort");
        Console.WriteLine("7. HeapSort");
        
// Sorting/Program.cs
int algorithmChoice;
if (!int.TryParse(Console.ReadLine(), out algorithmChoice))
{
    Console.WriteLine("Entrada inválida!");
    return;
}

// Repita para outras entradas...        
        Console.WriteLine("Choose sorting criteria:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Health");
        Console.WriteLine("3. Damage");
        Console.WriteLine("4. Level");
        
        int criteriaChoice = int.Parse(Console.ReadLine());
        string criteria = criteriaChoice switch {
            1 => "name",
            2 => "health",
            3 => "damage",
            4 => "level",
            _ => "name"
        };
        
        // Display before sorting
        Console.WriteLine("\nBefore sorting:");
        foreach (var enemy in enemies)
        {
            Console.WriteLine(enemy);
        }
        
        // Sort
// Sorting/Program.cs
Enemy[] sortedEnemies = algorithmChoice switch {
    1 => BubbleSort.Sorting(enemies, criteria),
    2 => SelectionSort.Sorting(enemies, criteria),
    3 => InsertionSort.Sorting(enemies, criteria),
    4 => ShellSort.Sorting(enemies, criteria),
    5 => QuickSort.Sorting(enemies, criteria),
    6 => MergeSort.Sorting(enemies, criteria),
    7 => HeapSort.Sorting(enemies, criteria),
    _ => enemies
};
        
        // Display after sorting
        Console.WriteLine("\nAfter sorting:");
        foreach (var enemy in sortedEnemies)
        {
            Console.WriteLine(enemy);
        }
        
        // Save to file
        string algorithmName = algorithmChoice switch {
            1 => "bubble",
            2 => "selection",
            3 => "insertion",
            4 => "shell",
            5 => "quick",
            6 => "merge",
            7 => "heap",
            _ => "unknown"
        };
        
        string outputPath = $"./outputs/enemys-{algorithmName}.txt";
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (var enemy in sortedEnemies)
            {
                writer.WriteLine($"{enemy.Name},{enemy.Health},{enemy.Damage},{enemy.Level}");
            }
        }
        
        Console.WriteLine($"Results saved to {outputPath}");
    }
}