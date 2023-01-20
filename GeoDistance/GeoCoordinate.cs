namespace GeoDistance
{
    public record GeoCoordinate(double Latitude, double Longitude)
    {
        public override string ToString()
        {
            return $"{Math.Abs(Latitude):G4}{(Latitude >= 0 ? "N" : "S")} {Math.Abs(Longitude):G4}{(Longitude >= 0 ? "E" : "W")}";
        }

        public double DistanceTo(GeoCoordinate point)
        {
            return DistanceBetweenCoordinates(this, point);
        }

        private const int EarthRadiusKilometers = 6371;
        private const double Deg2Rad = MathF.PI / 180;

        public static double DistanceBetweenCoordinates(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
        {
            var deltaLat = (latitudeB - latitudeA) * Deg2Rad;
            var deltaLon = (longitudeB - longitudeA) * Deg2Rad;
            var a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                    Math.Cos(latitudeA * Deg2Rad) * Math.Cos(latitudeB * Deg2Rad) *
                    Math.Pow(Math.Sin(deltaLon / 2), 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return c * EarthRadiusKilometers;
        }

        public static double DistanceBetweenCoordinates(GeoCoordinate pointA, GeoCoordinate pointB)
        {
            return DistanceBetweenCoordinates(pointA.Latitude, pointA.Longitude, pointB.Latitude, pointB.Longitude);
        }
    }
}