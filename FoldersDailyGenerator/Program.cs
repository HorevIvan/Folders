Console.WriteLine("This program generate empty folders for each days");

Console.WriteLine("Horev Ivan 2023");

Console.WriteLine("Enter start date or press Enter for use current date");

var strIn = Console.ReadLine();

var date1 = string.IsNullOrEmpty(strIn) ? DateTime.Now.Date : DateTime.Parse(strIn);

Console.WriteLine("Enter finish date or press Enter for generate to end of current year");

strIn = Console.ReadLine();

var date2 = string.IsNullOrEmpty(strIn) ? new DateTime(DateTime.Now.Year + 1, 1, 1) : DateTime.Parse(strIn);

Console.WriteLine("Enter destination directory or Enter for use current directory");

strIn = Console.ReadLine();

var root = string.IsNullOrEmpty(strIn) ? Environment.CurrentDirectory : strIn;

Console.WriteLine("Enter directory name format or Enter for use default");

strIn = Console.ReadLine();

var format = string.IsNullOrEmpty(strIn) ? "yyyy-MM-dd-ddd" : strIn;

for (var date = date1; date < date2; date += TimeSpan.FromDays(1))
{
    Directory.CreateDirectory(Path.Combine(root, date.Year.ToString(), date.ToString(format)));
}