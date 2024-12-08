dotnet new sln
dotnet new webapi -controllers -n API
dotnet sln add API

dotnet tool install --global dotnet-ef

// to migrate database
dotnet ef migrations add InitialCreate -o Data/Migrations

//to insert values
ctrl + P; >sqlite open database; new dbexplorer created outside;



angular new client






