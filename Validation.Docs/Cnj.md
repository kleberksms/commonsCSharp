# Validation

### CNJ

 - Verify CNJ number
  
```cs
    var cnj = new Cnj("0003182-81.2015.8.21.0139");
    cnj.IsValid(); //true
    
    var cnj = new Cnj("00031828120158210139");
    cnj.IsValid(); //true
```