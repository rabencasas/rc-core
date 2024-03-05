using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace RC.Core.Controllers
{
    public class ListViewController
    {
        public ListViewController()
        { }

        private ListView Lv;
        private ListViewItem li;

        public ListViewItem GetItem(int Index, ListView L)
        {
            return L.SelectedItems[Index];
        }

        public string GetItemAsString(int Index, ListView L)
        {
            return L.SelectedItems[Index].Text;
        }

        public void AddNew(ListView L, string Item)
        {
            Lv = L;
            li = Lv.Items.Add(Item);
        }

        public void AddSubItem(string Item)
        {
            li.SubItems.Add(Item);
        }

        public void Reselect(ListView L, int Index)
        {
            L.Items[Index].Selected = true;
            L.Items[Index].Focused = true;
            L.Focus();
            L.Items[Index].EnsureVisible();
        }

        public string SubItem(ListView L, int Index)
        {
            if (this.Selected(L))
            {
                return L.SelectedItems[0].SubItems[Index].Text;
            }

            return "";
        }

        public bool Selected(ListView L)
        {
            try
            {
                if (L.SelectedItems.Count != 0 && L.SelectedItems[0].Text != string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }

        public void BindValue(ListView L, Control C)
        {
            if (this.Selected(L))
            {
                C.Text = L.SelectedItems[0].Text;
            }
        }

        public void BindValue(ListView L, int SubitemIndex, Control C)
        {
            if (this.Selected(L))
            {
                C.Text = L.SelectedItems[0].SubItems[SubitemIndex].Text;
            }
        }

        public void DisplayRecods<T>(ref T record, List<T> records, ListView L, bool include_counter = false)
        {
            L.Items.Clear();
            PropertyInfo[] properties = record.GetType().GetProperties();
            var columnnames = L.Columns.Cast<ColumnHeader>().Select(x => x.Text).ToList();

            if (include_counter)
            {
                int counter = 1;

                foreach (T item in records)
                {
                    var propertyInfo = record.GetType().GetProperty(columnnames.First());
                    string item_id = propertyInfo.GetValue(item, null).ToString();

                    ListViewItem li = L.Items.Add(item_id);
                    li.SubItems.Add(counter.ToString());

                    foreach (string item2 in columnnames)
                    {
                        propertyInfo = record.GetType().GetProperty(item2);
                        string item_value = propertyInfo.GetValue(item, null).ToString();
                    }

                    counter++;
                }
            }
            else
            {

            }
        }

    }
}
