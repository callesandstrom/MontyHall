namespace MontyHall;

record Door(int Index, string Prize);

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Run();
        }
    }

    private static void Run()
    {
        Console.Write("Byta dörr? Ja (1), Nej (Övrigt): ");
        var shouldSwitch = Console.ReadKey().KeyChar == '1';
        Console.Clear();
        Console.WriteLine($"Byta dörr? {(shouldSwitch ? "Ja" : "Nej")}");

        var winningCount = 0;

        for (int i = 0; i < 100; i++)
        {
            var carDoorIndex = Random.Shared.Next(3);
            var doors = Enumerable.Range(0, 3).Select(index => new Door(index, index == carDoorIndex ? "Car" : "Goat")).ToList();
            var doorPickedIndex = Random.Shared.Next(3);
            var doorOpened = doors.OrderBy(_ => Random.Shared.Next()).First(x => x.Prize != "Car" && x.Index != doorPickedIndex);

            var finalDoor = shouldSwitch
                ? doors.Single(x => x.Index != doorPickedIndex && x.Index != doorOpened.Index)
                : doors.ElementAt(doorPickedIndex);

            winningCount += finalDoor.Prize == "Car" ? 1 : 0;
        }

        Console.WriteLine($"\nVinster: {winningCount}/100\n");
    }
}
