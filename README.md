# CRUD de Personas con Razor Pages

Aplicación ASP.NET Core Razor Pages (.NET 10) que implementa un CRUD completo de personas con Entity Framework Core y SQL Server.

## Relaciones implementadas

- Persona → País: muchos a uno.
- Persona ↔ Pasaporte: uno a uno.
- Persona ↔ Materia: muchos a muchos mediante la tabla `Inscripcion`.

El formulario permite elegir un país, registrar un pasaporte y seleccionar varias materias. El listado y la vista de detalle muestran todas estas relaciones.

El archivo `entrega-modelos-dbcontext.zip` contiene las carpetas `Models` y `Data` solicitadas para la entrega.

## Funcionalidades

- Crear, listar, ver, editar y eliminar personas.
- Validación de campos obligatorios y fecha de nacimiento.
- Validación de números de pasaporte únicos.
- Catálogo inicial de países y materias mediante migraciones.
- Eliminación en cascada del pasaporte y las inscripciones de la persona.

## Cómo ejecutar

Requisitos:

- .NET SDK 10.
- SQL Server LocalDB (incluido habitualmente con Visual Studio) o una instancia de SQL Server.

Desde la raíz del proyecto:

```powershell
dotnet restore
dotnet run
```

En desarrollo, la aplicación aplica automáticamente las migraciones y crea la base `CrudPersonasRazor` en `(localdb)\MSSQLLocalDB`.

Si usas otra instancia, cambia `ConnectionStrings:DefaultConnection` en `appsettings.json` y ejecuta:

```powershell
dotnet ef database update
```

Después abre la dirección que muestre la terminal y entra en **Personas**.

## Tecnologías

- ASP.NET Core Razor Pages 10
- Entity Framework Core 10
- SQL Server
- Bootstrap 5
