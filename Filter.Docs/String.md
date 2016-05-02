# Filter

### String

 - [Slugfy]
 - [RemoveAccent]
 - [Excerpt]
 - [OnlyNumbers]
 - [OnlyAlphanumerics]
 - [FindFirstByMaskExpression]
 - [FindListByMaskExpression]
 - [FormatterRegex]
 - [GetBetween]
 - [AddMask]
  
#### Slugfy
```cs
    var text = "Hello World เม";
    text.Slugfy(); //hello-world-aa
```

#### RemoveAccent
```cs
    var text = "Hello World ม";
    text.RemoveAccent(); //Hello World A
```
#### Excerpt
```cs
    var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
    text.Excerpt(26); //"Lorem ipsum dolor sit..."
    text.Excerpt(26, "!!!")//"Lorem ipsum dolor sit!!!"
    "Lorem ipsum dolor sit amet".Excerpt(30); //"Lorem ipsum dolor sit amet"
```
#### OnlyNumbers
```cs
    var text = "Hello World ม 123456789";
    String.OnlyNumbers(text); // string type "123456789"
```

#### OnlyAlphanumerics
```cs
    var text = "Hello @#$ World ม 123456789";
    String.OnlyAlphanumerics(text); // string type "Hello World ม 123456789"
```

#### Mask
- "A" for chars
- "0" for numbers


#### FindFirstByMaskExpression
```cs
    String.FindFirstByMaskExpression("000","hello world 123 456"); // "123"
    String.FindFirstByMaskExpression("000.000.000-00", "foo bar 123.123.599-50");// "123.123.599-50"
```

#### FindListByMaskExpression
- Equals FindFirstByMaskExpression, but retuns a list of string

#### FormatterRegex
```cs
    String.FormatterRegex("AA 00000-0000");// ([A-Za-z]{2}\\s+\\d{5}(\\-)\\d{4})
```

#### GetBetween
```cs
    String.GetBetween("This is an example string and my data is here", "my", "is", true);// "my data is"
```
#### AddMask
```cs
    String.AddMask("0000000-00.0000.000.0000","12345671212341231234"); //"1234567-12.1234.123.1234"
```

[Slugfy]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#slugfy>
[RemoveAccent]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#removeaccent>
[Excerpt]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#slugfy>
[OnlyNumbers]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#excerpt>
[OnlyAlphanumerics]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#onlynumbers>
[FindFirstByMaskExpression]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#findfirstbymaskexpression>
[FindListByMaskExpression]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#findlistbymaskexpression>
[FormatterRegex]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#formatterregex>
[GetBetween]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#getbetween>
[AddMask]: <https://github.com/kleberksms/commonsCSharp/blob/master/Filter.Docs/String.md#addmask>


