using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Model;

[Table("Products")]
public class Product
{
    private  Guid _productID;
    public Guid ProductId
    {
        get{return _productID;}
        private set
        {
            _productID = Guid.NewGuid();
        }
    }

    private string _name = "";
    public string Name
    {
        get{return _name;}

        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException();
            }

            if(value.Length <= 2)
            {
                throw new Exception("the name has to have at least 3 characters");
            } 

            else{ _name = value; }
        }
    }

    private decimal _price;
    public decimal Price
    {
        get{return _price;}
        
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("the price have to be bigger than 0");
            }

            else{_price = value;}

        }
    }

    public string? Description {get; set;}

    public Product(string name, decimal price, string? description = "")
    {
        Name = name;
        Price = price;
        if(! String.IsNullOrEmpty(description))
        {
            Description = description;
        }
    }

}