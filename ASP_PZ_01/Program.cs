var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();

var countrequest = 0;

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";

    countrequest++;

    var myCookie = context.Request.Cookies["MyCookie"];
    context.Response.Cookies.Append("MyCookie", "Hello World");

    await context.Response.WriteAsync(
        $"<!DOCTYPE html>" +
        $"<html lang=\"en\">" +
            $"<head>" +
                $"<meta charset=\"UTF-8\">" +
                $"<title>PZ_01</title>" +
            $"</head>" +
                $"<body>" +
                $"<h2>Асеев Артём</h2>" +
                $"<h3>16 лет</h3>" +
                $"<h3>Мариуполь</h3>" +
                $"<h3>10 класс</h3>" +
                $"<a href=\"/skills\">My skills</a>" +
                $"<a href=\"/gallery\">Gallery</a>" +
                $"<h2>{myCookie}</h2>" +
                $"<h2>Count of request : {countrequest}</h2>" +
                $"</body>" +
        $"</html>");
});

app.MapGet("/skills", async context =>
{
    await context.Response.WriteAsync(
        $"<!DOCTYPE html>" +
        $"<html lang=\"en\">" +
            $"<head>" +
                $"<meta charset=\"UTF-8\">" +
                $"<title>PZ_01_skills</title>" +
            $"</head>" +
                $"<body>" +
                $"<ul>" +
                    $"<li>C#/C++</li>" +
                    $"<li>MySQL</li>" +
                    $"<li>HTML/CSS</li>" +
                    $"<li>JS</li>" +
                    $"<li>Angular/React</li>" +
                $"</ul>" +
                $"<a href=\"/\">Back</a>" +
                $"</body>" +
        $"</html>");
});

app.MapGet("/gallery", async context =>
{
    await context.Response.WriteAsync(
        $"<!DOCTYPE html>" +
        $"<html lang=\"en\">" +
            $"<head>" +
                $"<meta charset=\"UTF-8\">" +
                $"<title>PZ_01_gallery</title>" +
            $"</head>" +
                $"<body>" +
                $"<img src=\"/src/fon.jpg\" >" +
                $"<a href=\"/\">Back</a>" +
                $"</body>" +
        $"</html>");
});
app.Run();
