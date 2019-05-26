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
        public void AddObjectToList(List<Object> Objects, Object CurrentObject)
        {
            Objects.Add(CurrentObject);
        }
        public void AddObjectToComboBox(List<Object> Objects, Object CurrentObject)
        {
            ComboBoxObjects.Items.Add(CurrentObject);
        }
        public void DeleteObjectFromList(List<Object> Objects, Object CurrentObject)
        {
            Objects.Remove(CurrentObject);
        }
        public void DeleteObjectFromComboBox(List<Object> Objects, Object CurrentObject)
        {
            ComboBoxObjects.Items.Remove(CurrentObject);
            ComboBoxObjects.Text = "";
        }
        public delegate void ObjectCreatedDelegate(List<Object> Objects, Object CurrentObject);
        public event ObjectCreatedDelegate ObjectCreatedEvent;
        public void CallObjectCreatedEvent(List<Object> Objects, Object CurrentObject)
        {
            ObjectCreatedEvent(Objects, CurrentObject);
        }
        public delegate void ObjectDeletedDelegate(List<Object> Objects, Object CurrentObject);
        public event ObjectDeletedDelegate ObjectDeletedEvent;
        public void CallObjectDeletedEvent(List<Object> Objects, Object CurrentObject)
        {
            ObjectDeletedEvent(Objects, CurrentObject);
        }
    }
}