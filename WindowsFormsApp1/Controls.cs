using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_2
{
    public static class Controls
    {        
        public static Form AddForm(Object obj, int controlWidth, int controlHeight)
        {
            Form form = new Form
            {
                ClientSize = new Size(controlWidth * 2, (obj.GetType().GetProperties().Count() * controlHeight * 2) +
                (obj.GetType().GetFields().Count() * controlHeight * 2) + (controlHeight * 2))
            };
            return form;
        }
        public static void AddLabel(Form form, int top, int left, int controlWidth, int controlHeight, string text)
        {
            Label label = new Label { Top = top, Left = left, Width = controlWidth, Height = controlHeight, Text = text };
            form.Controls.Add(label);
        }
        public static void AddTextBox(Form form, int top, int left, int controlWidth, int controlHeight, string text)
        {
            TextBox textBox = new TextBox { Top = top, Left = left, Width = controlWidth, Height = controlHeight, Text = text };
            form.Controls.Add(textBox);
        }
        public static void AddCheckBox(Form form, int top, int left, int controlWidth, int controlHeight, bool Availability)
        {
            CheckBox textBox = new CheckBox { Top = top, Left = left, Width = controlWidth, Height = controlHeight, Checked = Availability };
            form.Controls.Add(textBox);
        }
        public static void AddComboBox(Form form, int top, int left, int controlWidth, int controlHeight, object[] elements, string text)
        {
            ComboBox comboBox = new ComboBox { Top = top, Left = left, Width = controlWidth, Height = controlHeight, Text = text };
            comboBox.Items.AddRange(elements);
            form.Controls.Add(comboBox);
        }
        public static void AddComboBox(Form form, int top, int left, int controlWidth, int controlHeight, object[] elements, object selectedItem)
        {
            ComboBox comboBox = new ComboBox { Top = top, Left = left, Width = controlWidth, Height = controlHeight,
                SelectedItem = selectedItem, Text = selectedItem?.ToString() };
            comboBox.Items.AddRange(elements);
            form.Controls.Add(comboBox);
        }
        public static Button AddButton(Form form, int top, int left, int controlWidth, int controlHeight, string text)
        {
            Button button = new Button { Top = top, Left = left, Width = controlWidth, Height = controlHeight * 2, Text = text };
            form.Controls.Add(button);
            return button;
        }
    }
}