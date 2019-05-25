using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_2
{
    public class ApplicationDataContext
    {
        public List<Object> Objects;
        public ComboBox ComboBoxObjects;
        public void ComboBoxObjectsRefresh()
        {
            ComboBoxObjects.Items.Clear();
            ComboBoxObjects.Items.AddRange(Objects.ToArray());
        }
        public delegate void ObjectCreatedDelegate(List<Object> Objects, Object obj);
        public event ObjectCreatedDelegate ObjectCreatedEvent;
        public void CallObjectCreatedEvent(List<Object> Objects, Object obj)
        {          
            ObjectCreatedEvent(Objects, obj);
        }
        public void AddObjectToList(List<Object> Objects, Object obj)
        {
            Objects.Add(obj);
        }
        public void AddObjectToComboBox(List<Object> Objects, Object obj)
        {
            this.ComboBoxObjects.Items.Add(obj);
        }
        public delegate void ObjectDeletedDelegate(List<Object> Objects, Object obj);
        public event ObjectDeletedDelegate ObjectDeletedEvent;
        public void CallObjectDeletedEvent(List<Object> Objects, Object obj)
        {
            ObjectDeletedEvent(Objects, obj);
        }
        public void DeleteObjectFromList(List<Object> Objects, Object obj)
        {
            Objects.Remove(obj);
        }
        public void DeleteObjectFromComboBox(List<Object> Objects, Object obj)
        {
            ComboBoxObjects.Items.Remove(obj);
            ComboBoxObjects.Text = "";
        }
    }
}