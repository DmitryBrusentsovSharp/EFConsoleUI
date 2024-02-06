using System;
using System.Collections.Generic;
using System.Text;

namespace EFConsoleUI.Models
{
	public class Contact
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<Email> EmailAddresses { get; set; }
		public List<Phone> PhoneAddresses { get; set; }
	}
}
