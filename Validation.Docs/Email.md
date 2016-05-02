# Validation

### Email

 - Verify Email
  
 ```cs
    var email = new Email("someone@xptofoobar.com");
    email.IsValid(); //true
	
	    var email = new Email("someone@xptofoobar.");
    email.IsValid(); //false

	var email = new Email("someone@xptofoobar.com"){resolveDns = true};
    email.IsValid(); //false
	
	var email = new Email("someone@somewhere.com"){resolveDns = true};
    email.IsValid(); //true
	
	var email = new Email("someone@somewhere.com"){resolveDns = true, whiteListOnly = true};
    email.IsValid(); //false - @todo not implemented yet
```