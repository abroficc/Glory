using Microsoft.AspNetCore.Mvc;
using Inspinia.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Inspinia.Controllers
{
    public class Auth3Controller : Controller
    {
        // Simple in-memory "database" of dummy users
        private static readonly List<DummyUser> _users = new List<DummyUser>
        {
            new DummyUser { Email = "test@example.com", Password = "password123", Name = "مستخدم تجريبي" },
            new DummyUser { Email = "admin@example.com", Password = "admin123", Name = "مدير النظام" },
            new DummyUser { Email = "user@example.com", Password = "user123", Name = "مستخدم عادي" }
        };

        // GET: Auth3/SignIn
        public IActionResult SignIn(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: Auth3/SignIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginViewModel model, string? returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                // Simple authentication - check against our dummy users
                var user = _users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
                
                if (user != null)
                {
                    // Create claims for the authenticated user
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Name ?? "Unknown"),
                        new Claim(ClaimTypes.Email, user.Email ?? "unknown@example.com"),
                        new Claim(ClaimTypes.NameIdentifier, user.Email ?? "unknown@example.com")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    // Sign in the user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    // Store user name in temp data for the two-factor page
                    TempData["UserName"] = user.Name;
                    
                    // Redirect to returnUrl if provided, otherwise to dashboard
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        // Redirect to dashboard
                        return RedirectToAction("Index1", "Dashboards");
                    }
                }
                
                // If we got this far, something failed, redisplay form
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            
            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }

        // GET: Auth3/SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: Auth3/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if user already exists
                if (_users.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "البريد الإلكتروني مسجل بالفعل");
                    return View(model);
                }

                // Validate phone number format
                if (!string.IsNullOrEmpty(model.PhoneNumber))
                {
                    // Here you could add more specific phone number validation
                    // For now, we'll just ensure they're not empty
                    if (!model.PhoneNumber.All(c => char.IsDigit(c) || c == '-' || c == ' '))
                    {
                        ModelState.AddModelError("PhoneNumber", "رقم الهاتف يجب أن يحتوي على أرقام فقط");
                        return View(model);
                    }
                }

                // Handle document image upload
                if (model.DocumentImage != null && model.DocumentImage.Length > 0)
                {
                    // Validate file type
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
                    var fileExtension = Path.GetExtension(model.DocumentImage.FileName).ToLowerInvariant();
                    
                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("DocumentImage", "نوع الملف غير مدعوم. يرجى تحميل ملف من نوع JPG, PNG, أو PDF.");
                        return View(model);
                    }
                    
                    // Validate file size (5MB max)
                    if (model.DocumentImage.Length > 5 * 1024 * 1024)
                    {
                        ModelState.AddModelError("DocumentImage", "حجم الملف كبير جداً. الحد الأقصى هو 5 ميجابايت.");
                        return View(model);
                    }
                    
                    // In a real application, you would save the file to a secure location
                    // For this example, we'll just validate it exists
                    // Example of how you might save the file:
                    /*
                    var fileName = Path.GetFileNameWithoutExtension(model.DocumentImage.FileName) + 
                                   "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + 
                                   fileExtension;
                    var filePath = Path.Combine("wwwroot/uploads/documents", fileName);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.DocumentImage.CopyToAsync(stream);
                    }
                    */
                }
                else
                {
                    ModelState.AddModelError("DocumentImage", "صورة الوثيقة مطلوبة");
                    return View(model);
                }

                // Create new user
                var newUser = new DummyUser
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.FullName
                };

                // Add to our dummy users list
                _users.Add(newUser);

                // Redirect to success page or sign in page
                return RedirectToAction("SuccessMail", "Auth3");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public IActionResult LoginPin() => View();
        public IActionResult LockScreen() => View();
        public IActionResult TwoFactor() => View();
        public IActionResult ResetPass() => View();
        public IActionResult DeleteAccount() => View();
        public IActionResult NewPass() => View();
        public IActionResult SuccessMail() => View();
        
        // Logout action
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }
    }
}