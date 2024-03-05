using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace RC.Core.Controllers
{
    public static class Authenticate
    {
        public static bool Password(TextBox T, int Minimum, int Maximum, Label MessageContainer)
        {
            int valLength = T.Text.ToCharArray().Length;

            if (valLength >= Minimum && valLength <= Maximum)
            {
                return true;
            }

            // ensure visibility
            MessageContainer.Visible = true;
            MessageContainer.ForeColor = Color.Maroon;
            MessageContainer.Text = "Password does not match required criteria.";
            return false;
        }

        public static bool ConfirmedPassword(TextBox T1, TextBox C)
        {
            if (C.Text == T1.Text)
            {
                return true;
            }

            return false;
        }

        public static bool Password(TextBox T, int Minimum, int Maximum)
        {
            int valLength = T.Text.ToCharArray().Length;

            if (valLength >= Minimum && valLength <= Maximum)
            {
                return true;
            }

            return false;
        }
    }
}
