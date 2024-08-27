using Microsoft.AspNetCore.Authentication.Cookies; // Authentication -> Kimlik Doðrulama , build -> inþa etmek.


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamýza  View ve Controlleri Ekler.


builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/LoginView/"; // Kimlik doðrulanma baþarýsýz olduðunda yönlendirilecek url'yi belirler.

        /*
        CookieAuthenticationDefaults.AuthenticationScheme parametresi, kimlik doðrulamanýn cookie tabanlý olacaðýný belirtir.
         */
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    /*
     Uygulamanýn çalýþma ortamýný kontrol eder.Eðer ortam bir geliþtirme ortamý deðilse özel hata sayfalarýný kullanýcýya göstermek yerine
     genel bir hata sayfasý gösterir.
     */
    app.UseExceptionHandler("/Home/Error"); // Eðer bir hata oluþursa "/Home/Error" url'sine yönlendir.
    // Use -> Kullanmak , Exception -> istisna , Handler -> Ýdareci
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // HTTP Strict Transport Security (HSTS) protokolünü etkinleþtirir.
    // Bu sayede uyglamanýn HTTPS üzerinde çalýþmasýný saðlar ve HTTPS olmayan baðlantýlarý engeller.
}

app.UseHttpsRedirection(); // Gelen Http isteklerini otomatik olarak Https'ye yönlendirir güvenliliði arttýrmak için.

app.UseStaticFiles(); // wwwroot dosyasýndaki CSS,JavaScript,resim gibi dosyalarýn sunulmasýný saðlar.

app.UseRouting(); // Routing gelen URL'leri uygun Controller ve Actionlara yönlendirir.

app.UseAuthorization(); // Authorization -> Yetkilendirme. Kullanýcýnýn belirli bir kaynaða veya iþleme eriþim iznini olup olmadýðýný kontrol eder.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=GetAllDepartment}/{id?}"); // Var sayýlan url'yi belirler.

app.Run(); // Uygulama Çalýþmaya baþlar ve HTTP isteklerini kabul etmeye baþlar.


