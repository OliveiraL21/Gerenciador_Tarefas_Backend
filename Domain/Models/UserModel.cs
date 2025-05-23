using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel : BaseModel
    {
		private string _username;

		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private string _phoneNumber;

		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}

		private string _profileImageUrl;

		public string ProfileImageUrl
		{
			get { return _profileImageUrl; }
			set { _profileImageUrl = value; }
		}


	}
}
