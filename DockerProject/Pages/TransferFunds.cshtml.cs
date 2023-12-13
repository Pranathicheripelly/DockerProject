using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DockerProject.Pages
{
   
        public class TransferFundsModel : PageModel
        {
            // Replace these properties with your actual account data model
            public List<Account> Accounts { get; set; }
            public int FromAccountId { get; set; }
            public int ToAccountId { get; set; }
            public decimal TransferAmount { get; set; }

            // Simulated data - replace with logic to retrieve account info
            public void OnGet()
            {
                // Simulated account data - Replace this with your logic to retrieve actual account details
                Accounts = new List<Account>
            {
                new Account { Id = 1, Name = "Account 1", Balance = 1000 },
                new Account { Id = 2, Name = "Account 2", Balance = 500 }
                // Add other accounts as needed
            };
            }

            public IActionResult OnPost()
            {
                try
                {
                    // Simulated logic for transferring funds
                    if (TransferAmount <= 0)
                    {
                        ModelState.AddModelError("TransferAmount", "Please enter a valid amount to transfer.");
                        return Page();
                    }

                    // Find the accounts involved in the transfer
                    Account fromAccount = Accounts.Find(a => a.Id == FromAccountId);
                    Account toAccount = Accounts.Find(a => a.Id == ToAccountId);

                    // Check if both accounts exist
                    if (fromAccount == null || toAccount == null)
                    {
                        ModelState.AddModelError("", "One or both accounts are invalid.");
                        return Page();
                    }

                    // Check if the transfer amount exceeds the balance of the fromAccount
                    if (fromAccount.Balance < TransferAmount)
                    {
                        ModelState.AddModelError("TransferAmount", "Insufficient funds in the selected account.");
                        return Page();
                    }

                    // Perform the transfer
                    fromAccount.Balance -= TransferAmount;
                    toAccount.Balance += TransferAmount;

                    // Redirect to the success page after successful transfer
                    return RedirectToPage("/TransferSuccess");
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    ModelState.AddModelError("", $"Error during transfer: {ex.Message}");
                    return Page();
                }
            }
        }

        public class Account
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Balance { get; set; }
            // Other account properties
        }
    }
