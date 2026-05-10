using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DB_Edata>(opt => opt.UseInMemoryDatabase("EdataList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "EdataAPI";
    config.Title = "EdataAPI CRUD";
    config.Version = "v1";
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "EdataAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}


app.MapGet("/RSE_data/{id}", async (int id, DB_Edata db) =>
{
    var rse_data = await db.RSE_datas.FindAsync(id);
    if (rse_data is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(rse_data);
});

app.MapGet("/RSE_datas", async (DB_Edata db) =>
    await db.RSE_datas.ToListAsync());

app.MapPost("/RSE_data", async(RSE_data rse_data, DB_Edata db) => 
{
    db.RSE_datas.Add(rse_data);
    await db.SaveChangesAsync();

    return Results.Created($"/edatas/{rse_data.Id}", rse_data);
});

app.MapPost("/RSE_datas", async (List<RSE_data> datas, DB_Edata db) =>
{
    await db.RSE_datas.AddRangeAsync(datas);

    await db.SaveChangesAsync();

    return Results.Ok(new {inserted = datas.Count});
});

app.MapPut("/RSE_data/{id}", async (int id, RSE_data updatedData, DB_Edata db) =>
{
    var rse_data = await db.RSE_datas.FindAsync(id);
    if (rse_data is null)
    {
        return Results.NotFound();
    }

    rse_data.MonthlyDate = updatedData.MonthlyDate;
    rse_data.TotalKWh = updatedData.TotalKWh;
    rse_data.HeatingKWh = updatedData.HeatingKWh;
    rse_data.WaterHeatingKWh = updatedData.WaterHeatingKWh;
    rse_data.AppliancesKWh = updatedData.AppliancesKWh;
    rse_data.LightingKWh = updatedData.LightingKWh;
    rse_data.OtherKWh = updatedData.OtherKWh;
    await db.SaveChangesAsync();

    return Results.Ok(rse_data);
});

app.MapDelete("/RSE_data/{id}", async (int id, DB_Edata db) =>
{
    var rse_data = await db.RSE_datas.FindAsync(id);
    if (rse_data is null)
    {
        return Results.NotFound();
    }

    db.RSE_datas.Remove(rse_data);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


app.MapGet("/Technician_data/{id}", async (int id, DB_Edata db) =>
{
    var technician_data = await db.Technician_datas.FindAsync(id);
    if (technician_data is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(technician_data);
});

app.MapGet("/Technician_datas", async (DB_Edata db) =>
    await db.Technician_datas.ToListAsync());

app.MapPost("/Technician_data", async(Technician_data technician_data, DB_Edata db) => 
{
    db.Technician_datas.Add(technician_data);
    await db.SaveChangesAsync();

    return Results.Created($"/edatas/{technician_data.Id}", technician_data);
});

app.MapPost("/Technician_datas", async (List<Technician_data> datas, DB_Edata db) =>
{
    await db.Technician_datas.AddRangeAsync(datas);
    await db.SaveChangesAsync();

    return Results.Ok(new {inserted = datas.Count});
});

app.MapPut("/Technician_data/{id}", async (int id, Technician_data updatedData, DB_Edata db) =>
{
    var technician_data = await db.Technician_datas.FindAsync(id);
    if (technician_data is null)
    {
        return Results.NotFound();
    }

    technician_data.DailyDate = updatedData.DailyDate;
    technician_data.HourlyDate = updatedData.HourlyDate;
    technician_data.ElectricityKWh = updatedData.ElectricityKWh;

    await db.SaveChangesAsync();

    return Results.Ok(technician_data);
});

app.MapDelete("/Technician_data/{id}", async (int id, DB_Edata db) =>
{
    var technician_data = await db.Technician_datas.FindAsync(id);
    if (technician_data is null)
    {
        return Results.NotFound();
    }

    db.Technician_datas.Remove(technician_data);
    await db.SaveChangesAsync();

    return Results.NoContent();
});




app.Run();
