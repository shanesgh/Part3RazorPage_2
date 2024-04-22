using System.ComponentModel.DataAnnotations;

namespace TelerikAspNetCoreApp1.Data;

public class OrderViewModel
{
    public int OrderID
    {
        get;
        set;
    }

    [Required]
    public decimal? Freight
    {
        get;
        set;
    }
    [Required]
    public DateTime? OrderDate
    {
        get;
        set;
    }
    [Required]
    public string ShipCity
    {
        get;
        set;
    }
    [Required]
    [MinLength(5, ErrorMessage = "Ship Name must be at least 5 characters long")]
    public string ShipName
    {
        get;
        set;
    }
}