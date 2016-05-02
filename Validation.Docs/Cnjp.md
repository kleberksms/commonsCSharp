# Validation

### CNPJ

 - Verify calidate of Cnpj number
  
 ```cs
    var cnpj = new Cnpj("45.855.406/0001-94");
    cnpj.IsValid(); //true
    
    var cnpj = new Cnpj("45855406000194");
    cnpj.IsValid(); //true
```