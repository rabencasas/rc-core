using System;

namespace RC.Core.Controllers
{
	public sealed class Validation
	{
		public Validation()
		{
		}
		
		public bool ValidateTwoPasswords(string Password1, string Password2)
		{
			if (Password1 == Password2) {
				
				return true;
			}
			else{
				
				return false;
			}
		}
		
		public bool ValidateIfNumber(string NumberInString)
		{
			float no;
			
			if (float.TryParse(NumberInString,out no)) {
				
				return true;
			}
			else{
				
				return false;
			}
		}
		
		public bool ValidateIfCPNumber(string NumberInString)
		{
			long no;
			
			if (long.TryParse(NumberInString,out no) && NumberInString.Length == 11) {
				
				return true;
			}
			else{
				
				return false;
			}
		}
        
        public void ShowErrorException(Exception X)
        {
            //if (Configuration.environment == App_Environment.Development)
            //{
            //    RC.Message.Error(Configuration.app + " - " + "Development Mode", X.ToString());
            //}
            //else
            //{
            //    RC.Message.Error(Configuration.app + " - " + "Production Mode", Datas.UnexpectedError);
            //}
        }
	}
}
