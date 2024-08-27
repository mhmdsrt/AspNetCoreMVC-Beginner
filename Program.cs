using Microsoft.AspNetCore.Authentication.Cookies; // Authentication -> Kimlik Do�rulama , build -> in�a etmek.


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulam�za  View ve Controlleri Ekler.


builder.Services.AddAuthentication
    (CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/LoginView/"; // Kimlik do�rulanma ba�ar�s�z oldu�unda y�nlendirilecek url'yi belirler.

        /*
        CookieAuthenticationDefaults.AuthenticationScheme parametresi, kimlik do�rulaman�n cookie tabanl� olaca��n� belirtir.
         */
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    /*
     Uygulaman�n �al��ma ortam�n� kontrol eder.E�er ortam bir geli�tirme ortam� de�ilse �zel hata sayfalar�n� kullan�c�ya g�stermek yerine
     genel bir hata sayfas� g�sterir.
     */
    app.UseExceptionHandler("/Home/Error"); // E�er bir hata olu�ursa "/Home/Error" url'sine y�nlendir.
    // Use -> Kullanmak , Exception -> istisna , Handler -> �dareci
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // HTTP Strict Transport Security (HSTS) protokol�n� etkinle�tirir.
    // Bu sayede uyglaman�n HTTPS �zerinde �al��mas�n� sa�lar ve HTTPS olmayan ba�lant�lar� engeller.
}

app.UseHttpsRedirection(); // Gelen Http isteklerini otomatik olarak Https'ye y�nlendirir g�venlili�i artt�rmak i�in.

app.UseStaticFiles(); // wwwroot dosyas�ndaki CSS,JavaScript,resim gibi dosyalar�n sunulmas�n� sa�lar.

app.UseRouting(); // Routing gelen URL'leri uygun Controller ve Actionlara y�nlendirir.

app.UseAuthorization(); // Authorization -> Yetkilendirme. Kullan�c�n�n belirli bir kayna�a veya i�leme eri�im iznini olup olmad���n� kontrol eder.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=GetAllDepartment}/{id?}"); // Var say�lan url'yi belirler.

app.Run(); // Uygulama �al��maya ba�lar ve HTTP isteklerini kabul etmeye ba�lar.


