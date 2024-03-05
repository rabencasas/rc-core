using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace RC.Core.Controllers
{
    public class FormManagement
    {
        public void ItemReselect(ListView L, int Index)
        {
            L.Items[Index].Selected = true;
            L.Items[Index].Focused = true;
            L.Focus();
        }

        public string GetSubItem(ListView L, int Index)
        {
            if (L.SelectedItems.Count != 0)
            {
                return L.SelectedItems[0].SubItems[Index].Text;
            }

            return "";
        }

        public void Clear(Control[] Controls)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox || item is RichTextBox)
                {
                    item.Text = String.Empty;
                }
                else if (item is ComboBox)
                {
                    ComboBox x = (ComboBox)item;

                    x.SelectedItem = null;
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown x = (NumericUpDown)item;

                    x.Value = x.Minimum;
                }
            }
        }

        public void Disable(Control[] Controls)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox || item is RichTextBox)
                {
                    item.Enabled = false;
                }
                else if (item is ComboBox)
                {
                    ComboBox x = (ComboBox)item;

                    x.Enabled = false;
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown x = (NumericUpDown)item;

                    x.Enabled = false;
                }
            }
        }

        public void Enable(Control[] Controls)
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox || item is RichTextBox)
                {
                    item.Enabled = true;
                }
                else if (item is ComboBox)
                {
                    ComboBox x = (ComboBox)item;

                    x.Enabled = true;
                }
                else if (item is NumericUpDown)
                {
                    NumericUpDown x = (NumericUpDown)item;

                    x.Enabled = true;
                }
            }
        }

        public void ToggleReadOnly(Control[] Controls, bool isreadonly = true)
        {
            foreach (Control item in Controls)
            {
                if (isreadonly)
                {
                    if (item is TextBox)
                    {
                        TextBox x = (TextBox)item;

                        x.ReadOnly = true;
                    }
                    else if (item is RichTextBox)
                    {
                        RichTextBox x = (RichTextBox)item;

                        x.ReadOnly = true;
                    }
                    else if (item is NumericUpDown)
                    {
                        NumericUpDown x = (NumericUpDown)item;

                        x.ReadOnly = true;
                    }
                }
                else
                {
                    if (item is TextBox)
                    {
                        TextBox x = (TextBox)item;

                        x.ReadOnly = false;
                    }
                    else if (item is RichTextBox)
                    {
                        RichTextBox x = (RichTextBox)item;

                        x.ReadOnly = false;
                    }
                    else if (item is NumericUpDown)
                    {
                        NumericUpDown x = (NumericUpDown)item;

                        x.ReadOnly = false;
                    }
                }
            }
        }

        public bool Validate(Control[] Controls)
        {
            int ctr = 0;

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text != "" || c.Text != string.Empty)
                    {
                        ctr++;
                    }
                }
                else if (c is ComboBox)
                {
                    ComboBox x = (ComboBox)c;

                    if (x.SelectedItem != null || x.Text != "" || x.Text != string.Empty)
                    {
                        ctr++;
                    }
                }
                else if (c is RichTextBox)
                {
                    RichTextBox x = (RichTextBox)c;

                    if (x.Text != "" || x.Text != string.Empty)
                    {
                        ctr++;
                    }
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker x = (DateTimePicker)c;

                    if (x.Value.Year != 1001 || x.Value != null)
                    {
                        ctr++;
                    }
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown x = (NumericUpDown)c;

                    if (x.Value != 0 || x.Value != null)
                    {
                        ctr++;
                    }
                }
            }

            if (ctr == Controls.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int ValidateGetCount(Control[] Controls)
        {
            int ctr = 0;

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if (c.Text != "" || c.Text != string.Empty)
                    {
                        ctr++;
                    }
                }
                else if (c is ComboBox)
                {
                    ComboBox x = (ComboBox)c;

                    if (x.SelectedItem != null || x.Text != "" || x.Text != string.Empty)
                    {
                        ctr++;
                    }
                }
                else if (c is RichTextBox)
                {
                    RichTextBox x = (RichTextBox)c;

                    if (x.Text != "" || x.Text != string.Empty)
                    {
                        ctr++;
                    }
                }
                else if (c is DateTimePicker)
                {
                    DateTimePicker x = (DateTimePicker)c;

                    if (x.Value.Year != 1001 || x.Value != null)
                    {
                        ctr++;
                    }
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown x = (NumericUpDown)c;

                    if (x.Value != 0 || x.Value != null)
                    {
                        ctr++;
                    }
                }
            }

            if (ctr == Controls.Length)
            {
                return ctr;
            }
            else
            {
                return ctr;
            }
        }
    }
}
