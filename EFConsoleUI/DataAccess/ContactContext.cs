﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EFConsoleUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFConsoleUI.DataAccess
{
	public class ContactContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Email> Emails { get; set; }
		public DbSet<Phone> Phones { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder options) 
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var config = builder.Build();

			options.UseSqlServer(config.GetConnectionString("Default"));
		}
	}
}
