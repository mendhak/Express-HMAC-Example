Install dependencies

```
npm install
```


Start the Express app

```
npm start
```

Try browsing to http://localhost:3000/protected and get blocked.  It requires an [HMAC header](https://github.com/connorjburton/hmac-auth-express#generating-your-hmac-digest). 

---


Generate header using C#

```
dotnet run
```

Call using C# generated header

```
curl -v -X POST -H "Content-Type: application/json" -H "Authentication: $(dotnet run)" http://localhost:3000/protected --data '{"a":"b"}'

```

Generate header using NodeJS

```
node test.js
```

Call using NodeJS generated header

```
curl -v -X POST -H "Content-Type: application/json" -H "Authentication: $(node test.js)" http://localhost:3000/protected --data '{"a":"b"}'
```



