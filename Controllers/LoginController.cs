using AspNetCoreProject1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspNetCoreProject1.Controllers
{
	public class LoginController : Controller
	{
		Context context = new Context();

		[HttpGet]
		public IActionResult LoginView()
		{
			return View();
		}

		//[HttpPost] ->>>>>>>>>>>>> BU BASİT KULLANIM ŞEKLİ İLE YAPARKEN KULLANICIN KİMLİĞİNİ DOĞRULAYIP OTURUM AÇTIĞINI UYGULAMANIN DİĞER KISIMLARINA İLETMENİN BİR YOLU YOKTUR. 
		//          ->>>>>>>>>>>>> YANİ KULLANICI DOĞRU BİR ŞEKİLDE GİRİŞ YAPMIŞ OLSA BİLE BUNUN, UYGULAMANIN DİĞER KISIMLARINI BİLDİREMİYORUZ.
		//public IActionResult LoginView(Admin entity)
		//{
		//    var infoAdmin = context.Admins.FirstOrDefault(x => x.AdminName == entity.AdminName && x.AdminPassword == entity.AdminPassword);
		//    if (infoAdmin != null)
		//    {
		//        return RedirectToAction("GetAllEmployee", "Employee");
		//    }
		//    else
		//    {
		//        return RedirectToAction("LoginView", "Login");
		//    }
		//}

		[HttpPost]
		public async Task<IActionResult> LoginView(Admin entity)
		{
			var adminUser = context.Admins.FirstOrDefault(x => (x.AdminName == entity.AdminName && x.AdminPassword == entity.AdminPassword));
			if (adminUser != null)
			{
				var claims = new List<Claim>() // Claim -> Hak/İddia , Claim -> Talep , Bu kod satırında kullanıcın kimlik bilgilerini temsil eden bir liste oluşturuyoruz.
                {
					new Claim(ClaimTypes.Name,entity.AdminName)
				};

				var identity = new ClaimsIdentity(claims,"Login"); // Burada bir tane kimlik oluşturup oluşturduğumuz kimlik bilgilerini ve kimlik doğrulama türünü parametre olarak belitriyoruz.
																   // Yani "Login" ile kimlik doğrulama türünü belirtiyoruz ve bunun bir oturum açma için yapacağımızı belirtiyoruz.

				
				var claimsPrincipal = new ClaimsPrincipal(identity); // Kimlik doğrulama bilgilerini ve yetkilerini temsil eder.

				HttpContext.SignInAsync(claimsPrincipal); // Parametre olarak aldığı "claimsPrincipal" kimlik bilgilerini doğrulanmış olarak işaretler ve tarayıcı bunu cookie(çerez) olarak kaydeder.
														  // Böylece sitenin diğer kimlik doğrulama gerektiren sayfalarına tekrar giriş yapmasına gerek kalmadan tarayıcıda bulunan cookie(çerez) sayesinde dolaşabiliyor.
				return RedirectToAction("GetAllEmployee", "Employee");
			}
			else
			{
				return View();
			}
		}
	}
}
