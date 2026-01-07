
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
