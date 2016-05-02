# Validation

### Consonant

 - Verify if is consonant
  
```cs
    var consonant = new Consonant("b");
    consonant.IsConsonant(); //true
    
    var consonant = new Consonant("bcdf");
    consonant.IsSetOfConsonants(); //true
	
	var consonant = new Consonant("adbcdef");
    consonant.ContainsConsonant(); //true
```