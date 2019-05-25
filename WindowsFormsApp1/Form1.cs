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
        public void CreateCatalog(uint NumOfGoods, string Name)
        {
            Catalog obj = new Catalog
            {
                NumOfGoods = NumOfGoods,
                Name = Name
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }
        public void CreateHotGoods(uint numOfItemsDisplayed, string name, uint minAmountOfDiscount, uint days, uint hours, uint minutes, uint seconds)
        {
            HotGoods obj = new HotGoods
            {
                NumOfItemsDisplayed = numOfItemsDisplayed,
                Name = name,
                MinAmountOfDiscount = minAmountOfDiscount,
                promotionTime = new PromotionTime()
                {
                    Days = days,
                    Hours = hours,
                    Minutes = minutes,
                    Seconds = seconds
                },
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }

        public void CreateComputerFilter(uint numOfItemsDisplayed, string name, uint minVideoMemory, bool opticalDriveAvailability, uint minDiskRotationSpeed)
        {
            ComputerFilter obj = new ComputerFilter
            {
                NumOfItemsDisplayed = numOfItemsDisplayed,
                Name = name,
                MinVideoMemory = minVideoMemory,
                OpticalDriveAvailability = opticalDriveAvailability,
                MinDiskRotationSpeed = minDiskRotationSpeed

            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }

        public void CreateTelephoneFilter(uint numOfItemsDisplayed, string name, uint minNumOfSIMCards, uint minNumOfCameras, bool miniJackAvailability)
        {
            TelephoneFilter obj = new TelephoneFilter
            {
                NumOfItemsDisplayed = numOfItemsDisplayed,
                Name = name,
                MinNumOfSIMCards = minNumOfSIMCards,
                MinNumOfCameras = minNumOfCameras,
                MiniJackAvailability = miniJackAvailability
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }

        public void CreateRefrigeratorFilter(uint numOfItemsDisplayed, string name, bool smart, bool bulky, bool builtInAvailability, uint minNumOfFunctions,
            uint minNumOfBoxes, uint minNumOfShelves, uint minNumOfCompressors)
        {
            RefrigeratorFilter obj = new RefrigeratorFilter
            {
                NumOfItemsDisplayed = numOfItemsDisplayed,
                Name = name,
                Smart = smart,
                Bulky = bulky,
                BuiltInAvailability = builtInAvailability,
                MinNumOfFunctions = minNumOfFunctions,
                MinNumOfBoxes = minNumOfBoxes,
                MinNumOfShelves = minNumOfShelves,
                MinNumOfCompressors = minNumOfCompressors
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }

        public void CreateWashingFilter(uint numOfItemsDisplayed, string name, bool smart, bool bulky, bool builtInAvailability, uint minNumOfFunctions,
            uint minSpinSpeed, bool steamTreatmentAvailability, uint minNumOfPrograms)
        {
            WashingFilter obj = new WashingFilter
            {
                NumOfItemsDisplayed = numOfItemsDisplayed,
                Name = name,
                Smart = smart,
                Bulky = bulky,
                BuiltInAvailability = builtInAvailability,
                MinNumOfFunctions = minNumOfFunctions,
                MinSpinSpeed = minSpinSpeed,
                SteamTreatmentAvailability = steamTreatmentAvailability,
                MinNumOfPrograms = minNumOfPrograms
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }

        public void CreateOvenFilter(uint numOfItemsDisplayed, string name, bool smart, bool bulky, bool builtInAvailability, uint minNumOfFunctions,
            bool grillAvailability)
        {
            OvenFilter obj = new OvenFilter
            {
                NumOfItemsDisplayed = numOfItemsDisplayed,
                Name = name,
                Smart = smart,
                Bulky = bulky,
                BuiltInAvailability = builtInAvailability,
                MinNumOfFunctions = minNumOfFunctions,
                GrillAvailability = grillAvailability
            };
            CommonList.CallObjectCreatedEvent(CommonList.Objects, obj);
        }



        public void CreateSomeObjects(ApplicationDataContext CommonList)
        {
            CreateCatalog(487059, "Catalog 1");
            CreateCatalog(609271, "Catalog 2");
            CreateCatalog(376948, "Catalog 3");

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
            IFactory factory = (IFactory)ComboBoxCreate.SelectedItem;
            Object obj = factory.CreateObject();
            obj.Update(CommonList, true);
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
