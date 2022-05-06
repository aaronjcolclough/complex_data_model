@echo off

echo Updating dbseeder dependencies...
cd .\dbseeder
call dotnet add package Microsoft.EntityFrameworkCore.Relational
call dotnet add package Microsoft.EntityFrameworkCore.SqlServer

echo Updating ComplexDataModel.Core dependencies...
cd ..\ComplexDataModel.Core
call dotnet add package Microsoft.EntityFrameworkCore
call dotnet add package Newtonsoft.Json

echo Updating ComplexDataModel.Auth dependencies...
cd ..\ComplexDataModel.Auth
call dotnet add package Microsoft.EntityFrameworkCore

echo Updating ComplexDataModel.Data dependencies...
cd ..\ComplexDataModel.Data
call dotnet add package Microsoft.EntityFrameworkCore.SqlServer
call dotnet add package Microsoft.EntityFrameworkCore.Tools
call dotnet add package Newtonsoft.Json

echo Updating ComplexDataModel.Identity dependencies...
cd ..\ComplexDataModel.Identity
call dotnet add package Microsoft.Extensions.Configuration.Abstractions
call dotnet add package Microsoft.Extensions.Configuration.Binder
call dotnet add package System.DirectoryServices
call dotnet add package System.DirectoryServices.AccountManagement

echo Updating ComplexDataModel.Identity.Mock dependencies...
cd ..\ComplexDataModel.Identity.Mock

echo Updating ComplexDataModel.Office dependencies...
cd ..\ComplexDataModel.Office
call dotnet add package DocumentFormat.OpenXml

echo Updating ComplexDataModel.Sql dependencies...
cd ..\ComplexDataModel.Sql
call dotnet add package Microsoft.Data.SqlClient
call dotnet add package Newtonsoft.Json

echo Updating ComplexDataModel.Web dependencies...
cd ..\ComplexDataModel.Web
call dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
call dotnet add package Microsoft.AspNetCore.OData
call dotnet add package Microsoft.EntityFrameworkCore.Design

echo Caching NuGet dependencies...
cd ..\
call dotnet restore --packages nuget-packages

cd ..
echo Dependencies successfully updated!
