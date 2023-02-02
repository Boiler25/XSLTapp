## Контур. Тестовое задание
### Задание
1. Написать xslt-преобразование, которое на основе входящего файла List.xml построит файл Groups.xml
2. Написать программу на языке C#, которая: 
- Запускает xslt-преобразование, написанное в задании I.
- После xslt-преобразования, дописывает в элемент group атрибут, который отражает количество item этого элемента
- В исходный файл List.xml в элемент list дописывает атрибут, который отражает количество item
- Имеет GUI (Windows.Form или WPF) с кнопкой запуска программы и отображением списка всех group и соответствующее им количество item, а также элемент list и его количество item

***

### Решение
- Файл с xslt-преобразованием находится [здесь](https://github.com/Boiler25/XSLTapp/blob/master/XSLTapp/Data/List.xsl)
- Класс, выполняющий преобразование, находится [здесь](https://github.com/Boiler25/XSLTapp/blob/master/XSLTapp/XslTransformer.cs)
- Функция, дописывающая в элемент group атрибут, который отражает количество item этого элемента, [здесь](https://github.com/Boiler25/XSLTapp/blob/master/XSLTapp/XmlHelper.cs)
- Функция дописывающая атрибут, который отражает количество item, [здесь](https://github.com/Boiler25/XSLTapp/blob/master/XSLTapp/XmlHelper.cs)
