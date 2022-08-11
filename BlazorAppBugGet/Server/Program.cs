using BlazorAppBugGet.Shared.Dtos;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents(routePrefix: "odata", GetEdmModel())
        .Select()
        .Count()
        .Filter()
        .Expand()
        .OrderBy()
        .SetMaxTop(maxTopValue: 100);

});

IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();

    builder.EntitySet<Class1>(name: "Class1")
        .EntityType.HasKey(e => e.Id);
    
    builder.EntitySet<Class2>(name: "Class2")
       .EntityType.HasKey(e => e.Id);
    
    builder.EntitySet<Class3>(name: "Class3")
       .EntityType.HasKey(e => e.Id);

    return builder.GetEdmModel();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
