namespace NHodlHodl.Models;

public class HodlHodlException : Exception
{
    public HodlHodlError? Error { get; set; }
}