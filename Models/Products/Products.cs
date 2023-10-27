using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Model;

[Table("Products")]
public class Product
{
    private  Guid _productId = Guid.NewGuid();
    public Guid ProductId
    {
        get{return _productId;}
        private set{_productId = value;}
    }

    private string _name = "";
    public string? Name
    {
        get{return _name;}

        set
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("name");
            }

            if(value.Length <= 2)
            {
                throw new Exception("the name has to have at least 3 characters");
            } 

            else{ _name = value; }
        }
    }

    private double _price;
    public double? Price
    {
        get{return _price;}
        
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("the price have to be bigger than 0");
            }

            if (value == null)
            {
                throw new ArgumentNullException("price");
            }

            else{_price = value.Value;}

        }
    }

    public string? Description {get; set;}

    public string? Image {get; set;}

    public Product(string? name, double? price, string? description = null, string? image = null)
    {
        Name = name;
        Price = price;
        if(! String.IsNullOrEmpty(description))
        {
            Description = description;
        }

        if(! String.IsNullOrEmpty(image))
        {
            Image = image;
        }
    }

}