using System;
using System.Linq;
using EFConsoleUI.DataAccess;
using EFConsoleUI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFConsoleUI
{
	public class Program
	{
		static void Main(string[] args)
		{

			//CreateTest();
			//ReadAll();
			ReadById(1);
			Console.WriteLine("Done processing");
			Console.ReadLine();
		}

		private static void CreateTest() {

			var c = new Contact
			{
				FirstName = "Test",
				LastName = "Testov",
			};
			c.EmailAddresses.Add(new Email { EmailAddress = "vasyan@ya.ru"});
			c.EmailAddresses.Add(new Email { EmailAddress = "vasya123@mail.ru" });
			c.PhoneNumbers.Add(new Phone { PhoneNumber = "65184666-75"});
			c.PhoneNumbers.Add(new Phone { PhoneNumber = "88482-209662" });

			using (var db = new ContactContext()) {
				
				db.Contacts.Add(c);
				db.SaveChanges();
			}
		}

		private static void ReadAll() {

			using (var db = new ContactContext())
			{
				var records = db.Contacts
					.Include(e => e.EmailAddresses)
					.Include(p => p.PhoneNumbers)
					.ToList();

				foreach (var c in records) {
					Console.WriteLine($"{ c.FirstName } {c.LastName} ");
				}
			}
		}

		private static void ReadById(int id) {

			using (var db = new ContactContext())
			{
				var user = db.Contacts.Where(c => c.Id == id).First();

				Console.WriteLine($"{user.FirstName} {user.LastName} ");
			}
		}
	}
}
