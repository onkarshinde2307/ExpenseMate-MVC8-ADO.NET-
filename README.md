# 💸 ExpenseMate — An ASP.NET Core MVC 8 Expense Tracker

Welcome to **ExpenseMate** — a simple, beautiful, and practical personal finance tracker built using *ASP.NET Core MVC 8* and *ADO.NET*. Designed with love to help you stay smart with your money, it lets you manage your **daily expenses**, track **monthly income**, and view a clean dashboard that summarizes everything in one glance. All with a light UI and motivational vibes 💖

✨ What it does  
📝 Add, edit, or delete your daily expense entries  
💰 Record your monthly income sources with amount and date  
📅 View today’s total expenses at a glance  
📆 See auto-calculated monthly totals for both income & expenses  
📊 Dashboard shows remaining balance (Income - Expenses)  
🌟 Motivational quote to keep you financially inspired  
🎨 Built with Bootstrap 5 & custom colors for a clean, soft UI  
💾 Uses lightweight ADO.NET (no Entity Framework) for DB access  

📁 Folder Overview

ExpenseMate/  
├── Controllers/  
│   ├── HomeController.cs  
│   ├── ExpenseController.cs  
│   └── IncomeController.cs  
├── DAL/  
│   └── DBManager.cs  
├── Models/  
│   ├── Expense.cs  
│   ├── ExpenseCategory.cs  
│   └── Income.cs  
├── Views/  
│   ├── Shared/ → _Layout.cshtml  
│   ├── Home/ → Index.cshtml  
│   ├── Expense/ → Index, Create, Edit, Delete, Details  
│   └── Income/ → Index, Create, Edit, Delete, Details  
├── wwwroot/  
│   ├── css/ → site.css  
│   └── images/  
├── appsettings.json  
├── Program.cs  
└── ExpenseMate.sln  

🚀 Run it locally

1. Clone the repo:  
   git clone https://github.com/onkarshinde2307/ExpenseMate-MVC8-AdoNet.git

2. Open the solution in Visual Studio 2022

3. Configure your database in `appsettings.json`:  
   "ConnectionStrings": {  
     "DefaultConnection": "Server=ONKAR-SHINDE\\SQLEXPRESS01;Database=DummyExpenseMateDemoDB;Trusted_Connection=True;"  
   }

4. Press Ctrl + F5 to run the app  

Now open your browser — you’ll land on a beautiful dashboard showing:  
→ Today's Expenses 💸  
→ This Month's Total Income 💰  
→ This Month's Total Expenses 📉  
→ Remaining Balance 💵  
→ And a lovely quote to motivate you 🌈  

💡 Quote of the Day

“Track every rupee you spend — not because you’re stingy, but because you’re smart.”  
— ExpenseMate 💬  

👨‍💻 Built By  
Made with ❤️ by **Onkar Shinde**  
GitHub: [@onkarshinde2307](https://github.com/onkarshinde2307)

🌟 Give it a Star  
If you found this project helpful, please ⭐ it on GitHub  
→ [github.com/onkarshinde2307/ExpenseMate-MVC8-AdoNet](https://github.com/onkarshinde2307/ExpenseMate-MVC8-ADO.NET-)

Your support motivates me to build more cute and useful apps like this 🌸
