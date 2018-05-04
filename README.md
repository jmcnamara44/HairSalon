# _HairSalon_

#### _This webpage will build a database for stylists and clients so that hair salon owners can track and add clients to a stylist. 05/04/18_

#### By _**Jimmy McNamara**_

## Description

_This project will use C# to build and work with databases for a hair salon.  In this databases there will be a one-to-many relationship between 2 tables, stylists and clients.  The clients table will have a column for stylist ID, because one stylist can have multiple clients but a client cannot have multiple stylists._

## Project Specs

_View stylist details._
_View client details._
_Add a new stylist._
_Add a new client._
_View a stylists list of clients._

## Setup/Installation Requirements

* _Clone repository from GitHub_
* _Open .cshtml files into your browser of choice_
* _CREATE DATABASE jimmy_mcnamara;_
* _USE jimmy_mcnamara;_
* _CREATE TABLE stylists (id serial PRIMARY KEY, stylist_name VARCHAR(50), days_available VARCHAR(60), years_active int(2), phone_number VARCHAR(12));_
* _CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(60), phone_number VARCHAR(12), stylist_id int(11));_

## Known Bugs

_No known bugs as of now.  Would like to make it so stylists available days can be entered as a checkbox, ran out of time before I could get to that._

## Support and contact details

_Contact Jimmy with any questions or comments_

## Technologies Used

_HTML_
_CSS_
_Bootstrap_
_JavaScript_
_jQuery_
_CSharp_

### License

*Licensed through the MIT open resource agreement*

Copyright (c) 2018 **_Jimmy_**
