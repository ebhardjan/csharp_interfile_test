class Utils {
    public string doesNotPropagateTaint(string x)
    {
        if(x) {
            return "foo";
        }
        return "bar";
    }

    public string propagateTaint(string x)
    {
        if(x) {
            return x;
        }
        return "bar";
    }
}