# INNOCV
This project contains the solution for the DotNet Exercise where it has being developed a rest web service for an IUD (AKA CRUD) application.

## Software versions used
Visual Studio 2019

## Style
- Bootstrap v3.4.1
- To personalizate some styles, it has been created a new style on [here](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/Content/innocv/style.css)

## Scrips
- Bootstrap v3.4.1 
- jQuery JavaScript Library v3.4.1

## Database
It has been created a localDB allocated on [here](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/App_Data/innocv_db.mdf). If contains an only table called [Users] with the following definition: 

```
CREATE TABLE [dbo].[Users] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [Birthdate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```
Note: we consider the Id as an unique and not null value. It will be automatic increment one by one value.

## Local set up
The solution compiles successfully. Then if you run the app with Visual Studio (IIS Express emulator) the url is ready to be http://localhost:44382.

## API 
- GET api/Users	
- GET api/Users/{id}	
- POST api/Users	
- PUT api/Users/{id}	
- DELETE api/Users/{id}	
Note: go to http://localhost:44382/Help to see more details. 

In addition, we have test the API with Postman and get the following results:
- GET api/Users	
 --return: Status 200 ok, Body: JSON items
 
- GET api/Users/{id}	
 --return: Status 200 ok, Body: JSON item
 --return: Status 404 Not found, Body: emtpy
 
- POST api/Users	
-- input: JSON item: example: {"Name":"Anna","Birthdate":"1991-01-01T00:00:00"}
 --return: Status 201 created, Body: JSON item
 
- PUT api/Users/{id}	
-- input: JSON item: example: {"Name":"Anna","Birthdate":"1991-01-01T00:00:00"}
 --return: Status 200 ok, Body: JSON item
 
- DELETE api/Users/{id}	
 --return: Status 200 ok, Body: JSON item
 
## Demo
Here you can see a demo of each actions

### List of users
Show the list of the users on a table and the different actions to make.

![list_users](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/Content/images/innocv_list_user.png)

### Detail
Show the details of the user selected. 

![detail_user](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/Content/images/innocv_detail.gif)

### Add user 
Allow to add a new user.

![add_user](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/Content/images/innocv_add_user.gif)

### Edit user 
Allow to edit the details of the user selected. 

![edit_user](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/Content/images/innocv_edit_user.gif)

### Remove user 
Allow to remove the details of the user selected. 

![remove_user](https://github.com/elenasanchezp/innocv-crud-api/blob/main/innocv-crud-api/Content/images/innocv_delete_user.gif)


## Next Steps
  - Complete innocv-crud-api.Test project to be sure all functionality is tested and It works fine.
  - Make published the Web Api  to be able to access from everywhere without run the project locally. 
