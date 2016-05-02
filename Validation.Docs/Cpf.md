# Validation

### CPF

 - Verify CPF number
  
 ```cs
    var cpf = new Cpf("585.056.827-18");
    cpf.IsValid(); //true

	var cpf = new Cpf("58505682718");
    cpf.IsValid(); //true
```