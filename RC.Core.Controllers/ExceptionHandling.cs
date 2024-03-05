using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace RC.Core.Controllers
{
    public class ExceptionHandling
    {
        App_Environment _environment;
        bool _display_general_message;

        public ExceptionHandling(App_Environment environment, bool display_general_message)
        {
            this._environment = environment;
            _display_general_message = display_general_message;
        }

        public dynamic HandlerExecute(Action methodName)
        {
            bool issuccess = false;
            string message = "";
            dynamic result = new { };

            try
            {
                methodName();

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }

            return new { Success = issuccess, Message = message, Result = result };
        }

        public dynamic HandlerExecute<T>(Func<T, dynamic> methodName, T argument)
        {
            bool issuccess = false;
            string message = "";
            dynamic result = new { };

            try
            {
                result = methodName(argument);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }

            return result;
            //return new { Success = issuccess, Message = message, Result = result };
        }

        public dynamic HandlerExecute<T, T2>(Func<T, T2, dynamic> methodName, T argument1, T2 argument2)
        {
            bool issuccess = false;
            string message = "";
            dynamic result = new { };

            try
            {
                result = methodName(argument1, argument2);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }

            return result;
            //return new { Success = issuccess, Message = message, Result = result };
        }

        public dynamic HandlerExecute<T, T2, T3>(Func<T, T2, T3, dynamic> methodName, T argument1, T2 argument2, T3 argument3)
        {
            bool issuccess = false;
            string message = "";
            dynamic result = new { };
            try
            {
                result = methodName(argument1, argument2, argument3);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }

            return result;
            //return new { Success = issuccess, Message = message, Result = result };
        }

        public dynamic HandlerExecute<T, T2, T3, T4>(Func<T, T2, T3, T4, dynamic> methodName, T argument1, T2 argument2, T3 argument3, T4 argument4)
        {
            bool issuccess = false;
            string message = "";
            dynamic result = new { };

            try
            {
                result = methodName(argument1, argument2, argument3, argument4);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }

            return result;
            //return new { Success = issuccess, Message = message, Result = result };
        }

        public dynamic HandlerExecute<T, T2, T3, T4, T5>(Func<T, T2, T3, T4, T5, dynamic> methodName, T argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5)
        {
            bool issuccess = false;
            string message = "";
            dynamic result = new { };

            try
            {
                result = methodName(argument1, argument2, argument3, argument4, argument5);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }

            return result;
            //return new { Success = issuccess, Message = message, Result = result };
        }

        public void HandlerExecute<T>(Action<T> methodName, T argument)
        {
            bool issuccess = false;
            string message = "";

            try
            {
                methodName(argument);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }
        }

        public void HandlerExecute<T, T2>(Action<T, T2> methodName, T argument1, T2 argument2)
        {
            bool issuccess = false;
            string message = "";

            try
            {
                methodName(argument1, argument2);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }
        }

        public void HandlerExecute<T, T2, T3>(Action<T, T2, T3> methodName, T argument1, T2 argument2, T3 argument3)
        {
            bool issuccess = false;
            string message = "";

            try
            {
                methodName(argument1, argument2, argument3);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }
        }

        public void HandlerExecute<T, T2, T3, T4>(Action<T, T2, T3, T4> methodName, T argument1, T2 argument2, T3 argument3, T4 argument4)
        {
            bool issuccess = false;
            string message = "";

            try
            {
                methodName(argument1, argument2, argument3, argument4);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }
        }

        public void HandlerExecute<T, T2, T3, T4, T5>(Action<T, T2, T3, T4, T5> methodName, T argument1, T2 argument2, T3 argument3, T4 argument4, T5 argument5)
        {
            bool issuccess = false;
            string message = "";

            try
            {
                methodName(argument1, argument2, argument3, argument4, argument5);

                message = "Action completed successfully.";

            }
            catch (Exception ex)
            {
                ShowException(ex);
                message = ex.Message;
            }
        }

        private void ShowException(Exception exception)
        {
            if (_environment == App_Environment.Testing || _environment == App_Environment.Development)
            {
                if (this._display_general_message)
                {
                    new Messaging().Error(exception.Message);
                }
                else
                {
                    new Messaging().Error(exception.ToString());
                }
            }
            else
            {
                if (this._display_general_message)
                {
                    new Messaging().Error("An unexpected error occured, please contact your administrator: \n\n" + exception.Message);
                }
            }
        }
    }
}
