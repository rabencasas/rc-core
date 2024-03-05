using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace RC.Core.Controllers
{
    public enum App_Environment { Development, Production, Testing }
    public enum DBEngine { SQLite, MySQL, SQLServer }
    public enum Gender { Male, Female }
    public enum MessageType { Success, Error, Warning }
}
