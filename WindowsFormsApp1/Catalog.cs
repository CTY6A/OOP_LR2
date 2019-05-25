namespace OOP_2
{
    [InterconnectionTypeAttribute("Агрегация")]
    public class Catalog : Object
    {
        [LabelAttribute("Количество товаров")]
        public uint NumOfGoods { get; set; }

        [LabelAttribute("Фильтр")]
        public Filter Filter { get; set; }

        [LabelAttribute("Имя каталога")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}