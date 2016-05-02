# Validation

### NFE Access Key

 - Verify NFE number (DANDFE)
  
 ```cs
    var nfe = new NfeAccessKey("42-10/04-84.684.182/0001-57-55-001-000.000.002-010.804.210-8");
    nfe.IsValid(); //true
```