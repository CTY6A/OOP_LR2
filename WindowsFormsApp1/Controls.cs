using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_2
{
    public static class Controls
    {        
        public static Form AddForm(Object CurrentObject, int ControlWidth, int ControlHeight)
        {
            return new Form
            {
                ClientSize = new Size(ControlWidth * 2, CurrentObject.GetType().GetProperties().Count() * ControlHeight * 2  + ControlHeight)
            };
        }
        public static void AddLabel(Form CurrentForm, int Top, int Left, int ControlWidth, int ControlHeight, string Text)
        {
            CurrentForm.Controls.Add(new Label { Top = Top, Left = Left, Width = ControlWidth, Height = ControlHeight, Text = Text });
        }
        public static void AddTextBox(Form CurrentForm, int Top, int Left, int ControlWidth, int ControlHeight, string Text)
        {
            CurrentForm.Controls.Add(new TextBox { Top = Top, Left = Left, Width = ControlWidth, Height = ControlHeight, Text = Text });
        }
        public static void AddCheckBox(Form CurrentForm, int Top, int Left, int ControlWidth, int ControlHeight, bool Availability)
        {
            CurrentForm.Controls.Add(new CheckBox { Top = Top, Left = Left, Width = ControlWidth, Height = ControlHeight, Checked = Availability });
        }
        public static void AddComboBox(Form CurrentForm, int Top, int Left, int ControlWidth, int ControlHeight, object[] Elements, string Text)
        {
            ComboBox ComboBox = new ComboBox { Top = Top, Left = Left, Width = ControlWidth, Height = ControlHeight, Text = Text, DropDownStyle = ComboBoxStyle.DropDownList};
            ComboBox.Items.AddRange(Elements);
            CurrentForm.Controls.Add(ComboBox);
        }
        public static void AddComboBox(Form CurrentForm, int Top, int Left, int ControlWidth, int ControlHeight, object[] Elements, object SelectedItem)
        {
            ComboBox ComboBox = new ComboBox { Top = Top, Left = Left, Width = ControlWidth, Height = ControlHeight, DropDownStyle = ComboBoxStyle.DropDownList};
            ComboBox.Items.AddRange(Elements);
            ComboBox.SelectedItem = SelectedItem;
            CurrentForm.Controls.Add(ComboBox);
        }
        public static Button AddButton(Form CurrentForm, int Top, int Left, int ControlWidth, int ControlHeight, string Text)
        {
            Button Button = new Button { Top = Top, Left = Left, Width = ControlWidth, Height = ControlHeight, Text = Text };
            CurrentForm.Controls.Add(Button);
            return Button;
        }
    }
}