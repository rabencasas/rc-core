using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace RC.Core.Controllers
{
    public class ModelsController
    {
        public ModelsController()
        {}


        public dynamic Bind<T>(ref T record, List<Control> fields)
        {
            PropertyInfo[] properties = record.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                var form_control = fields.Where(x => x.Name.ToLower().Split('_')[0] == property.Name.ToLower()).FirstOrDefault();

                if (form_control != null)
                {
                    try
                    {
                        if (form_control is TextBox || form_control is ComboBox || form_control is RadioButton || form_control is RichTextBox)
                        {
                            var propertyInfo = record.GetType().GetProperty(property.Name);

                            if (property.PropertyType == typeof(string))
                            {
                                propertyInfo.SetValue(record, form_control.Text, null);
                            }
                            if (property.PropertyType == typeof(int))
                            {
                                propertyInfo.SetValue(record, int.Parse(form_control.Text), null);
                            }
                            if (property.PropertyType == typeof(decimal))
                            {
                                propertyInfo.SetValue(record, decimal.Parse(form_control.Text), null);
                            }
                            if (property.PropertyType == typeof(long))
                            {
                                propertyInfo.SetValue(record, long.Parse(form_control.Text), null);
                            }
                            if (property.PropertyType == typeof(bool))
                            {
                                propertyInfo.SetValue(record, form_control.Text != String.Empty || form_control.Text == "Yes" ? true : false, null);
                            }
                            if (property.PropertyType == typeof(double))
                            {
                                propertyInfo.SetValue(record, double.Parse(form_control.Text), null);
                            }
                            if (property.PropertyType == typeof(float))
                            {
                                propertyInfo.SetValue(record, float.Parse(form_control.Text), null);
                            }
                        }

                        if (form_control is DateTimePicker)
                        {
                            var propertyInfo = record.GetType().GetProperty(property.Name);
                            propertyInfo.SetValue(record, DateTime.Parse(((DateTimePicker)form_control).Value.ToString()), null);
                        }

                        if (form_control is NumericUpDown)
                        {
                            var propertyInfo = record.GetType().GetProperty(property.Name);

                            if (property.PropertyType == typeof(int))
                            {
                                propertyInfo.SetValue(record, (int)((NumericUpDown)form_control).Value, null);
                            }
                            if (property.PropertyType == typeof(decimal))
                            {
                                propertyInfo.SetValue(record, (decimal)((NumericUpDown)form_control).Value, null);
                            }
                            if (property.PropertyType == typeof(long))
                            {
                                propertyInfo.SetValue(record, (long)((NumericUpDown)form_control).Value, null);
                            }
                            if (property.PropertyType == typeof(double))
                            {
                                propertyInfo.SetValue(record, (double)((NumericUpDown)form_control).Value, null);
                            }
                            if (property.PropertyType == typeof(float))
                            {
                                propertyInfo.SetValue(record, (float)((NumericUpDown)form_control).Value, null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        return new { Success = false, Message = "Error occured: " + ex.Message };
                    }
                }
            }

            return new { Success = true, Message = "Bind completed." };
        }

        public dynamic BindToForm<T>(ref T record, List<Control> fields)
        {
            PropertyInfo[] properties = record.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                try
                {
                    var form_control = fields.Where(x => x.Name.ToLower().Split('_')[0] == property.Name.ToLower()).Count() > 0 ? fields.Where(x => x.Name.ToLower().Split('_')[0] == property.Name.ToLower()).First() : null;

                    if (form_control != null)
                    {
                        try
                        {
                            if (form_control is TextBox)
                            {
                                var propertyInfo = record.GetType().GetProperty(property.Name);
                                var control = form_control as TextBox;

                                //control.Text = (string)propertyInfo.GetValue(record);
                                try
                                {
                                    control.Text = property.PropertyType == typeof(string) ? propertyInfo.GetValue(record).ToString() :
                                                property.PropertyType == typeof(int) ? int.Parse(propertyInfo.GetValue(record).ToString()).ToString() :
                                                property.PropertyType == typeof(DateTime) ? ((DateTime)propertyInfo.GetValue(record)).ToString(("MMMM dd, yyyy")) :
                                                property.PropertyType == typeof(double) ? ((double)propertyInfo.GetValue(record)).ToString() :
                                                property.PropertyType == typeof(decimal) ? propertyInfo.GetValue(record).ToString() : "";
                                }
                                catch (Exception ex)
                                {

                                }
                            }

                            if (form_control is Label)
                            {
                                var propertyInfo = record.GetType().GetProperty(property.Name);
                                var control = form_control as Label;

                                //control.Text = (string)propertyInfo.GetValue(record);

                                try {
                                    control.Text = property.PropertyType == typeof(string) ? propertyInfo.GetValue(record).ToString() :
                                                property.PropertyType == typeof(int) ? int.Parse(propertyInfo.GetValue(record).ToString()).ToString() :
                                                property.PropertyType == typeof(DateTime) ? DateTime.Parse(propertyInfo.GetValue(record).ToString()).ToString("MMMM dd, yyyy") :
                                                property.PropertyType == typeof(double) ? double.Parse(propertyInfo.GetValue(record).ToString()).ToString() :
                                                property.PropertyType == typeof(decimal) ? propertyInfo.GetValue(record).ToString() : "";
                                } catch(Exception ex) {
                                    Console.WriteLine(ex.ToString());
                                }
                            }

                            if (form_control is RichTextBox)
                            {
                                var propertyInfo = record.GetType().GetProperty(property.Name);
                                var control = form_control as RichTextBox;

                                try { control.Text = (string)propertyInfo.GetValue(record); } catch(Exception ex) { }
                            }

                            if (form_control is ComboBox) // to edit
                            {
                                var propertyInfo = record.GetType().GetProperty(property.Name);
                                var control = form_control as ComboBox;

                                try {
                                    control.Text = property.PropertyType == typeof(string) ? propertyInfo.GetValue(record).ToString() :
                                                    property.PropertyType == typeof(int) ? ((int)propertyInfo.GetValue(record)).ToString() :
                                                    property.PropertyType == typeof(double) ? ((double)propertyInfo.GetValue(record)).ToString() :
                                                    property.PropertyType == typeof(long) ? ((long)propertyInfo.GetValue(record)).ToString() :
                                                    property.PropertyType == typeof(float) ? ((float)propertyInfo.GetValue(record)).ToString() : ((decimal)propertyInfo.GetValue(record)).ToString();
                                } catch(Exception ex) { }
                            }

                            if (form_control is DateTimePicker) 
                            {
                                var propertyInfo = record.GetType().GetProperty(property.Name);
                                var control = form_control as DateTimePicker;
                                
                                try { control.Value = (DateTime)propertyInfo.GetValue(record); } catch(Exception ex) { }
                            }

                            if (form_control is NumericUpDown) // to edit
                            {
                                var propertyInfo = record.GetType().GetProperty(property.Name);
                                var control = form_control as NumericUpDown;
                                
                                try {
                                    control.Value = property.PropertyType == typeof(string) ? decimal.Parse(propertyInfo.GetValue(record).ToString()) :
                                                    property.PropertyType == typeof(int) ? (decimal)((int)propertyInfo.GetValue(record)) :
                                                    property.PropertyType == typeof(double) ? (decimal)((double)propertyInfo.GetValue(record)) :
                                                    property.PropertyType == typeof(long) ? (long)propertyInfo.GetValue(record) :
                                                    property.PropertyType == typeof(float) ? (decimal)((float)propertyInfo.GetValue(record)) : (decimal)propertyInfo.GetValue(record);

                                } catch(Exception ex) { }
                            }
                        }
                        catch (Exception ex)
                        {

                            return new { Success = false, Message = "Error occured: " + ex.Message };
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return new { Success = true, Message = "Bind completed." };
        }

        public void GenerateTemporaryId<T>(List<T> records, string identificationName)
        {
            int counter = 1;

            foreach (T item in records)
            {
                PropertyInfo[] properties = item.GetType().GetProperties();
                properties.Where(x => x.Name == identificationName).FirstOrDefault().SetValue(item,counter);

                counter++;
            }
        }

    }
}