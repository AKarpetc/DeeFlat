1. контейнеры не опубликованны в dockerhab для сборки контейнеров сперва нужно их собрать 
Для сборки монолита: docker build  --no-cache  ./Monolit -t  dee-flat-monolit
Для сборки Identity Server 4 :  docker build  --no-cache  ./DeeFlat.IS4 -t  dee-flat-is-4:0.1

2. Прежде чем запустить IS4 в docker нужно создать сертификат и сохранить его на ПК()
Для запуска https сперва нужно сгенерировать сертификат запустив эти команды

dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p DeeFlatPassword 
dotnet dev-certs https --trust  

3. Для подъема просто слеюует выполнить команду docker-compose up
4. если нужно для разработки можно просто запустить базы данных  docker-compose up dee-flat-db
5. Добавиленн RabbitMQ для примера реализованна схема обновление модели Skill в сервисе справочников и подписчик в админке

Пример запуска всех бах и шины docker-compose up  deeflat-dictionary-db  deeflat-rabbitmq-bus deeflat-is4-db
Подмена конфигурация для докера ещё не везде впилина