using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplicationForReqHTTP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

var users = new List<User>();
users.Add(new User { Email = "a@a", Name = "sadsa" });
users.Add(new User { Email = "b@a", Name = "223324dsfsdf" });

app.Run(async (context) =>
{
    var path = context.Request.Path;
    var response = context.Response;

    response.ContentType = "text/html; charset=utf-8";
    if (path == "/posts")
    {
        //context.Response.Headers.ContentDisposition = "attachment; filename=index.json";
        await response.WriteAsJsonAsync(users);
        //await response.SendFileAsync("Files/index.json");
    }
    else if (path == "/otherdir")
    {
        await response.WriteAsJsonAsync(users[1]);
    }
    else
    {
        response.StatusCode = 404;
        await response.WriteAsync("<h2>Not Found</h2>");
    }
});

app.Run();
