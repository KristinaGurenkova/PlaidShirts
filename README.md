# Информационная система для магазина одежды «PlaidShirts».
### Название приложения: PlaidShirts
### Описание приложения:
**Система «PlaidShirts» предназначена для управления и отображения информации о товарах, находящихся в магазине, их цене и производителях. Пользователь может выбрать интересующий его товар и получить чек.**

# Функции, реализованные в программе:
1. **Просмотр всего товара.** На главном экране присутствует список всех доступных товаров для покупки. Пользователь видит изображение, название, цену, производителя, тип и количество товара.
2. **Добавление товара в корзину.** Нужно выбрать товар и нажать кнопку «Добавить в корзину», либо вызвать контекстное меню и нажать «Добавить в корзину». 
3. **Получение чека.** После добавления товаров в корзину нужно нажать кнопку «Получить чек». Пользователю будет представлен чек с названием магазина, списком всех купленных товаров и общей ценой.
4. **Список товаров на складе.** При нажатии на кнопку «Список товаров на складе» откроется окно со списком товаров, хранящихся на складе.
4. **Список товаров в зале .** При нажатии на кнопку «Список товаров в зале» откроется окно со списком товаров, находящихся в зале.
4. **Панель управления.** При нажатии на кнопку «Панель управления» откроется окно, где можно добавлять, изменять, удалять товары, а также перемещать какое-то количество товаров в зал.
5. **Запись логов.** С помощью класс Logger происходит запись логов каждой нажатой кнопки. 
6. **Юнит-тестирование DLL.** В рамках проекта было проведено юнит-тестирование DLL, которая используется в приложении. Юнит-тесты были разработаны для каждого метода в DLL, что позволило проверить корректность её работы.

# Технологии, которые были использованы для разработки приложения:
- **C#** - объектно-ориентированный язык программирования.
- **Visual Studio Community 2022** - интегрированная среда разработки (IDE), которая обеспечивает удобное создание, отладку и развертывание приложений.
- **Windows Presentation Foundation** - система для построения клиентских приложений Windows с визуально привлекательными возможностями взаимодействия с пользователем, графическая подсистема в составе .NET Framework, использующая язык XAML.
- **Microsoft SQL Server** - система управления реляционными базами данных (РСУБД), разработанная корпорацией Microsoft.
- **Entity Framework** - это набор технологий в ADO.NET, которые поддерживают разработку программных приложений, ориентированных на данные.
- **MSTest** - это фреймворк для модульного тестирования в Visual Studio, который предоставляет классы и члены в пространстве имен Microsoft.VisualStudio.TestTools.UnitTesting для написания модульных тестов.

# Описание базы данных:
#### Файл базы данных называется checkeredshirts.bacpac <br/>
Файл базы данных расположен локально в проекте по пути **PlaidShirts\PlaidShirts\bin\Debug** </br>
В базе данных находятся 7 таблиц _Product_, _Storage_, _Hall_, _Type_, _Manufacturer_, _Basket_, _Order_.

- **Таблица «Product»** _(idProduct, nameProduct, barcode, price, idManufacturer, idType, path, count)_ содержит информацию о товарах
- **Таблица «Storage»** _(idStorage, idProduct, countProduct)_ содержит информацию о товарах, хранящихся на складе
- **Таблица «Hall»** _(idHall, idProduct, countProduct)_ содержит информацию о товарах, находящихся в зале
- **Таблица «Type»** _(idType, nameType)_ содержит информацию о типах товаров
- **Таблица «Manufacturer»** _(idManufacturer, nameManufacturer)_ содержит информацию о производителях
- **Таблица «Basket»** _(idBasket, idProduct, count, price, sum)_ содержит информацию о товарах, находящихся в корзине
- **Таблица «Order»** _(idOrder, idBasket, sum)_ содержит информацию о заказе


# Скриншоты приложения:

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/MainWindow.png">
</br>Главная страница
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/Basket.png">
</br>Корзина
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/Chek.png">
</br>Чек
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/Storage.png">
</br>Склад
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/Hall.png">
</br>Зал
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/Control.png">
</br>Панель управления
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/log.png">
</br>Лог-файл
</br> </br> </br>
</p>

<p align="center">
  <img <img src="https://github.com/KristinaGurenkova/PlaidShirts/tree/main/Screenshots/UnitTest.png">
</br>Юнит-тестирование DLL
</br> </br> </br>
</p>
