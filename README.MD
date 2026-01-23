
# Appo
 
 Actualmente estoy trabajando en la creacion del multitenant para este proyecto, como guia estay usando este video del gran Felipe: ` https://www.youtube.com/watch?v=wOSQ3hc7SRs&t=2666s ` hoy quede en 41:16.
 Segun veo el codigo solo falta implementar el UI y verificar que todo funciona 

 > [] De alli pasariamos a realizar las pruebas que se puede usar una IA para que las ejecute y asi reducir tiempo.
 > [] Tambien generar una pruebas usando una base de datos en memoria para tenerla para despues..
 > [] Generar las vistas actuales y terminar de construir los endpoint
 > [] bloquear cada endpoint por su validacion de permisos
 > [] Identificar que Endpoints seran libres (aunque estos son mas para la web)
 > [] Crear una ayuda visual para ver los endPoint's y trabajarlos a nivel general

### Trabajo con la base de datos


Para *crear migracion* de nuestro servicion principal iniciamos con el siguiente codigo
```bash
dotnet ef migrations add [NameMigration] --startup-project ../Appo.API/Appo.API.csproj --output-dir Migrations                                                                                
```

donde: 
* [NameMigration]: es el nombre de la migracion, en el caso de este producto todo nombre termina con la palabra 'Migration' para no tener confusiones en el buscador.


En el casdo de querer *Aplicar las migraciones* se utiliza el siguiente codigo desde el proyecto de persistencia

```bash
 dotnet ef database update --startup-project ../Appo.API/Appo.API.csproj                                                                                                                        
```

 en el caso de querer generar una migracion desde la identidad(ocea desde este proyecto) se necesita indicar la base de datos a la cual apunta el identity, como se ve acontinuacion

```
 dotnet ef migrations add IdentityFirstMigration --startup-project ../Appo.API/Appo.API.csproj --output-dir Migrations --context AppoIdentityDB
```

 y para que actualice la base de datos, igual desde el proyecto de identidad se ejecuta

```
dotnet ef database update --startup-project ../Appo.API/Appo.API.csproj --context AppoIdentityDB  
```
