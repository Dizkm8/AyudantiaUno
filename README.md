# Backend -  Introducción Desarrollo Web/Móvil
Backend para el curso Introducción al Desarrollo Web/Móvil (IDWM), utilizando .NET 7, .NET EF y SQLite
## Requisitos

- SDK [.NET 7](https://dotnet.microsoft.com/es-es/download/dotnet/7.0).
- .NET [EF CLI](https://www.nuget.org/packages/dotnet-ef/)
- Puerto 5267 disponible
- git [2.33.0](https://git-scm.com/downloads) o superior.

## Instalación

Inicialmente se prepará el backend, para ello se deberá ejecutar el siguiente comando en la terminal:
```
git clone https://github.com/Dizkm8/Backend-IDWM
cd Backend-IDWM
dotnet restore
dotnet ef database update
dotnet run
```

Una vez realizado esto el servidor del backend estará corriendo en el puerto 5267.

## Uso

Para utilizar la aplicación se deberá ingresar a la siguiente dirección en el navegador: http://localhost:5267/swagger

También puedes utilizar [Postman](https://www.postman.com/) para testear los endpoints.


