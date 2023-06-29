Console.WriteLine("This program move each folders from directory to subdirectories another folders");

Console.WriteLine("(C) Horev Ivan 2023 (horevivan@yandex.ru)");

//

Console.WriteLine("Enter source directory or Enter for use current directory");

var strIn = Console.ReadLine();

var source = string.IsNullOrEmpty(strIn) ? Environment.CurrentDirectory : strIn;

Console.WriteLine($"Found directories: {Directory.GetDirectories(source).Length}");

//

Console.WriteLine("Enter destination directory or Enter for use current directory");

strIn = Console.ReadLine();

var destination = string.IsNullOrEmpty(strIn) ? Environment.CurrentDirectory : strIn;

Console.WriteLine($"Found directories: {Directory.GetDirectories(destination).Length}");

//

if(source == destination) throw new Exception("Source and destination direactories are equal");

//

Console.WriteLine("Enter max subitems in each destination folder or Enter for unlimited subitems");

strIn = Console.ReadLine();

var maxSubitems = string.IsNullOrEmpty(strIn) ? ushort.MaxValue : ushort.Parse(strIn);

//

Console.WriteLine("Enter incrementation step or Enter for use 1");

strIn = Console.ReadLine();

var step = string.IsNullOrEmpty(strIn) ? ushort.MaxValue : ushort.Parse(strIn);

//

var i = 0;

var destinationDirectories = Directory.GetDirectories(destination);

foreach (var sourceSubDirectory in Directory.GetDirectories(source))
{
    Console.WriteLine();

    if (destinationDirectories.Length <= i)
    {
        Console.WriteLine("End of destination directories");

        break;
    }

    Console.WriteLine($"Source: {sourceSubDirectory}");

    var destinationDirectory = destinationDirectories[i];

    Console.WriteLine($"Destination: {destinationDirectory}");

    var destinationSubdirectory = Path.Combine(destinationDirectory, new DirectoryInfo(sourceSubDirectory).Name);

    Console.WriteLine($"Destination: {destinationSubdirectory}");

    var destinationDirectoriesCount = Directory.GetDirectories(destinationDirectory, "*", SearchOption.TopDirectoryOnly).Length;

    Console.WriteLine($"Directories: {destinationDirectoriesCount}");

    var destinationFilesCount = Directory.GetFiles(destinationDirectory).Length;

    Console.WriteLine($"Files: {destinationFilesCount}");

    var itemsCount = destinationDirectoriesCount + destinationFilesCount;

    if (itemsCount >= maxSubitems)
    {
        Console.WriteLine($"SKIP {destinationDirectory} ({itemsCount} of {maxSubitems})");

        i++;

        continue;
    }

    Directory.Move(sourceSubDirectory, destinationSubdirectory);

    i += step;

    Console.WriteLine(i);
}