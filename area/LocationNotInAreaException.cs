public class LocationNotInAreaException : System.Exception {
    public int point;
    public LocationNotInAreaException() : base() {}
    public LocationNotInAreaException(string message) : base(message) {}
    public LocationNotInAreaException(string message, System.Exception inner) : base(message, inner) {}
    public LocationNotInAreaException(string message, int point) : base(message) {
        this.point = point;
    }
}