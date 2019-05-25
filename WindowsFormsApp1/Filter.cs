namespace OOP_2
{
    [InterconnectionTypeAttribute("Агрегация")]
    public class Filter : Object
    {
        [LabelAttribute("Количество отображаемых товаров")]
        public uint NumOfItemsDisplayed { get; set; }

        public override void ObjectDeleted(ApplicationDataContext CommonList)
        {
            for (int i = 0; i < CommonList.Objects.Count; i++)
            {
                Object obj = CommonList.Objects[i];
                if (obj is Catalog && ((Catalog)obj).Filter == this)
                {
                    ((Catalog)obj).Filter = null;
                }
            }
        }

        [LabelAttribute("Имя фильтра")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


    [InterconnectionTypeAttribute("Композиция")]
    public class PromotionTime : Object
    {
        [LabelAttribute("Дни")]
        public uint Days { get; set; }

        [LabelAttribute("Часы")]
        public uint Hours { get; set; }

        [LabelAttribute("Минуты")]
        public uint Minutes { get; set; }

        [LabelAttribute("Секунды")]
        public uint Seconds { get; set; }
    }

    public class HotGoods : Filter
    {
        [LabelAttribute("Минимальная размер скидки")]
        public uint MinAmountOfDiscount { get; set; }

        [LabelAttribute("Время действия скидки")]
        public PromotionTime promotionTime { get; set; }
    }

    public class ElectronicsFilter : Filter
    {
        [LabelAttribute("Портативность")]
        public bool Portability { get; set; }

        [LabelAttribute("Наличие дисплея")]
        public bool DisplayAvailability { get; set; }
    }



    public class ComputerFilter : ElectronicsFilter
    {
        [LabelAttribute("Минимальный размер видеопамяти")]
        public uint MinVideoMemory { get; set; }

        [LabelAttribute("Наличие оптического привода")]
        public bool OpticalDriveAvailability { get; set; }

        [LabelAttribute("Минимальная скорость вращения диска")]
        public uint MinDiskRotationSpeed { get; set; }
    }

    public class TelephoneFilter : ElectronicsFilter
    {
        [LabelAttribute("Минимальное количество SIM-карт")]
        public uint MinNumOfSIMCards { get; set; }

        [LabelAttribute("Минимальное количество камер")]
        public uint MinNumOfCameras { get; set; }

        [LabelAttribute("Наличие mini-jack")]
        public bool MiniJackAvailability { get; set; }
    }

    public class HomeApplianceFilter : ElectronicsFilter
    {
        [LabelAttribute("Smart")]
        public bool Smart { get; set; }

        [LabelAttribute("Громоздкость")]
        public bool Bulky { get; set; }

        [LabelAttribute("Встроенность")]
        public bool BuiltInAvailability { get; set; }

        [LabelAttribute("Минимальное количество функций")]
        public uint MinNumOfFunctions { get; set; }
    }



    public class RefrigeratorFilter : HomeApplianceFilter
    {
        [LabelAttribute("Минимальное количество ящиков")]
        public uint MinNumOfBoxes { get; set; }

        [LabelAttribute("Минимальное количество полок")]
        public uint MinNumOfShelves { get; set; }

        [LabelAttribute("Минимальное количество компрессоров")]
        public uint MinNumOfCompressors { get; set; }
    }

    public class WashingFilter : HomeApplianceFilter
    {
        [LabelAttribute("Минимальная скорость вращения")]
        public uint MinSpinSpeed { get; set; }

        [LabelAttribute("Обработка паром")]
        public bool SteamTreatmentAvailability { get; set; }

        [LabelAttribute("Минимальное количество программ")]
        public uint MinNumOfPrograms { get; set; }
    }

    
    public class OvenFilter : HomeApplianceFilter
    {
        [LabelAttribute("Наличие гриля")]
        public bool GrillAvailability { get; set; }
    }
}