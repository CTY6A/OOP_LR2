namespace OOP_2
{
    public interface IFactory
    {
        Object CreateObject();
    }


    public class CatalogFactory : IFactory
    {
        public string Name { get; set; }

        public CatalogFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            return new Catalog();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class HotGoodsFactory : IFactory
    {
        public string Name { get; set; }

        public HotGoodsFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            HotGoods hotGoods = new HotGoods
            {
                promotionTime = new PromotionTime()
            };

            return hotGoods;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ComputerFilterFactory : IFactory
    {
        public string Name { get; set; }

        public ComputerFilterFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            return new ComputerFilter();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class TelephoneFilterFactory : IFactory
    {
        public string Name { get; set; }

        public TelephoneFilterFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            return new TelephoneFilter();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class RefrigeratorFilterFactory : IFactory
    {
        public string Name { get; set; }

        public RefrigeratorFilterFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            return new RefrigeratorFilter();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class WashingFilterFactory : IFactory
    {
        public string Name { get; set; }

        public WashingFilterFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            return new WashingFilter();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class OvenFilterFactory : IFactory
    {
        public string Name { get; set; }

        public OvenFilterFactory(string name)
        {
            Name = name;
        }

        public Object CreateObject()
        {
            return new OvenFilter();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}