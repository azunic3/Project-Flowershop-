using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Ayana.Models;
using Ayana.Data;
using Ayana.MailgunService;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;

namespace Ayana.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _sender;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _context;

        public RegisterConfirmationModel(ApplicationDbContext context, IEmailService emailService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IEmailSender sender)
        {
            _context = context;
            _userManager = userManager;
            _sender = sender;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;
            // Rest of the code...

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string confirmationCode, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var email = Request.Form["Email"]; // Retrieve the email value from the request form

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            // Verify the code
            if (_emailService.VerifyCode(email, confirmationCode))
            {
                user.EmailConfirmed = true;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
            {
                await _userManager.DeleteAsync(user);

                await _context.SaveChangesAsync();
                ModelState.AddModelError(string.Empty, "Invalid verification code.");
            }

            // If the code is invalid or account creation fails, return to the registration page
            return RedirectToPage("/Account/Register");
        }
    }
}
