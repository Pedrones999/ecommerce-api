namespace Products.Model;


public class Product
{
    private readonly Guid _uuid = Guid.NewGuid();

    public Guid ProductId
    {
        get{return _uuid;}
        set
        {
            throw new ArgumentException("uuid cannot be changed");
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



}