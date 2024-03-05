using System;
using System.Windows.Forms;
using System.Drawing;
using RC.Core;

namespace RC.Core.Controllers
{
    public sealed class Messaging
	{
		
		public Messaging()
		{
			
		}
		
		public bool Confirm(string Title, string Message)
		{						
			if (MessageBox.Show(Message,Title,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes) {
				
				return true;
			}
			else{
				
				return false;
			}

		}
        public bool Confirm(string Message)
        {
            if (MessageBox.Show(Message, "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                return true;
            }
            else
            {

                return false;
            }

        }
        public void Label(string Message, Label MessageLabel, MessageType MessageType)
		{
			MessageLabel.Visible = true;
			MessageLabel.Text = Message;
			
			switch (MessageType) {
				
				case MessageType.Success:
					MessageLabel.ForeColor = Color.Green;
					break;
					
				case MessageType.Error:
					MessageLabel.ForeColor = Color.DarkRed;
					break;

				case MessageType.Warning:
					MessageLabel.ForeColor = Color.Orange;
					break;
			}
		}
		
		public void Success(string Title, string Message)
		{			
			MessageBox.Show(Message,Title,MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
        public void Success(string Message)
        {
            MessageBox.Show(Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Error(string Title, string Message)
		{			
			MessageBox.Show(Message,Title,MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
        public void Error(string Message)
        {
            MessageBox.Show(Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Warning(string Title, string Message)
		{			
			MessageBox.Show(Message,Title,MessageBoxButtons.OK,MessageBoxIcon.Stop);
		}
        public void Warning(string Message)
        {
            MessageBox.Show(Message, "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }	
}
