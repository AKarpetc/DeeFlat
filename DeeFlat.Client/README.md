
### Документация по работе с шаблоном

## Добавление страницы

Для добвяление страницы нужно добавить небходимую страницу в папку page(как компонент react)  после добавить сслыку на эту страницу в файл src\routes.js, добавить пункт меню с переходом на эту страницу в файле src/components/DashboardSidebar.js с ссылкой как в файле route: /app/названиеСтраницы.js

## Добавление защищенных страниц 
Для добавление защищенных страниц следует добавлять в файл routes страницы обернуть в функцию  SecureElement(Account) { path: 'account', element: SecureElement(Account) }

## Запросы на серверное API 

Для запросов на API IdentityServer можно использовать featch на остальные сервисы WebApi нужно использовать запросы с токеном обертка находится utils-authFetch
Использование 

  `let authRequest = authFetch();`
   `authRequest.get('/dicthttp/api/Skill/GetAuthorized').then(res => res.json()).then(x => console.log(x));`

Post Put пока не добавленны

