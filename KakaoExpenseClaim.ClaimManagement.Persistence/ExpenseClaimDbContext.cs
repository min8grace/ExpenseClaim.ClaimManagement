using KakaoExpenseClaim.ClaimManagement.Application.Contracts;
using KakaoExpenseClaim.ClaimManagement.Domain.Common;
using KakaoExpenseClaim.ClaimManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Persistence
{
    public class ExpenseClaimDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public ExpenseClaimDbContext(DbContextOptions<ExpenseClaimDbContext> options)
         : base(options)
        {
        }

        public ExpenseClaimDbContext(DbContextOptions<ExpenseClaimDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ExpenseClaim> ExpenseClaims { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseClaimDbContext).Assembly);

            //seed data, added through migrations

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1,  Code = "RO",  Name = "Rent Office"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2,  Code = "HO",  Name = "Home office costs"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3,  Code = "UT",  Name = "Utilities"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4,  Code = "FUR",  Name = "Furniture"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 5,  Code = "SPP",  Name = "Office supplies"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 6,  Code = "EQ",  Name = "Equipment"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 7,  Code = "MC",  Name = "Machinery"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 8,  Code = "AM",  Name = "Advertising and marketing"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 9,  Code = "WS",  Name = "Website and software expenses"} );
            modelBuilder.Entity<Category>().HasData(new Category { Id = 10, Code = "ET", Name = "Entertainment"} );
        
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 1, Name = "EUR" , Symbol = "€"   });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 2, Name = "KRW" , Symbol = "₩"   });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 3, Name = "CAD" , Symbol = "C$"   });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 4, Name = "JPN" , Symbol = "¥"   });
            modelBuilder.Entity<Currency>().HasData(new Currency { Id = 5, Name = "USD" , Symbol = "$" });

            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 1, Title = "Expense Claim case 1", TotalAmount = 60915, Status = Status.Requested, RequesterId = 21000986, SubmitDate = DateTime.Now.AddMonths(6), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 2, Title = "Expense Claim case 2", TotalAmount = 27098, Status = Status.Requested, RequesterId = 21000986, SubmitDate = DateTime.Now.AddMonths(6), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 3, Title = "Expense Claim case 3", TotalAmount = 60227, Status = Status.Requested, RequesterId = 21000986, SubmitDate = DateTime.Now.AddMonths(6), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 4, Title = "Expense Claim case 4", TotalAmount = 5840, Status = Status.Requested, RequesterId = 21000986, SubmitDate = DateTime.Now.AddMonths(6), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 5, Title = "Expense Claim case 5", TotalAmount = 16434, Status = Status.Requested, RequesterId = 21000986, SubmitDate = DateTime.Now.AddMonths(3), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 6, Title = "Expense Claim case 6", TotalAmount = 63415, Status = Status.Processing, RequesterId = 21000986, SubmitDate = DateTime.Now.AddMonths(3), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 7, Title = "Expense Claim case 7", TotalAmount = 77098, Status = Status.Processing, RequesterId = 21000319, SubmitDate = DateTime.Now, RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 8, Title = "Expense Claim case 8", TotalAmount = 10227, Status = Status.Processing, RequesterId = 21000812, SubmitDate = DateTime.Now, RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 9, Title = "Expense Claim case 9", TotalAmount = 3840, Status = Status.Processing, RequesterId = 21000546, SubmitDate = DateTime.Now.AddMonths(6), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 10, Title = "Expense Claim case 10", TotalAmount = 76434, Status = Status.Processing, RequesterId = 21000173, SubmitDate = DateTime.Now, RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 11, Title = "Expense Claim case 11", TotalAmount = 50915, Status = Status.Processing, RequesterId = 21000986, SubmitDate = DateTime.Now, RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 12, Title = "Expense Claim case 12", TotalAmount = 97098, Status = Status.Requested, RequesterId = 21000319, SubmitDate = DateTime.Now.AddMonths(3), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 13, Title = "Expense Claim case 13", TotalAmount = 80227, Status = Status.Requested, RequesterId = 21000812, SubmitDate = DateTime.Now.AddMonths(3), RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 14, Title = "Expense Claim case 14", TotalAmount = 4840, Status = Status.Requested, RequesterId =  21000546, SubmitDate = DateTime.Now, RequesterComments = "please, check this out and approve it	" });
            modelBuilder.Entity<ExpenseClaim>().HasData(new ExpenseClaim { ExpenseClaimId = 15, Title = "Expense Claim case 15", TotalAmount = 26434, Status = Status.Requested, RequesterId = 21000173, SubmitDate = DateTime.Now, RequesterComments = "please, check this out and approve it	" });

            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 1, CategoryId = 3, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 240, CurrencyId = 1, USDAmount = 290, Description = "	Home office costs, Feb 2020	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 2, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 50000, CurrencyId = 2, USDAmount = 45, Description = "	Utilities, Jan 2019	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 3, CategoryId = 5, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 240, CurrencyId = 3, USDAmount = 197, Description = "	Furniture, March 2020	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 4, CategoryId = 6, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 20000, CurrencyId = 4, USDAmount = 182, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 4 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 5, CategoryId = 3, PayeeId = 21000812, Date = DateTime.Now.AddMonths(6), Amount = 5567, CurrencyId = 5, USDAmount = 5567, Description = "	Entertainment, Oct 2018	", ExpenseClaimId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 6, CategoryId = 4, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 645, CurrencyId = 1, USDAmount = 780, Description = "	Website and software expenses, Nov 2021	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 7, CategoryId = 5, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 770000, CurrencyId = 2, USDAmount = 685, Description = "	Office supplies, Sept 2019	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 8, CategoryId = 6, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 5356, CurrencyId = 3, USDAmount = 4392, Description = "	Office supplies, Sept 2019	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 9, CategoryId = 3, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 105070, CurrencyId = 4, USDAmount = 956, Description = "	Entertainment, Oct 2018	", ExpenseClaimId = 4 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 10, CategoryId = 4, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3860, CurrencyId = 5, USDAmount = 3860, Description = "	Utilities, Jan 2019	", ExpenseClaimId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 11, CategoryId = 5, PayeeId = 21000812, Date = DateTime.Now.AddMonths(6), Amount = 4435, CurrencyId = 1, USDAmount = 5366, Description = "	Office supplies, May 2021	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 12, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 450000, CurrencyId = 2, USDAmount = 401, Description = "	Office supplies, Sept 2019	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 13, CategoryId = 6, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 5446, CurrencyId = 3, USDAmount = 4466, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 14, CategoryId = 5, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 38740, CurrencyId = 4, USDAmount = 353, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 4 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 15, CategoryId = 4, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 234, CurrencyId = 5, USDAmount = 234, Description = "	Office supplies, Sept 2019	", ExpenseClaimId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 16, CategoryId = 5, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3454, CurrencyId = 1, USDAmount = 4179, Description = "	Website and software expenses, Nov 2021	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 17, CategoryId = 6, PayeeId = 21000812, Date = DateTime.Now.AddMonths(6), Amount = 650000, CurrencyId = 2, USDAmount = 579, Description = "	Furniture, March 2020	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 18, CategoryId = 4, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 3497, CurrencyId = 3, USDAmount = 2868, Description = "	Entertainment, Oct 2018	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 19, CategoryId = 5, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 59430, CurrencyId = 4, USDAmount = 541, Description = "	Office supplies, May 2021	", ExpenseClaimId = 4 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 20, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 10890, CurrencyId = 5, USDAmount = 10890, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 21, CategoryId = 3, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 1046, CurrencyId = 1, USDAmount = 1266, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 22, CategoryId = 4, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 8000000, CurrencyId = 2, USDAmount = 7120, Description = "	Website and software expenses, Nov 2021	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 23, CategoryId = 5, PayeeId = 21000812, Date = DateTime.Now.AddMonths(6), Amount = 54986, CurrencyId = 3, USDAmount = 45089, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 24, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 42300, CurrencyId = 4, USDAmount = 385, Description = "	Furniture, March 2020	", ExpenseClaimId = 4 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 25, CategoryId = 3, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 3067, CurrencyId = 5, USDAmount = 3067, Description = "	Office supplies, Sept 2019	", ExpenseClaimId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 26, CategoryId = 3, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 3096, CurrencyId = 1, USDAmount = 3746, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 27, CategoryId = 3, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 895320, CurrencyId = 2, USDAmount = 797, Description = "	Advertising and marketing, Feb 2020	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 28, CategoryId = 4, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 578, CurrencyId = 3, USDAmount = 474, Description = "	Furniture, March 2020	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 29, CategoryId = 5, PayeeId = 21000812, Date = DateTime.Now.AddMonths(6), Amount = 100587, CurrencyId = 4, USDAmount = 915, Description = "	Furniture, March 2020	", ExpenseClaimId = 4 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 30, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 3480, CurrencyId = 5, USDAmount = 3480, Description = "	Furniture, March 2020	", ExpenseClaimId = 2 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 31, CategoryId = 6, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 88659, CurrencyId = 4, USDAmount = 807, Description = "	Requesting claimsB	", ExpenseClaimId = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 32, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 42387, CurrencyId = 1, USDAmount = 51288, Description = "	bought a car	", ExpenseClaimId = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 33, CategoryId = 5, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 3080000, CurrencyId = 2, USDAmount = 2741, Description = "	Rental fee  Nov 2021	", ExpenseClaimId = 3 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 34, CategoryId = 6, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3058, CurrencyId = 3, USDAmount = 2508, Description = "	Rental fee  Nov 2021	", ExpenseClaimId = 4 });

            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 40, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 3480, CurrencyId = 5, USDAmount = 3480, Description = "	Furniture, March 2020	",  ExpenseClaimId = 6 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 41, CategoryId = 6, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 88659, CurrencyId = 4, USDAmount = 807, Description = "	Requesting claimsB	",      ExpenseClaimId = 6 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 42, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 42387, CurrencyId = 1, USDAmount = 51288, Description = "	bought a car	",      ExpenseClaimId = 6 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 43, CategoryId = 5, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 3080000, CurrencyId = 2, USDAmount = 2741, Description = "	Rental fee  Nov 2021	",  ExpenseClaimId = 7 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 44, CategoryId = 6, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3058, CurrencyId = 3, USDAmount = 2508, Description = "	Rental fee  Nov 2021	",      ExpenseClaimId = 7 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 45, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 3480, CurrencyId = 5, USDAmount = 3480, Description = "	Furniture, March 2020	",  ExpenseClaimId = 7 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 46, CategoryId = 6, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 88659, CurrencyId = 4, USDAmount = 807, Description = "	Requesting claimsB	",      ExpenseClaimId = 7 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 47, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 42387, CurrencyId = 1, USDAmount = 51288, Description = "	bought a car	",      ExpenseClaimId = 8 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 48, CategoryId = 5, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 3080000, CurrencyId = 2, USDAmount = 2741, Description = "	Rental fee  Nov 2021	",  ExpenseClaimId = 8 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 49, CategoryId = 6, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3058, CurrencyId = 3, USDAmount = 2508, Description = "	Rental fee  Nov 2021	",      ExpenseClaimId = 8 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 50, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 3480, CurrencyId = 5, USDAmount = 3480, Description = "	Furniture, March 2020	",  ExpenseClaimId = 9 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 51, CategoryId = 6, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 88659, CurrencyId = 4, USDAmount = 807, Description = "	Requesting claimsB	",      ExpenseClaimId = 9 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 52, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 42387, CurrencyId = 1, USDAmount = 51288, Description = "	bought a car	",      ExpenseClaimId = 9 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 53, CategoryId = 5, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 3080000, CurrencyId = 2, USDAmount = 2741, Description = "	Rental fee  Nov 2021	",  ExpenseClaimId = 10 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 54, CategoryId = 6, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3058, CurrencyId = 3, USDAmount = 2508, Description = "	Rental fee  Nov 2021	",      ExpenseClaimId = 10 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 55, CategoryId = 6, PayeeId = 21000319, Date = DateTime.Now.AddMonths(6), Amount = 3480, CurrencyId = 5, USDAmount = 3480, Description = "	Furniture, March 2020	",  ExpenseClaimId = 11 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 56, CategoryId = 6, PayeeId = 21000986, Date = DateTime.Now.AddMonths(6), Amount = 88659, CurrencyId = 4, USDAmount = 807, Description = "	Requesting claimsB	",      ExpenseClaimId = 12 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 57, CategoryId = 4, PayeeId = 21000365, Date = DateTime.Now.AddMonths(6), Amount = 42387, CurrencyId = 1, USDAmount = 51288, Description = "	bought a car	",      ExpenseClaimId = 13 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 58, CategoryId = 5, PayeeId = 21000173, Date = DateTime.Now.AddMonths(6), Amount = 3080000, CurrencyId = 2, USDAmount = 2741, Description = "	Rental fee  Nov 2021	",  ExpenseClaimId = 14 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemId = 59, CategoryId = 6, PayeeId = 21000546, Date = DateTime.Now.AddMonths(6), Amount = 3058, CurrencyId = 3, USDAmount = 2508, Description = "	Rental fee  Nov 2021	",      ExpenseClaimId = 15 });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        //entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        //entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
