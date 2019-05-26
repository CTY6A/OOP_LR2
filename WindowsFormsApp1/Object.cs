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
        private readonly int ControlHeight = 30;
        private readonly int ControlWidth = 150;
        private bool CompareTypes(Type InheritedType, Type BaseType)
        {
            while (InheritedType != BaseType && InheritedType != null)
            {
                InheritedType = InheritedType.BaseType;
            }
            if (InheritedType == BaseType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GetProperties(Form CurrentForm, Object CurrentObject, ref int TopIndent, ApplicationDataContext CommonList)
        {
            foreach (PropertyInfo CurrentProperty in CurrentObject.GetType().GetProperties())
            {
                LabelAttribute CurrentAttribute = CurrentProperty.GetCustomAttributes(true).OfType<LabelAttribute>().First();
                Controls.AddLabel(CurrentForm, TopIndent, 0, ControlWidth, ControlHeight, CurrentAttribute.LabelText);
                if (CurrentProperty.PropertyType == typeof(uint) || CurrentProperty.PropertyType == typeof(string))
                {
                    Controls.AddTextBox(CurrentForm, TopIndent, ControlWidth, ControlWidth, ControlHeight, CurrentProperty.GetValue(CurrentObject)?.ToString());
                }
                else if (CurrentProperty.PropertyType == typeof(bool))
                {
                    Controls.AddCheckBox(CurrentForm, TopIndent, ControlWidth, ControlWidth, ControlHeight, (bool)CurrentProperty.GetValue(CurrentObject));
                }
                else if (CurrentProperty.PropertyType.GetCustomAttributes(true).OfType<InterconnectionTypeAttribute>().First().InterconnectionType == "Композиция")
                {
                    Button CreateObjectButton = Controls.AddButton(CurrentForm, TopIndent, ControlWidth, ControlWidth, ControlHeight, "Посмотреть объект");
                    CreateObjectButton.Click += (sender, e) =>
                    {
                        Object NewObj = (Object)CurrentProperty.GetValue(CurrentObject);
                        NewObj.Update(CommonList, false);
                    };
                }
                else if (CurrentProperty.PropertyType.GetCustomAttributes(true).OfType<InterconnectionTypeAttribute>().First().InterconnectionType == "Агрегация")
                {
                    List<Object> CheckBoxList = new List<Object>();
                    foreach (Object Element in CommonList.Objects)
                    {
                        if (CompareTypes(Element.GetType(), CurrentProperty.PropertyType))
                        {
                            CheckBoxList.Add(Element);
                        }
                    }
                    Controls.AddComboBox(CurrentForm, TopIndent, ControlWidth, ControlWidth, ControlHeight, CheckBoxList.Cast<object>().ToArray(), CurrentProperty.GetValue(this));
                }
                TopIndent += ControlHeight * 2;
            }
        }
        public void Update(ApplicationDataContext CommonList, bool NeedToCreate)
        {           
            Form CurrentForm = Controls.AddForm(this, ControlWidth, ControlHeight);
            int TopIndent = 0;
            GetProperties(CurrentForm, this, ref TopIndent, CommonList);
            Button SaveButton = Controls.AddButton(CurrentForm, TopIndent, 0, ControlWidth, ControlHeight, "Сохранить");
            SaveButton.Click += (sender, e) =>
            {
                int i = 1;
                foreach (PropertyInfo CurrentProperty in GetType().GetProperties())
                {
                    if (CurrentProperty.PropertyType == typeof(uint) || CurrentProperty.PropertyType == typeof(string))
                    {
                        CurrentProperty.SetValue(this, Convert.ChangeType(CurrentForm.Controls[i].Text, CurrentProperty.PropertyType));                        
                    }
                    else if (CurrentProperty.PropertyType == typeof(bool))
                    {
                        CurrentProperty.SetValue(this, ((CheckBox)CurrentForm.Controls[i]).Checked); 
                    }
                    else if (CurrentProperty.PropertyType.GetCustomAttributes(true).OfType<InterconnectionTypeAttribute>().First().InterconnectionType == "Агрегация")
                    {
                        ComboBox ComboBox = (ComboBox)CurrentForm.Controls[i];
                        if (ComboBox.SelectedItem != null)
                        {
                            CurrentProperty.SetValue(this, ComboBox.SelectedItem);
                        }
                    }
                    i += 2;
                }    
                if (NeedToCreate)
                {
                    CommonList.CallObjectCreatedEvent(CommonList.Objects, this);
                }
                CommonList.ComboBoxObjectsRefresh();
                CurrentForm.Close();
            };
            Button CancelButton = Controls.AddButton(CurrentForm, TopIndent, ControlWidth, ControlWidth, ControlHeight, "Отмена");
            CancelButton.Click += (sender, e) =>
            {
                CurrentForm.Close();
            };
            CurrentForm.Show();
        }
    }   
}