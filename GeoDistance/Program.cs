using GeoDistance;

GeoCoordinate Parse(string str)
{
    var parts = str.Split(' ');
    var lat = double.Parse(parts[0].Substring(0, parts[0].Length - 1)) * (parts[0][parts[0].Length - 1] == 'N' ? 1 : -1);
    var lon = double.Parse(parts[1].Substring(0, parts[1].Length - 1)) * (parts[1][parts[1].Length - 1] == 'E' ? 1 : -1);
    return new GeoCoordinate(lat, lon);
}

Console.WriteLine("Enter coordinate A:");
var input = Console.ReadLine();
var coordA = Parse(input);
Console.WriteLine("Enter coordinate B:");
input = Console.ReadLine();
var coordB = Parse(input);

Console.WriteLine($"Distance from {coordA} to {coordB} is: {coordA.DistanceTo(coordB):G4}km");
