
#Appo


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
