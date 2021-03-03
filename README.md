Anonimizzatore (Anonymizer)
==
C# module and SQL content to randomize/anonymized personal data (name, surname, city of birth) from production database to test
[![Software License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
![netVersion-badge](https://img.shields.io/static/v1.svg?label=C%23&message=4.7&color=green)
![SQL-badge](https://img.shields.io/static/v1.svg?label=SQL&message=script&color=brown)

## About
Anonimizzatore is a simple script in C# to anonimyze a database containing private and sensitive data (name, surname, city of birth).
When I receive production database to make debug on code, I don't like to work with real data. Normally, databases contains thousands of records and their anonimization, by hand, is unpossible.

In real software, I use NHibernate to make persistence (ORM) to database and a class to execute RAW queries. In this snippet this classes are not implemented. Everyone can use their preferred method to R/W to database. Code in Controller is the main part of this repository. A very very interesting part is, also, the SQL script that contains (italians) 300 surnames and 622 names with sex distinction.

To maximize anonymity, the script change city of birth and refresh "Codice Fiscale" (class not implemented)
