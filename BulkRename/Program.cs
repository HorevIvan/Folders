Console.WriteLine("This program rename folders and files");

Console.WriteLine("(C) Horev Ivan 2023 (horevivan@yandex.ru)");

Console.WriteLine("Enter directory or Enter for use current directory");

var dir = Console.ReadLine();

if (string.IsNullOrWhiteSpace(dir)) dir = Environment.CurrentDirectory;

var files = Directory.GetFiles(dir).Select(p => new FileInfo(p)).ToArray();

var folders = Directory.GetDirectories(dir).Select(p => new DirectoryInfo(p)).ToArray();

Console.WriteLine($"Folders: {folders.Length}");

Console.WriteLine($"Files: {files.Length}");

Console.WriteLine("Enter mode:");

Console.WriteLine("P - add prefix");

var mode = Console.ReadLine();

switch(mode)
{
    case "P":

        AddPrefix(dir, files, folders);

        return;

    default:

        Console.WriteLine("Unknown mode");

        return;
}

void AddPrefix(string dir, FileInfo[] files, DirectoryInfo[] folders)
{
    Console.WriteLine("Enter prefix: ");

    var prefix = Console.ReadLine();

    foreach (var folder in folders)
    {
        RenameFolder(folder, $"{prefix}{folder.Name}");
    }

    foreach (var file in files)
    {
        RenameFile(file, $"{prefix}{file.Name}");
    }
}

void RenameFile(FileInfo file, string newName)
{
    try
    {
        Console.WriteLine(file);

        var path = Path.Combine(file.Directory.FullName, newName);

        file.MoveTo(path);
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception);
    }
}

void RenameFolder(DirectoryInfo folder, string newName)
{
    try
    {
        Console.WriteLine(folder);

        var path = Path.Combine(folder.Parent.FullName, newName);

        folder.MoveTo(path);
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception);
    }
}