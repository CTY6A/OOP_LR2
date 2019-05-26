using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_2
{
    public partial class FormMain : Form
    {       
        public FormMain()
        {
            InitializeComponent();
        }
        public ApplicationDataContext CommonList;
        public void CreateCatalog(uint NumOfGoods, Filter Filter, string Name)
        {
            Catalog CurrentObject = new Catalog
            {
                NumOfGoods = NumOfGoods,
                Filter = Filter,
                Name = Name
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }
        public void CreateHotGoods(uint NumOfItemsDisplayedMemory, string Name, uint MinAmountOfDiscount, uint Days, uint Hours, uint Minutes, uint Seconds)
        {
            HotGoods CurrentObject = new HotGoods
            {
                NumOfItemsDisplayed = NumOfItemsDisplayedMemory,
                Name = Name,
                MinAmountOfDiscount = MinAmountOfDiscount,
                PromotionTime = new PromotionTime()
                {
                    Days = Days,
                    Hours = Hours,
                    Minutes = Minutes,
                    Seconds = Seconds
                },
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }

        public void CreateComputerFilter(uint NumOfItemsDisplayed, string Name, uint MinVideoMemory, bool opticalDriveAvailability, uint minDiskRotationSpeed)
        {
            ComputerFilter CurrentObject = new ComputerFilter
            {
                NumOfItemsDisplayed = NumOfItemsDisplayed,
                Name = Name,
                MinVideoMemory = MinVideoMemory,
                OpticalDriveAvailability = opticalDriveAvailability,
                MinDiskRotationSpeed = minDiskRotationSpeed

            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }

        public void CreateTelephoneFilter(uint NumOfItemsDisplayedMemory, string Name, uint MinNumOfSIMCards, uint MinNumOfCameras, bool MiniJackAvailability)
        {
            TelephoneFilter CurrentObject = new TelephoneFilter
            {
                NumOfItemsDisplayed = NumOfItemsDisplayedMemory,
                Name = Name,
                MinNumOfSIMCards = MinNumOfSIMCards,
                MinNumOfCameras = MinNumOfCameras,
                MiniJackAvailability = MiniJackAvailability
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }

        public void CreateRefrigeratorFilter(uint NumOfItemsDisplayedMemory, string Name, bool Smart, bool Bulky, bool BuiltInAvailability, uint MinNumOfFunctions,
            uint MinNumOfBoxes, uint MinNumOfShelves, uint MinNumOfCompressors)
        {
            RefrigeratorFilter CurrentObject = new RefrigeratorFilter
            {
                NumOfItemsDisplayed = NumOfItemsDisplayedMemory,
                Name = Name,
                Smart = Smart,
                Bulky = Bulky,
                BuiltInAvailability = BuiltInAvailability,
                MinNumOfFunctions = MinNumOfFunctions,
                MinNumOfBoxes = MinNumOfBoxes,
                MinNumOfShelves = MinNumOfShelves,
                MinNumOfCompressors = MinNumOfCompressors
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }

        public void CreateWashingFilter(uint NumOfItemsDisplayedMemory, string Name, bool Smart, bool Bulky, bool BuiltInAvailability, uint MinNumOfFunctions,
            uint MinSpinSpeed, bool SteamTreatmentAvailability, uint MinNumOfPrograms)
        {
            WashingFilter CurrentObject = new WashingFilter
            {
                NumOfItemsDisplayed = NumOfItemsDisplayedMemory,
                Name = Name,
                Smart = Smart,
                Bulky = Bulky,
                BuiltInAvailability = BuiltInAvailability,
                MinNumOfFunctions = MinNumOfFunctions,
                MinSpinSpeed = MinSpinSpeed,
                SteamTreatmentAvailability = SteamTreatmentAvailability,
                MinNumOfPrograms = MinNumOfPrograms
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }

        public void CreateOvenFilter(uint NumOfItemsDisplayedMemory, string Name, bool Smart, bool Bulky, bool BuiltInAvailability, uint MinNumOfFunctions,
            bool GrillAvailability)
        {
            OvenFilter CurrentObject = new OvenFilter
            {
                NumOfItemsDisplayed = NumOfItemsDisplayedMemory,
                Name = Name,
                Smart = Smart,
                Bulky = Bulky,
                BuiltInAvailability = BuiltInAvailability,
                MinNumOfFunctions = MinNumOfFunctions,
                GrillAvailability = GrillAvailability
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, CurrentObject);
        }



        public void CreateSomeObjects(ApplicationDataContext CommonList)
        {
            CreateHotGoods(50, "HotGoods 1", 50, 3, 0, 0, 0);
            CreateHotGoods(50, "HotGoods 2", 90, 0, 5, 0, 0);
            CreateHotGoods(50, "HotGoods 3", 30, 30, 0, 0, 0);

            CreateComputerFilter(50, "CompterFilter 1", 2, true, 3600);
            CreateComputerFilter(50, "CompterFilter 2", 4, false, 6800);

            CreateTelephoneFilter(100, "Telephone Filter 1", 2, 2, true);
            CreateTelephoneFilter(100, "Telephone Filter 2", 1, 4, false);

            CreateRefrigeratorFilter(20, "Refrigerator Filter 1", true, true, true, 10, 3, 4, 2);

            CreateWashingFilter(30, "Washing Filter 1", false, false, false, 2, 3000, false, 15);

            CreateOvenFilter(25, "Oven Filter 1", true, true, true, 2, true);

            CreateCatalog(487059, (Filter)CommonList.Objects[0], "Catalog 1");
            CreateCatalog(609271, (Filter)CommonList.Objects[1], "Catalog 2");
            CreateCatalog(376948, (Filter)CommonList.Objects[2], "Catalog 3");
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            CommonList = new ApplicationDataContext()
            {   
                Objects = new List<Object>(),
                ComboBoxObjects = ComboBoxObjects,
            };
            CommonList.ObjectCreatedEvent += CommonList.AddObjectToList;
            CommonList.ObjectCreatedEvent += CommonList.AddObjectToComboBox;
            CommonList.ObjectDeletedEvent += CommonList.DeleteObjectFromList;
            CommonList.ObjectDeletedEvent += CommonList.DeleteObjectFromComboBox;
            IFactory[] Arr = new IFactory[] {
                new CatalogFactory("Каталог"),
                new HotGoodsFactory("Фильтр \"Горячие\" товары"),
                new ComputerFilterFactory("Фильтр \"Компьютеры\""),
                new TelephoneFilterFactory("Фильтр \"Телефоны\""),
                new RefrigeratorFilterFactory("Фильтр \"Холодильники\""),
                new WashingFilterFactory("Фильтр \"Стрильные машины\""),
                new OvenFilterFactory("Фильтр \"Печи\""),
            };
            ComboBoxCreate.Items.AddRange(Arr);
            CreateSomeObjects(CommonList);
        }
        private void ComboBoxCreate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IFactory Factory = (IFactory)ComboBoxCreate.SelectedItem;
            Object CurrentObject = Factory.CreateObject();
            CurrentObject.Update(CommonList, true);
        }
        private void ButtonDeleteObject_Click(object sender, EventArgs e)
        {
            if ((Object)ComboBoxObjects.SelectedItem != null)
            {
                Object SelectedItem = (Object)ComboBoxObjects.SelectedItem;
                SelectedItem.ObjectDeleted(CommonList);
                CommonList.CallObjectDeletedEvent(CommonList.Objects, SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите объект");
            }
        }
        private void ButtonUpdateObject_Click(object sender, EventArgs e)
        {
            if ((Object)ComboBoxObjects.SelectedItem != null)
            {
                Object SelectedItem = (Object)ComboBoxObjects.SelectedItem;
                SelectedItem.Update(CommonList, false);
            }
            else
            {
                MessageBox.Show("Выберите объект");
            }
        }
    }
}
