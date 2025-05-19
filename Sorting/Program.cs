using Sorting.enemy;
using Sorting.manager;
using Sorting.print;
using Sorting.reader;
using Sorting.utils;
using Sorting.enums;
using Sorting.sorting.simple;
using Sorting.sorting.efficient;
using Sorting.sorting.specials;
using Sorting.structures;
using Sorting.tree;
using Sorting.hash;
using Sorting.search;
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

        // Main menu
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Sorting Algorithms");
            Console.WriteLine("2. Data Structures (Part V)");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int mainChoice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (mainChoice)
            {
                case 1:
                    ShowSortingMenu(enemies);
                    break;
                case 2:
                    ShowDataStructuresMenu(enemies);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }

    private static void ShowSortingMenu(Enemy[] enemies)
    {
        Console.WriteLine("\nSorting Algorithms Menu:");
        Console.WriteLine("1. BubbleSort");
        Console.WriteLine("2. SelectionSort");
        Console.WriteLine("3. InsertionSort");
        Console.WriteLine("4. ShellSort");
        Console.WriteLine("5. QuickSort");
        Console.WriteLine("6. MergeSort");
        Console.WriteLine("7. HeapSort");
        Console.WriteLine("8. Back to Main Menu");
        Console.Write("Choose an algorithm: ");

        if (!int.TryParse(Console.ReadLine(), out int algorithmChoice) || algorithmChoice == 8)
            return;

        if (algorithmChoice < 1 || algorithmChoice > 7)
        {
            Console.WriteLine("Invalid option!");
            return;
        }

        Console.WriteLine("\nChoose sorting criteria:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Health");
        Console.WriteLine("3. Damage");
        Console.WriteLine("4. Level");
        Console.Write("Choose criteria: ");

        if (!int.TryParse(Console.ReadLine(), out int criteriaChoice))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

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

        Console.WriteLine($"\nResults saved to {outputPath}");
    }

    private static void ShowDataStructuresMenu(Enemy[] enemies)
    {
        // Initialize data structures
        var listaDinamica = new ListaDinamica();
        var arvore = new BinaryTree();
        var tabelaHash = new HashTable();

        foreach (var enemy in enemies)
        {
            listaDinamica.Inserir(enemy);
            arvore.Insert(enemy);
            tabelaHash.Add(enemy);
        }

        while (true)
        {
            Console.WriteLine("\nData Structures Menu (Part V):");
            Console.WriteLine("1. Sequential Search in Dynamic List");
            Console.WriteLine("2. Binary Search in Dynamic List");
            Console.WriteLine("3. Binary Tree Search");
            Console.WriteLine("4. Hash Table Search");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            if (choice == 5) break;

            Console.Write("\nEnter enemy name to search: ");
            string searchName = Console.ReadLine() ?? string.Empty;

            bool found = false;
            string structureName = "";

            switch (choice)
            {
                case 1:
                    found = SequentialSearch.Search(listaDinamica, searchName);
                    structureName = "Dynamic List (Sequential)";
                    break;
                case 2:
                    found = BinarySearch.Search(listaDinamica, searchName);
                    structureName = "Dynamic List (Binary)";
                    break;
                case 3:
                    found = arvore.Search(searchName);
                    structureName = "Binary Tree";
                    break;
                case 4:
                    found = tabelaHash.Contains(searchName);
                    structureName = "Hash Table";
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    continue;
            }

            Console.WriteLine(found 
                ? $"\nEnemy '{searchName}' FOUND in {structureName}!"
                : $"\nEnemy '{searchName}' NOT FOUND in {structureName}.");
        }
    }
}