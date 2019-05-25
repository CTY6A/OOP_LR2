using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace OOP_2
{
    public class LabelAttribute : Attribute
    {
        public string LabelText { get; set; }

        public LabelAttribute(string Text)
        {
            LabelText = Text;
        }
    }

    public class InterconnectionTypeAttribute : Attribute
    {
        public string InterconnectionType { get; set; }

        public InterconnectionTypeAttribute(string Type)
        {
            InterconnectionType = Type;
        }
    }


    public class Object
    {
        public virtual void ObjectDeleted(ApplicationDataContext CommonList)
        {
        }
        
        private readonly int ControlHeight = 15;
        private readonly int ControlWidth = 150;
        private void GetProperties(Form form, Object obj, ref int y, ApplicationDataContext CommonList)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                LabelAttribute attribute = property.GetCustomAttributes(true).OfType<LabelAttribute>().First();
                Controls.AddLabel(form, y, 0, ControlWidth, ControlHeight, attribute.LabelText);
                if (property.PropertyType.IsGenericType)
                {
                    IList list = (IList)property.GetValue(obj);
                    Controls.AddComboBox(form, y, ControlWidth, ControlWidth, ControlHeight, list.Cast<object>().ToArray(), "");
                }
                else if (property.PropertyType.IsEnum)
                {
                    Controls.AddComboBox(form, y, ControlWidth, ControlWidth, ControlHeight, property.PropertyType.GetEnumNames(), property.GetValue(obj).ToString());                   
                }
                else if (property.PropertyType == typeof(uint) || property.PropertyType == typeof(string))
                {
                    Controls.AddTextBox(form, y, ControlWidth, ControlWidth, ControlHeight, property.GetValue(obj)?.ToString());
                }
                else if (property.PropertyType == typeof(bool))
                {
                    Controls.AddCheckBox(form, y, ControlWidth, ControlWidth, ControlHeight, (bool)property.GetValue(obj));
                }
                else if (property.PropertyType.GetCustomAttributes(true).OfType<InterconnectionTypeAttribute>().First().InterconnectionType == "Композиция")
                {
                    Button createObjectButton = Controls.AddButton(form, y, ControlWidth, ControlWidth, ControlHeight, "Посмотреть объект");
                    createObjectButton.Click += (sender, e) =>
                    {
                        Object newObj = (Object)property.GetValue(obj);
                        newObj.Update(CommonList, false);
                    };
                }
                else if (property.PropertyType.GetCustomAttributes(true).OfType<InterconnectionTypeAttribute>().First().InterconnectionType == "Агрегация")
                {
                    List<Object> list = new List<Object>();
                    foreach (Object element in CommonList.Objects)
                    {
                        if ((element as Filter) != null)
                        {
                            list.Add(element);
                        }
                    }
                    Controls.AddComboBox(form, y, ControlWidth, ControlWidth, ControlHeight, list.Cast<object>().ToArray(), property.GetValue(this));
                }
                y += ControlHeight * 2;
            }
        }
        public void Update(ApplicationDataContext CommonList, bool NeedToCreate)
        {           
            Form form = Controls.AddForm(this, ControlWidth, ControlHeight);
            int y = 0;
            GetProperties(form, this, ref y, CommonList);
            Button saveButton = Controls.AddButton(form, y, 0, ControlWidth, ControlHeight, "Сохранить");
            saveButton.Click += (sender, e) =>
            {
                int i = 1;
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(this, Enum.Parse(property.PropertyType, form.Controls[i].Text));                       
                    }
                    else if (property.PropertyType == typeof(uint) || property.PropertyType == typeof(string))
                    {
                        property.SetValue(this, Convert.ChangeType(form.Controls[i].Text, property.PropertyType));                        
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        property.SetValue(this, Convert.ChangeType(((CheckBox)form.Controls[i]).Checked, property.PropertyType)); 
                    }
                    else if (!property.PropertyType.IsGenericType && property.PropertyType.GetCustomAttributes(true).OfType<InterconnectionTypeAttribute>().First().InterconnectionType == "Агрегация")
                    {
                        ComboBox comboBox = (ComboBox)form.Controls[i];
                        if (comboBox.SelectedItem != null)
                        {
                            if (property.GetValue(this) != null)
                            {
                                foreach (var el in property.PropertyType.GetProperties())
                                {
                                    if (el.PropertyType.IsGenericType)
                                    {
                                        IList list = (IList)el.GetValue(property.GetValue(this));
                                        list.Remove(this);
                                    }
                                }
                            }
                            property.SetValue(this, comboBox.SelectedItem);
                            foreach (var el in property.PropertyType.GetProperties())
                            {
                                if (el.PropertyType.IsGenericType)
                                {
                                    IList list = (IList)el.GetValue(comboBox.SelectedItem);
                                    list.Add(this);
                                }
                            }
                        }
                    }
                    i += 2;
                }    
                if (NeedToCreate)
                {
                    CommonList.CallObjectCreatedEvent(CommonList.Objects, this);
                }
                CommonList.ComboBoxObjectsRefresh();
                form.Close();
            };
            Button cancelButton = Controls.AddButton(form, y, ControlWidth, ControlWidth, ControlHeight, "Отмена");
            cancelButton.Click += (sender, e) =>
            {
                form.Close();
            };
            form.Show();
        }
    }   
}